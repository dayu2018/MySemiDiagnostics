using CommunityToolkit.Mvvm.ComponentModel;

namespace MySemiDiagnostics.Domain.Core;

public abstract partial class BaseConfigEntity : ObservableObject
{
    [ObservableProperty] private int _id;
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _description = string.Empty;
}

public partial class SubsystemConfig : BaseConfigEntity
{
    public virtual ICollection<DeviceConfig> DeviceConfigs { get; set; } = new List<DeviceConfig>();
    [ObservableProperty] private bool _isEnabled;
}

public partial class DeviceConfig : BaseConfigEntity
{
    public int SubsystemConfigId { get; set; }
    public virtual SubsystemConfig? SubsystemConfig { get; set; }
    [ObservableProperty] private string _driverType = string.Empty;
}

public partial class AxisConfig : DeviceConfig
{
    [ObservableProperty] private double _maxSpeed;
    [ObservableProperty] private double _acceleration;
    [ObservableProperty] private double _pulsePerMm;
}

public partial class CameraConfig : DeviceConfig
{
    [ObservableProperty] private int _width;
    [ObservableProperty] private int _height;
    [ObservableProperty] private double _exposureTime;
}
