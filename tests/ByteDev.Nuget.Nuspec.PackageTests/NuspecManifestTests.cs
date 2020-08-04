using System;
using System.IO;
using System.Linq;
using ByteDev.Collections;
using NUnit.Framework;

namespace ByteDev.Nuget.Nuspec.PackageTests
{
    [TestFixture]
    public class NuspecManifestTests
    {
        [Test]
        public void WhenFileCannotBeFound_ThenThrowException()
        {
            Assert.Throws<FileNotFoundException>(() => CreateSut(@"C:\e4992b8d157a422ca1859133985def3f.nuspec"));
        }

        #region Metadata

        [Test]
        public void WhenMetaDataMandatoryExists_ThenSetProperties()
        {
            var sut = CreateSut(TestFiles.Everything);

            Assert.That(sut.MetaData.Id, Is.EqualTo("TestId"));
            Assert.That(sut.MetaData.Version, Is.EqualTo("1.2.3"));
            Assert.That(sut.MetaData.Description, Is.EqualTo(".NET Standard library of nuget related functionality."));
            Assert.That(sut.MetaData.Authors.First(), Is.EqualTo("John Smith"));
            Assert.That(sut.MetaData.Authors.Second(), Is.EqualTo("Bob Smith"));
        }

        [Test]
        public void WhenMetaDataOptionalExists_ThenSetProperties()
        {
            var sut = CreateSut(TestFiles.Everything);

            Assert.That(sut.MetaData.MinClientVersion, Is.EqualTo("100.0.0.1"));
            Assert.That(sut.MetaData.Owners.First(), Is.EqualTo("Donald Trump"));
            Assert.That(sut.MetaData.Owners.Second(), Is.EqualTo("Joe Biden"));
            Assert.That(sut.MetaData.ProjectUrl, Is.EqualTo(new Uri("https://github.com/ByteDev/ByteDev.Nuget")));
            Assert.That(sut.MetaData.License.PathOrId, Is.EqualTo("LICENSE"));
            Assert.That(sut.MetaData.License.Type, Is.EqualTo("file"));
            Assert.That(sut.MetaData.Icon, Is.EqualTo(@"images\icon.png"));
            Assert.That(sut.MetaData.RequireLicenseAcceptance, Is.True);
            Assert.That(sut.MetaData.DevelopmentDependency, Is.True);
            Assert.That(sut.MetaData.ReleaseNotes, Is.EqualTo("some release notes"));
            Assert.That(sut.MetaData.Copyright, Is.EqualTo("Copyright 2020"));
            Assert.That(sut.MetaData.Language, Is.EqualTo("en"));
            Assert.That(sut.MetaData.Title, Is.EqualTo("TestTitle"));

            Assert.That(sut.MetaData.Tags.First(), Is.EqualTo("nuget"));
            Assert.That(sut.MetaData.Tags.Second(), Is.EqualTo("nuspec"));
            Assert.That(sut.MetaData.Tags.Third(), Is.EqualTo("package"));
            
            Assert.That(sut.MetaData.Repository.Type, Is.EqualTo("git"));
            Assert.That(sut.MetaData.Repository.Url, Is.EqualTo(new Uri("https://github.com/NuGet/NuGet.Client.git")));
            Assert.That(sut.MetaData.Repository.Branch, Is.EqualTo("dev"));
            Assert.That(sut.MetaData.Repository.Commit, Is.EqualTo("e1c65e4524cd70ee6e22abe33e6cb6ec73938cb3"));
        }

        [Test]
        public void WhenDependenciesPresent_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            var group = sut.MetaData.Dependencies.Groups.Single();

            Assert.That(group.TargetFramework, Is.EqualTo(".NETStandard2.0"));

            Assert.That(group.Dependencies.First().Id, Is.EqualTo("Microsoft.Extensions.Configuration"));
            Assert.That(group.Dependencies.First().Version, Is.EqualTo("2.0.0"));
            Assert.That(group.Dependencies.First().IncludeTags.First(), Is.EqualTo("contentFiles"));
            Assert.That(group.Dependencies.First().IncludeTags.Second(), Is.EqualTo("runtime"));
            Assert.That(group.Dependencies.First().ExcludeTags.First(), Is.EqualTo("native"));
            Assert.That(group.Dependencies.First().ExcludeTags.Second(), Is.EqualTo("compile"));
            
            Assert.That(group.Dependencies.Second().Id, Is.EqualTo("Microsoft.Extensions.DependencyInjection"));
            Assert.That(group.Dependencies.Second().Version, Is.EqualTo("3.0.0"));
        }

        [Test]
        public void WhenReferenceGroupsPresent_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            var groups = sut.MetaData.References.Groups.ToList();

            Assert.That(groups.First().TargetFramework, Is.Null);
            Assert.That(groups.First().Files.Single().FileName, Is.EqualTo("a.dll"));

            Assert.That(groups.Second().TargetFramework, Is.EqualTo("net45"));
            Assert.That(groups.Second().Files.Single().FileName, Is.EqualTo("b45.dll"));

            Assert.That(groups.Third().TargetFramework, Is.EqualTo("netcore45"));
            Assert.That(groups.Third().Files.First().FileName, Is.EqualTo("bcore45.dll"));
            Assert.That(groups.Third().Files.Second().FileName, Is.EqualTo("bcore451.dll"));
        }

        [Test]
        public void WhenFrameworkAssembliesPresent_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            var assemblies = sut.MetaData.FrameworkAssemblies.ToList();

            Assert.That(assemblies.First().AssemblyName, Is.EqualTo("System.Net"));
            Assert.That(assemblies.First().TargetFramework, Is.Null);

            Assert.That(assemblies.Second().AssemblyName, Is.EqualTo("System.ServiceModel"));
            Assert.That(assemblies.Second().TargetFramework, Is.EqualTo("net40"));
        }

        [Test]
        public void WhenPackageTypesPresent_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            Assert.That(sut.MetaData.PackageTypes.First().Name, Is.EqualTo("Dependency"));
            Assert.That(sut.MetaData.PackageTypes.First().Version, Is.Null);

            Assert.That(sut.MetaData.PackageTypes.Second().Name, Is.EqualTo("DotnetTool"));
            Assert.That(sut.MetaData.PackageTypes.Second().Version, Is.EqualTo("1.0.0"));

            Assert.That(sut.MetaData.PackageTypes.Third().Name, Is.EqualTo("Template"));
            Assert.That(sut.MetaData.PackageTypes.Third().Version, Is.EqualTo("1.0.0"));
        }

        [Test]
        public void WhenContentFilesPresents_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            var contentFiles = sut.MetaData.ContentFiles.ToList();

            Assert.That(contentFiles.First().IncludeFiles, Is.EqualTo("cs/net45/scripts/*"));
            Assert.That(contentFiles.First().ExcludeFiles.First(), Is.EqualTo("**/*.exe"));
            Assert.That(contentFiles.First().ExcludeFiles.Second(), Is.EqualTo("**/*.tmp"));
            Assert.That(contentFiles.First().BuildAction, Is.Null);
            Assert.That(contentFiles.First().CopyToOutput, Is.False);
            Assert.That(contentFiles.First().Flatten, Is.False);

            Assert.That(contentFiles.Second().IncludeFiles, Is.EqualTo("cs/uap/config/config.xml"));
            Assert.That(contentFiles.Second().ExcludeFiles, Is.Empty);
            Assert.That(contentFiles.Second().BuildAction, Is.EqualTo("None"));
            Assert.That(contentFiles.Second().CopyToOutput, Is.True);
            Assert.That(contentFiles.Second().Flatten, Is.True);
        }

        #endregion

        #region Files

        [Test]
        public void WhenFilesPresent_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            Assert.That(sut.Files.First().Src, Is.EqualTo(@"..\src\ByteDev.Nuget\bin\Release\netstandard2.0\ByteDev.Nuget.dll"));
            Assert.That(sut.Files.First().Target, Is.EqualTo(@"lib\netstandard2.0"));
            Assert.That(sut.Files.First().ExcludeFiles, Is.Empty);

            Assert.That(sut.Files.Second().Src, Is.EqualTo(@"..\images\icon.png"));
            Assert.That(sut.Files.Second().Target, Is.EqualTo(@"images\"));
            Assert.That(sut.Files.Second().ExcludeFiles, Is.Empty);

            Assert.That(sut.Files.Third().Src, Is.EqualTo(@"..\docs\*.*"));
            Assert.That(sut.Files.Third().Target, Is.EqualTo(@"docs\"));
            Assert.That(sut.Files.Third().ExcludeFiles.First(), Is.EqualTo(@"..\docs\**\*.log"));
            Assert.That(sut.Files.Third().ExcludeFiles.Second(), Is.EqualTo(@"..\docs\**\*.txt"));
        }

        #endregion

        private static NuspecManifest CreateSut(string filePath)
        {
            return NuspecManifest.Load(filePath);
        }
    }
}