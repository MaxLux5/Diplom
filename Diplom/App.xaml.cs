using System.Windows;
using Diplom.Services;
using Diplom.View.Windows;
using Diplom.ViewModel.Windows;

namespace Diplom;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow mainWindow = new MainWindow();
        mainWindow.DataContext = new MainWindowViewModel(DialogService.GetInstance());
        mainWindow.Show();
    }
}