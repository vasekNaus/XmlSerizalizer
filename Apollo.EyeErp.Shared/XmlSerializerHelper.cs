using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared
{
    public static class XmlSerializerHelper
    {
        public static void SerializeToXml(string filePath, Task data)
        {
            var serializer = new XmlSerializer(typeof(Task));

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                Encoding = new UTF8Encoding(false) 
            };

            using (var stream = new FileStream(filePath, FileMode.Create))
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, data);
            }
        }

        public static string SerializeToXml(Task data)
        {
            var serializer = new XmlSerializer(typeof(Task));

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

        public static Task DeserializeFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(Task));
            using (var reader = new StreamReader(filePath))
            {
                return (Task)serializer.Deserialize(reader);
            }
        }

        public static Task DeserializeFromXmlString(string xml)
        {
            var serializer = new XmlSerializer(typeof(Task));
            using (var reader = new StringReader(xml))
            {
                return (Task)serializer.Deserialize(reader);
            }
        }
    }
}
