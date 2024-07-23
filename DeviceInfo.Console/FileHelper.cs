using System.Text;
using CommunityToolkit.WinUI.Notifications;

namespace DeviceInfo.Console;

public static class FileHelper
{
    public static void CreateFileAndWriteText(string fileName, StringBuilder stringBuilder)
    {
        var desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        System.Console.WriteLine(desktopDirectory);
        var path = desktopDirectory + $@"\{fileName}.txt";
        using FileStream fs = File.Create(path);
        fs.Close();
        File.WriteAllText(path, stringBuilder.ToString());

        SendNotification(path);
        
    }

    private static void SendNotification(string path)
    {
        var toast = new ToastContentBuilder()
            .AddText("Device Info Saved!");
        toast.Show();
    }
}