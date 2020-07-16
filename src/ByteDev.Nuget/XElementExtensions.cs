using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ByteDev.Nuget
{
    internal static class XElementExtensions
    {
        public static IEnumerable<XElement> GetChildElements(this XElement source, string elementName)
        {
            return source?.Descendants().Where(d => d.Name.LocalName == elementName);
        }

        public static XElement GetChildElement(this XElement source, string elementName)
        {
            return source?.Descendants().SingleOrDefault(d => d.Name.LocalName == elementName);
        }

        public static string GetChildElementValue(this XElement source, string elementName)
        {
            return GetChildElement(source, elementName)?.Value;
        }

        public static Uri GetChildElementUriValue(this XElement source, string elementName)
        {
            var value = GetChildElementValue(source, elementName);

            if (string.IsNullOrEmpty(value))
                return null;

            return new Uri(value);
        }

        public static bool GetChildElementBoolValue(this XElement source, string elementName)
        {
            var value = GetChildElementValue(source, elementName);

            if (string.IsNullOrEmpty(value))
                return false;

            if (bool.TryParse(value, out bool result))
                return result;

            return false;
        }


        public static string GetChildElementAttributeValue(this XElement source, string elementName, string attributeName)
        {
            XElement element = GetChildElement(source, elementName);

            return element?
                .Attributes(attributeName)
                .SingleOrDefault()?
                .Value;
        }

        public static string GetAttributeValue(this XElement source, string attributeName)
        {
            return source?.Attribute(attributeName)?.Value;
        }

        public static Uri GetAttributeUriValue(this XElement source, string attributeName)
        {
            var value = GetAttributeValue(source, attributeName);

            if (string.IsNullOrEmpty(value))
                return null;

            return new Uri(value);
        }
    }
}