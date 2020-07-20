using System.Collections.Generic;

namespace ByteDev.Nuget
{
    /// <summary>
    /// Represents a package dependency.
    /// </summary>
    public class NuspecDependency
    {
        /// <summary>
        /// The package ID of the dependency, such as "EntityFramework" and "NUnit",
        /// which is the name of the package nuget.org shows on a package page.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The range of versions acceptable as a dependency.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// List of include tags indicating of the dependency to include in the final package.
        /// </summary>
        public IEnumerable<string> Include { get; internal set; }

        /// <summary>
        /// List of exclude tags indicating of the dependency to include in the final package.
        /// </summary>
        public IEnumerable<string> Exclude { get; internal set; }

        /*
        Possible tags:
        Tag             Affected folders of the target
        --------------------------------------
        contentFiles 	Content
        runtime 	    Runtime, Resources, and FrameworkAssemblies
        compile 	    lib
        build 	        build (MSBuild props and targets)
        native 	        native
        none 	        No folders
        all 	        All folders
        */
    }
}