using Microsoft.EntityFrameworkCore;
using MySemiDiagnostics.Domain.Core;

namespace MySemiDiagnostics.Infra.Data;

public interface IConfigRepository
{
    Task<List<SubsystemConfig>> LoadAllConfigurationsAsync();
    Task SaveConfigurationAsync(SubsystemConfig config);
    Task<T?> GetDeviceConfigAsync<T>(int id) where T : DeviceConfig;
}

public class ConfigRepository : IConfigRepository
{
    private readonly AppDbContext _context;

    public ConfigRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubsystemConfig>> LoadAllConfigurationsAsync()
    {
        return await _context.Subsystems
            .Include(s => s.DeviceConfigs)
            .ToListAsync();
    }

    public async Task SaveConfigurationAsync(SubsystemConfig config)
    {
        _context.Subsystems.Update(config);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetDeviceConfigAsync<T>(int id) where T : DeviceConfig
    {
        return await _context.Set<T>().FindAsync(id);
    }
}
