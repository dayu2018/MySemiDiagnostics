using MySemiDiagnostics.Interfaces;

namespace MySemiDiagnostics.Modules.Motion;

/// <summary>
/// Motion control module service implementation
/// </summary>
public class MotionModuleService : IModuleService
{
    public string ModuleName => "MotionSystem";

    public Task InitializeAsync()
    {
        // Motion module initialization logic
        return Task.CompletedTask;
    }
}
