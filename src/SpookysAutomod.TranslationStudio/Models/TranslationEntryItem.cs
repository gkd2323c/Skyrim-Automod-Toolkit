using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace SpookysAutomod.TranslationStudio.Models;

public sealed class TranslationEntryItem : INotifyPropertyChanged
{
    private readonly XElement _destElement;
    private string _dest;
    private bool _isTranslating;
    private bool _isLowConfidence;
    private bool _isFailed;
    private bool _isTranslatedByAi;
    private bool _isFromCache;
    private double? _confidence;
    private string _notes = string.Empty;
    private int _editVersion;

    public TranslationEntryItem(int index, XElement element)
    {
        Index = index;
        Edid = NormalizeText(element.Element("EDID")?.Value);
        Record = NormalizeText(element.Element("REC")?.Value);
        Source = NormalizeText(element.Element("Source")?.Value);
        _destElement = element.Element("Dest") ?? new XElement("Dest");
        if (_destElement.Parent is null)
            element.Add(_destElement);

        _dest = NormalizeText(_destElement.Value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public int Index { get; }
    public string Edid { get; }
    public string Record { get; }
    public string Source { get; }

    public string Dest
    {
        get => _dest;
        set
        {
            var normalized = value ?? string.Empty;
            if (_dest == normalized)
                return;

            _dest = normalized;
            _destElement.Value = normalized;
            _editVersion++;
            IsLowConfidence = false;
            IsFailed = false;
            IsTranslatedByAi = false;
            IsFromCache = false;
            Confidence = null;
            Notes = string.Empty;
            OnPropertyChanged();
            RaiseDerivedState();
        }
    }

    public bool IsTranslating
    {
        get => _isTranslating;
        set { _isTranslating = value; OnPropertyChanged(); OnPropertyChanged(nameof(StatusLabel)); }
    }

    public bool IsLowConfidence
    {
        get => _isLowConfidence;
        set { _isLowConfidence = value; OnPropertyChanged(); OnPropertyChanged(nameof(StatusLabel)); }
    }

    public bool IsFailed
    {
        get => _isFailed;
        set { _isFailed = value; OnPropertyChanged(); OnPropertyChanged(nameof(StatusLabel)); }
    }

    public bool IsTranslatedByAi
    {
        get => _isTranslatedByAi;
        set { _isTranslatedByAi = value; OnPropertyChanged(); OnPropertyChanged(nameof(StatusLabel)); }
    }

    public bool IsFromCache
    {
        get => _isFromCache;
        set { _isFromCache = value; OnPropertyChanged(); OnPropertyChanged(nameof(StatusLabel)); }
    }

    public double? Confidence
    {
        get => _confidence;
        set { _confidence = value; OnPropertyChanged(); OnPropertyChanged(nameof(ConfidenceLabel)); }
    }

    public string Notes
    {
        get => _notes;
        set { _notes = value; OnPropertyChanged(); }
    }

    public int EditVersion => _editVersion;
    public bool NeedsTranslation => string.IsNullOrWhiteSpace(Dest) || string.Equals(Source, Dest, StringComparison.Ordinal);
    public bool IsModified => !string.Equals(Source, Dest, StringComparison.Ordinal);
    public string StatusLabel =>
        IsTranslating ? "Translating" :
        IsFailed ? "Failed" :
        IsLowConfidence ? "Review" :
        IsFromCache ? "Cached" :
        IsTranslatedByAi ? "AI" :
        NeedsTranslation ? "Pending" :
        "Edited";
    public string ConfidenceLabel => Confidence.HasValue ? $"{Confidence:P0}" : string.Empty;
    public string AiWorkKey => $"{Record}\u001F{Source}";

    public bool TryApplyAiTranslation(string translation, double confidence, string? notes, bool fromCache, int expectedEditVersion, double minConfidence)
    {
        IsTranslating = false;
        if (EditVersion != expectedEditVersion && !NeedsTranslation)
            return false;

        Confidence = confidence;
        Notes = notes ?? string.Empty;

        if (confidence < minConfidence)
        {
            IsLowConfidence = true;
            IsFailed = false;
            IsTranslatedByAi = false;
            IsFromCache = false;
            OnPropertyChanged(nameof(StatusLabel));
            return false;
        }

        _dest = translation;
        _destElement.Value = translation;
        IsLowConfidence = false;
        IsFailed = false;
        IsTranslatedByAi = true;
        IsFromCache = fromCache;
        OnPropertyChanged(nameof(Dest));
        RaiseDerivedState();
        return true;
    }

    public void MarkFailed(string message)
    {
        IsTranslating = false;
        IsFailed = true;
        Notes = message;
        OnPropertyChanged(nameof(StatusLabel));
    }

    public void MarkQueued()
    {
        IsTranslating = true;
        IsFailed = false;
        Notes = string.Empty;
        OnPropertyChanged(nameof(StatusLabel));
    }

    public void ResetToSource() => Dest = Source;

    private static string NormalizeText(string? value) =>
        string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();

    private void RaiseDerivedState()
    {
        OnPropertyChanged(nameof(IsModified));
        OnPropertyChanged(nameof(NeedsTranslation));
        OnPropertyChanged(nameof(StatusLabel));
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
