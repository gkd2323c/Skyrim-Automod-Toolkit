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
