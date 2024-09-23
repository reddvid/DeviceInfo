using System.Text;
using CommandLine;
using CommandLine.Text;
using DeviceInfo.Console;
using Hardware.Info;

Console.WriteLine("Hello World");

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(options =>
    {
        // var loggerFactory = LoggerFactory.Create(builder =>
        // {
        //     builder
        //         .ClearProviders()
        //         .AddConsole()
        //         .AddDebug();
        //
        //     if (options.Verbose)
        //     {
        //         builder.SetMinimumLevel(LogLevel.Debug);
        //     }
        //
        // });
        //
        // logger = loggerFactory.CreateLogger<Program>();
        // logger.LogDebug("Show verbose output.");

        Console.WriteLine($"File name: {options.MachineName}");
        var fileName = options.MachineName;

        if (string.IsNullOrWhiteSpace(options.InfoType)) return;
        
        if (InfoType.Hardware.Contains(options.InfoType.ToLower()))
        {
            GetDeviceInfo(fileName);
        }

        if (InfoType.Software.Contains(options.InfoType.ToLower()))
        {
            GetAppList(fileName);
        }

        if (InfoType.All.Contains(options.InfoType.ToLower()))
        {
            GetDeviceInfo(fileName);
            GetAppList(fileName);
        }
    });
