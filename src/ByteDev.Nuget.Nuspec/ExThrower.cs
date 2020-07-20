namespace ByteDev.Nuget.Nuspec
{
    internal static class ExThrower
    {
        public static void ThrowMissingRootElement()
        {
            throw new InvalidNuspecManifestException("Nuspec manifest is missing root element: 'package'.");
        }

        public static void ThrowMissingElement(string elementName)
        {
            throw new InvalidNuspecManifestException($"Nuspec manifest is missing mandatory element: '{elementName}'.");
        }
    }
}