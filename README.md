[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Nuget.Nuspec?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Nuget-Nuspec/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Nuget.Nuspec.svg)](https://www.nuget.org/packages/ByteDev.Nuget.Nuspec)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Nuget.Nuspec/blob/master/LICENSE)

# ByteDev.Nuget.Nuspec

.NET Standard library for reading nuget nuspec manifest files.

## Installation

ByteDev.Nuget.Nuspec has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Nuget.Nuspec is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Nuget.Nuspec`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Nuget.Nuspec/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Nuget.Nuspec/blob/master/docs/RELEASE-NOTES.md).

## Usage

The primary type in the ByteDev.Nuget.Nuspec package is `NuspecManifest`.  

`NuspecManifest` can either be instantiated directly from an existing `XDocument` on it's constructor or by loading a nuspec file using the `Load` method.

```csharp
// Load a manifest from file
NuspecManifest nuspec = NuspecManifest.Load(@"C:\MyProj\MyApp.nuspec");

Console.WriteLine(nuspec.MetaData.Id);
Console.WriteLine(nuspec.MetaData.Version);
Console.WriteLine(nuspec.MetaData.Description);
Console.WriteLine(nuspec.MetaData.Authors.First());
Console.WriteLine(nuspec.Files.Count());
```

`NuspecManifest` will enforce the currently mandatory elements of a valid nuspec XML file. Upon any mandatory elements missing a `InvalidNuspecManifestException` will be thrown.

As of writing the minimum valid nuspec XML manifest contains a root `package` element with `metadata` child element with `id`, `version`, `description` and `authors` child elements.

Example minimum valid nuspec XML manifest:

```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2011/08/nuspec.xsd">
  <metadata>
    <id>MyTestPackage</id>
    <version>1.0.0</version>
    <description>My test package.</description>
    <authors>John Smith, Bob Smith</authors>
  </metadata>
</package>
```

### Not supported elements

The following `metadata` elements are not supported as they have now been deprecated:

- `licenseUrl` (use `license` instead)
- `iconUrl` (use `icon` instead)
- `summary` (use `description` instead)

If any exist in the nuspec manifest they will simply be ignored.
