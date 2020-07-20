using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Factories
{
    internal static class NuspecDependenciesFactory
    {
        public static NuspecDependencies Create(XElement xMetaData)
        {
            var xDependencies = xMetaData.GetChildElement("dependencies");

            if (xDependencies == null)
                return null;

            var nuspecDependencies = new NuspecDependencies();

            var xGroups = xMetaData.GetChildElements("group");

            foreach (var xGroup in xGroups)
            {
                nuspecDependencies.Groups.Add(CreateNuspecDependencyGroup(xGroup));
            }

            var xNoGroupDependencies = xMetaData.GetChildElements("dependency");

            foreach (var xDependency in xNoGroupDependencies)
            {
                nuspecDependencies.NoGroupDependencies.Add(CreateNuspecDependency(xDependency));
            }

            return nuspecDependencies;
        }

        private static NuspecDependencyGroup CreateNuspecDependencyGroup(XElement xGroup)
        {
            var nuspecGroup = new NuspecDependencyGroup
            {
                TargetFramework = xGroup.GetAttributeValue("targetFramework")
            };

            var xDependencys = xGroup.GetChildElements("dependency");

            foreach (var xDependency in xDependencys)
            {
                nuspecGroup.Dependencies.Add(CreateNuspecDependency(xDependency));
            }

            return nuspecGroup;
        }

        private static NuspecDependency CreateNuspecDependency(XElement xDependency)
        {
            return new NuspecDependency
            {
                Id = xDependency.GetAttributeValue("id"),
                Version = xDependency.GetAttributeValue("version"),
                IncludeTags = xDependency.GetAttributeValue("include").ToCsv(true),
                ExcludeTags = xDependency.GetAttributeValue("exclude").ToCsv(true)
            };
        }
    }
}