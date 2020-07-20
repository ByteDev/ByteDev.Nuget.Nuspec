using System;
using System.Xml.Linq;

namespace ByteDev.Nuget.Nuspec
{
    internal static class XDocumentExtensions
    {
        public static bool IsRootName(this XDocument source, string rootName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(rootName))
                throw new ArgumentException("Root name was null or empty.", nameof(rootName));

            return source.Root?.Name.LocalName == rootName;
        }
    }
}