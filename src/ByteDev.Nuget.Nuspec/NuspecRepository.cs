using System;

namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents repository information.
    /// </summary>
    public class NuspecRepository
    {
        /// <summary>
        /// Type (e.g. git).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// URL that points to the repository.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Branch name.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Commit hash.
        /// </summary>
        public string Commit { get; set; }
    }
}