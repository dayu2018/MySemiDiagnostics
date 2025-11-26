using Autofac;
using Microsoft.EntityFrameworkCore;
using MySemiDiagnostics.Infra.Data;

namespace MySemiDiagnostics.Infra.IoC;

public class Bootstrapper
{
    public IContainer Bootstrap()
    {
        var builder = new ContainerBuilder();

        var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "diagnostics.db");
        builder.Register(c =>
        {
            var opt = new DbContextOptionsBuilder<AppDbContext>();
            opt.UseSqlite($"Data Source={dbPath}");
            return new AppDbContext(opt.Options);
        }).AsSelf().InstancePerLifetimeScope();

        builder.RegisterType<ConfigRepository>().As<IConfigRepository>().InstancePerLifetimeScope();

        return builder.Build();
    }
}
