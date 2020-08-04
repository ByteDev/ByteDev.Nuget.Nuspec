using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Xml;

namespace ByteDev.Nuget.Nuspec.Factories
{
    internal static class NuspecFrameworkAssembliesFactory
    {
        public static IEnumerable<NuspecFrameworkAssembly> Create(XElement xMetaData)
        {
            var xFrameworkAssemblies = xMetaData.GetChildElement("frameworkAssemblies");

            if (xFrameworkAssemblies == null)
                return Enumerable.Empty<NuspecFrameworkAssembly>();

            return xFrameworkAssemblies
                .GetChildElements("frameworkAssembly")
                .Select(CreateNuspecFrameworkAssembly);
        }

        private static NuspecFrameworkAssembly CreateNuspecFrameworkAssembly(XElement xFrameworkAssembly)
        {
            return new NuspecFrameworkAssembly
            {
                AssemblyName = xFrameworkAssembly.GetAttributeValue("assemblyName"),
                TargetFramework = xFrameworkAssembly.GetAttributeValue("targetFramework")
            };
        }
    }
}