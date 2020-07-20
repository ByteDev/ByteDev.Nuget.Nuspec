namespace ByteDev.Nuget.IntTests
{
    public static class TestFiles
    {
        private const string BasePath = @"TestFiles\";

        public static readonly string Everything = BasePath + "Everything.Xml";

        public static readonly string MandatoryOnly = BasePath + "MandatoryOnly.xml";

        public static readonly string MissingAuthors = BasePath + "MissingAuthors.xml";
        public static readonly string MissingDescription = BasePath + "MissingDescription.xml";
        public static readonly string MissingId = BasePath + "MissingId.xml";
        public static readonly string MissingVersion = BasePath + "MissingVersion.xml";
        
        public static readonly string DependenciesNoGroups = BasePath + "DependenciesNoGroups.xml";
    }
}