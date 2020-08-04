using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Xml;

namespace ByteDev.Nuget.Nuspec.Factories
{
    internal static class NuspecPageTypesFactory
    {
        public static IEnumerable<NuspecPackageType> Create(XElement metaData)
        {
            var xPackageTypes = metaData.GetChildElement("packageTypes");

            if (xPackageTypes == null)
                return Enumerable.Empty<NuspecPackageType>();

            return xPackageTypes
                .GetChildElements("packageType")
                .Select(CreateNuspecPackageType);
        }

        private static NuspecPackageType CreateNuspecPackageType(XElement xPackageType)
        {
            return new NuspecPackageType
            {
                Name = xPackageType.GetAttributeValue("name"),
                Version = xPackageType.GetAttributeValue("version")
            };
        }
    }
}