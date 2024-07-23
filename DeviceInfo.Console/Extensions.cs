using System.Text;
using Hardware.Info;

namespace DeviceInfo.Console;

public class DeviceList<T>
{
    public void ToString(T device)
    {
    }
}

public static class Extensions
{
    public static void AppendCollection<T>(this StringBuilder stringBuilder, IEnumerable<T> devices, string? title = "Generic Device")
    {
        stringBuilder.Append($"==== {title} ====");
        foreach (var device in devices)
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(device);
        }
        stringBuilder.Append(Environment.NewLine);
    }

    public static void AppendCollection(this StringBuilder stringbuilder, List<CPU> hardwareInfoCpuList)
    {
        throw new NotImplementedException();
    }
}