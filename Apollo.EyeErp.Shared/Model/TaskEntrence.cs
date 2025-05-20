using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    internal class TaskEntrence : Task
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Job_id")]
        public int? Job_id { get; set; }

        [XmlElement("Patient_id")]
        public int? Patient_id { get; set; }

        [XmlElement("Note")]
        public string Note { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("PriceFull")]
        public decimal PriceFull { get; set; }

        [XmlElement("InsertData")]
        public DateTime InsertDate { get; set; }

        [XmlElement("IsActive")]
        public bool IsActive { get; set; }

        [XmlElement("IsExternalBonus")]
        public bool IsExternalBonus { get; set; }

        [XmlElement("ExternalDoctor_id")]
        public int? ExternalDoctor_id { get; set; }

        [XmlElement("JobRecomended_id")]
        public int? JobRecomended_id { get; set; }

        [XmlElement("Conclusion")]
        public string Conclusion { get; set; }

        [XmlElement("TaskConclusion_id")]
        public int? TaskConclusion_id { get; set; }

        [XmlElement("TaskConclusionReason_id")]
        public int? TaskConclusionReason_id { get; set; }

    }
}
