namespace ByteDev.Nuget.Nuspec
{
    /// <summary>
    /// Framework assembly reference. Framework assemblies are those that are part of the
    /// .NET framework and should already be in the global assembly cache (GAC) for any given machine.
    /// </summary>
    public class NuspecFrameworkAssembly
    {
        /// <summary>
        /// The fully qualified assembly name.
        /// </summary>
        public string AssemblyName { get; internal set; }

        /// <summary>
        /// Specifies the target framework to which this reference applies.
        /// If omitted, indicates that the reference applies to all frameworks.
        /// </summary>
        public string TargetFramework { get; internal set; }
    }
}