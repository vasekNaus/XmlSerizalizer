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

    private readonly Encoding defaultEncoding;
    private readonly XmlWriterSettings defaultWriterSettings;
    private readonly XmlSerializerNamespaces defaultNamespaces;


    public XmlSerializerService(Encoding encoding = null, XmlWriterSettings writerSettings = null, XmlSerializerNamespaces namespaces = null)
    {
      this.serializers = new Dictionary<Type, XmlSerializer>();

      this.defaultEncoding = encoding ?? Encoding.UTF8;

      this.defaultWriterSettings = writerSettings ?? new XmlWriterSettings
      {
        OmitXmlDeclaration = true,
        Indent = true,
        Encoding = this.defaultEncoding
      };

      this.defaultNamespaces = namespaces ?? new XmlSerializerNamespaces(new[]
      {
        new XmlQualifiedName("xsd", "http://www.w3.org/2001/XMLSchema"),
        new XmlQualifiedName("xsi", "http://www.w3.org/2001/XMLSchema-instance"),
        new XmlQualifiedName("", "")
      });
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
      var serializer = GetOrCreateSerializer<T>();
      return Serialize(data, serializer, defaultEncoding, defaultWriterSettings, defaultNamespaces);
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

    //public static string SerializeObject<Object>(Object toSerialize, XmlSerializer serializer, XmlSerializerNamespaces ns = null)
    //{
    //  return SerializeObject<Object>(toSerialize, serializer, Encoding.Unicode, ns);
    //}

    //public static string SerializeObject<Object>(Object toSerialize, XmlSerializer serializer, Encoding enc, XmlSerializerNamespaces ns = null)
    //{
    //  using (StringWriterEx textWriter = new StringWriterEx(enc))
    //  {
    //    if (ns != null)
    //      serializer.Serialize(textWriter, toSerialize, ns);
    //    else
    //      serializer.Serialize(textWriter, toSerialize);

    //    return textWriter.ToString();
    //  }
    //}

    public static string Serialize<T>(T toSerialize, XmlSerializer serializer, Encoding enc = null, XmlWriterSettings writerSettings = null, XmlSerializerNamespaces ns = null)
    {
      if (enc == null)
        enc = Encoding.UTF8;

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
    [Obsolete("Apollo.XmlSerializer")]
    public static string SerializeObject<Object>(Object toSerialize, Type[] extraTypes = null)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), extraTypes);
      return Serialize<Object>(toSerialize, serializer);
    }

    /// <summary>
    /// Pozor na MemoryLeak, každá instance XmlSerializer nìco žere
    /// </summary>
    /// <typeparam name="Object"></typeparam>
    /// <param name="toSerialize"></param>
    /// <param name="overrides"></param>
    /// <returns></returns>
    [Obsolete("Apollo.XmlSerializer")]
    public static string SerializeObject<Object>(Object toSerialize, XmlAttributeOverrides overrides)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), overrides);
      return Serialize<Object>(toSerialize, serializer);
    }

    public static T Deserialize<T>(string xml, XmlSerializer serializer)
    {
      using (TextReader reader = new StringReader(xml))
      {
        return (T)serializer.Deserialize(reader);
      }
    }

    //public static object DeserializeObject(string xml, XmlSerializer serializer)
    //{
    //  using (TextReader reader = new StringReader(xml))
    //  {
    //    return serializer.Deserialize(reader);
    //  }
    //}
    [Obsolete("Apollo.XmlSerializer")]
    public static Object DeserializeObject<Object>(string xml, Type[] extraTypes = null)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), extraTypes);
      return Deserialize<Object>(xml, serializer);
    }
    [Obsolete("Apollo.XmlSerializer")]
    public static Object DeserializeObject<Object>(string xml, XmlAttributeOverrides overrides)
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Object), overrides);
      return Deserialize<Object>(xml, serializer);
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
