using System.Diagnostics;
using System.Reflection;
using System.Text;
using CommunityToolkit.WinUI.Notifications;

namespace DeviceInfo.Console;

public static class FileHelper
{
    public static void CreateFileAndWriteText(string? fileName, StringBuilder stringBuilder)
    {
        var saveDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = saveDirectory + $@"\{fileName}.txt";
        using FileStream fs = File.Create(path);
        fs.Close();
        File.WriteAllText(path, stringBuilder.ToString());

        SendNotification(path);
    }

    public static void OpenFolder()
    {
        var saveDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        Process.Start("explorer.exe", saveDirectory);
    }

    private static void SendNotification(string path)
    {
        // var toast = new ToastContentBuilder()
        //     .AddText("Device Info Saved!");
        // toast.SetProtocolActivation(new Uri($"file:///{path}"), null);
        // toast.Show();
    }
}