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
        public static void SerializeToXml(string filePath, Task data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            // Use the actual runtime type for proper polymorphic serialization
            var serializer = new XmlSerializer(data.GetType(), GetExtraTypes());

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                Encoding = new UTF8Encoding(false)
            };

            using (var stream = new FileStream(filePath, FileMode.Create))
            using (var writer = XmlWriter.Create(stream, settings))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", ""); 
                serializer.Serialize(writer, data, ns);
            }
        }

        public static string SerializeToXml(Task data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var serializer = new XmlSerializer(data.GetType(), GetExtraTypes());

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
                ns.Add("", ""); 
                serializer.Serialize(xmlWriter, data, ns);
                return stringWriter.ToString();
            }
        }

        public static Task DeserializeFromXml(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("XML file not found", filePath);

            
            var type = DetermineTypeFromXmlFile(filePath);
            var serializer = new XmlSerializer(type, GetExtraTypes());

            using (var reader = new StreamReader(filePath))
            {
                return (Task)serializer.Deserialize(reader);
            }
        }

        public static Task DeserializeFromXmlString(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                throw new ArgumentException("XML string cannot be empty", nameof(xml));

            
            var type = DetermineTypeFromXmlString(xml);
            var serializer = new XmlSerializer(type, GetExtraTypes());

            using (var reader = new StringReader(xml))
            {
                return (Task)serializer.Deserialize(reader);
            }
        }

        private static Type[] GetExtraTypes()
        {
            
            return new Type[]
            {
                typeof(TaskEntrance),
                //typeof(TaskOperation),
                //typeof(TaskInstrument)
                
            };
        }

        private static Type DetermineTypeFromXmlFile(string filePath)
        {
            using (var reader = XmlReader.Create(filePath))
            {
                if (reader.ReadToFollowing("Task"))
                {
                    if (reader.GetAttribute("xsi:type") != null)
                    {
                        string typeName = reader.GetAttribute("xsi:type");
                        switch (typeName)
                        {
                            case "TaskEntrance": return typeof(TaskEntrance);
                            //case "TaskOperation": return typeof(TaskOperation);
                            //case "TaskInstrument": return typeof(TaskInstrument);
                            default: return typeof(Task);
                        }
                    }
                }
            }
            return typeof(Task);
        }

        private static Type DetermineTypeFromXmlString(string xml)
        {
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                if (reader.ReadToFollowing("Task"))
                {
                    if (reader.GetAttribute("xsi:type") != null)
                    {
                        string typeName = reader.GetAttribute("xsi:type");
                        switch (typeName)
                        {
                            case "TaskEntrance": return typeof(TaskEntrance);
                            //case "TaskOperation": return typeof(TaskOperation);
                            //case "TaskInstrument": return typeof(TaskInstrument);
                            default: return typeof(Task);
                        }
                    }
                }
            }
            return typeof(Task);
        }

        private sealed class StringWriterWithEncoding : StringWriter
        {
            private readonly Encoding _encoding;

            public StringWriterWithEncoding(Encoding encoding)
            {
                _encoding = encoding;
            }

            public override Encoding Encoding => _encoding;
        }
    }
}