using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace WinUI.Extension
{
    public static class String
    {
        public static string ToTitleCase(this string title) => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
    }
}