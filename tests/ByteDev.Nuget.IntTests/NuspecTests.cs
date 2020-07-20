using System;
using System.Linq;
using ByteDev.Collections;
using NUnit.Framework;

namespace ByteDev.Nuget.IntTests
{
    [TestFixture]
    public class NuspecTests
    {
        [Test]
        public void WhenMissingMetaDataId_ThenThrowException()
        {
            Assert.Throws<InvalidNuspecException>(() => CreateSut(TestFiles.MissingId));
        }

        [Test]
        public void WhenMissingMetaDataVersion_ThenThrowException()
        {
            Assert.Throws<InvalidNuspecException>(() => CreateSut(TestFiles.MissingVersion));
        }

        [Test]
        public void WhenMissingMetaDataAuthors_ThenThrowException()
        {
            Assert.Throws<InvalidNuspecException>(() => CreateSut(TestFiles.MissingAuthors));
        }

        [Test]
        public void WhenMissingMetaDataDescription_ThenThrowException()
        {
            Assert.Throws<InvalidNuspecException>(() => CreateSut(TestFiles.MissingDescription));
        }

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
            Assert.That(sut.MetaData.License, Is.EqualTo("LICENSE"));
            Assert.That(sut.MetaData.LicenseType, Is.EqualTo("file"));
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
        public void WhenMetaDataMandatoryOnly_ThenSetDefaults()
        {
            var sut = CreateSut(TestFiles.MandatoryOnly);

            Assert.That(sut.MetaData.MinClientVersion, Is.Null);
            Assert.That(sut.MetaData.Owners, Is.Empty);
            Assert.That(sut.MetaData.ProjectUrl, Is.Null);
            Assert.That(sut.MetaData.License, Is.Null);
            Assert.That(sut.MetaData.LicenseType, Is.Null);
            Assert.That(sut.MetaData.Icon, Is.Null);
            Assert.That(sut.MetaData.RequireLicenseAcceptance, Is.False);
            Assert.That(sut.MetaData.DevelopmentDependency, Is.False);
            Assert.That(sut.MetaData.ReleaseNotes, Is.Null);
            Assert.That(sut.MetaData.Copyright, Is.Null);
            Assert.That(sut.MetaData.Language, Is.Null);
            Assert.That(sut.MetaData.Tags, Is.Empty);
            Assert.That(sut.MetaData.Repository, Is.Null);
            Assert.That(sut.MetaData.Title, Is.Null);
        }

        [Test]
        public void WhenMetaDataDependenciesNotPresent_ThenSetToEmpty()
        {
            var sut = CreateSut(TestFiles.MandatoryOnly);

            Assert.That(sut.MetaData.Dependencies, Is.Null);
        }

        [Test]
        public void WhenMetaDataDependenciesPresent_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            var group = sut.MetaData.Dependencies.Groups.Single();

            Assert.That(group.TargetFramework, Is.EqualTo(".NETStandard2.0"));
            Assert.That(group.Dependencies.First().Id, Is.EqualTo("Microsoft.Extensions.Configuration"));
            Assert.That(group.Dependencies.First().Version, Is.EqualTo("2.0.0"));
            Assert.That(group.Dependencies.Second().Id, Is.EqualTo("Microsoft.Extensions.DependencyInjection"));
            Assert.That(group.Dependencies.Second().Version, Is.EqualTo("3.0.0"));
        }

        [Test]
        public void WhenMetaDataDependenciesAreNotInGroups_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.DependenciesNoGroups);

            var noGroupDependencies = sut.MetaData.Dependencies.NoGroupDependencies;

            Assert.That(noGroupDependencies.First().Id, Is.EqualTo("Newtonsoft.Json"));
            Assert.That(noGroupDependencies.First().Version, Is.EqualTo("12.0.3"));

            Assert.That(noGroupDependencies.Second().Id, Is.EqualTo("ByteDev.Collections"));
            Assert.That(noGroupDependencies.Second().Version, Is.EqualTo("2.0.0"));
        }

        [Test]
        public void WhenFilesNotPresent_ThenSetToEmpty()
        {
            var sut = CreateSut(TestFiles.MandatoryOnly);

            Assert.That(sut.Files, Is.Empty);
        }

        [Test]
        public void WhenFilesPresent_ThenSetProperty()
        {
            var sut = CreateSut(TestFiles.Everything);

            Assert.That(sut.Files.First().Src, Is.EqualTo(@"..\src\ByteDev.Nuget\bin\Release\netstandard2.0\ByteDev.Nuget.dll"));
            Assert.That(sut.Files.First().Target, Is.EqualTo(@"lib\netstandard2.0"));
            Assert.That(sut.Files.First().Exclude, Is.Null);

            Assert.That(sut.Files.Second().Src, Is.EqualTo(@"..\images\icon.png"));
            Assert.That(sut.Files.Second().Target, Is.EqualTo(@"images\"));
            Assert.That(sut.Files.Second().Exclude, Is.Null);

            Assert.That(sut.Files.Third().Src, Is.EqualTo(@"..\docs\*.*"));
            Assert.That(sut.Files.Third().Target, Is.EqualTo(@"docs\"));
            Assert.That(sut.Files.Third().Exclude, Is.EqualTo(@"..\docs\**\*.log"));
        }

        [Test]
        public void WhenPackageTypesNotPresent_ThenSetToEmpty()
        {
            var sut = CreateSut(TestFiles.MandatoryOnly);

            Assert.That(sut.MetaData.PackageTypes, Is.Empty);
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

        private static Nuspec CreateSut(string filePath)
        {
            return Nuspec.Load(filePath);
        }
    }
}