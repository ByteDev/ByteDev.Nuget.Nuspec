﻿using System.Xml.Linq;
using ByteDev.Strings;

namespace ByteDev.Nuget.Factories
{
    internal static class NuspecRepositoryFactory
    {
        public static NuspecRepository Create(XElement metaData)
        {
            XElement repository = metaData.GetChildElement("repository");

            if (repository == null)
                return null;

            return new NuspecRepository
            {
                Type = repository.GetAttributeValue("type"),
                Branch = repository.GetAttributeValue("branch"),
                Commit = repository.GetAttributeValue("commit"),
                Url = repository.GetAttributeValue("url").ToUri()
            };
        }
    }
}