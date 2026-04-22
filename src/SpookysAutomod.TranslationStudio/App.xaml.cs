using System.Windows;
using SpookysAutomod.TranslationStudio.Services;
using SpookysAutomod.TranslationStudio.Views;

namespace SpookysAutomod.TranslationStudio;

public partial class App : Application
{
    public TranslationStudioSettingsService SettingsService { get; private set; } = null!;
    public ThemeService ThemeService { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        SettingsService = new TranslationStudioSettingsService();
        ThemeService = new ThemeService(SettingsService);
        ThemeService.ApplyCurrentTheme();

        var window = new TranslationStudioWindow();
        MainWindow = window;
        window.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        ThemeService?.Dispose();
        base.OnExit(e);
    }
}
