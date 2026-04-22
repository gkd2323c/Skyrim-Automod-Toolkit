using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using SpookysAutomod.TranslationStudio.Services;

namespace SpookysAutomod.TranslationStudio.ViewModels;

public sealed class TranslationStudioSettingsViewModel : INotifyPropertyChanged
{
    private readonly TranslationStudioSettingsService _settingsService;
    private readonly ThemeService _themeService;
    private string _endpoint = string.Empty;
    private string _apiKey = string.Empty;
    private string _model = string.Empty;
    private string _dictionaryDirectory = string.Empty;
    private string _cacheFile = string.Empty;
    private string _reportFile = string.Empty;
    private int _batchSize;
    private int _dictionaryHintLimit;
    private int _maxHintEnglishLength;
    private int _maxHintChineseLength;
    private double _minConfidence;
    private int _maxOutputTokens;
    private string _systemPrompt = string.Empty;
    private string _userPromptPreamble = string.Empty;
    private ThemeModeOption _selectedThemeMode = null!;

    public TranslationStudioSettingsViewModel(TranslationStudioSettingsService settingsService, ThemeService themeService)
    {
        _settingsService = settingsService;
        _themeService = themeService;
        ThemeModes = new[]
        {
            new ThemeModeOption(ThemeMode.FollowSystem, "Follow System"),
            new ThemeModeOption(ThemeMode.Light, "Light"),
            new ThemeModeOption(ThemeMode.Dark, "Dark")
        };

        var settings = settingsService.Load();
        var ai = settingsService.WithDefaults(settings.AiTranslation);
        DictionaryDirectory = ai.DictionaryDirectory;
        Endpoint = ai.Endpoint;
        ApiKey = ai.ApiKey;
        Model = ai.Model;
        CacheFile = ai.CacheFile;
        ReportFile = ai.ReportFile;
        BatchSize = ai.BatchSize <= 0 ? 20 : ai.BatchSize;
        DictionaryHintLimit = ai.DictionaryHintLimit <= 0 ? 2 : ai.DictionaryHintLimit;
        MaxHintEnglishLength = ai.MaxHintEnglishLength <= 0 ? 48 : ai.MaxHintEnglishLength;
        MaxHintChineseLength = ai.MaxHintChineseLength <= 0 ? 24 : ai.MaxHintChineseLength;
        MinConfidence = ai.MinConfidence <= 0 ? 0.75 : ai.MinConfidence;
        MaxOutputTokens = ai.MaxOutputTokens <= 0 ? 4000 : ai.MaxOutputTokens;
        SystemPrompt = ai.SystemPrompt;
        UserPromptPreamble = ai.UserPromptPreamble;
        SelectedThemeMode = ThemeModes.First(option => option.Mode == themeService.ThemeMode);

        SaveCommand = new RelayCommand(window => Save(window as Window), _ => CanSave);
        CancelCommand = new RelayCommand(window => (window as Window)?.Close());
        BrowseDictionaryDirectoryCommand = new RelayCommand(_ => BrowseDictionaryDirectory());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public IReadOnlyList<ThemeModeOption> ThemeModes { get; }

    public string Endpoint
    {
        get => _endpoint;
        set { _endpoint = value ?? string.Empty; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public string ApiKey
    {
        get => _apiKey;
        set { _apiKey = value ?? string.Empty; OnPropertyChanged(); }
    }

    public string Model
    {
        get => _model;
        set { _model = value ?? string.Empty; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public string DictionaryDirectory
    {
        get => _dictionaryDirectory;
        set { _dictionaryDirectory = value ?? string.Empty; OnPropertyChanged(); }
    }

    public string CacheFile
    {
        get => _cacheFile;
        set { _cacheFile = value ?? string.Empty; OnPropertyChanged(); }
    }

    public string ReportFile
    {
        get => _reportFile;
        set { _reportFile = value ?? string.Empty; OnPropertyChanged(); }
    }

    public int BatchSize
    {
        get => _batchSize;
        set { _batchSize = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public int DictionaryHintLimit
    {
        get => _dictionaryHintLimit;
        set { _dictionaryHintLimit = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public int MaxHintEnglishLength
    {
        get => _maxHintEnglishLength;
        set { _maxHintEnglishLength = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public int MaxHintChineseLength
    {
        get => _maxHintChineseLength;
        set { _maxHintChineseLength = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public double MinConfidence
    {
        get => _minConfidence;
        set { _minConfidence = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public int MaxOutputTokens
    {
        get => _maxOutputTokens;
        set { _maxOutputTokens = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanSave)); }
    }

    public string SystemPrompt
    {
        get => _systemPrompt;
        set { _systemPrompt = value ?? string.Empty; OnPropertyChanged(); }
    }

    public string UserPromptPreamble
    {
        get => _userPromptPreamble;
        set { _userPromptPreamble = value ?? string.Empty; OnPropertyChanged(); }
    }

    public ThemeModeOption SelectedThemeMode
    {
        get => _selectedThemeMode;
        set { _selectedThemeMode = value; OnPropertyChanged(); }
    }

    public string ConfigFilePath => _settingsService.ConfigFilePath;

    public bool CanSave =>
        !string.IsNullOrWhiteSpace(Endpoint)
        && !string.IsNullOrWhiteSpace(Model)
        && BatchSize > 0
        && DictionaryHintLimit >= 0
        && MaxHintEnglishLength > 0
        && MaxHintChineseLength > 0
        && MinConfidence >= 0
        && MinConfidence <= 1
        && MaxOutputTokens > 0;

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand BrowseDictionaryDirectoryCommand { get; }

    private void Save(Window? window)
    {
        var settings = new StudioSettings
        {
            AiTranslation = new StudioAiTranslationSettings
            {
                DictionaryDirectory = DictionaryDirectory,
                Endpoint = Endpoint,
                ApiKey = ApiKey,
                Model = Model,
                CacheFile = CacheFile,
                ReportFile = ReportFile,
                BatchSize = BatchSize,
                DictionaryHintLimit = DictionaryHintLimit,
                MaxHintEnglishLength = MaxHintEnglishLength,
                MaxHintChineseLength = MaxHintChineseLength,
                MinConfidence = MinConfidence,
                MaxOutputTokens = MaxOutputTokens,
                SystemPrompt = SystemPrompt,
                UserPromptPreamble = UserPromptPreamble
            },
            TranslationStudio = new StudioUiSettings
            {
                ThemeMode = SelectedThemeMode.Mode switch
                {
                    ThemeMode.Light => "light",
                    ThemeMode.Dark => "dark",
                    _ => "system"
                }
            }
        };

        _settingsService.SaveSettings(settings);
        _themeService.SetThemeMode(SelectedThemeMode.Mode);
        window?.Close();
    }

    private void BrowseDictionaryDirectory()
    {
        var dialog = new OpenFolderDialog
        {
            Title = "Select Dictionary Directory"
        };

        if (dialog.ShowDialog() != true)
            return;

        if (IsValidDictionaryDirectory(dialog.FolderName))
        {
            DictionaryDirectory = dialog.FolderName;
            return;
        }

        MessageBox.Show(
            "The selected folder does not contain a valid dictionary export.\n\nExpected one of:\n- manifest.json\n- entries/*.jsonl\n- records/*.jsonl",
            "Invalid Dictionary Directory",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
    }

    private static bool IsValidDictionaryDirectory(string folderPath)
    {
        if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            return false;

        if (File.Exists(Path.Combine(folderPath, "manifest.json")))
            return true;

        var entriesDirectory = Path.Combine(folderPath, "entries");
        if (Directory.Exists(entriesDirectory) &&
            Directory.EnumerateFiles(entriesDirectory, "*.jsonl", SearchOption.TopDirectoryOnly).Any())
            return true;

        var recordsDirectory = Path.Combine(folderPath, "records");
        return Directory.Exists(recordsDirectory) &&
               Directory.EnumerateFiles(recordsDirectory, "*.jsonl", SearchOption.TopDirectoryOnly).Any();
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
