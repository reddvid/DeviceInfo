using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Text;
using DeviceInfo.Console;
using Hardware.Info;
using Microsoft.Win32;


[SuppressMessage("ReSharper", "CheckNamespace")]
public partial class Program
{
   private static void GetDeviceInfo(string? fileName)
   {
      HardwareInfo hardwareInfo = new();
      hardwareInfo.RefreshAll();

      StringBuilder stringBuilder = new();
      var now = DateTime.Now.ToString("yyyyMMdd_HHmmss");

      fileName = $"{fileName} - {now} Device Info";
      stringBuilder.Append(fileName);
      stringBuilder.Append(Environment.NewLine);
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
   }

   private static void GetAppList(string? fileName)
   {
      StringBuilder stringBuilder = new();
      var now = DateTime.Now.ToString("yyyyMMdd_HHmmss");

      fileName = $"{fileName} - {now} App List";
      stringBuilder.Append(fileName);
      stringBuilder.Append(Environment.NewLine);
      stringBuilder.Append(Environment.NewLine);

      string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
      using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(registryKey))
      {
         if (key == null)
         {
            return;
         }

         int appCount = 0;

         foreach (string subkeyName in key.GetSubKeyNames())
         {
            using RegistryKey? subkey = key.OpenSubKey(subkeyName);
            if (subkey == null) continue;
            if (string.IsNullOrWhiteSpace(subkey.GetValue("DisplayName")?.ToString())) continue;

            var appName = subkey.GetValue("DisplayName")?.ToString();
            var appVersion = subkey.GetValue("DisplayVersion")?.ToString();

            appCount++;
            stringBuilder.Append($"{appName} - {appVersion}");
            stringBuilder.Append(Environment.NewLine);
         }

         stringBuilder.Append(Environment.NewLine);
         stringBuilder.Append($"Found {appCount} installed apps!");
      }

      FileHelper.CreateFileAndWriteText(fileName, stringBuilder);

      return;
   }

   private static void ShowError()
   {
   }

   static bool IsRunningAsAdministrator()
   {
      using WindowsIdentity identity = WindowsIdentity.GetCurrent();
      WindowsPrincipal principal = new WindowsPrincipal(identity);
      return principal.IsInRole(WindowsBuiltInRole.Administrator);
   }
}