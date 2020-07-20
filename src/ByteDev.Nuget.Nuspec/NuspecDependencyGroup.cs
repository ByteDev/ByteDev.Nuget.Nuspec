using System.Collections.Generic;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents a dependency group. Dependencies in the group are installed together
    /// when the target framework is compatible with the project's framework profile.
    /// </summary>
    public class NuspecDependencyGroup
    {
        /// <summary>
        /// Target framework.
        /// </summary>
        public string TargetFramework { get; internal set; }

        /// <summary>
        /// Dependencies for the group.
        /// </summary>
        public IEnumerable<NuspecDependency> Dependencies { get; internal set; }
    }
}