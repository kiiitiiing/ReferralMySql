using System;
using System.ComponentModel.DataAnnotations;

namespace Referral2.Models.ViewModels
{
    public partial class PatientModel
    {
        public int Id { get; set; }
        [Display(Name = "philhealth status")]
        public string PhicStatus { get; set; }
        [Display(Name = "philhealth id")]
        public string PhicId { get; set; }
        [Required]
        [Display(Name = "first name")]
        public string Fname { get; set; }
        [Required]
        [Display(Name = "middle name")]
        public string Mname { get; set; }
        [Required]
        [Display(Name = "last name")]
        public string Lname { get; set; }
        [Required]
        [Display(Name = "date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        [Display(Name = "civil status")]
        public string CivilStatus { get; set; }
        [Display(Name = "province")]
        public int ProvinceId { get; set; }
        [Required]
        [Display(Name = "city/municipality")]
        public int MuncityId { get; set; }
        [Required]
        [Display(Name = "barangay")]
        public int BarangayId { get; set; }
    }
}
