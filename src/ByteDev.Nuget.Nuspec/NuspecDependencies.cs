using System.Collections.Generic;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents a dependencies collection.
    /// </summary>
    public class NuspecDependencies
    {
        private IEnumerable<NuspecDependencyGroup> _groups;
        private IEnumerable<NuspecDependency> _noGroupDependencies;

        /// <summary>
        /// Dependency groups.
        /// </summary>
        public IEnumerable<NuspecDependencyGroup> Groups
        {
            get => _groups ?? (_groups = new List<NuspecDependencyGroup>());
            internal set => _groups = value;
        }

        /// <summary>
        /// Dependencies that exist outside of a group.
        /// </summary>
        public IEnumerable<NuspecDependency> NoGroupDependencies
        {
            get => _noGroupDependencies ?? (_noGroupDependencies = new List<NuspecDependency>());
            internal set => _noGroupDependencies = value;
        }
    }
}