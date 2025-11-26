using System.Windows;

namespace MySemiDiagnostics.Shell;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void Settings_Click(object sender, RoutedEventArgs e)
    {
        // Settings dialog placeholder
        MessageBox.Show("参数配置功能待实现", "设置", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}