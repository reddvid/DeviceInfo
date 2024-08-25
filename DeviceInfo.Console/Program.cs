using System.Text;
using DeviceInfo.Console;
using Hardware.Info;


if (args.Length != 0)
{
    if (args.Length == 1)
    {
        // Check if type argument or name
        if (Constants.ValidArgs.Contains(args[0], StringComparer.OrdinalIgnoreCase))
        {
            // Get Info -- Create/Get PC Name
            var pcName = Environment.MachineName;
        }
        else
        {
            // Show Error Message
            ShowError();
        }
    }
    else if (args.Length == 2)
    {
        // Check args position
        var firstArg = args[0];
        var secondArg = args[1];
        
        if ()
    }
    else
    {
        // Show Error
        ShowError();
    }

    var dataArg =
        args[0].StartsWith('-') ? args[0] : args[1];

    if (dataArg is "--all" or "-a")
    {
        Console.WriteLine("Getting all info.");

        await GetDeviceInfo(args);

        await GetAppList(args);
    }
    else if (dataArg is "--hardware" or "--hw" or "-h")
    {
        Console.WriteLine("Getting list of hardware info.");

        await GetDeviceInfo(args);
    }
    else if (dataArg is "--software" or "--sw" or "-s")
    {
        Console.WriteLine("Getting list of installed software");

        await GetAppList(args);
    }
}
else
{
    Console.WriteLine("Getting all info.");

    await GetDeviceInfo(args);
}