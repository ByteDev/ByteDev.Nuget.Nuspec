using System;
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

        public static Uri ToUri(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return null;

            return new Uri(source);
        }

        public static bool ToBool(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            if (bool.TryParse(source, out bool result))
                return result;

            return false;
        }
    }
}