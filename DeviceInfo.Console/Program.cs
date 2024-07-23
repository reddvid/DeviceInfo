using System.Text;
using DeviceInfo.Console;
using Hardware.Info;

string? userName;
HardwareInfo hardwareInfo = new();
hardwareInfo.RefreshAll();
string? fileName;

StringBuilder stringBuilder = new();
var now = DateTime.Now.ToString("yyyyMMdd_HHmmss");

fileName = $"PC - {now}";

if (args.Length != 0)
{
    userName = args.FirstOrDefault();
    stringBuilder.Append(userName);
    stringBuilder.Append(Environment.NewLine);
}

stringBuilder.Append(now);
stringBuilder.Append(Environment.NewLine);

// Get Devices

// CPU
stringBuilder.AppendCollection(hardwareInfo.CpuList, "CPU");
// Motherboard
stringBuilder.AppendCollection(hardwareInfo.MotherboardList, "Motherboard");
// BIOS
stringBuilder.AppendCollection(hardwareInfo.BiosList, "BIOS");
// RAM
stringBuilder.AppendCollection(hardwareInfo.MemoryList, "RAM");
// Drives
stringBuilder.AppendCollection(hardwareInfo.DriveList, "Drives");
// OS
stringBuilder.Append(hardwareInfo.OperatingSystem, "Operating System");
// Network
stringBuilder.AppendCollection(hardwareInfo.NetworkAdapterList, "Network Adapters");
// Video Adapters
stringBuilder.AppendCollection(hardwareInfo.VideoControllerList, "Video Adapters");
// Audio Adapters
stringBuilder.AppendCollection(hardwareInfo.SoundDeviceList, "Sound Devices");

// Peripherals

// Keyboard
stringBuilder.AppendCollection(hardwareInfo.KeyboardList, "Keyboards");
// Mouse
stringBuilder.AppendCollection(hardwareInfo.MouseList, "Mice");
// Monitors
stringBuilder.AppendCollection(hardwareInfo.MonitorList, "Monitors");

// Write to Text
FileHelper.CreateFileAndWriteText(fileName, stringBuilder);


Console.WriteLine(stringBuilder.ToString());