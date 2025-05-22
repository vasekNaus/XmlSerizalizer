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
        [XmlElement("PriceFull")]
        public decimal PriceFull { get; set; }

        [XmlElement("Anaesthesia_id")]
        public int? AnaesthesiaId { get; set; }

        [XmlElement("IsSecondEye")]
        public bool IsSecondEye { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("IsReoperation")]
        public bool IsReoperation { get; set; }

        [XmlElement("Task_Entrance_id")]
        public int TaskEntranceId { get; set; }

        [XmlElement("Task_FirstOperation_id")]
        public int? TaskFirstOperationId { get; set; }

        public TaskOperation()
        {

        }
    }
}