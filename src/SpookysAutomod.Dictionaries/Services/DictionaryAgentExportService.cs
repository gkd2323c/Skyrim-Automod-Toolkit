using System.Text.Encodings.Web;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SpookysAutomod.Core.Logging;
using SpookysAutomod.Core.Models;
using SpookysAutomod.Dictionaries.Models;

namespace SpookysAutomod.Dictionaries.Services;

public sealed class DictionaryAgentExportService
{
    private static readonly UTF8Encoding Utf8WithBom = new(true);

    private readonly IModLogger _logger;
    private readonly JsonSerializerOptions _jsonLineOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private readonly JsonSerializerOptions _manifestOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public DictionaryAgentExportService(IModLogger logger)
    {
        _logger = logger;
    }

    public Result<DictionaryAgentExportSummary> Export(DictionaryAgentExportOptions options)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(options.OutputDirectory))
            {
                return Result<DictionaryAgentExportSummary>.Fail(
                    "Output directory is required.",
                    suggestions: new List<string> { "Pass --output with a writable folder path." });
            }

            if (options.ShardSize <= 0)
            {
                return Result<DictionaryAgentExportSummary>.Fail(
                    "Shard size must be greater than zero.",
                    suggestions: new List<string> { "Use a positive value such as --shard-size 5000." });
            }

            var outputDirectory = Path.GetFullPath(options.OutputDirectory);
            var catalogService = new DictionaryCatalogService(_logger);
            var catalogResult = catalogService.Load(options.InputDirectory);
            if (!catalogResult.Success || catalogResult.Value is null)
            {
                return Result<DictionaryAgentExportSummary>.Fail(
                    catalogResult.Error ?? "Failed to load dictionaries.",
                    catalogResult.ErrorContext,
                    catalogResult.Suggestions);
            }

            var catalog = catalogResult.Value;

            PrepareOutputDirectory(outputDirectory);

            var entriesDirectory = Path.Combine(outputDirectory, "entries");
            var recordsDirectory = Path.Combine(outputDirectory, "records");
            Directory.CreateDirectory(entriesDirectory);
            Directory.CreateDirectory(recordsDirectory);

            var addonSummaries = new List<DictionaryAgentAddonSummary>();
            var generatedFiles = new List<string>();
            var recordTypeCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var generatedAt = DateTimeOffset.UtcNow;

            var totalEntries = 0;
            var totalRecordDocuments = 0;

            foreach (var file in catalog.Files)
            {
                foreach (var entry in file.Entries)
                {
                    if (!recordTypeCounts.TryAdd(entry.RecordType, 1))
                        recordTypeCounts[entry.RecordType]++;
                }

                var addonSlug = SanitizeFileName(file.Addon);
                var entryFiles = WriteShardedJsonl(
                    file.Entries,
                    entriesDirectory,
                    $"{addonSlug}.entries",
                    options.ShardSize);
                var recordFiles = WriteShardedJsonl(
                    file.RecordDocuments,
                    recordsDirectory,
                    $"{addonSlug}.records",
                    options.ShardSize);

                generatedFiles.AddRange(entryFiles);
                generatedFiles.AddRange(recordFiles);

                addonSummaries.Add(new DictionaryAgentAddonSummary
                {
                    Addon = file.Addon,
                    SourceFile = file.SourceFile,
                    EntryCount = file.Entries.Count,
                    RecordDocumentCount = file.RecordDocuments.Count,
                    EntryFiles = entryFiles,
                    RecordFiles = recordFiles
                });

                totalEntries += file.Entries.Count;
                totalRecordDocuments += file.RecordDocuments.Count;
            }

            var manifestPath = Path.Combine(outputDirectory, "manifest.json");
            generatedFiles.Add(manifestPath);

            var summary = new DictionaryAgentExportSummary
            {
                InputDirectory = catalog.InputDirectory,
                OutputDirectory = outputDirectory,
                GeneratedAtUtc = generatedAt,
                ShardSize = options.ShardSize,
                TotalSourceFiles = catalog.Files.Count,
                TotalEntries = totalEntries,
                TotalRecordDocuments = totalRecordDocuments,
                Addons = addonSummaries,
                RecordTypes = recordTypeCounts
                    .OrderByDescending(kv => kv.Value)
                    .ThenBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
                    .Select(kv => new DictionaryAgentRecordTypeCount
                    {
                        RecordType = kv.Key,
                        Count = kv.Value
                    })
                    .ToList(),
                GeneratedFiles = generatedFiles
            };

            var manifestSummary = CreatePortableManifestSummary(summary, outputDirectory);
            File.WriteAllText(manifestPath, JsonSerializer.Serialize(manifestSummary, _manifestOptions), Utf8WithBom);

            return Result<DictionaryAgentExportSummary>.Ok(summary);
        }
        catch (Exception ex)
        {
            _logger.Error("Failed to export dictionary files.", ex);
            return Result<DictionaryAgentExportSummary>.Fail(
                "Failed to export XML dictionaries into agent-readable files.",
                ex.Message,
                new List<string>
                {
                    "Validate that the input XML files are well-formed.",
                    "Use a writable --output directory.",
                    "Try again with --verbose for progress details."
                });
        }
    }

    private void PrepareOutputDirectory(string outputDirectory)
    {
        Directory.CreateDirectory(outputDirectory);

        var manifestPath = Path.Combine(outputDirectory, "manifest.json");
        if (File.Exists(manifestPath))
            File.Delete(manifestPath);

        ResetGeneratedSubdirectory(Path.Combine(outputDirectory, "entries"));
        ResetGeneratedSubdirectory(Path.Combine(outputDirectory, "records"));
    }

    private static void ResetGeneratedSubdirectory(string path)
    {
        if (Directory.Exists(path))
            Directory.Delete(path, true);
    }

    private static DictionaryAgentExportSummary CreatePortableManifestSummary(
        DictionaryAgentExportSummary summary,
        string outputDirectory)
    {
        return new DictionaryAgentExportSummary
        {
            InputDirectory = ToPortableRelativePath(outputDirectory, summary.InputDirectory),
            OutputDirectory = ".",
            GeneratedAtUtc = summary.GeneratedAtUtc,
            ShardSize = summary.ShardSize,
            TotalSourceFiles = summary.TotalSourceFiles,
            TotalEntries = summary.TotalEntries,
            TotalRecordDocuments = summary.TotalRecordDocuments,
            Addons = summary.Addons
                .Select(addon => new DictionaryAgentAddonSummary
                {
                    Addon = addon.Addon,
                    SourceFile = addon.SourceFile,
                    EntryCount = addon.EntryCount,
                    RecordDocumentCount = addon.RecordDocumentCount,
                    EntryFiles = addon.EntryFiles
                        .Select(path => ToPortableRelativePath(outputDirectory, path))
                        .ToList(),
                    RecordFiles = addon.RecordFiles
                        .Select(path => ToPortableRelativePath(outputDirectory, path))
                        .ToList()
                })
                .ToList(),
            RecordTypes = summary.RecordTypes
                .Select(recordType => new DictionaryAgentRecordTypeCount
                {
                    RecordType = recordType.RecordType,
                    Count = recordType.Count
                })
                .ToList(),
            GeneratedFiles = summary.GeneratedFiles
                .Select(path => ToPortableRelativePath(outputDirectory, path))
                .ToList()
        };
    }

    private List<string> WriteShardedJsonl<T>(
        IReadOnlyList<T> items,
        string directory,
        string filePrefix,
        int shardSize)
    {
        var files = new List<string>();
        if (items.Count == 0)
            return files;

        for (var start = 0; start < items.Count; start += shardSize)
        {
            var shardIndex = (start / shardSize) + 1;
            var filePath = Path.Combine(directory, $"{filePrefix}.part-{shardIndex:0000}.jsonl");

            using var writer = new StreamWriter(filePath, false, Utf8WithBom);
            var endExclusive = Math.Min(start + shardSize, items.Count);
            for (var i = start; i < endExclusive; i++)
            {
                writer.WriteLine(JsonSerializer.Serialize(items[i], _jsonLineOptions));
            }

            files.Add(filePath);
        }

        return files;
    }

    private static string ToPortableRelativePath(string baseDirectory, string targetPath)
    {
        if (string.IsNullOrWhiteSpace(targetPath))
            return string.Empty;

        var relativePath = Path.GetRelativePath(baseDirectory, targetPath);
        return string.IsNullOrWhiteSpace(relativePath)
            ? "."
            : relativePath.Replace('\\', '/');
    }

    private static string SanitizeFileName(string value)
    {
        var sanitized = value;
        foreach (var invalidChar in Path.GetInvalidFileNameChars())
            sanitized = sanitized.Replace(invalidChar, '_');

        return string.IsNullOrWhiteSpace(sanitized) ? "dictionary" : sanitized.Replace(' ', '_');
    }
}
