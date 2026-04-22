using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Win32;
using SpookysAutomod.TranslationStudio.Models;
using SpookysAutomod.TranslationStudio.Services;

namespace SpookysAutomod.TranslationStudio.ViewModels;

public sealed class TranslationStudioViewModel : INotifyPropertyChanged
{
    private readonly TranslationStudioService _service;
    private readonly ThemeService _themeService;
    private DictionaryReferenceService _dictionaryReferenceService;
    private TranslationDocumentSession? _session;
    private TranslationEntryItem? _selectedEntry;
    private string _searchText = string.Empty;
    private bool _showPendingOnly = true;
    private string _selectedStatusFilter = "All";
    private string _statusMessage = "Open an XML translation file to begin.";
    private string _currentFilePath = string.Empty;
    private bool _isBusy;
    private int _processedUnits;
    private int _totalUnits;
    private CancellationTokenSource? _translationCts;

    public TranslationStudioViewModel()
    {
        var app = (App)System.Windows.Application.Current;
        _themeService = app.ThemeService;
        _service = new TranslationStudioService(app.SettingsService);
        var aiSettings = _service.LoadAiSettings();
        _dictionaryReferenceService = new DictionaryReferenceService(
            aiSettings.DictionaryDirectory,
            aiSettings.MaxHintEnglishLength,
            aiSettings.MaxHintChineseLength);
        Entries = new ObservableCollection<TranslationEntryItem>();
        EntriesView = CollectionViewSource.GetDefaultView(Entries);
        EntriesView.Filter = FilterEntry;

        OpenFileCommand = new RelayCommand(async _ => await OpenFileAsync());
        SaveCommand = new RelayCommand(_ => Save(), _ => CanSave);
        SaveAsCommand = new RelayCommand(_ => SaveAs(), _ => _session != null);
        TranslateSelectedCommand = new RelayCommand(async _ => await TranslateSelectionAsync(), _ => SelectedEntry != null && !IsBusy);
        TranslateAllCommand = new RelayCommand(async _ => await TranslateAllAsync(), _ => _session != null && !IsBusy && Entries.Any(entry => entry.NeedsTranslation));
        StopTranslationCommand = new RelayCommand(_ => StopTranslation(), _ => IsBusy);
        ResetSelectedCommand = new RelayCommand(_ => SelectedEntry?.ResetToSource(), _ => SelectedEntry != null && !IsBusy);
        OpenSettingsCommand = new RelayCommand(_ => OpenSettings());
        _themeService.ThemeChanged += ThemeServiceOnThemeChanged;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<TranslationEntryItem> Entries { get; }
    public ICollectionView EntriesView { get; }

    public TranslationEntryItem? SelectedEntry
    {
        get => _selectedEntry;
        set
        {
            _selectedEntry = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedEntryHints));
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public string SearchText
    {
        get => _searchText;
        set { _searchText = value ?? string.Empty; OnPropertyChanged(); EntriesView.Refresh(); }
    }

    public bool ShowPendingOnly
    {
        get => _showPendingOnly;
        set { _showPendingOnly = value; OnPropertyChanged(); EntriesView.Refresh(); }
    }

    public IReadOnlyList<string> StatusFilters { get; } = new[]
    {
        "All",
        "Pending",
        "AI",
        "Cached",
        "Review",
        "Failed",
        "Edited"
    };

    public string SelectedStatusFilter
    {
        get => _selectedStatusFilter;
        set
        {
            if (_selectedStatusFilter == value)
                return;

            _selectedStatusFilter = value;
            OnPropertyChanged();
            EntriesView.Refresh();
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set { _statusMessage = value; OnPropertyChanged(); }
    }

    public string CurrentFilePath
    {
        get => _currentFilePath;
        set { _currentFilePath = value; OnPropertyChanged(); }
    }

    public bool IsBusy
    {
        get => _isBusy;
        set { _isBusy = value; OnPropertyChanged(); OnPropertyChanged(nameof(ProgressLabel)); CommandManager.InvalidateRequerySuggested(); }
    }

    public int TotalCount => Entries.Count;
    public int PendingCount => Entries.Count(entry => entry.NeedsTranslation);
    public int AiCount => Entries.Count(entry => entry.IsTranslatedByAi);
    public int CachedCount => Entries.Count(entry => entry.IsFromCache);
    public int ReviewCount => Entries.Count(entry => entry.IsLowConfidence || entry.IsFailed);
    public int FailedCount => Entries.Count(entry => entry.IsFailed);
    public int EditedCount => Entries.Count(entry => entry.IsModified && !entry.IsTranslatedByAi && !entry.IsFromCache && !entry.NeedsTranslation);
    public string ProgressLabel => IsBusy ? $"Translating {_processedUnits}/{_totalUnits} deduplicated work items..." : "Idle";
    public string ConfigDirectory => _service.ConfigDirectory;
    public string ConfigFilePath => _service.ConfigFilePath;
    public bool CanSave => _session != null && !string.IsNullOrWhiteSpace(CurrentFilePath);
    public IReadOnlyList<ThemeModeOption> ThemeModes { get; } = new[]
    {
        new ThemeModeOption(ThemeMode.FollowSystem, "Follow System"),
        new ThemeModeOption(ThemeMode.Light, "Light"),
        new ThemeModeOption(ThemeMode.Dark, "Dark")
    };

    public ThemeModeOption SelectedThemeMode
    {
        get => ThemeModes.First(option => option.Mode == _themeService.ThemeMode);
        set
        {
            if (value.Mode == _themeService.ThemeMode)
                return;

            _themeService.SetThemeMode(value.Mode);
            OnPropertyChanged();
            OnPropertyChanged(nameof(ResolvedThemeLabel));
        }
    }

    public string ResolvedThemeLabel => _themeService.ResolvedTheme switch
    {
        ResolvedTheme.Light => "Light",
        _ => "Dark"
    };

    public IReadOnlyList<DictionaryHint> SelectedEntryHints =>
        SelectedEntry is null || _service.LoadAiSettings().DictionaryHintLimit == 0
            ? Array.Empty<DictionaryHint>()
            : _dictionaryReferenceService.FindHints(SelectedEntry.Record, SelectedEntry.Source, _service.LoadAiSettings().DictionaryHintLimit);

    public ICommand OpenFileCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand SaveAsCommand { get; }
    public ICommand TranslateSelectedCommand { get; }
    public ICommand TranslateAllCommand { get; }
    public ICommand StopTranslationCommand { get; }
    public ICommand ResetSelectedCommand { get; }
    public ICommand OpenSettingsCommand { get; }

    private async Task OpenFileAsync()
    {
        var dialog = new OpenFileDialog
        {
            Title = "Open Translation XML",
            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog() != true)
            return;

        await LoadSessionAsync(dialog.FileName);
    }

    private async Task LoadSessionAsync(string filePath)
    {
        try
        {
            var session = await Task.Run(() => _service.LoadSession(filePath));
            _session = session;
            var cacheApplied = 0;
            var cacheReview = 0;
            var settings = _service.LoadAiSettings();
            var cacheFile = _service.ResolveCacheFile(session, settings);
            var cache = _service.LoadCache(cacheFile, _service.BuildContextKey(settings));

            Entries.Clear();
            foreach (var entry in session.Entries)
            {
                entry.PropertyChanged += EntryOnPropertyChanged;

                if (entry.NeedsTranslation && cache.Entries.TryGetValue(entry.AiWorkKey, out var cached))
                {
                    if (cached.Confidence >= settings.MinConfidence && !string.IsNullOrWhiteSpace(cached.Translation))
                    {
                        entry.TryApplyAiTranslation(
                            cached.Translation,
                            cached.Confidence,
                            cached.Notes,
                            fromCache: true,
                            expectedEditVersion: entry.EditVersion,
                            minConfidence: settings.MinConfidence);
                        cacheApplied++;
                    }
                    else if (!string.IsNullOrWhiteSpace(cached.Translation))
                    {
                        entry.Confidence = cached.Confidence;
                        entry.Notes = cached.Notes;
                        entry.IsLowConfidence = true;
                        cacheReview++;
                    }
                }

                Entries.Add(entry);
            }

            CurrentFilePath = session.FilePath;
            SelectedEntry = Entries.FirstOrDefault();
            RefreshCounts();
            StatusMessage = cacheApplied > 0 || cacheReview > 0
                ? $"Loaded {Entries.Count} translation entries. Applied {cacheApplied} cached translations, {cacheReview} cached review items."
                : $"Loaded {Entries.Count} translation entries.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to open file: {ex.Message}";
        }
    }

    private void Save()
    {
        if (_session is null)
            return;

        _service.SaveSession(_session);
        StatusMessage = $"Saved {CurrentFilePath}";
    }

    private void SaveAs()
    {
        if (_session is null)
            return;

        var dialog = new SaveFileDialog
        {
            Title = "Save Translation XML",
            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
            FileName = Path.GetFileName(CurrentFilePath)
        };

        if (dialog.ShowDialog() != true)
            return;

        _service.SaveSession(_session, dialog.FileName);
        CurrentFilePath = _session.FilePath;
        StatusMessage = $"Saved {CurrentFilePath}";
    }

    private async Task TranslateSelectionAsync()
    {
        if (SelectedEntry is null)
            return;

        await RunTranslationAsync(new[] { SelectedEntry });
    }

    private async Task TranslateAllAsync() => await RunTranslationAsync(Entries.Where(entry => entry.NeedsTranslation));

    private async Task RunTranslationAsync(IEnumerable<TranslationEntryItem> sourceEntries)
    {
        if (_session is null)
            return;

        var settings = _service.LoadAiSettings();
        var cacheFile = _service.ResolveCacheFile(_session, settings);
        var cache = _service.LoadCache(cacheFile, _service.BuildContextKey(settings));

        var targetEntries = sourceEntries.Where(entry => entry.NeedsTranslation).Distinct().ToList();
        var workItems = targetEntries
            .GroupBy(entry => entry.AiWorkKey, StringComparer.Ordinal)
            .Select(group => new TranslationWorkItem
            {
                CacheKey = group.Key,
                Record = group.First().Record,
                Source = group.First().Source,
                Targets = group.Select(entry => new TranslationTarget(entry, entry.EditVersion)).ToList()
            })
            .ToList();

        if (workItems.Count == 0)
        {
            StatusMessage = "Nothing pending for translation.";
            return;
        }

        _translationCts = new CancellationTokenSource();
        _processedUnits = 0;
        _totalUnits = workItems.Count;
        IsBusy = true;
        StatusMessage = $"Queued {workItems.Count} deduplicated translation work items.";

        try
        {
            foreach (var item in workItems)
            {
                if (cache.Entries.TryGetValue(item.CacheKey, out var cached))
                {
                    ApplyTranslationToTargets(item.Targets, cached.Translation, cached.Confidence, cached.Notes, true, settings.MinConfidence);
                    _processedUnits++;
                    OnPropertyChanged(nameof(ProgressLabel));
                    continue;
                }

                foreach (var target in item.Targets)
                    target.Entry.MarkQueued();
            }

            var uncachedItems = workItems.Where(item => !cache.Entries.ContainsKey(item.CacheKey)).ToList();
            foreach (var batch in Chunk(uncachedItems, Math.Max(1, settings.BatchSize)))
            {
                _translationCts.Token.ThrowIfCancellationRequested();

                var requestItems = batch.Select((item, index) => new TranslationBatchRequestItem
                {
                    Id = $"batch-{_processedUnits:D5}-{index:D3}",
                    Edid = item.Targets[0].Entry.Edid,
                    Record = item.Record,
                    Source = item.Source
                }).ToList();

                var requestMap = batch.Zip(requestItems, (work, request) => new { work, request })
                    .ToDictionary(pair => pair.request.Id, pair => pair.work, StringComparer.Ordinal);

                Dictionary<string, AiTranslationBatchItem> results;
                try
                {
                    results = await _service.TranslateBatchAsync(requestItems, settings, _translationCts.Token);
                }
                catch (Exception ex)
                {
                    foreach (var item in batch)
                        foreach (var target in item.Targets)
                            target.Entry.MarkFailed(ex.Message);

                    StatusMessage = $"Translation batch failed: {ex.Message}";
                    break;
                }

                foreach (var request in requestItems)
                {
                    var workItem = requestMap[request.Id];
                    if (!results.TryGetValue(request.Id, out var result) || string.IsNullOrWhiteSpace(result.Translation))
                    {
                        foreach (var target in workItem.Targets)
                            target.Entry.MarkFailed("Model did not return a translation for this item.");
                    }
                    else
                    {
                        cache.Entries[workItem.CacheKey] = new TranslationCacheItem
                        {
                            Translation = result.Translation,
                            Confidence = result.Confidence,
                            Notes = result.Notes ?? string.Empty,
                            CachedAtUtc = DateTimeOffset.UtcNow
                        };

                        ApplyTranslationToTargets(workItem.Targets, result.Translation, result.Confidence, result.Notes, false, settings.MinConfidence);
                    }

                    _processedUnits++;
                    OnPropertyChanged(nameof(ProgressLabel));
                }

                _service.SaveCache(cacheFile, cache);
                RefreshCounts();
            }

            StatusMessage = _translationCts.IsCancellationRequested
                ? "Translation stopped."
                : $"Translation pass finished. Pending: {PendingCount}, Review: {ReviewCount}.";
        }
        catch (OperationCanceledException)
        {
            StatusMessage = "Translation stopped.";
        }
        finally
        {
            IsBusy = false;
            _translationCts?.Dispose();
            _translationCts = null;
            RefreshCounts();
        }
    }

    private void StopTranslation() => _translationCts?.Cancel();

    private void OpenSettings()
    {
        var window = new Views.SettingsWindow(((App)Application.Current).SettingsService, _themeService)
        {
            Owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(window => window.IsActive)
        };

        window.ShowDialog();
        var aiSettings = _service.LoadAiSettings();
        _dictionaryReferenceService = new DictionaryReferenceService(
            aiSettings.DictionaryDirectory,
            aiSettings.MaxHintEnglishLength,
            aiSettings.MaxHintChineseLength);
        OnPropertyChanged(nameof(SelectedThemeMode));
        OnPropertyChanged(nameof(ResolvedThemeLabel));
        OnPropertyChanged(nameof(SelectedEntryHints));
        StatusMessage = "Settings updated.";
    }

    private void ApplyTranslationToTargets(
        IReadOnlyList<TranslationTarget> targets,
        string translation,
        double confidence,
        string? notes,
        bool fromCache,
        double minConfidence)
    {
        foreach (var target in targets)
            target.Entry.TryApplyAiTranslation(translation, confidence, notes, fromCache, target.EditVersion, minConfidence);
    }

    private bool FilterEntry(object item)
    {
        if (item is not TranslationEntryItem entry)
            return false;

        if (!MatchesStatusFilter(entry))
            return false;

        if (SelectedStatusFilter == "All" && ShowPendingOnly && !entry.NeedsTranslation)
            return false;

        if (string.IsNullOrWhiteSpace(SearchText))
            return true;

        return entry.Edid.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
               || entry.Record.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
               || entry.Source.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
               || entry.Dest.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
    }

    private bool MatchesStatusFilter(TranslationEntryItem entry)
    {
        return SelectedStatusFilter switch
        {
            "Pending" => entry.NeedsTranslation,
            "AI" => entry.IsTranslatedByAi,
            "Cached" => entry.IsFromCache,
            "Review" => entry.IsLowConfidence,
            "Failed" => entry.IsFailed,
            "Edited" => entry.IsModified && !entry.IsTranslatedByAi && !entry.IsFromCache && !entry.NeedsTranslation,
            _ => true
        };
    }

    private void EntryOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(TranslationEntryItem.Dest) or nameof(TranslationEntryItem.IsFailed) or nameof(TranslationEntryItem.IsLowConfidence))
        {
            RefreshCounts();
            EntriesView.Refresh();
        }
    }

    private void RefreshCounts()
    {
        OnPropertyChanged(nameof(TotalCount));
        OnPropertyChanged(nameof(PendingCount));
        OnPropertyChanged(nameof(AiCount));
        OnPropertyChanged(nameof(CachedCount));
        OnPropertyChanged(nameof(ReviewCount));
        OnPropertyChanged(nameof(FailedCount));
        OnPropertyChanged(nameof(EditedCount));
        OnPropertyChanged(nameof(CanSave));
    }

    private static IEnumerable<List<T>> Chunk<T>(IReadOnlyList<T> items, int batchSize)
    {
        for (var index = 0; index < items.Count; index += batchSize)
            yield return items.Skip(index).Take(batchSize).ToList();
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private void ThemeServiceOnThemeChanged(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(SelectedThemeMode));
        OnPropertyChanged(nameof(ResolvedThemeLabel));
    }

    private sealed class TranslationWorkItem
    {
        public string CacheKey { get; init; } = string.Empty;
        public string Record { get; init; } = string.Empty;
        public string Source { get; init; } = string.Empty;
        public List<TranslationTarget> Targets { get; init; } = new();
    }

    private sealed class TranslationTarget
    {
        public TranslationTarget(TranslationEntryItem entry, int editVersion)
        {
            Entry = entry;
            EditVersion = editVersion;
        }

        public TranslationEntryItem Entry { get; }
        public int EditVersion { get; }
    }
}

public sealed record ThemeModeOption(ThemeMode Mode, string Label);
