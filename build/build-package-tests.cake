#addin "nuget:?package=Cake.Incubator&version=5.1.0"
#tool "nuget:?package=NUnit.ConsoleRunner&version=3.11.1"
#tool "nuget:?package=GitVersion.CommandLine&version=5.2.4"
#load "ByteDev.Utilities.cake"

var solutionName = "ByteDev.Nuget.Nuspec.PackageTests";

var solutionFilePath = "../" + solutionName + ".sln";

var nugetSources = new[] {"https://api.nuget.org/v3/index.json"};

var target = Argument("target", "Default");

var configuration = GetBuildConfiguration();

Information("Configurtion: " + configuration);


Task("Clean")
    .Does(() =>
	{
		CleanBinDirectories();
		CleanObjDirectories();
	});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
		var settings = new NuGetRestoreSettings
		{
			Source = nugetSources
		};

		NuGetRestore(solutionFilePath, settings);
    });

Task("Build")
	.IsDependentOn("Restore")
    .Does(() =>
	{	
		var settings = new DotNetCoreBuildSettings()
        {
            Configuration = configuration
        };

        DotNetCoreBuild(solutionFilePath, settings);
	});

Task("NetCorePackageTests")
	.IsDependentOn("Build")
    .Does(() =>
    {
        var settings = new DotNetCoreTestSettings()
		{
			Configuration = configuration,
			NoBuild = true
		};

		DotNetCorePackageTests(settings);
    });
	
Task("Default")
	.IsDependentOn("NetCorePackageTests");

RunTarget(target);
