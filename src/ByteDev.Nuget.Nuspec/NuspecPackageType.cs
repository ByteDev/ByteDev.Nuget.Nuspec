namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents a package type.
    /// </summary>
    public class NuspecPackageType
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Version.
        /// </summary>
        public string Version { get; internal set; }
    }
}