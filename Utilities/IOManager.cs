using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Management.Automation;

namespace WinUI.Utilities
{
    public static class IOManager
    {
        public static readonly PowerShell Powershell = PowerShell.Create();
        public static string[] FindFile(string SourceDirectory,Regex Pattern, string FileExtension)
        {
            return Directory.GetFiles(SourceDirectory, FileExtension)
                            .Where(file => Pattern.IsMatch(Path.GetFileName(file)))
                            .ToArray();
        }
        public static void CopyAllFiles(string SourceDirectory, string TargetDirectory)
        {
            // var files = Directory.GetFiles(SourceDirectory);
            // foreach (var file in files)
            // {
            //     var FileName = Path.GetFileName(file);
            //     File.Copy(Path.Combine(SourceDirectory, FileName), Path.Combine(TargetDirectory, FileName));
            // }
            Powershell.AddScript($"Robocopy.exe /S '{SourceDirectory}' '{TargetDirectory}' /E /XF '*.cpp'");
            Powershell.Invoke();
        }

        public static void CopyAllFiles(string[] SourceDirectories, string TargetDirectory)
        {
            foreach (var SourceDirectory in SourceDirectories)
            {
                CopyAllFiles(SourceDirectory, TargetDirectory);
            }
        }

        public static string FindLasModifiedDirectory(string SourceDirectory)
        {
            return Directory.GetDirectories(SourceDirectory)
                            .OrderByDescending(directory => Directory.GetLastWriteTime(directory))
                            .First();
        }

        public static void CompressDirectory(string SourceDirectory, string ZipFilePath)
        {
            var Command =
$@"$CompressInfo = @{{
    Path = '{SourceDirectory}\*'
    CompressionLevel = 'Optimal'
    DestinationPath = '{ZipFilePath}'
}}
Compress-Archive @CompressInfo -Update";
            Powershell.AddScript(Command);
            Powershell.Invoke();
        }
    }
}