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
        /// <summary>
        /// Package meta data.
        /// </summary>
        public NuspecMetaData MetaData { get; }

        /// <summary>
        /// Assembly and content files included in the package.
        /// </summary>
        public IEnumerable<NuspecFile> Files { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Nuget.Nuspec" /> class.
        /// </summary>
        /// <param name="xDoc">XML document of the nuspec file.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="xDoc" /> is null.</exception>
        public Nuspec(XDocument xDoc)
        {
            if (xDoc == null)
                throw new ArgumentNullException(nameof(xDoc));

            MetaData = NuspecMetaDataFactory.CreateMetaData(xDoc);
            Files = NuspecFileFactory.CreateFiles(xDoc);
        }

        /// <summary>
        /// Loads the nuspec file and returns a new <see cref="T:ByteDev.Nuget.Nuspec" /> instance.
        /// </summary>
        /// <param name="nuspecFilePath">Nuspec file path.</param>
        /// <returns>New <see cref="T:ByteDev.Nuget.Nuspec" /> instance.</returns>
        public static Nuspec Load(string nuspecFilePath)
        {
            var xDoc = XDocument.Load(nuspecFilePath);

            return new Nuspec(xDoc);
        }
    }
}