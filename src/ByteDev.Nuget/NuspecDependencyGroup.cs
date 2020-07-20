using System.Collections.Generic;

namespace ByteDev.Nuget
{
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
}