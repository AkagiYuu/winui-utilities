using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WinUI.Utilities;
using WinUI.Dependency;

namespace WinUI.Command.Create;

internal class Main
{
    public static void Installer(string Target)
    {
        var InstallerPath = DependencyPath.Installer;
        var RuntimePath = DependencyPath.Runtime;

        IOManager.CopyAllFiles(new string[] { InstallerPath, RuntimePath }, Target);
    }

    public static void Release(string Target)
    {
        var Architecture = "x64";
        var BinFolder = @$"{Target}\bin\{Architecture}\Release";

        var DotnetBuildDirectory = IOManager.FindLasModifiedDirectory(BinFolder);
        var AppSource = IOManager.FindLasModifiedDirectory(DotnetBuildDirectory);

        var ProjectFile = Directory.GetFiles(Target, "*.csproj")[0];
        var ProjectName = Path.GetFileNameWithoutExtension(ProjectFile);

        var ReleaseFolder = @$"{Target}\Release\{ProjectName}-{Architecture}";
        var AppDirectory = @$"{ReleaseFolder}\App";
        var ZipFilePath = $"{ReleaseFolder}.zip";

        // Generate Release
        Directory.CreateDirectory(AppDirectory);
        IOManager.CopyAllFiles(AppSource, AppDirectory);
        Installer(ReleaseFolder);

        IOManager.CompressDirectory(ReleaseFolder, ZipFilePath);
    }
}