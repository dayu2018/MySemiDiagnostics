using MySemiDiagnostics.Domain.Core;

namespace MySemiDiagnostics.Interfaces;

/// <summary>
/// Repository interface for managing configuration data
/// </summary>
public interface IConfigRepository
{
    Task<List<SubsystemConfig>> LoadAllConfigurationsAsync();
    Task SaveConfigurationAsync(SubsystemConfig config);
    Task<T?> GetDeviceConfigAsync<T>(int id) where T : DeviceConfig;
}
