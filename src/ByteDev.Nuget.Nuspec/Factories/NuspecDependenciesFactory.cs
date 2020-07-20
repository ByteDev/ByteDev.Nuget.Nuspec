using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Nuspec.Factories
{
    internal static class NuspecDependenciesFactory
    {
        public static NuspecDependencies Create(XElement xMetaData)
        {
            var xDependencies = xMetaData.GetChildElement("dependencies");

            if (xDependencies == null)
                return null;

            return new NuspecDependencies
            {
                Groups = CreateGroups(xDependencies),
                NoGroupDependencies = CreateNoGroupDependencies(xDependencies)
            };
        }

        private static IEnumerable<NuspecDependencyGroup> CreateGroups(XElement xDependencies)
        {
            var xGroups = xDependencies.GetChildElements("group");

            if (xGroups == null)
                return Enumerable.Empty<NuspecDependencyGroup>();

            return xGroups.Select(CreateDependencyGroup);
        }

        private static IEnumerable<NuspecDependency> CreateNoGroupDependencies(XElement xDependencies)
        {
            var xDeps = xDependencies.GetChildElements("dependency");

            if (xDeps == null)
                return Enumerable.Empty<NuspecDependency>();

            return xDeps.Select(CreateDependency);
        }

        private static NuspecDependencyGroup CreateDependencyGroup(XElement xGroup)
        {
            return new NuspecDependencyGroup
            {
                TargetFramework = xGroup.GetAttributeValue("targetFramework"),
                Dependencies = CreateGroupDependencies(xGroup)
            };
        }

        private static IEnumerable<NuspecDependency> CreateGroupDependencies(XElement xGroup)
        {
            var xDependencies = xGroup.GetChildElements("dependency");

            if (xDependencies == null)
                return Enumerable.Empty<NuspecDependency>();

            return xDependencies.Select(CreateDependency);
        }

        private static NuspecDependency CreateDependency(XElement xDependency)
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