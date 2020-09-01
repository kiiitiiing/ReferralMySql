using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class RepeatCall
    {
        public int Id { get; set; }
        public int? EncodedBy { get; set; }
        public string CallClassification { get; set; }
        public string ReferenceNumber { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public int? ProvinceId { get; set; }
        public int? MunicipalityId { get; set; }
        public int? BarangayId { get; set; }
        public string Sitio { get; set; }
        public string ContactNumber { get; set; }
        public string Relationship { get; set; }
        public string ReasonCalling { get; set; }
        public string ReasonNotes { get; set; }
        public string ReasonPatientData { get; set; }
        public string ReasonChiefComplains { get; set; }
        public string ReasonActionTaken { get; set; }
        public string TransactionComplete { get; set; }
        public string TransactionIncomplete { get; set; }
        public DateTime? TimeStarted { get; set; }
        public DateTime? TimeEnded { get; set; }
        public string TimeDuration { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
