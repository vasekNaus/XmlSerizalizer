using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task")]
    
    public class TaskEntrance : Task
    {
        [XmlElement("Task_id")]
        public int Task_id { get; set; }

        [XmlElement("User_Reception_id")]
        public int User_Reception_id { get; set; }

        [XmlElement("User_Nurse_id")]
        public int User_Nurse_id { get; set; }

        [XmlElement("User_Optometric_id")]
        public int User_Optometric_id { get; set; }

        [XmlElement("User_Indicate_id")]
        public int User_Indicate_id { get; set; }

        [XmlElement("TaskConclusion_id")]
        public int TaskConclusion_id { get; set; }

        [XmlElement("Conclusion")]
        public string Conclusion { get; set; }

        [XmlElement("JobRecommended_id")]
        public int JobRecommended_id { get; set; }

        [XmlElement("ExternalDoctor_id")]
        public int ExternalDoctor_id { get; set; }

        [XmlElement("ExternalActivityRecommended_id")]
        public int ExternalActivityRecommended_id { get; set; }

        [XmlElement("IsExternalBonus")]
        public bool IsExternalBonus { get; set; }

        [XmlElement("TaskConclusionReason_id")]
        public int TaskConclusionReason_id { get; set; }

        [XmlElement("TaskConclusionL_id")]
        public int TaskConclusionL_id { get; set; }

        [XmlElement("TaskConclusionP_id")]
        public int TaskConclusionP_id { get; set; }

        [XmlElement("TaskConclusionReasonL_id")]
        public int TaskConclusionReasonL_id { get; set; }

        [XmlElement("TaskConclusionReasonP_id")]
        public int TaskConclusionReasonP_id { get; set; }

        [XmlElement("JobRecommendedP_id")]
        public int JobRecommendedP_id { get; set; }

        [XmlElement("JobRecommendedL_id")]
        public int JobRecommendedL_id { get; set; }

        [XmlElement("InclusionReasonL_id")]
        public int InclusionReasonL_id { get; set; }

        [XmlElement("InclusionReasonP_id")]
        public int InclusionReasonP_id { get; set; }

        [XmlElement("InclusionNoteL")]
        public string InclusionNoteL { get; set; }

        [XmlElement("InclusionNoteP")]
        public string InclusionNoteP { get; set; }

        [XmlElement("InclusionInMonthsL")]
        public int InclusionInMonthsL { get; set; }

        [XmlElement("InclusionInMonthsP")]
        public int InclusionInMonthsP { get; set; }
    }
}