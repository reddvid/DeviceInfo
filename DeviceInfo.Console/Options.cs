using CommandLine;

public class Options
{
    [Option('n', "name", Required = true, HelpText = "The Machine's Name/Output file name")]
    public string MachineName { get; set; }

    [Option('y', "type", Required = true, 
        HelpText = "The info to collect.\n" +
                   "Use 'all', 'a', '.' to collect hardware and software info.\n" +
                   "Use 'hardware', 'hw', 'h' to get list of hardware devices.\n" +
                   "Use 'software', 'sw', 's' to get list of installed software.")]
    public string InfoType { get; set; }
}