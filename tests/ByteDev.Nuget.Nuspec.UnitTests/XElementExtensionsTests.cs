using System;
using System.Linq;
using System.Xml.Linq;
using ByteDev.Collections;
using NUnit.Framework;

namespace ByteDev.Nuget.Nuspec.UnitTests
{
    [TestFixture]
    public class XElementExtensionsTests
    {
        private const string XmlNs = "http://schemas.microsoft.com/packaging/2011/08/nuspec.xsd";

        private static XElement CreateSut(string xml)
        {
            var template = @"<?xml version=""1.0"" encoding=""utf-8""?>" + Environment.NewLine +
                           @"<AppRoot xmlns=""{0}"">{1}</AppRoot>";

            var text = string.Format(template, XmlNs, xml);

            return XDocument.Parse(text).Root;
        }

        [TestFixture]
        public class GetChildElements : XElementExtensionsTests
        {
            [Test]
            public void WhenSutIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => XElementExtensions.GetChildElements(null, "A"));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenElementNameIsNullOrEmpty_ThenReturnEmpty(string elementName)
            {
                var sut = CreateSut("<A>1</A><A>2</A>");

                Assert.Throws<ArgumentException>(() => sut.GetChildElements(elementName));
            }

            [Test]
            public void WhenElementDoesNotExist_ThenReturnEmpty()
            {
                var sut = CreateSut(string.Empty);

                var result = sut.GetChildElements("A");
                
                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenElementsExist_ThenReturnElements()
            {
                var sut = CreateSut("<A>1</A><A>2</A>");

                var result = sut.GetChildElements("A").ToList();

                Assert.That(result.First().Value, Is.EqualTo("1"));
                Assert.That(result.Second().Value, Is.EqualTo("2"));
            }
        }

        [TestFixture]
        public class GetChildElement : XElementExtensionsTests
        {
            [Test]
            public void WhenSutIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => XElementExtensions.GetChildElement(null, "A"));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenElementNameIsNullOrEmpty_ThenReturnNull(string elementName)
            {
                var sut = CreateSut("<A>1</A><A>2</A>");

                Assert.Throws<ArgumentException>(() => sut.GetChildElement(elementName));
            }

            [Test]
            public void WhenElementDoesNotExist_ThenReturnNull()
            {
                var sut = CreateSut("<A>1</A><B>2</B>");

                var result = sut.GetChildElement("C");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenElementExists_ThenReturnElement()
            {
                var sut = CreateSut("<A>1</A><B>2</B>");

                var result = sut.GetChildElement("B");

                Assert.That(result.Value, Is.EqualTo("2"));
            }
        }

        [TestFixture]
        public class GetChildElementValue : XElementExtensionsTests
        {
            [Test]
            public void WhenSutIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => XElementExtensions.GetChildElementValue(null, "A"));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenElementNameIsNullOrEmpty_ThenReturnNull(string elementName)
            {
                var sut = CreateSut("<A>1</A><A>2</A>");

                Assert.Throws<ArgumentException>(() => sut.GetChildElementValue(elementName));
            }

            [Test]
            public void WhenElementDoesNotExist_ThenReturnNull()
            {
                var sut = CreateSut("<A>1</A><B>2</B>");

                var result = sut.GetChildElementValue("C");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenElementExists_ThenReturnValue()
            {
                var sut = CreateSut("<A>1</A><B>2</B>");

                var result = sut.GetChildElementValue("B");

                Assert.That(result, Is.EqualTo("2"));
            }
        }

        [TestFixture]
        public class GetAttributeValue : XElementExtensionsTests
        {
            [Test]
            public void WhenSutIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => XElementExtensions.GetAttributeValue(null, "A"));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenAttributeNameIsNullOrEmpty_ThenThrowException(string name)
            {
                var sut = CreateSut("<A>1</A><B>2</B>");

                var element = sut.GetChildElement("B");

                Assert.Throws<ArgumentException>(() => element.GetAttributeValue(name));
            }

            [Test]
            public void WhenAttributeDoesNotExist_ThenReturnNull()
            {
                var sut = CreateSut("<A>1</A><B>2</B>");

                var result = sut.GetChildElement("B").GetAttributeValue("type");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenAttributeExists_ThenReturnValue()
            {
                var sut = CreateSut(@"<A>1</A><B type=""int"">2</B>");

                var result = sut.GetChildElement("B").GetAttributeValue("type");

                Assert.That(result, Is.EqualTo("int"));
            }
        }
    }
}