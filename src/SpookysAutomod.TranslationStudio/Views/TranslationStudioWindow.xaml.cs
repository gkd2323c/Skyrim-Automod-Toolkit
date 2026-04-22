using System.Windows;
using SpookysAutomod.TranslationStudio.ViewModels;

namespace SpookysAutomod.TranslationStudio.Views;

public partial class TranslationStudioWindow : Window
{
    public TranslationStudioWindow()
    {
        InitializeComponent();
        DataContext = new TranslationStudioViewModel();
    }
}
