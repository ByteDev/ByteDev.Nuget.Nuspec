using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Factories
{
    internal static class NuspecMetaDataFactory
    {
        public static NuspecMetaData CreateMetaData(XDocument xDoc)
        {
            XElement metaData = xDoc.Root.GetChildElement("metadata");

            if (metaData == null) 
                ExThrower.ThrowMissingElement("metadata");

            return new NuspecMetaData
            {
                MinClientVersion = metaData.GetAttributeValue("minClientVersion"),

                Id = GetMandatoryMetaDataValue(metaData, "id"),
                Version = GetMandatoryMetaDataValue(metaData, "version"),
                Description = GetMandatoryMetaDataValue(metaData, "description"),
                Authors = GetMandatoryMetaDataValue(metaData, "authors").ToCsv(true),

                ProjectUrl = metaData.GetChildElementValue("projectUrl").ToUri(),
                License = metaData.GetChildElementValue("license"),
                LicenseType = metaData.GetChildElement("license")?.GetAttributeValue("type"),
                Icon = metaData.GetChildElementValue("icon"),
                RequireLicenseAcceptance = metaData.GetChildElementValue("requireLicenseAcceptance").ToBool(),
                DevelopmentDependency = metaData.GetChildElementValue("developmentDependency").ToBool(),
                ReleaseNotes = metaData.GetChildElementValue("releaseNotes"),
                Copyright = metaData.GetChildElementValue("copyright"),
                Language = metaData.GetChildElementValue("language"),
                Title = metaData.GetChildElementValue("title"),

                Owners = metaData.GetChildElementValue("owners").ToCsv(true),
                Tags = metaData.GetChildElementValue("tags").ToCsv(' ', true),

                Repository = NuspecRepositoryFactory.Create(metaData),
                Dependencies = NuspecDependenciesFactory.Create(metaData),
                PackageTypes = NuspecPageTypesFactory.Create(metaData)
            };
        }

        private static string GetMandatoryMetaDataValue(XElement metaData, string elementName)
        {
            var value = metaData.GetChildElementValue(elementName);

            if (value == null)
                ExThrower.ThrowMissingElement(elementName);

            return value;
        }
    }
}