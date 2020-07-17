namespace ByteDev.Nuget
{
    internal static class ExThrower
    {
        public static void ThrowMissingElement(string elementName)
        {
            throw new InvalidNuspecException($"Nuspec is missing mandatory element: '{elementName}'.");
        }
    }
}