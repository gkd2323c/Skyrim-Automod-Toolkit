namespace SpookysAutomod.Dictionaries.Models;

public sealed class DictionaryCatalog
{
    public string InputDirectory { get; init; } = string.Empty;
    public List<DictionaryCatalogFile> Files { get; init; } = new();
}

public sealed class DictionaryCatalogFile
{
    public string Addon { get; init; } = string.Empty;
    public string SourceLanguage { get; init; } = string.Empty;
    public string TargetLanguage { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public string SourceFile { get; init; } = string.Empty;
    public List<DictionaryAgentEntry> Entries { get; init; } = new();
    public List<DictionaryAgentRecordDocument> RecordDocuments { get; init; } = new();
}
