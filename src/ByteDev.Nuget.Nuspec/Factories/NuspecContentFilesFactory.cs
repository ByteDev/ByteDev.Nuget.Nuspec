using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Nuspec.Factories
{
    internal class NuspecContentFilesFactory
    {
        public static IEnumerable<NuspecContentFile> Create(XElement xMetaData)
        {
            var xContentFiles = xMetaData.GetChildElement("contentFiles");

            if (xContentFiles == null)
                return Enumerable.Empty<NuspecContentFile>();

            return xContentFiles.GetChildElements("files")
                .Select(CreateNuspecContentFile);
        }

        private static NuspecContentFile CreateNuspecContentFile(XElement xFile)
        {
            return new NuspecContentFile
            {
                IncludeFiles = xFile.GetAttributeValue("include"),
                ExcludeFiles = xFile.GetAttributeValue("exclude").ToCsv(';', true),
                BuildAction = xFile.GetAttributeValue("buildAction"),
                CopyToOutput = xFile.GetAttributeValue("copyToOutput").ToBool(),
                Flatten = xFile.GetAttributeValue("flatten").ToBool()
            };
        }
    }
}