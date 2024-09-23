using CommandLine;

namespace DeviceInfo.Console;

public abstract class Options
{
    protected Options(string? machineName, string? infoType)
    {
        MachineName = machineName;
        InfoType = infoType;
    }

    [Option('n', "name", Required = true, HelpText = "The Machine's Name/Output file name")]
    public string? MachineName { get; }

    [Option('y', "type", Required = true, 
        HelpText = "The info to collect.\n" +
                   "Use 'all', 'a', '.' to collect hardware and software info.\n" +
                   "Use 'hardware', 'hw', 'h' to get list of hardware devices.\n" +
                   "Use 'software', 'sw', 's' to get list of installed software.")]
    public string? InfoType { get; }
}