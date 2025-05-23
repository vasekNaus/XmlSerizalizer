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

    public string SerializeToXmlString<T>(T data)
    {
      if (data == null) throw new ArgumentNullException(nameof(data));

      //var serializer = new XmlSerializer(typeof(T));

     if (this.serializers.TryGetValue(typeof(T), out var serializer))
      {
        ;// Do nothing, serializer already exists
      }
      else
      {
        serializer = new XmlSerializer(typeof(T));
        this.serializers.Add(typeof(T), serializer);
      }

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
  }

  public static class XmlSerializerHelper
  {
    public static void SerializeToXml<T>(string filePath, T data)
    {
      string xmlContent = SerializeToXmlString(data);
      File.WriteAllText(filePath, xmlContent, Encoding.UTF8);
    }

    public static string SerializeToXmlString<T>(T data)
    {
      if (data == null) throw new ArgumentNullException(nameof(data));

      var serializer = new XmlSerializer(typeof(T));

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

      var serializer = new XmlSerializer(typeof(T));
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
