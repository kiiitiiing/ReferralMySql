using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class PregnantForm
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Code { get; set; }
        public int ReferringFacility { get; set; }
        public int ReferredBy { get; set; }
        public string RecordNo { get; set; }
        public DateTime ReferredDate { get; set; }
        public int ReferredTo { get; set; }
        public int DepartmentId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string HealthWorker { get; set; }
        public int PatientWomanId { get; set; }
        public string WomanReason { get; set; }
        public string WomanMajorFindings { get; set; }
        public string WomanBeforeTreatment { get; set; }
        public DateTime WomanBeforeGivenTime { get; set; }
        public string WomanDuringTransport { get; set; }
        public DateTime WomanTransportGivenTime { get; set; }
        public string WomanInformationGiven { get; set; }
        public int PatientBabyId { get; set; }
        public string BabyReason { get; set; }
        public string BabyMajorFindings { get; set; }
        public DateTime BabyLastFeed { get; set; }
        public string BabyBeforeTreatment { get; set; }
        public DateTime BabyBeforeGivenTime { get; set; }
        public string BabyDuringTransport { get; set; }
        public DateTime BabyTransportGivenTime { get; set; }
        public string BabyInformationGiven { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
