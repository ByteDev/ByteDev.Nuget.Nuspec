using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ByteDev.Nuget.Factories
{
    internal static class NuspecFileFactory
    {
        public static IEnumerable<NuspecFile> CreateFiles(XDocument xDoc)
        {
            XElement files = xDoc.Root.GetChildElement("files");

            if (files == null)
                return Enumerable.Empty<NuspecFile>();

            IEnumerable<XElement> filesCollection = files.Elements().Where(e => e.Name.LocalName == "file");

            return filesCollection.Select(CreateNuspecFile);
        }

        private static NuspecFile CreateNuspecFile(XElement file)
        {
            return new NuspecFile
            {
                Src = file.GetAttributeValue("src"),
                Target = file.GetAttributeValue("target"),
                Exclude = file.GetAttributeValue("exclude")
            };
        }
    }
}