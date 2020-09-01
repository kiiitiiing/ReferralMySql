using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Forms
{
    public partial class PatientFormModel
    {
        public string UniqueId { get; set; }
        public string Code { get; set; }
        public int ReferringFacility { get; set; }
        public string ReferringFacilityName { get; set; }
        public string ReferringFacilityAddress { get; set; }
        public string ReferringFacilityContact { get; set; }
        public int ReferredTo { get; set; }
        public string ReferredToName { get; set; }
        public string ReferredToAddress { get; set; }
        public string ReferredToContact { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string CovidNumber { get; set; }
        public string ReferClinicalStatus { get; set; }
        public string ReferSurCategory { get; set; }
        public string DisClinicalStatus { get; set; }
        public string DisSurCategory { get; set; }
        public DateTime TimeReferred { get; set; }
        public DateTime TimeTransferred { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public string PatientSex { get; set; }
        public string PatientStatus { get; set; }
        public string PhicId { get; set; }
        public string PhicStatus { get; set; }
        public DateTime PatientDob { get; set; }
        public string CaseSummary { get; set; }
        public string RecoSummary { get; set; }
        public string Diagnosis { get; set; }
        public string Reason { get; set; }
        public int ReferringMd { get; set; }
        public string ReferringMdName { get; set; }
        public string ReferringMdContact { get; set; }
        public int ReferredMd { get; set; }
        public string ReferredMdName { get; set; }
        public string ReferredMdContact { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
