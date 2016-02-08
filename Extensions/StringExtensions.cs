using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_extensions.Extensions
{
    public static class StringExtensions
    {
        public static string Gsub(this string str, string pattern, string replaceWith)
        {
            var regex = new Regex(pattern);
            return regex.Replace(str, replaceWith);
        }
    }
}
