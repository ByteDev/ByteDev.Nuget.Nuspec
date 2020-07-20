using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ByteDev.Nuget.Nuspec
{
    internal static class XElementExtensions
    {
        public static IEnumerable<XElement> GetChildElements(this XElement source, string elementName, XNamespace ns = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(elementName))
                throw new ArgumentException("Element name was null or empty.", nameof(elementName));

            if (ns == null)
                return source.Elements().Where(e => e.Name.LocalName == elementName);

            return source.Elements(ns + elementName);
        }

        public static XElement GetChildElement(this XElement source, string elementName, XNamespace ns = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(elementName))
                throw new ArgumentException("Element name was null or empty.", nameof(elementName));

            if (ns == null)
                return source.Elements().SingleOrDefault(e => e.Name.LocalName == elementName);

            return source.Element(ns + elementName);
        }

        public static string GetChildElementValue(this XElement source, string elementName)
        {
            return GetChildElement(source, elementName)?.Value;
        }

        public static string GetAttributeValue(this XElement source, string attributeName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(attributeName))
                throw new ArgumentException("Attribute name was null or empty.", nameof(attributeName));

            return source.Attribute(attributeName)?.Value;
        }
    }
}