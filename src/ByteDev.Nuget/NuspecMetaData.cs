using System;
using System.Collections.Generic;

namespace ByteDev.Nuget
{
    public class NuspecMetaData
    {
        #region Mandatory

        /// <summary>
        /// The case-insensitive package identifier, which must be unique across nuget.org or whatever
        /// gallery the package resides in.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The version of the package, following the major.minor.patch pattern.
        /// Version numbers may include a pre-release suffix.
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// A description of the package for UI display.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Collection of packages authors, matching the profile names on nuget.org.
        /// </summary>
        public IEnumerable<string> Authors { get; set; }

        #endregion

        #region Optional

        /// <summary>
        /// Collection of the package creators using profile names on nuget.org.
        /// This is often the same list as in authors, and is ignored when uploading the package to nuget.org.
        /// </summary>
        public IEnumerable<string> Owners { get; set; }

        /// <summary>
        /// A URL for the package's home page, often shown in UI displays as well as nuget.org.
        /// </summary>
        public Uri ProjectUrl { get; set; }

        /// <summary>
        /// License file path or SPDX license identifier.
        /// </summary>
        public string License { get; set; }

        public string LicenseType { get; set; }

        /// <summary>
        /// It is a path to an image file within the package, often shown in UIs like
        /// nuget.org as the package icon. 
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Specifys whether the client must prompt the consumer to accept the package license
        /// before installing the package.
        /// </summary>
        public bool RequireLicenseAcceptance { get; set; }

        /// <summary>
        /// Specifying whether the package is be marked as a development-only-dependency, which prevents
        /// the package from being included as a dependency in other packages.
        /// </summary>
        public bool DevelopmentDependency { get; set; }

        /// <summary>
        /// A description of the changes made in this release of the package, often used in UI like
        /// the Updates tab of the Visual Studio Package Manager in place of the package description.
        /// </summary>
        public string ReleaseNotes { get; set; }

        /// <summary>
        /// Copyright details for the package.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// The locale ID for the package.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Collection of tags (keywords) that describe the package and aid discoverability of packages
        /// through search and filtering.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Details the repository that built the .nupkg.
        /// </summary>
        public NuspecRepository Repository { get; set; }

        /// <summary>
        /// A human-friendly title of the package which may be used in some UI displays.
        /// (nuget.org and the Package Manager in Visual Studio do not show title)
        /// </summary>
        public string Title { get; set; }




        // licenseUrl - deprecated
        // iconUrl - deprecated
        // summary - deprecated (use description)

        #endregion
    }
}