using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinUI.Command;

public class ProjectInfo
{
    public string ProjectName { get; set; }
    public string WinUIVersion { get; set; }

    public ProjectInfo(string projectName, string winUIVersion)
    {
        ProjectName = projectName;
        WinUIVersion = winUIVersion;
    }

    public override string ToString()
    {
        var Builder = new StringBuilder();

        TypeDescriptor.GetProperties(this)
                      .Cast<PropertyDescriptor>().ToList()
                      .ForEach(Property => Builder.AppendLine($"{Property.Name}: {Property.GetValue(this) ?? string.Empty}"));

        return Builder.ToString();
    }
}
public static class Info
{
    public static ProjectInfo Full(string Target)
    {
        if (Target == ".") Target = Directory.GetCurrentDirectory();

        var CSProjFile = Directory.GetFiles(Target, "*.csproj")[0];
        var Content = File.ReadAllText(CSProjFile);

        var ProjectName = Path.GetFileNameWithoutExtension(CSProjFile);
        var WinUIVersion = Regex.Match(Content, "(?<=Microsoft.WindowsAppSDK\" Version=\").+(?=\")").Value;

        return new ProjectInfo(ProjectName, WinUIVersion);
    }
}