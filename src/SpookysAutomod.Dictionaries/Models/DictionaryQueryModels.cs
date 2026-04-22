namespace SpookysAutomod.Dictionaries.Models;

public enum DictionarySearchScope
{
    All,
    Edid,
    English,
    Chinese
}

public enum DictionaryResultGrouping
{
    Entry,
    Record
}

public sealed class DictionaryLookupOptions
{
    public string InputDirectory { get; init; } = string.Empty;
    public string Edid { get; init; } = string.Empty;
    public string? Addon { get; init; }
    public string? RecordType { get; init; }
    public string? Field { get; init; }
}

public sealed class DictionaryLookupResult
{
    public string Edid { get; init; } = string.Empty;
    public int MatchCount { get; init; }
    public List<DictionaryAgentRecordDocument> Matches { get; init; } = new();
}

public sealed class DictionarySearchOptions
{
    public string InputDirectory { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public string? Addon { get; init; }
    public string? RecordType { get; init; }
    public string? Field { get; init; }
    public int Limit { get; init; } = 20;
    public DictionarySearchScope Scope { get; init; } = DictionarySearchScope.All;
    public DictionaryResultGrouping GroupBy { get; init; } = DictionaryResultGrouping.Entry;
}

public sealed class DictionarySearchResult
{
    public string Text { get; init; } = string.Empty;
    public string Scope { get; init; } = string.Empty;
    public string GroupBy { get; init; } = string.Empty;
    public int TotalMatches { get; init; }
    public int ReturnedCount { get; init; }
    public List<DictionaryAgentEntry>? Entries { get; init; }
    public List<DictionaryAgentRecordDocument>? Records { get; init; }
}

public sealed class DictionaryTranslateXmlOptions
{
    public string InputFile { get; init; } = string.Empty;
    public string OutputFile { get; init; } = string.Empty;
    public string ReferenceDirectory { get; init; } = string.Empty;
    public bool OverwriteExisting { get; init; }
}

public sealed class DictionaryTranslateXmlResult
{
    public string InputFile { get; init; } = string.Empty;
    public string OutputFile { get; init; } = string.Empty;
    public string ReferenceDirectory { get; init; } = string.Empty;
    public int TotalEntries { get; init; }
    public int TranslatedEntries { get; init; }
    public int SkippedExistingEntries { get; init; }
    public int UnmatchedEntries { get; init; }
    public int AmbiguousEntries { get; init; }
    public List<DictionaryTranslateXmlAmbiguousMatch> AmbiguousSamples { get; init; } = new();
    public List<DictionaryTranslateXmlUnmatchedEntry> UnmatchedSamples { get; init; } = new();
}

public sealed class DictionaryTranslateXmlAmbiguousMatch
{
    public string Edid { get; init; } = string.Empty;
    public string Record { get; init; } = string.Empty;
    public string Source { get; init; } = string.Empty;
    public List<string> Candidates { get; init; } = new();
}

public sealed class DictionaryTranslateXmlUnmatchedEntry
{
    public string Edid { get; init; } = string.Empty;
    public string Record { get; init; } = string.Empty;
    public string Source { get; init; } = string.Empty;
}

public sealed class DictionaryTranslateXmlAiOptions
{
    public string InputFile { get; init; } = string.Empty;
    public string OutputFile { get; init; } = string.Empty;
    public string ReferenceDirectory { get; init; } = string.Empty;
    public string? ConfigFile { get; init; }
    public string? ReportFile { get; init; }
    public bool OverwriteExisting { get; init; }
    public string ApiKey { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public string Endpoint { get; init; } = string.Empty;
    public string? SystemPrompt { get; init; }
    public string? UserPromptPreamble { get; init; }
    public int BatchSize { get; init; }
    public double MinConfidence { get; init; }
    public int MaxOutputTokens { get; init; }
}

public sealed class DictionaryTranslateXmlAiResult
{
    public string InputFile { get; init; } = string.Empty;
    public string OutputFile { get; init; } = string.Empty;
    public string? ConfigFile { get; init; }
    public string? ReportFile { get; init; }
    public string ReferenceDirectory { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public int TotalEntries { get; init; }
    public int DictionaryTranslatedEntries { get; init; }
    public int AiAttemptedEntries { get; init; }
    public int AiTranslatedEntries { get; init; }
    public int SkippedExistingEntries { get; init; }
    public int DictionaryUnmatchedEntries { get; init; }
    public int DictionaryAmbiguousEntries { get; init; }
    public int LowConfidenceEntries { get; init; }
    public int FailedAiEntries { get; init; }
    public int RemainingUntranslatedEntries { get; init; }
    public List<DictionaryTranslateXmlAiSample> LowConfidenceSamples { get; init; } = new();
    public List<DictionaryTranslateXmlAiSample> FailedAiSamples { get; init; } = new();
}

public sealed class DictionaryTranslateXmlAiSample
{
    public string Edid { get; init; } = string.Empty;
    public string Record { get; init; } = string.Empty;
    public string Source { get; init; } = string.Empty;
    public string? Translation { get; init; }
    public double? Confidence { get; init; }
    public string? Notes { get; init; }
}
