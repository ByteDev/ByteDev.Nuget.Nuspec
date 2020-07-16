using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Nuget
{
    internal static class StringExtensions
    {
        public static IEnumerable<string> ToCsv(this string source)
        {
            return ToCsv(source, ',');
        }

        public static IEnumerable<string> ToCsv(this string source, char delimiter)
        {
            if (string.IsNullOrEmpty(source))
                return Enumerable.Empty<string>();

            return source.Split(delimiter)
                .Select(a => a.Trim())
                .Where(s => s != string.Empty);
        }
    }
}