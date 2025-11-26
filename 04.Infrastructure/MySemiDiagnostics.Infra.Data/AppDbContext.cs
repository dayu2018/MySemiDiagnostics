using Microsoft.EntityFrameworkCore;
using MySemiDiagnostics.Domain.Core;

namespace MySemiDiagnostics.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<SubsystemConfig> Subsystems { get; set; }
    public DbSet<DeviceConfig> Devices { get; set; }
    public DbSet<AxisConfig> AxisConfigs { get; set; }
    public DbSet<CameraConfig> CameraConfigs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubsystemConfig>()
            .HasMany(s => s.DeviceConfigs)
            .WithOne(d => d.SubsystemConfig)
            .HasForeignKey(d => d.SubsystemConfigId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubsystemConfig>().HasData(
            new SubsystemConfig { Id = 1, Name = "MotionSystem", Description = "运动控制子系统", IsEnabled = true },
            new SubsystemConfig { Id = 2, Name = "VisionSystem", Description = "视觉检测子系统", IsEnabled = true }
        );

        modelBuilder.Entity<AxisConfig>().HasData(
            new AxisConfig { Id = 1, SubsystemConfigId = 1, Name = "X-Axis", Description = "X轴", MaxSpeed = 500, Acceleration = 1000, PulsePerMm = 1000, DriverType = "ACS" },
            new AxisConfig { Id = 2, SubsystemConfigId = 1, Name = "Y-Axis", Description = "Y轴", MaxSpeed = 500, Acceleration = 1000, PulsePerMm = 1000, DriverType = "ACS" },
            new AxisConfig { Id = 3, SubsystemConfigId = 1, Name = "Z-Axis", Description = "Z轴", MaxSpeed = 200, Acceleration = 500, PulsePerMm = 2000, DriverType = "ACS" }
        );

        modelBuilder.Entity<CameraConfig>().HasData(
            new CameraConfig { Id = 4, SubsystemConfigId = 2, Name = "TopCamera", Description = "顶部相机", Width = 2048, Height = 2048, ExposureTime = 10.0, DriverType = "Basler" }
        );
    }
}
