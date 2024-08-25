using System.Diagnostics.CodeAnalysis;
using System.Text;
using DeviceInfo.Console;
using Hardware.Info;
using Microsoft.Win32;


[SuppressMessage("ReSharper", "CheckNamespace")]
public partial class Program
{
    private static Task GetDeviceInfo(string[] args)
    {
        HardwareInfo hardwareInfo = new();
        hardwareInfo.RefreshAll();

        StringBuilder stringBuilder = new();
        var now = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        var fileName = $"PC - {now} Device Info";

        if (args.Length != 0)
        {
            var pcName = args.FirstOrDefault();

            fileName = $"{pcName} - {now} Device Info";
            stringBuilder.Append(pcName);
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

        System.Console.WriteLine("Finished getting hardware info.");

        return Task.CompletedTask;
    }

    private static Task GetAppList(string[] args)
    {
        StringBuilder stringBuilder = new();
        var now = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        var fileName = $"PC - {now} App List";

        if (args.Length != 0)
        {
            var pcName = args.FirstOrDefault();

            fileName = $"{pcName} - {now} App List";
            stringBuilder.Append(pcName);
            stringBuilder.Append(Environment.NewLine);
        }

        stringBuilder.Append(now);
        stringBuilder.Append(Environment.NewLine);

        string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(registryKey))
        {
            if (key == null)
            {
                return Task.CompletedTask;
            }

            int appCount = 0;

            foreach (string subkeyName in key.GetSubKeyNames())
            {
                using RegistryKey? subkey = key.OpenSubKey(subkeyName);
                if (subkey == null) continue;
                if (string.IsNullOrWhiteSpace(subkey.GetValue("DisplayName")?.ToString())) continue;

                var appName = subkey.GetValue("DisplayName")?.ToString();
                appCount++;
                stringBuilder.Append(appName);
                stringBuilder.Append(Environment.NewLine);
            }

            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($"Found {appCount} installed apps!");
        }

        System.Console.WriteLine("Finished getting apps.");

        FileHelper.CreateFileAndWriteText(fileName, stringBuilder);

        return Task.CompletedTask;
    }

    private static void ShowError()
    {
    }
}