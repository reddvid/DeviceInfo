using DeviceInfo.Models;
using Hardware.Info;

namespace DeviceInfo;

public class DeviceInfo
{
    private static readonly HardwareInfo HardwareInfo = new();

    public DeviceInfo()
    {
        HardwareInfo.RefreshAll();
    }
    
    public IEnumerable<Cpu> GetCpu()
    {
        var cpus = new List<Cpu>();
        
        foreach (var cpu in HardwareInfo.CpuList)
        {
        }

        return new Cpu[]
        {
        };
    }
}