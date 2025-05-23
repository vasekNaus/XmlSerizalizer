using Apollo.EyeErp.Shared.Model;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Utilities
{
    public static class XmlSerializerHelper
    {
        private static readonly Type[] extraTypes = new Type[]
        {
            typeof(TaskEntrance),
            typeof(TaskOperation),
            typeof(TaskInstrument)
        };

        public static void SerializeToXml<T>(string filePath, T data)
        {
            string xmlContent = SerializeToXmlString(data);
            File.WriteAllText(filePath, xmlContent, Encoding.UTF8);
        }

        public static string SerializeToXmlString<T>(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var serializer = new XmlSerializer(typeof(T), extraTypes);

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                Encoding = new UTF8Encoding(false)
            };

            using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
            using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                ns.Add("", "");

                serializer.Serialize(xmlWriter, data, ns);
                return stringWriter.ToString();
            }
        }

        public static T DeserializeFromXml<T>(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("XML file not found", filePath);

            var serializer = new XmlSerializer(typeof(T), extraTypes);
            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        private sealed class StringWriterWithEncoding : StringWriter
        {
            private readonly Encoding _encoding;
            public StringWriterWithEncoding(Encoding encoding) { _encoding = encoding; }
            public override Encoding Encoding => _encoding;
        }
    }
}
