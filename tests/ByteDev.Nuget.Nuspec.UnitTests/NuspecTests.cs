using System;
using NUnit.Framework;

namespace ByteDev.Nuget.Nuspec.UnitTests
{
    [TestFixture]
    public class NuspecTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = new NuspecManifest(null));
            }
        }
    }
}