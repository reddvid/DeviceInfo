using System.Text;
using DeviceInfo.Console;
using Hardware.Info;

var dataArg = args[1];

Console.WriteLine($"Getting info for {args[0]} PC");

if (dataArg is "--all" or "-a" or "" or ".")
{
    Console.WriteLine("Getting all info.");

    await GetDeviceInfo(args);

    await GetAppList(args);
}
else if (dataArg is "--system" or "-s" or "--devices" or "-d")
{
    Console.WriteLine("Getting device hardware info.");

    await GetDeviceInfo(args);
}
else if (dataArg is "--apps" or "-p")
{
    Console.WriteLine("Getting app list.");

    await GetAppList(args);
}