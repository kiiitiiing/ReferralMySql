using System;
using System.Globalization;

namespace Referral2.Models.ViewModels.Forms
{
    public partial class PregnantFormModel : PatientFormModel
    {
        public string RecordNo { get; set; }
        public DateTime ReferredDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string HealthWorker { get; set; }
        public string WomanReason { get; set; }
        public string WomanMajorFindings { get; set; }
        public string WomanBeforeTreatment { get; set; }
        public DateTime WomanBeforeGivenTime { get; set; }
        public string WomanDuringTransport { get; set; }
        public DateTime WomanTransportGivenTime { get; set; }
        public string WomanInformationGiven { get; set; }
        public int PatientBabyId { get; set; }
        public string BabyName { get; set; }
        public DateTime BabyDob { get; set; }
        public int BabyWeight { get; set; }
        public int BabyGestationAge { get; set; }
        public string BabyReason { get; set; }
        public string BabyMajorFindings { get; set; }
        public DateTime BabyLastFeed { get; set; }
        public string BabyBeforeTreatment { get; set; }
        public DateTime BabyBeforeGivenTime { get; set; }
        public string BabyDuringTransport { get; set; }
        public DateTime BabyTransportGivenTime { get; set; }
        public string BabyInformationGiven { get; set; }
    }
}
