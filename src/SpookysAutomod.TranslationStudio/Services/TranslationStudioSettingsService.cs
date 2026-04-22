using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SpookysAutomod.TranslationStudio.Services;

public sealed class TranslationStudioSettingsService
{
    public const string DefaultEndpoint = "https://api.openai.com/v1/responses";
    public const string DefaultModel = "gpt-4.1-mini";
    public const int DefaultBatchSize = 20;
    public const double DefaultMinConfidence = 0.75;
    public const int DefaultMaxOutputTokens = 4000;
    public const int DefaultDictionaryHintLimit = 2;
    public const int DefaultMaxHintEnglishLength = 48;
    public const int DefaultMaxHintChineseLength = 24;
    public const string DefaultSystemPrompt = """
        You translate Skyrim Special Edition player-facing text from English to Simplified Chinese for SSTXMLRessources exports.

        Rules:
        - Preserve placeholders and markup exactly, including tokens like <Alias=...>, <Global=...>, %s, and line breaks.
        - Keep technical identifiers untouched; translate only the player-facing source text.
        - Prefer established vanilla Skyrim Chinese terminology over literal invention.
        - Translate titles and functional descriptors, but do not over-translate personal names just because they have surface meaning.
        - Return only valid JSON matching the requested schema.
        - Confidence is a number between 0 and 1.
        """;
    public const string DefaultUserPromptPreamble = """
        Translate the following entries.
        Return JSON with shape: {"translations":[{"id":"...","translation":"...","confidence":0.0,"notes":"..."}]}
        Entries:
        """;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    public string ConfigDirectory { get; }
    public string ConfigFilePath => Path.Combine(ConfigDirectory, "translation-studio.settings.json");

    public TranslationStudioSettingsService()
    {
        ConfigDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SpookysAutomodTranslationStudio");
    }

    public StudioSettings Load()
    {
        if (!File.Exists(ConfigFilePath))
            return WithDefaults(new StudioSettings());

        var json = File.ReadAllText(ConfigFilePath);
        return WithDefaults(JsonSerializer.Deserialize<StudioSettings>(json, JsonOptions) ?? new StudioSettings());
    }

    public ThemeMode LoadThemeMode()
    {
        return Load().TranslationStudio?.ThemeMode?.Trim().ToLowerInvariant() switch
        {
            "light" => ThemeMode.Light,
            "dark" => ThemeMode.Dark,
            _ => ThemeMode.FollowSystem
        };
    }

    public void SaveThemeMode(ThemeMode mode)
    {
        var root = LoadRootObject();
        var studioNode = root["translationStudio"] as JsonObject ?? new JsonObject();
        studioNode["themeMode"] = mode switch
        {
            ThemeMode.Light => "light",
            ThemeMode.Dark => "dark",
            _ => "system"
        };
        root["translationStudio"] = studioNode;
        SaveRootObject(root);
    }

    public void SaveSettings(StudioSettings settings)
    {
        var root = LoadRootObject();
        settings = WithDefaults(settings);

        if (settings.AiTranslation is not null)
        {
            root["aiTranslation"] = JsonSerializer.SerializeToNode(settings.AiTranslation, JsonOptions);
        }

        var studioNode = root["translationStudio"] as JsonObject ?? new JsonObject();
        if (settings.TranslationStudio is not null)
            studioNode["themeMode"] = settings.TranslationStudio.ThemeMode;

        root["translationStudio"] = studioNode;
        SaveRootObject(root);
    }

    private JsonObject LoadRootObject()
    {
        if (File.Exists(ConfigFilePath))
        {
            var existing = File.ReadAllText(ConfigFilePath);
            return JsonNode.Parse(existing)?.AsObject() ?? new JsonObject();
        }
        return new JsonObject();
    }

    private void SaveRootObject(JsonObject root)
    {
        Directory.CreateDirectory(ConfigDirectory);
        File.WriteAllText(ConfigFilePath, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
    }

    public StudioAiTranslationSettings WithDefaults(StudioAiTranslationSettings? settings)
    {
        settings ??= new StudioAiTranslationSettings();
        return new StudioAiTranslationSettings
        {
            DictionaryDirectory = settings.DictionaryDirectory ?? string.Empty,
            Endpoint = string.IsNullOrWhiteSpace(settings.Endpoint) ? DefaultEndpoint : settings.Endpoint,
            ApiKey = settings.ApiKey ?? string.Empty,
            Model = string.IsNullOrWhiteSpace(settings.Model) ? DefaultModel : settings.Model,
            CacheFile = settings.CacheFile ?? string.Empty,
            SystemPrompt = string.IsNullOrWhiteSpace(settings.SystemPrompt) ? DefaultSystemPrompt : settings.SystemPrompt,
            UserPromptPreamble = string.IsNullOrWhiteSpace(settings.UserPromptPreamble) ? DefaultUserPromptPreamble : settings.UserPromptPreamble,
            BatchSize = settings.BatchSize > 0 ? settings.BatchSize : DefaultBatchSize,
            MinConfidence = settings.MinConfidence > 0 ? settings.MinConfidence : DefaultMinConfidence,
            MaxOutputTokens = settings.MaxOutputTokens > 0 ? settings.MaxOutputTokens : DefaultMaxOutputTokens,
            DictionaryHintLimit = settings.DictionaryHintLimit >= 0 ? settings.DictionaryHintLimit : DefaultDictionaryHintLimit,
            MaxHintEnglishLength = settings.MaxHintEnglishLength > 0 ? settings.MaxHintEnglishLength : DefaultMaxHintEnglishLength,
            MaxHintChineseLength = settings.MaxHintChineseLength > 0 ? settings.MaxHintChineseLength : DefaultMaxHintChineseLength,
            ReportFile = settings.ReportFile ?? string.Empty
        };
    }

    public StudioSettings WithDefaults(StudioSettings settings)
    {
        return new StudioSettings
        {
            AiTranslation = WithDefaults(settings.AiTranslation),
            TranslationStudio = settings.TranslationStudio ?? new StudioUiSettings()
        };
    }
}

public sealed class StudioSettings
{
    public StudioAiTranslationSettings? AiTranslation { get; init; }
    public StudioUiSettings? TranslationStudio { get; init; }
}

public sealed class StudioAiTranslationSettings
{
    public string DictionaryDirectory { get; init; } = string.Empty;
    public string Endpoint { get; init; } = string.Empty;
    public string ApiKey { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public string CacheFile { get; init; } = string.Empty;
    public string SystemPrompt { get; init; } = string.Empty;
    public string UserPromptPreamble { get; init; } = string.Empty;
    public int BatchSize { get; init; } = 20;
    public double MinConfidence { get; init; } = 0.75;
    public int MaxOutputTokens { get; init; } = 4000;
    public int DictionaryHintLimit { get; init; } = 2;
    public int MaxHintEnglishLength { get; init; } = 48;
    public int MaxHintChineseLength { get; init; } = 24;
    public string ReportFile { get; init; } = string.Empty;
}

public sealed class StudioUiSettings
{
    public string ThemeMode { get; init; } = "system";
}
