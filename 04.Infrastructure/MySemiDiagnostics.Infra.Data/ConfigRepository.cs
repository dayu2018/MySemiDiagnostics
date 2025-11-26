using Microsoft.EntityFrameworkCore;
using MySemiDiagnostics.Domain.Core;
using MySemiDiagnostics.Interfaces;

namespace MySemiDiagnostics.Infra.Data;

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
        var exists = await _context.Subsystems.AnyAsync(s => s.Id == config.Id);
        if (exists)
        {
            _context.Subsystems.Update(config);
        }
        else
        {
            _context.Subsystems.Add(config);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<T?> GetDeviceConfigAsync<T>(int id) where T : DeviceConfig
    {
        return await _context.Set<T>().FindAsync(id);
    }
}
