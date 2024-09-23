using System.Reflection;
using System.Text;
using CommunityToolkit.WinUI.Notifications;

namespace DeviceInfo.Console;

public static class FileHelper
{
    public static void CreateFileAndWriteText(string? fileName, StringBuilder stringBuilder)
    {
        var saveDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        System.Console.WriteLine(saveDirectory);
        var path = saveDirectory + $@"\{fileName}.txt";
        using FileStream fs = File.Create(path);
        fs.Close();
        File.WriteAllText(path, stringBuilder.ToString());

        SendNotification(path);
        
    }

    private static void SendNotification(string path)
    {
        // var toast = new ToastContentBuilder()
        //     .AddText("Device Info Saved!");
        // toast.SetProtocolActivation(new Uri($"file:///{path}"), null);
        // toast.Show();
    }
}