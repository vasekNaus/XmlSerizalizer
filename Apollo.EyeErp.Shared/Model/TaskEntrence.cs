using System;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task", Namespace = "")]
    [XmlType("TaskEntrance")]
    public class TaskEntrance : Task
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

        [XmlElement("User_Reception_id")]
        public int? User_Reception_id { get; set; }

        [XmlElement("User_Nurse_id")]
        public int? User_Nurse_id { get; set; }

        [XmlElement("User_Optometric_id")]
        public int? User_Optometric_id { get; set; }

        [XmlElement("User_Indicate_id")]
        public int? User_Indicate_id { get; set; }

        [XmlElement("TaskConclusion_id")]
        public short? TaskConclusion_id { get; set; }

        [XmlElement("Conclusion")]
        public string Conclusion { get; set; }

        [XmlElement("JobRecomended_id")]
        public int? JobRecomended_id { get; set; }

        [XmlElement("ExternalDoctor_id")]
        public int? ExternalDoctor_id { get; set; }

        [XmlElement("ExternalActivityRecomended_id")]
        public int? ExternalActivityRecomended_id { get; set; }

        [XmlElement("IsExternalBonus")]
        public bool IsExternalBonus { get; set; }

        [XmlElement("TaskConclusionReason_id")]
        public int? TaskConclusionReason_id { get; set; }

        [XmlElement("TaskConclusionL_id")]
        public short? TaskConclusionL_id { get; set; }

        [XmlElement("TaskConclusionP_id")]
        public short? TaskConclusionP_id { get; set; }

        [XmlElement("TaskConclusionReasonL_id")]
        public int? TaskConclusionReasonL_id { get; set; }

        [XmlElement("TaskConclusionReasonP_id")]
        public int? TaskConclusionReasonP_id { get; set; }

        [XmlElement("JobRecomendedP_id")]
        public int? JobRecomendedP_id { get; set; }

        [XmlElement("JobRecomendedL_id")]
        public int? JobRecomendedL_id { get; set; }

        [XmlElement("InclusionReasonL_id")]
        public int? InclusionReasonL_id { get; set; }

        [XmlElement("InclusionReasonP_id")]
        public int? InclusionReasonP_id { get; set; }

        [XmlElement("InclusionNoteL")]
        public string InclusionNoteL { get; set; }

        [XmlElement("InclusionNoteP")]
        public string InclusionNoteP { get; set; }

        [XmlElement("InclusionInMonthsL")]
        public int? InclusionInMonthsL { get; set; }

        [XmlElement("InclusionInMonthsP")]
        public int? InclusionInMonthsP { get; set; }

        public TaskEntrance()
        {
            IsExternalBonus = false;
        }
    }
}