using Apollo.EyeErp.Shared.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Utilities
{

  public class XmlSerializerService
  {
    private Dictionary<Type, XmlSerializer> serializers;

    public XmlSerializerService()
    {
      this.serializers = new Dictionary<Type, XmlSerializer>();
    }

    protected virtual XmlSerializer CreateSerializer<T>()
    {
      return new XmlSerializer(typeof(T));
    }

    private XmlSerializer GetOrCreateSerializer<T>()
    {
      if (!this.serializers.TryGetValue(typeof(T), out var serializer))
      {
        serializer = CreateSerializer<T>();
        this.serializers.Add(typeof(T), serializer);
      }
      return serializer;
    }

    public string SerializeToXmlString<T>(T data)
    {
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

        GetOrCreateSerializer<T>().Serialize(xmlWriter, data, ns);
        return stringWriter.ToString();
      }
    }
    public void SerializeToXmlFile<T>(T data, string filePath)
    {
      string xmlContent = SerializeToXmlString(data);
      File.WriteAllText(filePath, xmlContent, Encoding.UTF8);
    }

    public T DeserializeFromXmlString<T>(string xml)
    {
      throw new NotImplementedException("This method is not implemented yet.");
      //var serializer = GetOrCreateSerializer<T>();
      //using (var reader = new StreamReader(filePath))
      //{
      //  return (T)serializer.Deserialize(reader);
      //}
    }
    public T DeserializeFromXmlFile<T>(string filePath)
    {
      var serializer = GetOrCreateSerializer<T>();
      using (var reader = new StreamReader(filePath))
      {
        return (T)serializer.Deserialize(reader);
      }
    }


    #region Old

    public static string SerializeObject<Object>(Object toSerialize, XmlSerializer serializer, XmlSerializerNamespaces ns = null)
    {
      return SerializeObject<Object>(toSerialize, serializer, Encoding.Unicode, ns);
    }

    public static string SerializeObject<Object>(Object toSerialize, XmlSerializer serializer, Encoding enc, XmlSerializerNamespaces ns = null)
    {
      using (StringWriterEx textWriter = new StringWriterEx(enc))
      {
        if (ns != null)
          serializer.Serialize(textWriter, toSerialize, ns);
        else
          serializer.Serialize(textWriter, toSerialize);

        return textWriter.ToString();
      }
    }

    public static string SerializeObject<Object>(Object toSerialize, XmlSerializer serializer, Encoding enc, XmlWriterSettings writerSettings = null, XmlSerializerNamespaces ns = null)
    {
      using (StringWriterEx textWriter = new StringWriterEx(enc))
      {
        using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, writerSettings))
        {
          if (ns != null)
            serializer.Serialize(xmlWriter, toSerialize, ns);
          else
            serializer.Serialize(xmlWriter, toSerialize);

          return textWriter.ToString();
        }
      }
    }

    /// <summary>
    /// Pozor na MemoryLeak, každá instance XmlSerializer nìco žere
    /// </summary>
    /// <typeparam name="Object"></typeparam>
    /// <param name="toSerialize"></param>
    /// <param name="extraTypes"></param>
    /// <returns></returns>
    public static string SerializeObject<Object>(Object toSerialize, Type[] extraTypes = null)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), extraTypes);
      return SerializeObject<Object>(toSerialize, serializer);
    }

    /// <summary>
    /// Pozor na MemoryLeak, každá instance XmlSerializer nìco žere
    /// </summary>
    /// <typeparam name="Object"></typeparam>
    /// <param name="toSerialize"></param>
    /// <param name="overrides"></param>
    /// <returns></returns>
    public static string SerializeObject<Object>(Object toSerialize, XmlAttributeOverrides overrides)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), overrides);
      return SerializeObject<Object>(toSerialize, serializer);
    }

    public static Object DeserializeObject<Object>(string xml, XmlSerializer serializer)
    {
      using (TextReader reader = new StringReader(xml))
      {
        return (Object)serializer.Deserialize(reader);
      }
    }

    public static object DeserializeObject(string xml, XmlSerializer serializer)
    {
      using (TextReader reader = new StringReader(xml))
      {
        return serializer.Deserialize(reader);
      }
    }

    public static Object DeserializeObject<Object>(string xml, Type[] extraTypes = null)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), extraTypes);
      return DeserializeObject<Object>(xml, serializer);
    }

    public static Object DeserializeObject<Object>(string xml, XmlAttributeOverrides overrides)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), overrides);
      return DeserializeObject<Object>(xml, serializer);
    }

    #endregion
  }


  public sealed class StringWriterWithEncoding : StringWriter
  {
    private readonly Encoding _encoding;
    public StringWriterWithEncoding(Encoding encoding) { _encoding = encoding; }
    public override Encoding Encoding => _encoding;
  }

  public class StringWriterEx : StringWriter
  {
    private Encoding encoding;

    public StringWriterEx(Encoding encoding)
    {
      this.encoding = encoding;
    }

    public override Encoding Encoding
    {
      get { return this.encoding; }
    }
  }
}
