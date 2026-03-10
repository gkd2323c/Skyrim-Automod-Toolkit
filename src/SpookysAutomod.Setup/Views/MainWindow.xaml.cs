using System.Windows;
using SpookysAutomod.Setup.ViewModels;

namespace SpookysAutomod.Setup.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new SetupViewModel();
    }
}
