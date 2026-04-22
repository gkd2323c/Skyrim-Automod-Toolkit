using System.Text;
using System.Xml.Linq;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Dictionaries.Models;

namespace SpookysAutomod.Dictionaries.Services;

public sealed class DictionaryXmlTranslationService
{
    private const int SampleLimit = 20;

    private readonly IModLogger _logger;
    private readonly DictionaryCatalogService _catalogService;

    public DictionaryXmlTranslationService(IModLogger logger)
    {
        _logger = logger;
        _catalogService = new DictionaryCatalogService(logger);
    }

    public Result<DictionaryTranslateXmlResult> Translate(DictionaryTranslateXmlOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.InputFile))
        {
            return Result<DictionaryTranslateXmlResult>.Fail(
                "Input file is required.",
                suggestions: new List<string> { "Pass the source XML path as the first argument." });
        }

        if (string.IsNullOrWhiteSpace(options.ReferenceDirectory))
        {
            return Result<DictionaryTranslateXmlResult>.Fail(
                "Reference directory is required.",
                suggestions: new List<string> { "Pass --reference with the dictionaries folder path." });
        }

        var inputFile = Path.GetFullPath(options.InputFile);
        if (!File.Exists(inputFile))
        {
            return Result<DictionaryTranslateXmlResult>.Fail(
                $"Input file not found: {inputFile}",
                suggestions: new List<string> { "Check the XML file path and try again." });
        }

        var outputFile = string.IsNullOrWhiteSpace(options.OutputFile)
            ? BuildDefaultOutputPath(inputFile)
            : Path.GetFullPath(options.OutputFile);

        var catalogResult = _catalogService.Load(options.ReferenceDirectory);
        if (!catalogResult.Success || catalogResult.Value is null)
            return Result<DictionaryTranslateXmlResult>.Fail(catalogResult.Error!, catalogResult.ErrorContext, catalogResult.Suggestions);

        try
        {
            var document = XDocument.Load(inputFile, LoadOptions.PreserveWhitespace);
            var root = document.Root;
            var contentElement = root?.Element("Content");
            if (root is null || contentElement is null)
            {
                return Result<DictionaryTranslateXmlResult>.Fail(
                    "Translation XML is missing the Content element.",
                    suggestions: new List<string> { "Make sure the input file is an SSTXMLRessources export." });
            }

            var indexes = TranslationIndexes.Build(catalogResult.Value.Files);

            var translatedEntries = 0;
            var skippedExistingEntries = 0;
            var unmatchedEntries = 0;
            var ambiguousEntries = 0;
            var ambiguousSamples = new List<DictionaryTranslateXmlAmbiguousMatch>();
            var unmatchedSamples = new List<DictionaryTranslateXmlUnmatchedEntry>();

            foreach (var stringElement in contentElement.Elements("String"))
            {
                var source = NormalizeText(stringElement.Element("Source")?.Value);
                var destElement = stringElement.Element("Dest");
                var currentDest = NormalizeText(destElement?.Value);

                if (!options.OverwriteExisting && HasExistingTranslation(source, currentDest))
                {
                    skippedExistingEntries++;
                    continue;
                }

                var recElement = stringElement.Element("REC");
                var candidate = ResolveTranslation(stringElement, source, recElement, indexes);
                if (candidate is null)
                {
                    unmatchedEntries++;
                    if (unmatchedSamples.Count < SampleLimit)
                    {
                        unmatchedSamples.Add(new DictionaryTranslateXmlUnmatchedEntry
                        {
                            Edid = NormalizeText(stringElement.Element("EDID")?.Value),
                            Record = NormalizeText(recElement?.Value),
                            Source = source
                        });
                    }

                    continue;
                }

                if (candidate.Candidates.Count > 1)
                {
                    ambiguousEntries++;
                    if (ambiguousSamples.Count < SampleLimit)
                    {
                        ambiguousSamples.Add(new DictionaryTranslateXmlAmbiguousMatch
                        {
                            Edid = NormalizeText(stringElement.Element("EDID")?.Value),
                            Record = NormalizeText(recElement?.Value),
                            Source = source,
                            Candidates = candidate.Candidates
                        });
                    }

                    continue;
                }

                if (destElement is null)
                {
                    destElement = new XElement("Dest");
                    stringElement.Add(destElement);
                }

                destElement.Value = candidate.Candidates[0];
                translatedEntries++;
            }

            var outputDirectory = Path.GetDirectoryName(outputFile);
            if (!string.IsNullOrWhiteSpace(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            using var writer = new StreamWriter(outputFile, false, new UTF8Encoding(true));
            document.Save(writer);

            return Result<DictionaryTranslateXmlResult>.Ok(new DictionaryTranslateXmlResult
            {
                InputFile = inputFile,
                OutputFile = outputFile,
                ReferenceDirectory = Path.GetFullPath(options.ReferenceDirectory),
                TotalEntries = contentElement.Elements("String").Count(),
                TranslatedEntries = translatedEntries,
                SkippedExistingEntries = skippedExistingEntries,
                UnmatchedEntries = unmatchedEntries,
                AmbiguousEntries = ambiguousEntries,
                AmbiguousSamples = ambiguousSamples,
                UnmatchedSamples = unmatchedSamples
            });
        }
        catch (Exception ex)
        {
            _logger.Error("Failed to translate XML file.", ex);
            return Result<DictionaryTranslateXmlResult>.Fail(
                $"Failed to translate XML file: {inputFile}",
                ex.Message,
                new List<string>
                {
                    "Check whether the input XML is well-formed.",
                    "Try again with --verbose to inspect progress."
                });
        }
    }

    private static TranslationCandidate? ResolveTranslation(
        XElement stringElement,
        string source,
        XElement? recElement,
        TranslationIndexes indexes)
    {
        var edid = NormalizeText(stringElement.Element("EDID")?.Value);
        var record = NormalizeText(recElement?.Value);
        var variantId = NormalizeText(recElement?.Attribute("id")?.Value);

        if (!string.IsNullOrWhiteSpace(edid) && !string.IsNullOrWhiteSpace(record))
        {
            var preciseKey = BuildPreciseKey(edid, record, variantId, source);
            if (indexes.ByPreciseKey.TryGetValue(preciseKey, out var preciseCandidates))
                return preciseCandidates;

            var recordKey = BuildRecordKey(edid, record, variantId);
            if (indexes.ByRecordKey.TryGetValue(recordKey, out var recordCandidates))
                return recordCandidates;
        }

        if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(record))
        {
            var textRecordKey = BuildTextRecordKey(source, record);
            if (indexes.ByTextAndRecordKey.TryGetValue(textRecordKey, out var textRecordCandidates))
                return textRecordCandidates;
        }

        if (!string.IsNullOrWhiteSpace(source) && indexes.BySourceText.TryGetValue(source, out var textCandidates))
            return textCandidates;

        return null;
    }

    private static bool HasExistingTranslation(string source, string dest) =>
        !string.IsNullOrWhiteSpace(dest) &&
        !string.Equals(source, dest, StringComparison.Ordinal);

    private static string BuildDefaultOutputPath(string inputFile)
    {
        var directory = Path.GetDirectoryName(inputFile) ?? Environment.CurrentDirectory;
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputFile);
        var extension = Path.GetExtension(inputFile);
        return Path.Combine(directory, $"{fileNameWithoutExtension}.translated{extension}");
    }

    private static string NormalizeText(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value.Trim().Replace("\r\n", "\n").Replace('\r', '\n');
    }

    private static string BuildPreciseKey(string edid, string record, string variantId, string source) =>
        string.Join('\u001F', NormalizeKey(edid), NormalizeKey(record), NormalizeKey(variantId), NormalizeKey(source));

    private static string BuildRecordKey(string edid, string record, string variantId) =>
        string.Join('\u001F', NormalizeKey(edid), NormalizeKey(record), NormalizeKey(variantId));

    private static string BuildTextRecordKey(string source, string record) =>
        string.Join('\u001F', NormalizeKey(source), NormalizeKey(record));

    private static string NormalizeKey(string? value) =>
        string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim().ToLowerInvariant();

    private sealed class TranslationIndexes
    {
        public Dictionary<string, TranslationCandidate> ByPreciseKey { get; } = new(StringComparer.Ordinal);
        public Dictionary<string, TranslationCandidate> ByRecordKey { get; } = new(StringComparer.Ordinal);
        public Dictionary<string, TranslationCandidate> ByTextAndRecordKey { get; } = new(StringComparer.Ordinal);
        public Dictionary<string, TranslationCandidate> BySourceText { get; } = new(StringComparer.Ordinal);

        public static TranslationIndexes Build(IEnumerable<DictionaryCatalogFile> files)
        {
            var indexes = new TranslationIndexes();
            foreach (var entry in files.SelectMany(file => file.Entries))
            {
                if (string.IsNullOrWhiteSpace(entry.Chinese))
                    continue;

                indexes.Add(indexes.ByPreciseKey, BuildPreciseKey(entry.Edid, entry.Record, entry.RecordVariantId?.ToString() ?? string.Empty, entry.English), entry.Chinese);
                indexes.Add(indexes.ByRecordKey, BuildRecordKey(entry.Edid, entry.Record, entry.RecordVariantId?.ToString() ?? string.Empty), entry.Chinese);
                indexes.Add(indexes.ByTextAndRecordKey, BuildTextRecordKey(entry.English, entry.Record), entry.Chinese);
                indexes.Add(indexes.BySourceText, NormalizeKey(entry.English), entry.Chinese);
            }

            return indexes;
        }

        private void Add(Dictionary<string, TranslationCandidate> index, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;

            if (!index.TryGetValue(key, out var candidate))
            {
                candidate = new TranslationCandidate();
                index[key] = candidate;
            }

            candidate.Add(value);
        }
    }

    private sealed class TranslationCandidate
    {
        private readonly HashSet<string> _candidateSet = new(StringComparer.Ordinal);

        public List<string> Candidates { get; } = new();

        public void Add(string value)
        {
            if (_candidateSet.Add(value))
                Candidates.Add(value);
        }
    }
}
