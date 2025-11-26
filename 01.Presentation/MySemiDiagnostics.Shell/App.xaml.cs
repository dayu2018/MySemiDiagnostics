using System.Windows;
using Autofac;
using MySemiDiagnostics.Infra.IoC;
using MySemiDiagnostics.Infra.Data;

namespace MySemiDiagnostics.Shell;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IContainer? Container { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var bootstrapper = new Bootstrapper();
        Container = bootstrapper.Bootstrap();

        using (var scope = Container.BeginLifetimeScope())
        {
            var db = scope.Resolve<AppDbContext>();
            db.Database.EnsureCreated();
        }

        var mainWindow = new MainWindow();
        mainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Container?.Dispose();
        base.OnExit(e);
    }
}
