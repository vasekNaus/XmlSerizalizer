using System;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task", Namespace = "")]
    [XmlType("TaskOperation")]
    public class TaskOperation : Task
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

        [XmlElement("User_OperatingNurse_id")]
        public int? User_OperatingNurse_id { get; set; } 

        [XmlElement("Anaesthesia_id")]
        public short? Anaesthesia_id { get; set; } 

        [XmlElement("Eye_id")]
        public short? Eye_id { get; set; } 

        [XmlElement("JobDone_id")]
        public int? JobDone_id { get; set; }

        [XmlElement("IsSecondEye")]
        public bool IsSecondEye { get; set; } 

        [XmlElement("Description")]
        public string Description { get; set; } 

        [XmlElement("IsReoperation")]
        public bool IsReoperation { get; set; } 

        [XmlElement("Task_Entrance_id")]
        public int? Task_Entrance_id { get; set; } 

        [XmlElement("Task_FirstOperation_id")]
        public int? Task_FirstOperation_id { get; set; } 

        [XmlElement("User_Indicate_id")]
        public int? User_Indicate_id { get; set; }

        [XmlElement("User_Operator_id")]
        public int? User_Operator_id { get; set; }  

        public TaskOperation()
        {
            Description = string.Empty; 
            IsSecondEye = false;
            IsReoperation = false;
        }
    }
}