using System.Windows;
using Microsoft.Win32;

namespace SpookysAutomod.TranslationStudio.Services;

public enum ThemeMode
{
    FollowSystem,
    Light,
    Dark
}

public enum ResolvedTheme
{
    Light,
    Dark
}

public sealed class ThemeService : IDisposable
{
    private const string PersonalizeRegistryKey = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
    private const string AppsUseLightThemeValue = "AppsUseLightTheme";

    private readonly TranslationStudioSettingsService _settingsService;
    private bool _disposed;

    public ThemeService(TranslationStudioSettingsService settingsService)
    {
        _settingsService = settingsService;
        ThemeMode = settingsService.LoadThemeMode();
        ResolvedTheme = ResolveTheme(ThemeMode);
        SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
    }

    public event EventHandler? ThemeChanged;

    public ThemeMode ThemeMode { get; private set; }

    public ResolvedTheme ResolvedTheme { get; private set; }

    public void ApplyCurrentTheme()
    {
        ApplyTheme(ResolveTheme(ThemeMode));
    }

    public void SetThemeMode(ThemeMode mode)
    {
        ThemeMode = mode;
        _settingsService.SaveThemeMode(mode);
        ApplyTheme(ResolveTheme(mode));
    }

    public void RefreshFromSystemIfNeeded()
    {
        if (ThemeMode != ThemeMode.FollowSystem)
            return;

        ApplyTheme(ResolveTheme(ThemeMode.FollowSystem));
    }

    private void OnUserPreferenceChanged(object? sender, UserPreferenceChangedEventArgs e)
    {
        if (ThemeMode != ThemeMode.FollowSystem)
            return;

        if (e.Category is UserPreferenceCategory.General or UserPreferenceCategory.Color)
            ApplyTheme(ResolveTheme(ThemeMode.FollowSystem));
    }

    private void ApplyTheme(ResolvedTheme theme)
    {
        ResolvedTheme = theme;

        var app = Application.Current;
        if (app is null)
            return;

        var dictionaries = app.Resources.MergedDictionaries;
        if (dictionaries.Count == 0)
            dictionaries.Add(new ResourceDictionary());

        var source = theme switch
        {
            ResolvedTheme.Light => new Uri("/Themes/LightTheme.xaml", UriKind.Relative),
            _ => new Uri("/Themes/DarkTheme.xaml", UriKind.Relative)
        };

        dictionaries[0] = new ResourceDictionary { Source = source };
        ThemeChanged?.Invoke(this, EventArgs.Empty);
    }

    private static ResolvedTheme ResolveTheme(ThemeMode mode)
    {
        return mode switch
        {
            ThemeMode.Light => ResolvedTheme.Light,
            ThemeMode.Dark => ResolvedTheme.Dark,
            _ => IsSystemLightTheme() ? ResolvedTheme.Light : ResolvedTheme.Dark
        };
    }

    private static bool IsSystemLightTheme()
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(PersonalizeRegistryKey, false);
            var value = key?.GetValue(AppsUseLightThemeValue);
            return value is int intValue ? intValue != 0 : true;
        }
        catch
        {
            return true;
        }
    }

    public void Dispose()
    {
        if (_disposed)
            return;

        _disposed = true;
        SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
    }
}
