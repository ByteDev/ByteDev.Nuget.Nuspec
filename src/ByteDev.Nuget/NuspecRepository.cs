using System;

namespace ByteDev.Nuget
{
    public class NuspecRepository
    {
        public string Type { get; set; }

        public Uri Url { get; set; }

        public string Branch { get; set; }

        public string Commit { get; set; }
    }
}