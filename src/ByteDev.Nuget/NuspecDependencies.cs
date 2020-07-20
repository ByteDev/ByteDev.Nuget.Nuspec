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

        public IList<NuspecDependencyGroup> Groups
        {
            get => _groups ?? (_groups = new List<NuspecDependencyGroup>());
            internal set => _groups = value;
        }

        public IList<NuspecDependency> NoGroupDependencies
        {
            get => _noGroupDependencies ?? (_noGroupDependencies = new List<NuspecDependency>());
            internal set => _noGroupDependencies = value;
        }
    }

    /// <summary>
    /// Represents a dependency group.
    /// </summary>
    public class NuspecDependencyGroup
    {
        private IList<NuspecDependency> _dependencies;

        public string TargetFramework { get; internal set; }

        public IList<NuspecDependency> Dependencies
        {
            get => _dependencies ?? (_dependencies = new List<NuspecDependency>());
            internal set => _dependencies = value;
        }
    }

    /// <summary>
    /// Represents a package dependency.
    /// </summary>
    public class NuspecDependency
    {
        public string Id { get; internal set; }

        public string Version { get; internal set; }
    }
}