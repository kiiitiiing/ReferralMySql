using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class PatientForm
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Code { get; set; }
        public int ReferringFacility { get; set; }
        public int ReferredTo { get; set; }
        public int DepartmentId { get; set; }
        public string CovidNumber { get; set; }
        public string ReferClinicalStatus { get; set; }
        public string ReferSurCategory { get; set; }
        public string DisClinicalStatus { get; set; }
        public string DisSurCategory { get; set; }
        public DateTime TimeReferred { get; set; }
        public DateTime TimeTransferred { get; set; }
        public int PatientId { get; set; }
        public string CaseSummary { get; set; }
        public string RecoSummary { get; set; }
        public string Diagnosis { get; set; }
        public string Reason { get; set; }
        public int ReferringMd { get; set; }
        public int ReferredMd { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
