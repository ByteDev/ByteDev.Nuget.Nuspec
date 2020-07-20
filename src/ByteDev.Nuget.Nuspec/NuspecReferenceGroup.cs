using System.Collections.Generic;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents a reference group.
    /// </summary>
    public class NuspecReferenceGroup
    {
        /// <summary>
        /// Group's target framework.
        /// </summary>
        public string TargetFramework { get; internal set; }

        /// <summary>
        /// Reference files.
        /// </summary>
        public IEnumerable<NuspecReferenceFile> Files { get; internal set; }
    }
}