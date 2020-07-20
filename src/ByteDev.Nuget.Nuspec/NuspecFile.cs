using System.Collections.Generic;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents an assembly or content file to include in the nuget package.
    /// </summary>
    public class NuspecFile
    {
        /// <summary>
        /// Location of the file or files to include, subject to exclusions specified by the exclude attribute.
        /// </summary>
        public string Src { get; internal set; }

        /// <summary>
        /// The relative path to the folder within the package where the source files are placed,
        /// which must begin with lib, content, build, or tools.
        /// </summary>
        public string Target { get; internal set; }

        /// <summary>
        /// Collection of files or file patterns to exclude from the src location.
        /// </summary>
        public IEnumerable<string> ExcludeFiles { get; internal set; }
    }
}