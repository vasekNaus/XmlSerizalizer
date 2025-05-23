using Apollo.EyeErp.Shared.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Utilities
{

  public class XmlSerializerHelper2
  {
    private Dictionary<Type, XmlSerializer> serializers;

    public XmlSerializerHelper2()
    {
      this.serializers = new Dictionary<Type, XmlSerializer>();
    }

        private XmlSerializer GetOrCreateSerializer<T>()
        {
            if (!this.serializers.TryGetValue(typeof(T), out var serializer))
            {
                serializer = new XmlSerializer(typeof(T));
                this.serializers.Add(typeof(T), serializer);
            }
            return serializer;
        }

        public string SerializeToXmlString<T>(T data)
    {


            var serializer = GetOrCreateSerializer<T>();

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
        public  void SerializeToXml<T>(string filePath, T data)
        {
            string xmlContent = SerializeToXmlString(data);
            File.WriteAllText(filePath, xmlContent, Encoding.UTF8);
        }

        public  T DeserializeFromXml<T>(string filePath)
        {
            var serializer = GetOrCreateSerializer<T>();
            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }


  public sealed class StringWriterWithEncoding : StringWriter
  {
    private readonly Encoding _encoding;
    public StringWriterWithEncoding(Encoding encoding) { _encoding = encoding; }
    public override Encoding Encoding => _encoding;
  }
}
