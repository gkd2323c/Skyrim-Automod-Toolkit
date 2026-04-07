using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Dictionaries.Models;

namespace SpookysAutomod.Dictionaries.Services;

public sealed class DictionaryCatalogService
{
    private static readonly Regex MultiWhitespace = new(@"\s+", RegexOptions.Compiled);
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly IModLogger _logger;

    public DictionaryCatalogService(IModLogger logger)
    {
        _logger = logger;
    }

    public Result<DictionaryCatalog> Load(string inputDirectory)
    {
        if (string.IsNullOrWhiteSpace(inputDirectory))
        {
            return Result<DictionaryCatalog>.Fail(
                "Input directory is required.",
                suggestions: new List<string> { "Pass --input with the dictionaries folder path." });
        }

        var fullInputDirectory = Path.GetFullPath(inputDirectory);
        if (!Directory.Exists(fullInputDirectory))
        {
            return Result<DictionaryCatalog>.Fail(
                $"Input directory not found: {fullInputDirectory}",
                suggestions: new List<string> { "Check the dictionaries folder path and try again." });
        }

        var xmlFiles = Directory.GetFiles(fullInputDirectory, "*.xml", SearchOption.TopDirectoryOnly)
            .OrderBy(Path.GetFileNameWithoutExtension, StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (xmlFiles.Count > 0)
            return LoadXmlCatalog(fullInputDirectory, xmlFiles);

        var exportDetection = DetectExportDirectory(fullInputDirectory);
        if (exportDetection.IsExportDirectory)
            return LoadExportedCatalog(fullInputDirectory, exportDetection);

        return Result<DictionaryCatalog>.Fail(
            $"No XML dictionaries or exported JSONL shards found in: {fullInputDirectory}",
            suggestions: new List<string>
            {
                "Point --input at the folder containing *_english_chinese.xml files.",
                "Or point --input at a previously exported dictionary folder such as dictionaries/agent-readable."
            });
    }

    private Result<DictionaryCatalog> LoadXmlCatalog(string inputDirectory, IReadOnlyList<string> xmlFiles)
    {
        var files = new List<DictionaryCatalogFile>();
        foreach (var xmlFile in xmlFiles)
        {
            _logger.Info($"Reading dictionary: {Path.GetFileName(xmlFile)}");

            var parsedResult = ParseDictionaryFile(xmlFile);
            if (!parsedResult.Success || parsedResult.Value is null)
            {
                return Result<DictionaryCatalog>.Fail(
                    parsedResult.Error ?? $"Failed to parse dictionary file: {xmlFile}",
                    parsedResult.ErrorContext,
                    parsedResult.Suggestions);
            }

            files.Add(parsedResult.Value);
        }

        return Result<DictionaryCatalog>.Ok(new DictionaryCatalog
        {
            InputDirectory = inputDirectory,
            Files = files
        });
    }

    private Result<DictionaryCatalog> LoadExportedCatalog(string inputDirectory, ExportDirectoryDetection detection)
    {
        try
        {
            _logger.Info($"Reading exported dictionary shards from: {inputDirectory}");

            var files = new Dictionary<(string Addon, string SourceFile), DictionaryCatalogFileBuilder>();

            foreach (var entryFile in detection.EntryFiles)
            {
                foreach (var entry in ReadJsonLines<DictionaryAgentEntry>(entryFile))
                {
                    var key = (entry.Addon, entry.SourceFile);
                    if (!files.TryGetValue(key, out var builder))
                    {
                        builder = DictionaryCatalogFileBuilder.FromEntry(entry);
                        files[key] = builder;
                    }

                    builder.Entries.Add(entry);
                }
            }

            foreach (var recordFile in detection.RecordFiles)
            {
                foreach (var record in ReadJsonLines<DictionaryAgentRecordDocument>(recordFile))
                {
                    var key = (record.Addon, record.SourceFile);
                    if (!files.TryGetValue(key, out var builder))
                    {
                        builder = DictionaryCatalogFileBuilder.FromRecord(record);
                        files[key] = builder;
                    }

                    builder.RecordDocuments.Add(record);
                }
            }

            var catalogFiles = files.Values
                .Select(builder => builder.Build())
                .OrderBy(file => file.Addon, StringComparer.OrdinalIgnoreCase)
                .ThenBy(file => file.SourceFile, StringComparer.OrdinalIgnoreCase)
                .ToList();

            return Result<DictionaryCatalog>.Ok(new DictionaryCatalog
            {
                InputDirectory = inputDirectory,
                Files = catalogFiles
            });
        }
        catch (Exception ex)
        {
            return Result<DictionaryCatalog>.Fail(
                $"Failed to read exported dictionary shards from: {inputDirectory}",
                ex.Message,
                new List<string>
                {
                    "Check that the export folder still contains entries/*.jsonl and records/*.jsonl.",
                    "If needed, regenerate the export with dictionary export-agent."
                });
        }
    }

    private static ExportDirectoryDetection DetectExportDirectory(string directory)
    {
        var entriesDirectory = Path.Combine(directory, "entries");
        var recordsDirectory = Path.Combine(directory, "records");
        var manifestPath = Path.Combine(directory, "manifest.json");

        var entryFiles = Directory.Exists(entriesDirectory)
            ? Directory.GetFiles(entriesDirectory, "*.jsonl", SearchOption.TopDirectoryOnly)
                .OrderBy(Path.GetFileName, StringComparer.OrdinalIgnoreCase)
                .ToList()
            : new List<string>();
        var recordFiles = Directory.Exists(recordsDirectory)
            ? Directory.GetFiles(recordsDirectory, "*.jsonl", SearchOption.TopDirectoryOnly)
                .OrderBy(Path.GetFileName, StringComparer.OrdinalIgnoreCase)
                .ToList()
            : new List<string>();

        return new ExportDirectoryDetection(
            IsExportDirectory: File.Exists(manifestPath) || entryFiles.Count > 0 || recordFiles.Count > 0,
            EntryFiles: entryFiles,
            RecordFiles: recordFiles);
    }

    private static IEnumerable<T> ReadJsonLines<T>(string filePath)
    {
        using var reader = new StreamReader(filePath, true);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var item = JsonSerializer.Deserialize<T>(line, JsonOptions);
            if (item is not null)
                yield return item;
        }
    }

    private Result<DictionaryCatalogFile> ParseDictionaryFile(string xmlFile)
    {
        try
        {
            var document = XDocument.Load(xmlFile, LoadOptions.None);
            var root = document.Root;
            if (root is null)
            {
                return Result<DictionaryCatalogFile>.Fail(
                    $"Dictionary file has no root element: {xmlFile}");
            }

            var paramsElement = root.Element("Params");
            var contentElement = root.Element("Content");
            if (paramsElement is null || contentElement is null)
            {
                return Result<DictionaryCatalogFile>.Fail(
                    $"Dictionary file is missing Params or Content: {xmlFile}");
            }

            var addon = NormalizeText(paramsElement.Element("Addon")?.Value);
            var sourceLanguage = NormalizeText(paramsElement.Element("Source")?.Value);
            var targetLanguage = NormalizeText(paramsElement.Element("Dest")?.Value);
            var version = NormalizeText(paramsElement.Element("Version")?.Value);
            var sourceFile = Path.GetFileName(xmlFile);

            var entries = contentElement.Elements("String")
                .Select(element => BuildEntry(element, addon, sourceLanguage, targetLanguage, version, sourceFile))
                .OrderBy(entry => entry.Sid, StringComparer.OrdinalIgnoreCase)
                .ToList();

            var recordDocuments = entries
                .GroupBy(entry => entry.Edid, StringComparer.OrdinalIgnoreCase)
                .Select(group => BuildRecordDocument(group.Key, group.ToList(), addon, sourceLanguage, targetLanguage, version, sourceFile))
                .OrderBy(documentEntry => documentEntry.Edid, StringComparer.OrdinalIgnoreCase)
                .ToList();

            return Result<DictionaryCatalogFile>.Ok(new DictionaryCatalogFile
            {
                Addon = addon,
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLanguage,
                Version = version,
                SourceFile = sourceFile,
                Entries = entries,
                RecordDocuments = recordDocuments
            });
        }
        catch (Exception ex)
        {
            return Result<DictionaryCatalogFile>.Fail(
                $"Failed to parse dictionary file: {xmlFile}",
                ex.Message,
                new List<string> { "Check whether the XML file is truncated or malformed." });
        }
    }

    private static DictionaryAgentEntry BuildEntry(
        XElement element,
        string addon,
        string sourceLanguage,
        string targetLanguage,
        string version,
        string sourceFile)
    {
        var sid = NormalizeText(element.Attribute("sID")?.Value);
        var listId = NormalizeText(element.Attribute("List")?.Value);
        var edid = NormalizeText(element.Element("EDID")?.Value);
        var recElement = element.Element("REC");
        var record = NormalizeText(recElement?.Value);
        var (recordType, field) = ParseRecord(record);
        var variantId = TryParseNullableInt(recElement?.Attribute("id")?.Value);
        var variantMax = TryParseNullableInt(recElement?.Attribute("idMax")?.Value);
        var english = NormalizeText(element.Element("Source")?.Value);
        var chinese = NormalizeText(element.Element("Dest")?.Value);

        return new DictionaryAgentEntry
        {
            Addon = addon,
            SourceLanguage = sourceLanguage,
            TargetLanguage = targetLanguage,
            Version = version,
            SourceFile = sourceFile,
            Sid = sid,
            ListId = listId,
            Edid = edid,
            Record = record,
            RecordType = recordType,
            Field = field,
            RecordVariantId = variantId,
            RecordVariantMax = variantMax,
            English = english,
            Chinese = chinese,
            EnglishNormalized = NormalizeForSearch(english),
            ChineseNormalized = NormalizeForSearch(chinese),
            AgentText = BuildEntryAgentText(addon, edid, record, sid, english, chinese)
        };
    }

    private static DictionaryAgentRecordDocument BuildRecordDocument(
        string edid,
        List<DictionaryAgentEntry> entries,
        string addon,
        string sourceLanguage,
        string targetLanguage,
        string version,
        string sourceFile)
    {
        var translations = entries
            .OrderBy(entry => entry.RecordType, StringComparer.OrdinalIgnoreCase)
            .ThenBy(entry => entry.Field, StringComparer.OrdinalIgnoreCase)
            .ThenBy(entry => entry.Sid, StringComparer.OrdinalIgnoreCase)
            .Select(entry => new DictionaryAgentRecordTranslation
            {
                Sid = entry.Sid,
                ListId = entry.ListId,
                Record = entry.Record,
                RecordType = entry.RecordType,
                Field = entry.Field,
                RecordVariantId = entry.RecordVariantId,
                RecordVariantMax = entry.RecordVariantMax,
                English = entry.English,
                Chinese = entry.Chinese
            })
            .ToList();

        return new DictionaryAgentRecordDocument
        {
            Addon = addon,
            SourceLanguage = sourceLanguage,
            TargetLanguage = targetLanguage,
            Version = version,
            SourceFile = sourceFile,
            Edid = edid,
            RecordKey = $"{addon}:{edid}",
            Translations = translations,
            AgentText = BuildRecordAgentText(addon, edid, translations)
        };
    }

    private static (string RecordType, string Field) ParseRecord(string record)
    {
        if (string.IsNullOrWhiteSpace(record))
            return (string.Empty, string.Empty);

        var parts = record.Split(':', 2, StringSplitOptions.TrimEntries);
        return parts.Length == 1
            ? (parts[0], string.Empty)
            : (parts[0], parts[1]);
    }

    private static string BuildEntryAgentText(
        string addon,
        string edid,
        string record,
        string sid,
        string english,
        string chinese)
    {
        return $"Addon: {addon}\nEDID: {edid}\nRecord: {record}\nSID: {sid}\nEnglish: {english}\nChinese: {chinese}";
    }

    private static string BuildRecordAgentText(
        string addon,
        string edid,
        IReadOnlyList<DictionaryAgentRecordTranslation> translations)
    {
        var builder = new StringBuilder()
            .Append($"Addon: {addon}\n")
            .Append($"EDID: {edid}\n")
            .Append("Translations:\n");

        foreach (var translation in translations)
        {
            builder.Append("- ");
            builder.Append(translation.Record);
            if (translation.RecordVariantId.HasValue)
            {
                builder.Append(" [");
                builder.Append(translation.RecordVariantId.Value);
                if (translation.RecordVariantMax.HasValue)
                {
                    builder.Append('/');
                    builder.Append(translation.RecordVariantMax.Value);
                }
                builder.Append(']');
            }

            builder.Append(" | EN: ");
            builder.Append(translation.English);
            builder.Append(" | ZH: ");
            builder.Append(translation.Chinese);
            builder.Append(" | SID: ");
            builder.Append(translation.Sid);
            builder.Append('\n');
        }

        return builder.ToString().TrimEnd();
    }

    private static string NormalizeText(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var decoded = WebUtility.HtmlDecode(value);
        return MultiWhitespace.Replace(decoded.Trim(), " ");
    }

    private static string NormalizeForSearch(string value) =>
        NormalizeText(value).ToLowerInvariant();

    private static int? TryParseNullableInt(string? value) =>
        int.TryParse(value, out var parsed) ? parsed : null;

    private sealed record ExportDirectoryDetection(
        bool IsExportDirectory,
        List<string> EntryFiles,
        List<string> RecordFiles);

    private sealed class DictionaryCatalogFileBuilder
    {
        public string Addon { get; private init; } = string.Empty;
        public string SourceLanguage { get; private init; } = string.Empty;
        public string TargetLanguage { get; private init; } = string.Empty;
        public string Version { get; private init; } = string.Empty;
        public string SourceFile { get; private init; } = string.Empty;
        public List<DictionaryAgentEntry> Entries { get; } = new();
        public List<DictionaryAgentRecordDocument> RecordDocuments { get; } = new();

        public static DictionaryCatalogFileBuilder FromEntry(DictionaryAgentEntry entry) =>
            new()
            {
                Addon = entry.Addon,
                SourceLanguage = entry.SourceLanguage,
                TargetLanguage = entry.TargetLanguage,
                Version = entry.Version,
                SourceFile = entry.SourceFile
            };

        public static DictionaryCatalogFileBuilder FromRecord(DictionaryAgentRecordDocument record) =>
            new()
            {
                Addon = record.Addon,
                SourceLanguage = record.SourceLanguage,
                TargetLanguage = record.TargetLanguage,
                Version = record.Version,
                SourceFile = record.SourceFile
            };

        public DictionaryCatalogFile Build() =>
            new()
            {
                Addon = Addon,
                SourceLanguage = SourceLanguage,
                TargetLanguage = TargetLanguage,
                Version = Version,
                SourceFile = SourceFile,
                Entries = Entries
                    .OrderBy(entry => entry.Sid, StringComparer.OrdinalIgnoreCase)
                    .ToList(),
                RecordDocuments = RecordDocuments
                    .OrderBy(record => record.Edid, StringComparer.OrdinalIgnoreCase)
                    .ToList()
            };
    }
}
