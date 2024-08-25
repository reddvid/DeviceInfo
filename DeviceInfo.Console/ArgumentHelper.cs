namespace DeviceInfo.Console;

public class ArgumentHelper
{
    public CommandType CheckArgType(string arg)
    {
        return Constants.ValidArgs.Contains(arg);
    }
}

public enum CommandType
{
    Info,
    Name
}