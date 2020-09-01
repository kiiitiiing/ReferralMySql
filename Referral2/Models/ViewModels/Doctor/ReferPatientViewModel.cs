using System.ComponentModel.DataAnnotations;

namespace Referral2.Models.ViewModels.Doctor
{
    public partial class ReferPatientViewModel
    {
        public string FacilityName { get; set; }
        public string FacilityBarangay { get; set; }
        public string FacilityMuncity { get; set; }
        public string FacilityProvince { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string PatientBarangay { get; set; }
        public string PatientMuncity { get; set; }
        public string PatientProvince { get; set; }
        public string PhicStatus { get; set; }
        public string PhicId { get; set; }
        //Send form
        [Required]
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "facility")]
        public int Facility { get; set; }
        [Required]
        [Display(Name = "department")]
        public int Department { get; set; }
        [Required]
        [Display(Name = "case summary")]
        public string CaseSummary { get; set; }
        [Required]
        [Display(Name = "summary of reco")]
        public string SummaryReco { get; set; }
        [Required]
        [Display(Name = "diagnosis/impression")]
        public string Diagnosis { get; set; }
        [Required]
        [Display(Name = "reason")]
        public string Reason { get; set; }
        [Display(Name = "covid number")]
        public string CovidNumber { get; set; }
        [Display(Name = "clinical status")]
        public string ClinicalStatus { get; set; }
        [Display(Name = "surveillance category")]
        public string SurveillanceCategory { get; set; }
        public int ReferredToMd { get; set; }
    }
}
