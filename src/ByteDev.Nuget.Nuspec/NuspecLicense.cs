namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Represents a license file.
    /// </summary>
    public class NuspecLicense
    {
        /// <summary>
        /// File path or SPDX license identifier.
        /// </summary>
        public string PathOrId { get; internal set; }

        /// <summary>
        /// License type.
        /// </summary>
        public string Type { get; internal set; }
    }
}