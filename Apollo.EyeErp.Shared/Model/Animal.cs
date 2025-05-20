using System;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared
{
    [Serializable]
    [XmlRoot("Animal")]
    public class Animal
    {
        public Animal() { 
        }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("Species")]
        public string Species { get; set; }
    }
}