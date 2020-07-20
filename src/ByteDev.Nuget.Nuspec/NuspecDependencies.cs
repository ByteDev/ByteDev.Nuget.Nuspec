using System.Collections.Generic;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents a set of dependencies.
    /// </summary>
    public class NuspecDependencies
    {
        /// <summary>
        /// Dependency groups.
        /// </summary>
        public IEnumerable<NuspecDependencyGroup> Groups { get; internal set; }

        /// <summary>
        /// Dependencies that exist outside of a group.
        /// </summary>
        public IEnumerable<NuspecDependency> NoGroupDependencies { get; internal set; }
    }
}