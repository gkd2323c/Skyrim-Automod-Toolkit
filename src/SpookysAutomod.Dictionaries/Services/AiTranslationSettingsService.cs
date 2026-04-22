using System.Text.Json;

namespace SpookysAutomod.Dictionaries.Services;

public sealed class AiTranslationSettingsService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public AiTranslationSettingsLoadResult Load(string? configFile)
    {
        var resolvedPath = ResolveConfigPath(configFile);
        if (resolvedPath is null || !File.Exists(resolvedPath))
            return new AiTranslationSettingsLoadResult();

        var json = File.ReadAllText(resolvedPath);
        var root = JsonSerializer.Deserialize<ToolkitSettingsRoot>(json, JsonOptions);
        return new AiTranslationSettingsLoadResult
        {
            ConfigFile = resolvedPath,
            Settings = root?.AiTranslation
        };
    }

    private static string? ResolveConfigPath(string? configFile)
    {
        if (!string.IsNullOrWhiteSpace(configFile))
            return Path.GetFullPath(configFile);

        var current = new DirectoryInfo(Environment.CurrentDirectory);
        while (current is not null)
        {
            var candidate = Path.Combine(current.FullName, "settings.json");
            if (File.Exists(candidate))
                return candidate;

            current = current.Parent;
        }

        var appBaseCandidate = Path.Combine(AppContext.BaseDirectory, "settings.json");
        if (File.Exists(appBaseCandidate))
            return appBaseCandidate;

        return null;
    }
}

public sealed class AiTranslationSettingsLoadResult
{
    public string? ConfigFile { get; init; }
    public AiTranslationSettings? Settings { get; init; }
}

public sealed class ToolkitSettingsRoot
{
    public AiTranslationSettings? AiTranslation { get; init; }
}

public sealed class AiTranslationSettings
{
    public string? Endpoint { get; init; }
    public string? ApiKey { get; init; }
    public string? Model { get; init; }
    public string? CacheFile { get; init; }
    public string? SystemPrompt { get; init; }
    public string? UserPromptPreamble { get; init; }
    public int? BatchSize { get; init; }
    public double? MinConfidence { get; init; }
    public int? MaxOutputTokens { get; init; }
    public string? ReportFile { get; init; }
}
