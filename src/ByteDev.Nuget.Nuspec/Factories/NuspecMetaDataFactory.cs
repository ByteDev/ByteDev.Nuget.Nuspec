using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Nuspec.Factories
{
    internal static class NuspecMetaDataFactory
    {
        public static NuspecMetaData CreateMetaData(XDocument xDoc)
        {
            XElement xMetaData = xDoc.Root.GetChildElement("metadata");

            if (xMetaData == null)
                ExThrower.ThrowMissingElement("metadata");

            return new NuspecMetaData
            {
                MinClientVersion = xMetaData.GetAttributeValue("minClientVersion"),

                Id = GetMandatoryMetaDataValue(xMetaData, "id"),
                Version = GetMandatoryMetaDataValue(xMetaData, "version"),
                Description = GetMandatoryMetaDataValue(xMetaData, "description"),
                Authors = GetMandatoryMetaDataValue(xMetaData, "authors").ToCsv(true),

                ProjectUrl = xMetaData.GetChildElementValue("projectUrl").ToUri(),
                Icon = xMetaData.GetChildElementValue("icon"),
                RequireLicenseAcceptance = xMetaData.GetChildElementValue("requireLicenseAcceptance").ToBool(),
                DevelopmentDependency = xMetaData.GetChildElementValue("developmentDependency").ToBool(),
                ReleaseNotes = xMetaData.GetChildElementValue("releaseNotes"),
                Copyright = xMetaData.GetChildElementValue("copyright"),
                Language = xMetaData.GetChildElementValue("language"),
                Title = xMetaData.GetChildElementValue("title"),

                Owners = xMetaData.GetChildElementValue("owners").ToCsv(true),
                Tags = xMetaData.GetChildElementValue("tags").ToCsv(' ', true),

                License = NuspecLicenseFactory.Create(xMetaData),
                Repository = NuspecRepositoryFactory.Create(xMetaData),
                Dependencies = NuspecDependenciesFactory.Create(xMetaData),
                PackageTypes = NuspecPageTypesFactory.Create(xMetaData),
                FrameworkAssemblies = NuspecFrameworkAssembliesFactory.Create(xMetaData),
                References = NuspecReferencesFactory.Create(xMetaData),
                ContentFiles = NuspecContentFilesFactory.Create(xMetaData)
            };
        }

        private static string GetMandatoryMetaDataValue(XElement xMetaData, string elementName)
        {
            var value = xMetaData.GetChildElementValue(elementName);

            if (value == null)
                ExThrower.ThrowMissingElement(elementName);

            return value;
        }
    }
}