using System.Xml.Linq;

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
                Authors = GetMandatoryMetaDataValue(metaData, "authors").ToCsv(),

                ProjectUrl = metaData.GetChildElementUriValue("projectUrl"),
                License = metaData.GetChildElementValue("license"),
                LicenseType = metaData.GetChildElementAttributeValue("license", "type"),
                Icon = metaData.GetChildElementValue("icon"),
                RequireLicenseAcceptance = metaData.GetChildElementBoolValue("requireLicenseAcceptance"),
                DevelopmentDependency = metaData.GetChildElementBoolValue("developmentDependency"),
                ReleaseNotes = metaData.GetChildElementValue("releaseNotes"),
                Copyright = metaData.GetChildElementValue("copyright"),
                Language = metaData.GetChildElementValue("language"),
                Title = metaData.GetChildElementValue("title"),

                Owners = metaData.GetChildElementValue("owners").ToCsv(),
                Tags = metaData.GetChildElementValue("tags").ToCsv(' '),

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