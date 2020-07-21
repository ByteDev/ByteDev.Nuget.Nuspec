using System;
using System.Xml.Linq;
using NUnit.Framework;

namespace ByteDev.Nuget.Nuspec.UnitTests
{
    [TestFixture]
    public class NuspecManifestTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = new NuspecManifest(null));
            }

            [Test]
            public void WhenRootNameIsIncorrect_ThenThrowException()
            {
                var xml = @"<?xml version=""1.0"" encoding=""utf-8""?>" + Environment.NewLine +
                          @"<AppRoot></AppRoot>";

                var xDoc = XDocument.Parse(xml);

                var ex = Assert.Throws<InvalidNuspecManifestException>(() => _ = new NuspecManifest(xDoc));
                Assert.That(ex.Message, Is.EqualTo("Nuspec manifest is missing root element: 'package'."));
            }
        }

        [TestFixture]
        public class Load : NuspecManifestTests
        {
            [Test]
            public void WhenPathIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => NuspecManifest.Load(null));
            }
        }
    }
}