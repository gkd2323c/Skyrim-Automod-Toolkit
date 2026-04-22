using System.Windows;
using SpookysAutomod.TranslationStudio.Services;
using SpookysAutomod.TranslationStudio.ViewModels;

namespace SpookysAutomod.TranslationStudio.Views;

public partial class SettingsWindow : Window
{
    public SettingsWindow(TranslationStudioSettingsService settingsService, ThemeService themeService)
    {
        InitializeComponent();
        DataContext = new TranslationStudioSettingsViewModel(settingsService, themeService);
    }
}
