using System.Text;
using DeviceInfo.Console;
using Hardware.Info;

string? userName;
HardwareInfo hardwareInfo = new();
hardwareInfo.RefreshAll();

StringBuilder stringBuilder = new();

if (args.Length != 0)
{
    // Split
    userName = args.FirstOrDefault();
    stringBuilder.Append(userName);
    stringBuilder.Append(Environment.NewLine);
}

// Get Devices

// CPU
stringBuilder.AppendCollection(hardwareInfo.CpuList, "CPU");
// Motherboard
stringBuilder.AppendCollection(hardwareInfo.MotherboardList, "Motherboard");
// RAM
stringBuilder.AppendCollection(hardwareInfo.MemoryList, "RAM");

Console.WriteLine(stringBuilder.ToString());
