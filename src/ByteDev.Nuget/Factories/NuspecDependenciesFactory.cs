using System.Xml.Linq;

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
                var nuspecGroup = new NuspecDependencyGroup
                {
                    TargetFramework = xGroup.GetAttributeValue("targetFramework")
                };

                var xDependencys = xGroup.GetChildElements("dependency");

                foreach (var xDependency in xDependencys)
                {
                    nuspecGroup.Dependencies.Add(new NuspecDependency
                    {
                        Id = xDependency.GetAttributeValue("id"),
                        Version = xDependency.GetAttributeValue("version")
                    });
                }
                
                nuspecDependencies.Groups.Add(nuspecGroup);
            }
            
            return nuspecDependencies;
        }
    }
}