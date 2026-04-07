namespace SpookysAutomod.Dictionaries.Models;

public sealed class DictionaryAgentRecordDocument
{
    public string Addon { get; init; } = string.Empty;
    public string SourceLanguage { get; init; } = string.Empty;
    public string TargetLanguage { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public string SourceFile { get; init; } = string.Empty;
    public string Edid { get; init; } = string.Empty;
    public string RecordKey { get; init; } = string.Empty;
    public List<DictionaryAgentRecordTranslation> Translations { get; init; } = new();
    public string AgentText { get; init; } = string.Empty;
}

public sealed class DictionaryAgentRecordTranslation
{
    public string Sid { get; init; } = string.Empty;
    public string ListId { get; init; } = string.Empty;
    public string Record { get; init; } = string.Empty;
    public string RecordType { get; init; } = string.Empty;
    public string Field { get; init; } = string.Empty;
    public int? RecordVariantId { get; init; }
    public int? RecordVariantMax { get; init; }
    public string English { get; init; } = string.Empty;
    public string Chinese { get; init; } = string.Empty;
}
