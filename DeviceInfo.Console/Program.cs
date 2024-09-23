using System.Text;
using CommandLine;
using CommandLine.Text;
using DeviceInfo.Console;
using Hardware.Info;
using Spectre.Console;

AnsiConsole.Write(
new FigletText("DeviceInfo")
    .LeftJustified()
    .Color(Color.Green));
Console.Write($"by {TerminalURL("Red David", "https://reddavid.me")}".PadLeft(23, '-'));
Console.WriteLine(Environment.NewLine);

if (args.Length > 0)
{
    Parser.Default.ParseArguments<Options>(args)
        .WithParsed(options =>
        {
            Console.WriteLine($"File name: {options.MachineName}");

            var fileName = options.MachineName;

            if (InfoType.Hardware.Contains(options.InfoType.ToLower()))
            {
                AnsiConsole.Status()
                    .Start($"[red]Getting Hardware Info for [underline]{fileName}[/].[/]", ctx =>
                    {
                        AnsiConsole.MarkupLine("[yellow]Getting Hardware Info...[/]");
                        ctx.Spinner(Spinner.Known.Star);
                        GetDeviceInfo(fileName);
                        ctx.Status("Getting Hardware Info");
                    });
            }

            if (InfoType.Software.Contains(options.InfoType.ToLower()))
            {
                AnsiConsole.Status()
                    .Start($"[red]Getting Software Info for [underline]{fileName}[/].[/]", ctx =>
                    {
                        AnsiConsole.MarkupLine("[yellow]Getting List of Installed Apps...[/]");
                        ctx.Spinner(Spinner.Known.Star);
                        GetAppList(fileName);
                        ctx.Status("Getting List of Installed Apps");
                    });
            }

            if (InfoType.All.Contains(options.InfoType.ToLower()))
            {
                AnsiConsole.Status()
                     .Start($"[red]Getting Hardware and Software Info for [underline]{fileName}[/].[/]", ctx =>
                     {
                         AnsiConsole.MarkupLine("[yellow]Getting Hardware Info...[/]");
                         ctx.Spinner(Spinner.Known.Star);
                         GetDeviceInfo(fileName);
                         ctx.Status("Getting Hardware Info");

                         AnsiConsole.MarkupLine("[yellow]Getting List of Installed Apps...[/]");
                         ctx.Spinner(Spinner.Known.Star);
                         GetAppList(fileName);
                         ctx.Status("Getting List of Installed Apps");
                     });
            }
        });

}
else
{
    var fileName = Environment.MachineName;

    AnsiConsole.Status()
        .Start($"[red]Getting Hardware and Software Info for [underline]{fileName}[/].[/]", ctx =>
        {
            AnsiConsole.MarkupLine("[yellow]Getting Hardware Info...[/]");
            ctx.Spinner(Spinner.Known.Star);
            GetDeviceInfo(fileName);
            ctx.Status("Getting Hardware Info");

            AnsiConsole.MarkupLine("[yellow]Getting List of Installed Apps...[/]");
            ctx.Spinner(Spinner.Known.Star);
            GetAppList(fileName);
            ctx.Status("Getting List of Installed Apps");
        });
}

Console.WriteLine(Environment.NewLine);
AnsiConsole.Markup($"[red]Finished getting device info.[/]");
Console.WriteLine(Environment.NewLine);
AnsiConsole.MarkupLine("[yellow]The folder containing the files should open.[/]");
Console.WriteLine(Environment.NewLine);
FileHelper.OpenFolder();

static string TerminalURL(string caption, string url) => $"\u001B]8;;{url}\a{caption}\u001B]8;;\a";

