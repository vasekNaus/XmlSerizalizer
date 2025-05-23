using System;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task", Namespace = "")]
    [XmlType("TaskEntrance")]
    public class TaskEntrance : MyTask
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

        [XmlElement("InvoicePhase_id")]
        public int? InvoicePhaseId { get; set; }

        [XmlElement("User_Nurse_id")]
        public int? UserNurseId { get; set; }

        [XmlElement("User_Reception_id")]
        public int? UserReceptionId { get; set; }

        [XmlElement("User_Optometric_id")]
        public int? UserOptometricId { get; set; }

        [XmlElement("User_Indicate_id")]
        public int? UserIndicateId { get; set; }

        [XmlElement("ExternalDoctor_id")]
        public int? ExternalDoctorId { get; set; }

        [XmlElement("ExternalActivityRecomended_id")]
        public int? ExternalActivityRecomendedId { get; set; }

        [XmlElement("IsExternalBonus")]
        public bool IsExternalBonus { get; set; }

        [XmlElement("User_OperatingNurse_id")]
        public int? UserOperatingNurseId { get; set; }

        [XmlElement("JobDone_id")]
        public int? JobDoneId { get; set; }

        [XmlElement("User_Operator_id")]
        public int? UserOperatorId { get; set; }

        [XmlElement("ProFormaInvoiceItem_id")]
        public int? ProFormaInvoiceItemId { get; set; }

        [XmlElement("InsurancePrice")]
        public decimal InsurancePrice { get; set; }

        [XmlElement("IsExternal")]
        public bool IsExternal { get; set; }

        [XmlElement("User_Technician_id")]
        public int? UserTechnicianId { get; set; }

        [XmlElement("User_Saved_Id")]
        public int? UserSavedId { get; set; }

        [XmlElement("AmbulatoryBookNumber")]
        public int? AmbulatoryBookNumber { get; set; }

        [XmlElement("InsuranceBilling_id")]
        public int? InsuranceBillingId { get; set; }

        [XmlElement("Eye_id")]
        public short? EyeId { get; set; }

        [XmlElement("IsIcBilled")]
        public bool? IsIcBilled { get; set; }

        [XmlElement("IsAnonymous")]
        public bool? IsAnonymous { get; set; }

        [XmlElement("Currency_id")]
        public int? CurrencyId { get; set; }

        [XmlElement("Urgency")]
        public bool? Urgency { get; set; }
   
        [XmlElement("TaskConclusion_id")]
        public short? TaskConclusionId { get; set; }

        [XmlElement("JobRecomended_id")]
        public int? JobRecomendedId { get; set; }

        [XmlElement("TaskConclusionReason_id")]
        public int? TaskConclusionReasonId { get; set; }

        [XmlElement("TaskConclusionL_id")]
        public short? TaskConclusionLId { get; set; }

        [XmlElement("TaskConclusionP_id")]
        public short? TaskConclusionPId { get; set; }

        [XmlElement("TaskConclusionReasonL_id")]
        public int? TaskConclusionReasonLId { get; set; }

        [XmlElement("TaskConclusionReasonP_id")]
        public int? TaskConclusionReasonPId { get; set; }

        [XmlElement("JobRecomendedP_id")]
        public int? JobRecomendedPId { get; set; }

        [XmlElement("JobRecomendedL_id")]
        public int? JobRecomendedLId { get; set; }

        [XmlElement("InclusionReasonL_id")]
        public int? InclusionReasonLId { get; set; }

        [XmlElement("InclusionReasonP_id")]
        public int? InclusionReasonPId { get; set; }

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