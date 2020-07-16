using System;
using System.Xml.Linq;

namespace ByteDev.Nuget
{
    /// <summary>
    /// Represents a nuget nuspec file.
    /// </summary>
    /// <remarks>
    /// Based on: https://docs.microsoft.com/en-us/nuget/reference/nuspec
    /// </remarks>
    public class NuspecFile
    {
        public NuspecMetaData MetaData { get; }

        public NuspecFile(XDocument xDoc)
        {
            if (xDoc == null)
                throw new ArgumentNullException(nameof(xDoc));

            MetaData = CreateMetaData(xDoc);
        }

        private NuspecMetaData CreateMetaData(XDocument xDoc)
        {
            XElement metaData = xDoc.Root.GetChildElement("metadata");

            if (metaData == null) 
                ExThrower.ThrowMissingElement("metadata");

            return new NuspecMetaData
            {
                Id = metaData.GetChildElementValue("id"),
                Version = metaData.GetChildElementValue("version"),
                Description = metaData.GetChildElementValue("description"),
                Authors = metaData.GetChildElementValue("authors").ToCsv(),

                Owners = metaData.GetChildElementValue("owners").ToCsv(),
                ProjectUrl = metaData.GetChildElementUriValue("projectUrl"),
                License = metaData.GetChildElementValue("license"),
                LicenseType = metaData.GetChildElementAttributeValue("license", "type"),
                Icon = metaData.GetChildElementValue("icon"),
                RequireLicenseAcceptance = metaData.GetChildElementBoolValue("requireLicenseAcceptance"),
                DevelopmentDependency = metaData.GetChildElementBoolValue("developmentDependency"),
                ReleaseNotes = metaData.GetChildElementValue("releaseNotes"),
                Copyright = metaData.GetChildElementValue("copyright"),
                Language = metaData.GetChildElementValue("language"),
                Tags = metaData.GetChildElementValue("tags").ToCsv(' '),
                Repository = NuspecRepositoryFactory.CreateRepository(metaData),

                Title = metaData.GetChildElementValue("title"),
            };
        }

        public static NuspecFile Load(string nuspecFilePath)
        {
            var xDoc = XDocument.Load(nuspecFilePath);

            return new NuspecFile(xDoc);
        }
    }
}