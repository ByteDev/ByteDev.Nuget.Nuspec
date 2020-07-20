using System.Xml.Linq;

namespace ByteDev.Nuget.Factories
{
    internal static class NuspecLicenseFactory
    {
        public static NuspecLicense Create(XElement xMetaData)
        {
            var xLicense = xMetaData.GetChildElement("license");

            if (xLicense == null)
                return null;

            return new NuspecLicense
            {
                PathOrId = xLicense.Value,
                Type = xLicense.GetAttributeValue("type")
            };
        }
    }
}