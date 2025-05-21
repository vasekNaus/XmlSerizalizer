using System;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task", Namespace = "")]
    [XmlType("TaskInstrument")]
    public class TaskInstrument : Task
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns
        {
            get
            {
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("xsd", "http://www.w3.org/2001/XMLSchema");
                namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                return namespaces;
            }
            set { }
        }

        [XmlElement("Task_id")]
        public int Task_id { get; set; } 

        [XmlElement("User_Indicate_id")]
        public int? User_Indicate_id { get; set; } 

        [XmlElement("ExternalDoctor_id")]
        public int? ExternalDoctor_id { get; set; } 

        [XmlElement("Eye_id")]
        public short? Eye_id { get; set; } 

        [XmlElement("JobDone_id")]
        public int? JobDone_id { get; set; }  

        public TaskInstrument()
        {
           
        }
    }
}