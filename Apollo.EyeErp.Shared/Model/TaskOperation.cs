using System;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task", Namespace = "")]
    [XmlType("TaskOperation")]
    public class TaskOperation : MyTask
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
        public int UserOperatorId { get; set; }

        [XmlElement("ProFormaInvoiceItem_id")]
        public int? ProFormaInvoiceItemId { get; set; }

        [XmlElement("InsurancePrice")]
        public decimal InsurancePrice { get; set; }

        [XmlElement("IsExternal")]
        public bool IsExternal { get; set; }

        [XmlElement("User_Technician_id")]
        public int? UserTechnicianId { get; set; }

        [XmlElement("User_Saved_Id")]
        public int UserSavedId { get; set; }

        [XmlElement("AmbulatoryBookNumber", IsNullable = true)]
        public string AmbulatoryBookNumber { get; set; }

        [XmlElement("InsuranceBilling_id")]
        public int? InsuranceBillingId { get; set; }

        [XmlElement("Eye_id")]
        public int EyeId { get; set; }

        [XmlElement("IsIcBilled")]
        public bool? IsIcBilled { get; set; }

        [XmlElement("IsAnonymous")]
        public bool? IsAnonymous { get; set; }

        [XmlElement("Currency_id")]
        public int CurrencyId { get; set; }

        [XmlElement("Urgency", IsNullable = true)]
        public string Urgency { get; set; }

        public TaskOperation()
        {

        }
    }
}