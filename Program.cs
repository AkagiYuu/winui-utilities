using Cocona;
using WinUI.Command;

var App = CoconaLiteApp.Create();

App.AddSubCommand("create", Command =>
{
    Command.AddCommand("installer", (string? Path) => Create.Installer(Path ?? "."));
    Command.AddCommand("release", (string? Path) => Create.Release(Path ?? "."));
});

App.AddCommand("info", (string? Target) => Console.WriteLine(Info.Full(Target ?? ".")));

App.Run();