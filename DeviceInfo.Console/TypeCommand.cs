using CommandLine;

namespace DeviceInfo.Console;

public class TypeCommand : ICommand
{
    public void Execute()
    {
    }
    
    [Option('a', "all", Required = false, HelpText = "Getting hardware and software list")]
    public string? All { get; set; }
    
    [Option('h', "hardware", Required = false, HelpText = "Getting hardware list")]
    public string? Hardware { get; set; }

    [Option('s', "software", Required = true, HelpText = "Getting list of installed software")]
    public string? Software { get; set; }
}