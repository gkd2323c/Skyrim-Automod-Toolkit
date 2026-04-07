namespace SpookysAutomod.Dictionaries.Models;

public sealed class DictionaryAgentExportSummary
{
    public string InputDirectory { get; init; } = string.Empty;
    public string OutputDirectory { get; init; } = string.Empty;
    public DateTimeOffset GeneratedAtUtc { get; init; }
    public int ShardSize { get; init; }
    public int TotalSourceFiles { get; init; }
    public int TotalEntries { get; init; }
    public int TotalRecordDocuments { get; init; }
    public List<DictionaryAgentAddonSummary> Addons { get; init; } = new();
    public List<DictionaryAgentRecordTypeCount> RecordTypes { get; init; } = new();
    public List<string> GeneratedFiles { get; init; } = new();
}

public sealed class DictionaryAgentAddonSummary
{
    public string Addon { get; init; } = string.Empty;
    public string SourceFile { get; init; } = string.Empty;
    public int EntryCount { get; init; }
    public int RecordDocumentCount { get; init; }
    public List<string> EntryFiles { get; init; } = new();
    public List<string> RecordFiles { get; init; } = new();
}

public sealed class DictionaryAgentRecordTypeCount
{
    public string RecordType { get; init; } = string.Empty;
    public int Count { get; init; }
}

public sealed class DictionaryAgentExportOptions
{
    public string InputDirectory { get; init; } = string.Empty;
    public string OutputDirectory { get; init; } = string.Empty;
    public int ShardSize { get; init; } = 5000;
}
