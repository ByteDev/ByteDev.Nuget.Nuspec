using System.Collections.Generic;

namespace ByteDev.Nuget
{
    /// <summary>
    /// Represents a dependencies collection.
    /// </summary>
    public class NuspecDependencies
    {
        private IList<NuspecDependencyGroup> _groups;
        private IList<NuspecDependency> _noGroupDependencies;

        /// <summary>
        /// Dependency groups.
        /// </summary>
        public IList<NuspecDependencyGroup> Groups
        {
            get => _groups ?? (_groups = new List<NuspecDependencyGroup>());
            internal set => _groups = value;
        }

        /// <summary>
        /// Dependencies that exist outside of a group.
        /// </summary>
        public IList<NuspecDependency> NoGroupDependencies
        {
            get => _noGroupDependencies ?? (_noGroupDependencies = new List<NuspecDependency>());
            internal set => _noGroupDependencies = value;
        }
    }
}