using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class PatientForm
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("unique_id")]
        [StringLength(50)]
        public string UniqueId { get; set; }
        [Required]
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; }
        [Column("referring_facility")]
        public int ReferringFacility { get; set; }
        [Column("referred_to")]
        public int ReferredTo { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Column("time_referred")]
        public DateTime TimeReferred { get; set; }
        [Column("time_transferred")]
        public DateTime TimeTransferred { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Required]
        [Column("case_summary", TypeName = "text")]
        public string CaseSummary { get; set; }
        [Required]
        [Column("reco_summary", TypeName = "text")]
        public string RecoSummary { get; set; }
        [Required]
        [Column("diagnosis")]
        [StringLength(255)]
        public string Diagnosis { get; set; }
        [Required]
        [Column("reason")]
        [StringLength(255)]
        public string Reason { get; set; }
        [Column("referring_md")]
        public int? ReferringMd { get; set; }
        [Column("referred_md")]
        public int? ReferredMd { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("PatientForm")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("PatientForm")]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(ReferredMd))]
        [InverseProperty(nameof(User.PatientFormReferredMdNavigation))]
        public virtual User ReferredMdNavigation { get; set; }
        [ForeignKey(nameof(ReferredTo))]
        [InverseProperty(nameof(Facility.PatientFormReferredToNavigation))]
        public virtual Facility ReferredToNavigation { get; set; }
        [ForeignKey(nameof(ReferringFacility))]
        [InverseProperty(nameof(Facility.PatientFormReferringFacilityNavigation))]
        public virtual Facility ReferringFacilityNavigation { get; set; }
        [ForeignKey(nameof(ReferringMd))]
        [InverseProperty(nameof(User.PatientFormReferringMdNavigation))]
        public virtual User ReferringMdNavigation { get; set; }
    }
}
