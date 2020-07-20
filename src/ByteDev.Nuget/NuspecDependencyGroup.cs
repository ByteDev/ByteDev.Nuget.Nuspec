using System.Collections.Generic;

namespace ByteDev.Nuget
{
    /// <summary>
    /// Represents a dependency group. Dependencies in the group are installed together
    /// when the target framework is compatible with the project's framework profile.
    /// </summary>
    public class NuspecDependencyGroup
    {
        private IList<NuspecDependency> _dependencies;

        /// <summary>
        /// Target framework.
        /// </summary>
        public string TargetFramework { get; internal set; }

        /// <summary>
        /// Dependencies for the group.
        /// </summary>
        public IList<NuspecDependency> Dependencies
        {
            get => _dependencies ?? (_dependencies = new List<NuspecDependency>());
            internal set => _dependencies = value;
        }
    }
}