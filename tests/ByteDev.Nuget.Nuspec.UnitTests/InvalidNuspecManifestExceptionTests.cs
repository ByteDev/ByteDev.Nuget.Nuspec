using System;
using NUnit.Framework;

namespace ByteDev.Nuget.Nuspec.UnitTests
{
    [TestFixture]
    public class InvalidNuspecManifestExceptionTests
    {
        [Test]
        public void WhenNoArgs_ThenSetMessageToDefault()
        {
            var sut = new InvalidNuspecManifestException();

            Assert.That(sut.Message, Is.EqualTo("Nuspec manifest file is invalid."));
        }

        [Test]
        public void WhenMessageSpecified_ThenSetMessage()
        {
            var sut = new InvalidNuspecManifestException("Some message.");

            Assert.That(sut.Message, Is.EqualTo("Some message."));
        }

        [Test]
        public void WhenMessageAndInnerExSpecified_ThenSetMessageAndInnerEx()
        {
            var innerException = new Exception();

            var sut = new InvalidNuspecManifestException("Some message.", innerException);

            Assert.That(sut.Message, Is.EqualTo("Some message."));
            Assert.That(sut.InnerException, Is.SameAs(innerException));
        }
    }
}