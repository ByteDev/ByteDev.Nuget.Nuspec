using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Factories
{
    internal static class NuspecDependenciesFactory
    {
        public static NuspecDependencies Create(XElement metaData)
        {
            var xDependencies = metaData.GetChildElement("dependencies");

            if (xDependencies == null)
                return null;

            var nuspecDependencies = new NuspecDependencies();

            var xGroups = metaData.GetChildElements("group");

            foreach (var xGroup in xGroups)
            {
                nuspecDependencies.Groups.Add(CreateNuspecDependencyGroup(xGroup));
            }

            var xNoGroupDependencies = metaData.GetChildElements("dependency");

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
                Include = xDependency.GetAttributeValue("include").ToCsv(true),
                Exclude = xDependency.GetAttributeValue("exclude").ToCsv(true)
            };
        }
    }
}