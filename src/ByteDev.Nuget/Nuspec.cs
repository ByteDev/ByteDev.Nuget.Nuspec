using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ByteDev.Nuget.Factories;

namespace ByteDev.Nuget
{
    /// <summary>
    /// Represents a nuget nuspec file.
    /// </summary>
    /// <remarks>
    /// Based on: https://docs.microsoft.com/en-us/nuget/reference/nuspec
    /// </remarks>
    public class Nuspec
    {
        public NuspecMetaData MetaData { get; }

        public IEnumerable<NuspecFile> Files { get; }

        public Nuspec(XDocument xDoc)
        {
            if (xDoc == null)
                throw new ArgumentNullException(nameof(xDoc));

            MetaData = NuspecMetaDataFactory.CreateMetaData(xDoc);
            Files = NuspecFileFactory.CreateFiles(xDoc);
        }

        public static Nuspec Load(string nuspecFilePath)
        {
            var xDoc = XDocument.Load(nuspecFilePath);

            return new Nuspec(xDoc);
        }
    }
}