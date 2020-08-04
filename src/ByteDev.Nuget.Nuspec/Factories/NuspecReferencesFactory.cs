using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Xml;

namespace ByteDev.Nuget.Nuspec.Factories
{
    internal class NuspecReferencesFactory
    {
        public static NuspecReferences Create(XElement xMetaData)
        {
            var xReferences = xMetaData.GetChildElement("references");

            if (xReferences == null)
                return null;

            return new NuspecReferences
            {
                Groups = CreateGroups(xReferences),
                NoGroupFiles = CreateNoGroupFiles(xReferences)
            };
        }

        private static IEnumerable<NuspecReferenceFile> CreateNoGroupFiles(XElement xReferences)
        {
            var xRefs = xReferences.GetChildElements("reference");

            if (xRefs == null)
                return Enumerable.Empty<NuspecReferenceFile>();

            return xRefs.Select(CreateNuspecReferenceFile);
        }

        private static IEnumerable<NuspecReferenceGroup> CreateGroups(XElement xReferences)
        {
            var xGroups = xReferences.GetChildElements("group");

            if (xGroups == null)
                return Enumerable.Empty<NuspecReferenceGroup>();

            return xGroups
                .Select(g => new NuspecReferenceGroup
                {
                    TargetFramework = g.GetAttributeValue("targetFramework"),
                    Files = g.GetChildElements("reference").Select(CreateNuspecReferenceFile)
                });
        }

        private static NuspecReferenceFile CreateNuspecReferenceFile(XElement xReference)
        {
            return new NuspecReferenceFile
            {
                FileName = xReference.GetAttributeValue("file")
            };
        }
    }
}