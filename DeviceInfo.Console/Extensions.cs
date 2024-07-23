using System.Text;
using Hardware.Info;

namespace DeviceInfo.Console;

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

}