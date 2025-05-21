using Apollo.EyeErp.Shared.Model;
using System;
using System.Xml.Serialization;

namespace Apollo.EyeErp.Shared.Model
{
    [Serializable]
    [XmlRoot("Task", Namespace = "")]
    [XmlInclude(typeof(TaskEntrance))]
    public class Task
    {
        public Task() { }

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

        [XmlElement("Reason")]
        public string Reason { get; set; }

        [XmlElement("InsertDate")]
        public DateTime InsertDate { get; set; }

        [XmlElement("IsActive")]
        public bool IsActive { get; set; }

        [XmlElement("QueuePhaseDate")]
        public DateTime QueuePhaseDate { get; set; }

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
    }
}
