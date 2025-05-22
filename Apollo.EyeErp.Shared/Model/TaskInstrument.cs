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

        [XmlElement("InvoicePhase_id")]
        public int? InvoicePhaseId { get; set; }

        [XmlElement("User_Indicate_id")]
        public int? UserIndicateId { get; set; }

        [XmlElement("ExternalDoctor_id")]
        public int? ExternalDoctorId { get; set; }

        [XmlElement("Eye_id")]
        public short? EyeId { get; set; }

        [XmlElement("JobDone_id")]
        public int? JobDoneId { get; set; }

        public TaskInstrument()
        {
           
        }
    }
}