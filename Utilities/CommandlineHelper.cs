using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinUI.Utilities
{
    public class CommandlineHelper
    {
        public const string CurrentDirectory = @"D:\DATA\Programming\Visual Studio Code\WinUI";
        public const string HelpMessage = "Usage: Program.cs <action> <object> <target>";
        public static void PrintError(string message)
        {
            Console.WriteLine($"Error: {message}");
            Console.WriteLine(HelpMessage);
        }
    }
}