using Apollo.EyeErp.Shared.Model;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared
{
    public static class XmlSerializerHelper
    {
        private static readonly Type[] KnownDerivedTypes = new Type[]
        {
            typeof(TaskEntrence)
        };

        public static void SerializeToXml(string filePath, Task data)
        {
            try
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("File path cannot be empty", nameof(filePath));

                var serializer = new XmlSerializer(data.GetType(), KnownDerivedTypes);

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Indent = true,
                    Encoding = new UTF8Encoding(false)
                };

                // Ensure directory exists
                var directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception ex)
            {
                throw new XmlSerializationException($"Failed to serialize object to file '{filePath}'", ex);
            }
        }

        public static string SerializeToXml(Task data)
        {
            try
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var serializer = new XmlSerializer(data.GetType(), KnownDerivedTypes);

                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Indent = true
                };

                using (var stringWriter = new StringWriter())
                using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(xmlWriter, data);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new XmlSerializationException("Failed to serialize object to XML string", ex);
            }
        }

        public static Task DeserializeFromXml(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("File path cannot be empty", nameof(filePath));

                if (!File.Exists(filePath))
                    throw new FileNotFoundException("XML file not found", filePath);

                var serializer = new XmlSerializer(typeof(Task), KnownDerivedTypes);
                using (var reader = new StreamReader(filePath))
                {
                    return (Task)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new XmlSerializationException($"Failed to deserialize from file '{filePath}'", ex);
            }
        }

        public static Task DeserializeFromXmlString(string xml)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(xml))
                    throw new ArgumentException("XML string cannot be empty", nameof(xml));

                var serializer = new XmlSerializer(typeof(Task), KnownDerivedTypes);
                using (var reader = new StringReader(xml))
                {
                    return (Task)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new XmlSerializationException("Failed to deserialize from XML string", ex);
            }
        }
    }

    public class XmlSerializationException : Exception
    {
        public XmlSerializationException(string message) : base(message) { }
        public XmlSerializationException(string message, Exception innerException) : base(message, innerException) { }
    }
}