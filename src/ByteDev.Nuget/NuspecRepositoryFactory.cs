using System;
using System.Linq;
using System.Xml.Linq;

namespace ByteDev.Nuget
{
    internal static class NuspecRepositoryFactory
    {
        public static NuspecRepository CreateRepository(XElement metaData)
        {
            XElement repository = metaData.Descendants().SingleOrDefault(d => d.Name.LocalName == "repository");

            if (repository == null)
                return null;

            XAttribute url = repository.Attribute("url");

            return new NuspecRepository
            {
                Type = repository.Attribute("type")?.Value,
                Url = url == null ? null : new Uri(url.Value),
                Branch = repository.Attribute("branch")?.Value,
                Commit = repository.Attribute("commit")?.Value
            };
        }
    }
}