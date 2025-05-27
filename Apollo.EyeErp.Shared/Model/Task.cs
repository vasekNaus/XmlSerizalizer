using Apollo.EyeErp.Shared.Model;
using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task", Namespace = "")]
    [XmlInclude(typeof(TaskEntrance))]
    [XmlInclude(typeof(TaskOperation))]
    [XmlInclude(typeof(TaskInstrument))]
    [KnownType(typeof(TaskEntrance))]
    [KnownType(typeof(TaskOperation))]
    [KnownType(typeof(TaskInstrument))]
    public class MyTask
    {
        public MyTask() { }

        [XmlElement("LensId")]

        public int? LensId { get; set; }

        #region Nepoužívané - nejsou v databázi
        [XmlElement("TaskLensSerialize")]
        public string TaskLensSerialize { get; set; }

        [XmlElement("MarketingEventsSerialize")]
        public string MarketingEventsSerialize { get; set; }

        [XmlElement("DiscountsSerialize")]
        public string DiscountsSerialize { get; set; }

        [XmlElement("JobOptionsSerialize")]
        public string JobOptionsSerialize { get; set; }

        [XmlElement("TimeFromSerialize")]
        public string TimeFromSerialize { get; set; }

        [XmlElement("TimeToSerialize")]
        public string TimeToSerialize { get; set; }

        [XmlElement("TimeArrivalSerialize")]
        public string TimeArrivalSerialize { get; set; }

        [XmlElement("TaskDateSerialize")]

        public string TaskDateSerialize { get; set; }

        #endregion

        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Block_id")]
        public int? BlockId { get; set; }

        [XmlElement("Patient_id")]
        public int PatientId { get; set; }

        [XmlElement("Job_id")]
        public int JobId { get; set; }

        [XmlElement("User_RecommendedBy_id")]
        public int? UserRecommendedById { get; set; }

        [XmlElement("User_Author_id")]
        public int UserAuthorId { get; set; }

        [XmlElement("TaskOrigin_id")]
        public int? TaskOriginId { get; set; }

        [XmlElement("QueuePhase_id")]
        public short QueuePhaseId { get; set; }

        [XmlElement("Company_id")]
        public int? CompanyId { get; set; }

        [XmlElement("TaskNext_id")]
        public int? TaskNextId { get; set; }

        [XmlElement("TimeFrom")]
        public TimeSpan? TimeFrom { get; set; }

        [XmlElement("TimeTo")]
        public TimeSpan? TimeTo { get; set; }

        [XmlElement("TimeArrival")]
        public TimeSpan? TimeArrival { get; set; }

        [XmlElement("Note")]
        public string Note { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("PriceNote")]
        public string PriceNote { get; set; }

        [XmlElement("PricePaid")]
        public decimal PricePaid { get; set; }


        [XmlIgnore]
        public bool PricePaidSpecified { get; set; }

        [XmlElement("PriceFull")]
        public decimal PriceFull { get; set; }

        [XmlIgnore]
        public bool PriceFullSpecified { get; set; }

        [XmlElement("Reason")]
        public string Reason { get; set; }

        [XmlElement("InsertDate")]
        public DateTime InsertDate { get; set; }

        [XmlElement("IsActive")]
        public bool IsActive { get; set; }

        [XmlElement("QueuePhaseDate")]
        public DateTime QueuePhaseDate { get; set; }

        [XmlIgnore]
        public bool QueuePhaseDateSpecified { get; set; }

        [XmlElement("IsRearranged")]
        public bool IsRearranged { get; set; }

        [XmlElement("IsEdited")]
        public bool IsEdited { get; set; }

        [XmlElement("Part")]
        public short Part { get; set; }

        [XmlElement("User_Final_id")]
        public int? UserFinalId { get; set; }

        [XmlElement("FinalDate")]
        public DateTime? FinalDate { get; set; }

        [XmlElement("ProFormaInvoice_id")]
        public int? ProFormaInvoiceId { get; set; }

        [XmlIgnore]

        public bool ProFormaInvoiceIdSpecified { get; set; }

    }
}
