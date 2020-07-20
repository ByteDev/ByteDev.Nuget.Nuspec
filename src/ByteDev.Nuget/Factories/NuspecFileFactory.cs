using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Factories
{
    internal static class NuspecFileFactory
    {
        public static IEnumerable<NuspecFile> CreateFiles(XDocument xDoc)
        {
            XElement xFiles = xDoc.Root.GetChildElement("files");

            if (xFiles == null)
                return Enumerable.Empty<NuspecFile>();

            return xFiles
                .GetChildElements("file")
                .Select(CreateNuspecFile);
        }

        private static NuspecFile CreateNuspecFile(XElement xFile)
        {
            return new NuspecFile
            {
                Src = xFile.GetAttributeValue("src"),
                Target = xFile.GetAttributeValue("target"),
                ExcludeFiles = xFile.GetAttributeValue("exclude").ToCsv(';', true)
            };
        }
    }
}