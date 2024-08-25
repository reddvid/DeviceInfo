using CommandLine;

namespace DeviceInfo.Console;

[Verb("get", true, HelpText = "Save all your commits to the cloud")]
public class GetCommand : ICommand
{
    public void Execute()
    {
    }

    [Option('n', "name", Required = false, HelpText = "Give a name for the machine")]
    public string? MachineName { get; set; }

}