using System.Collections.Generic;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents content file(s) to include/exclude.
    /// </summary>
    public class NuspecContentFile
    {
        /// <summary>
        /// The location of the file or files to include, subject to exclusions specified by the exclude attribute.
        /// </summary>
        public string IncludeFiles { get; internal set; }

        /// <summary>
        /// Collection of files or file patterns to exclude from the src location.
        /// </summary>
        public IEnumerable<string> ExcludeFiles { get; internal set; }

        /// <summary>
        /// The build action to assign to the content item for MSBuild, such as:
        /// Content, None, Embedded Resource, Compile, etc.
        /// </summary>
        public string BuildAction { get; internal set; }

        /// <summary>
        /// Indicates whether to copy content items to the build (or publish) output folder. 
        /// </summary>
        public bool CopyToOutput { get; internal set; }

        /// <summary>
        /// Indicates whether to copy content items to a single folder in the build output (true),
        /// or to preserve the folder structure in the package (false).
        /// </summary>
        public bool Flatten { get; internal set; }
    }
}