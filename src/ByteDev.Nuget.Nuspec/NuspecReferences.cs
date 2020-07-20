using System.Collections.Generic;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents a set of explicit assembly references.
    /// </summary>
    public class NuspecReferences
    {
        /// <summary>
        /// File groups.
        /// </summary>
        public IEnumerable<NuspecReferenceGroup> Groups { get; internal set; }

        /// <summary>
        /// Files that are not assigned to a group.
        /// </summary>
        public IEnumerable<NuspecReferenceFile> NoGroupFiles { get; internal set; }
    }
}