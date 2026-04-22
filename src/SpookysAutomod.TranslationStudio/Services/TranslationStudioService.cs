using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using SpookysAutomod.TranslationStudio.Models;

namespace SpookysAutomod.TranslationStudio.Services;

public sealed class TranslationStudioService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    private readonly TranslationStudioSettingsService _settingsService;
    private DictionaryReferenceService? _dictionaryReferenceService;
    private string _dictionaryReferenceSignature = string.Empty;

    public TranslationStudioService(TranslationStudioSettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public string ConfigDirectory => _settingsService.ConfigDirectory;
    public string ConfigFilePath => _settingsService.ConfigFilePath;

    public TranslationDocumentSession LoadSession(string filePath)
    {
        var fullPath = Path.GetFullPath(filePath);
        var document = XDocument.Load(fullPath, LoadOptions.PreserveWhitespace);
        var content = document.Root?.Element("Content")
            ?? throw new InvalidOperationException("Input XML is missing the Content element.");

        var entries = content.Elements("String")
            .Select((element, index) => new TranslationEntryItem(index + 1, element))
            .ToList();

        return new TranslationDocumentSession(fullPath, document, entries);
    }

    public void SaveSession(TranslationDocumentSession session, string? outputPath = null)
    {
        var target = Path.GetFullPath(string.IsNullOrWhiteSpace(outputPath) ? session.FilePath : outputPath);
        Directory.CreateDirectory(Path.GetDirectoryName(target)!);
        using var writer = new StreamWriter(target, false, new UTF8Encoding(true));
        session.Document.Save(writer);
        session.FilePath = target;
    }

    public StudioAiTranslationSettings LoadAiSettings()
    {
        var settings = _settingsService.Load();
        return _settingsService.WithDefaults(settings.AiTranslation);
    }

    public string ResolveCacheFile(TranslationDocumentSession session, StudioAiTranslationSettings settings)
    {
        var sidecar = $"{session.FilePath}.studio-cache.json";
        if (File.Exists(sidecar))
            return sidecar;

        if (!string.IsNullOrWhiteSpace(settings.CacheFile))
        {
            return Path.IsPathRooted(settings.CacheFile)
                ? settings.CacheFile
                : Path.GetFullPath(Path.Combine(ConfigDirectory, settings.CacheFile));
        }

        return sidecar;
    }

    public TranslationCacheDocument LoadCache(string cacheFile, string contextKey)
    {
        try
        {
            if (!File.Exists(cacheFile))
                return new TranslationCacheDocument { SchemaVersion = "1", ContextKey = contextKey };

            var json = File.ReadAllText(cacheFile);
            var doc = JsonSerializer.Deserialize<TranslationCacheDocument>(json, JsonOptions);
            if (doc is null || doc.ContextKey != contextKey || doc.SchemaVersion != "1")
                return new TranslationCacheDocument { SchemaVersion = "1", ContextKey = contextKey };

            return doc;
        }
        catch
        {
            return new TranslationCacheDocument { SchemaVersion = "1", ContextKey = contextKey };
        }
    }

    public void SaveCache(string cacheFile, TranslationCacheDocument cache)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(cacheFile)!);
        File.WriteAllText(cacheFile, JsonSerializer.Serialize(cache, JsonOptions), new UTF8Encoding(true));
    }

    public async Task<Dictionary<string, AiTranslationBatchItem>> TranslateBatchAsync(
        IReadOnlyList<TranslationBatchRequestItem> entries,
        StudioAiTranslationSettings settings,
        CancellationToken cancellationToken)
    {
        if (entries.Count == 0)
            return new Dictionary<string, AiTranslationBatchItem>(StringComparer.Ordinal);

        var endpoint = settings.Endpoint;
        var apiKey = string.IsNullOrWhiteSpace(settings.ApiKey) ? "local" : settings.ApiKey;
        var dictionaryReferenceService = GetDictionaryReferenceService(settings.DictionaryDirectory);

        try
        {
            return await TranslateWithResponsesAsync(entries, settings, endpoint, apiKey, dictionaryReferenceService, cancellationToken);
        }
        catch
        {
            return await TranslateWithChatCompletionsAsync(entries, settings, endpoint, apiKey, dictionaryReferenceService, cancellationToken);
        }
    }

    public string BuildContextKey(StudioAiTranslationSettings settings)
    {
        using var sha = SHA256.Create();
        var input = $"{settings.Model}\u001F{settings.SystemPrompt}\u001F{settings.UserPromptPreamble}";
        return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }

    public static string BuildAiWorkKey(string record, string source)
    {
        using var sha = SHA256.Create();
        var input = $"{record}\u001F{source}";
        return Convert.ToHexString(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }

    private static async Task<Dictionary<string, AiTranslationBatchItem>> TranslateWithResponsesAsync(
        IReadOnlyList<TranslationBatchRequestItem> entries,
        StudioAiTranslationSettings settings,
        string endpoint,
        string apiKey,
        DictionaryReferenceService dictionaryReferenceService,
        CancellationToken cancellationToken)
    {
        using var client = new HttpClient();
        if (!string.IsNullOrWhiteSpace(apiKey))
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var payload = new JsonObject
        {
            ["model"] = settings.Model,
            ["max_output_tokens"] = settings.MaxOutputTokens,
            ["text"] = new JsonObject
            {
                ["format"] = new JsonObject
                {
                    ["type"] = "json_object"
                }
            },
            ["input"] = new JsonArray
            {
                new JsonObject
                {
                    ["role"] = "system",
                    ["content"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["type"] = "input_text",
                            ["text"] = settings.SystemPrompt
                        }
                    }
                },
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = new JsonArray
                    {
                        new JsonObject
                        {
                            ["type"] = "input_text",
                            ["text"] = BuildUserPrompt(entries, settings, dictionaryReferenceService)
                        }
                    }
                }
            }
        };

        using var content = new StringContent(payload.ToJsonString(), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync(endpoint, content, cancellationToken);
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
        response.EnsureSuccessStatusCode();
        return ParseResponseResult(responseText);
    }

    private static async Task<Dictionary<string, AiTranslationBatchItem>> TranslateWithChatCompletionsAsync(
        IReadOnlyList<TranslationBatchRequestItem> entries,
        StudioAiTranslationSettings settings,
        string endpoint,
        string apiKey,
        DictionaryReferenceService dictionaryReferenceService,
        CancellationToken cancellationToken)
    {
        using var client = new HttpClient();
        if (!string.IsNullOrWhiteSpace(apiKey))
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        var chatEndpoint = endpoint.EndsWith("/responses", StringComparison.OrdinalIgnoreCase)
            ? endpoint[..^"/responses".Length] + "/chat/completions"
            : endpoint;

        var payload = new JsonObject
        {
            ["model"] = settings.Model,
            ["temperature"] = 0.2,
            ["messages"] = new JsonArray
            {
                new JsonObject
                {
                    ["role"] = "system",
                    ["content"] = settings.SystemPrompt
                },
                new JsonObject
                {
                    ["role"] = "user",
                    ["content"] = BuildUserPrompt(entries, settings, dictionaryReferenceService)
                }
            }
        };

        using var content = new StringContent(payload.ToJsonString(), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync(chatEndpoint, content, cancellationToken);
        var responseText = await response.Content.ReadAsStringAsync(cancellationToken);
        response.EnsureSuccessStatusCode();

        using var document = JsonDocument.Parse(responseText);
        var text = document.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? string.Empty;
        return ParseTranslationsJson(text);
    }

    private static string BuildUserPrompt(
        IReadOnlyList<TranslationBatchRequestItem> entries,
        StudioAiTranslationSettings settings,
        DictionaryReferenceService dictionaryReferenceService)
    {
        var builder = new StringBuilder()
            .AppendLine(string.IsNullOrWhiteSpace(settings.UserPromptPreamble)
                ? "Translate the following entries. Return JSON object with key 'translations'."
                : settings.UserPromptPreamble)
            .AppendLine("Return JSON object with key 'translations' and an array of objects containing id, translation, confidence, notes.")
            .AppendLine("Entries:");

        foreach (var entry in entries)
        {
            var compactHints = settings.DictionaryHintLimit == 0
                ? new List<string>()
                : dictionaryReferenceService.FindHints(entry.Record, entry.Source, limit: settings.DictionaryHintLimit)
                    .Select(hint => $"{hint.English} => {hint.Chinese}")
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .Take(settings.DictionaryHintLimit)
                    .ToList();

            builder.AppendLine(JsonSerializer.Serialize(new
            {
                id = entry.Id,
                edid = entry.Edid,
                record = entry.Record,
                source = entry.Source,
                dictionaryHints = compactHints
            }));
        }

        return builder.ToString();
    }

    private DictionaryReferenceService GetDictionaryReferenceService(string dictionaryDirectory)
    {
        var settings = LoadAiSettings();
        var normalized = dictionaryDirectory ?? string.Empty;
        var signature = $"{normalized}\u001F{settings.MaxHintEnglishLength}\u001F{settings.MaxHintChineseLength}";
        if (_dictionaryReferenceService is not null && string.Equals(_dictionaryReferenceSignature, signature, StringComparison.Ordinal))
            return _dictionaryReferenceService;

        _dictionaryReferenceSignature = signature;
        _dictionaryReferenceService = new DictionaryReferenceService(
            normalized,
            settings.MaxHintEnglishLength,
            settings.MaxHintChineseLength);
        return _dictionaryReferenceService;
    }

    private static Dictionary<string, AiTranslationBatchItem> ParseResponseResult(string responseText)
    {
        using var document = JsonDocument.Parse(responseText);
        var root = document.RootElement;

        string text = string.Empty;
        if (root.TryGetProperty("output_text", out var outputText) && outputText.ValueKind == JsonValueKind.String)
        {
            text = outputText.GetString() ?? string.Empty;
        }
        else if (root.TryGetProperty("output", out var output) && output.ValueKind == JsonValueKind.Array)
        {
            var builder = new StringBuilder();
            foreach (var item in output.EnumerateArray())
            {
                if (!item.TryGetProperty("content", out var content) || content.ValueKind != JsonValueKind.Array)
                    continue;

                foreach (var contentItem in content.EnumerateArray())
                {
                    if (contentItem.TryGetProperty("text", out var textValue) && textValue.ValueKind == JsonValueKind.String)
                        builder.Append(textValue.GetString());
                }
            }

            text = builder.ToString();
        }

        return ParseTranslationsJson(text);
    }

    private static Dictionary<string, AiTranslationBatchItem> ParseTranslationsJson(string jsonText)
    {
        var cleaned = jsonText.Trim();
        if (cleaned.StartsWith("```", StringComparison.Ordinal))
            cleaned = cleaned.Trim('`').Replace("json", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();

        var node = JsonNode.Parse(cleaned);
        var items = node?["translations"]?.Deserialize<List<AiTranslationBatchItem>>(JsonOptions) ?? new List<AiTranslationBatchItem>();
        return items.Where(item => !string.IsNullOrWhiteSpace(item.Id)).ToDictionary(item => item.Id, item => item, StringComparer.Ordinal);
    }
}

public sealed class TranslationDocumentSession
{
    public TranslationDocumentSession(string filePath, XDocument document, List<TranslationEntryItem> entries)
    {
        FilePath = filePath;
        Document = document;
        Entries = entries;
    }

    public string FilePath { get; set; }
    public XDocument Document { get; }
    public List<TranslationEntryItem> Entries { get; }
}

public sealed class TranslationBatchRequestItem
{
    public string Id { get; init; } = string.Empty;
    public string Edid { get; init; } = string.Empty;
    public string Record { get; init; } = string.Empty;
    public string Source { get; init; } = string.Empty;
}

public sealed class TranslationCacheDocument
{
    public string SchemaVersion { get; init; } = "1";
    public string ContextKey { get; init; } = string.Empty;
    public Dictionary<string, TranslationCacheItem> Entries { get; init; } = new(StringComparer.Ordinal);
}

public sealed class TranslationCacheItem
{
    public string Translation { get; init; } = string.Empty;
    public double Confidence { get; init; }
    public string Notes { get; init; } = string.Empty;
    public DateTimeOffset CachedAtUtc { get; init; } = DateTimeOffset.UtcNow;
}

public sealed class AiTranslationBatchItem
{
    public string Id { get; init; } = string.Empty;
    public string Translation { get; init; } = string.Empty;
    public double Confidence { get; init; }
    public string? Notes { get; init; }
}
