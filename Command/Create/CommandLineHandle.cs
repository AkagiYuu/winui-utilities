using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CliFx.Exceptions;

namespace WinUI.Command.Create;

[Command("Create")]
public class Create : ICommand
{
    public ValueTask ExecuteAsync(IConsole console) => throw new CommandException("Not enough parameters.", showHelp: true);
}


[Command("Create Installer")]
public class CreateInstaller : ICommand
{
    [CommandOption("Target", 't', Description = "Target folder")]
    public string Target { get; init; } = @".\";

    public ValueTask ExecuteAsync(IConsole console)
    {
        Main.Installer(Target);

        return default;
    }
}

[Command("Create Release")]
public class CreateRelease : ICommand
{
    [CommandOption("Target", 't', Description = "Target folder")]
    public string Target { get; init; } = @".\";
    
    public ValueTask ExecuteAsync(IConsole console)
    {
        Main.Release(Target);

        return default;
    }
}

