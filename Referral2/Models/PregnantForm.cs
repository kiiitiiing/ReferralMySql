using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class PregnantForm
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
        [Column("referred_by")]
        public int? ReferredBy { get; set; }
        [Column("record_no")]
        [StringLength(50)]
        public string RecordNo { get; set; }
        [Column("referred_date")]
        public DateTime ReferredDate { get; set; }
        [Column("referred_to")]
        public int ReferredTo { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Column("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [Column("health_worker")]
        [StringLength(50)]
        public string HealthWorker { get; set; }
        [Column("patient_woman_id")]
        public int PatientWomanId { get; set; }
        [Required]
        [Column("woman_reason")]
        [StringLength(255)]
        public string WomanReason { get; set; }
        [Required]
        [Column("woman_major_findings", TypeName = "text")]
        public string WomanMajorFindings { get; set; }
        [Column("woman_before_treatment", TypeName = "text")]
        public string WomanBeforeTreatment { get; set; }
        [Column("woman_before_given_time")]
        public DateTime WomanBeforeGivenTime { get; set; }
        [Column("woman_during_transport")]
        [StringLength(255)]
        public string WomanDuringTransport { get; set; }
        [Column("woman_transport_given_time")]
        public DateTime WomanTransportGivenTime { get; set; }
        [Required]
        [Column("woman_information_given", TypeName = "text")]
        public string WomanInformationGiven { get; set; }
        [Column("patient_baby_id")]
        public int? PatientBabyId { get; set; }
        [Required]
        [Column("baby_reason")]
        [StringLength(255)]
        public string BabyReason { get; set; }
        [Column("baby_major_findings", TypeName = "text")]
        public string BabyMajorFindings { get; set; }
        [Column("baby_last_feed")]
        public DateTime BabyLastFeed { get; set; }
        [Column("baby_before_treatment")]
        [StringLength(255)]
        public string BabyBeforeTreatment { get; set; }
        [Column("baby_before_given_time")]
        public DateTime BabyBeforeGivenTime { get; set; }
        [Column("baby_during_transport")]
        [StringLength(255)]
        public string BabyDuringTransport { get; set; }
        [Column("baby_transport_given_time")]
        public DateTime BabyTransportGivenTime { get; set; }
        [Column("baby_information_given")]
        [StringLength(255)]
        public string BabyInformationGiven { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("PregnantForm")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(PatientBabyId))]
        [InverseProperty(nameof(Patient.PregnantFormPatientBaby))]
        public virtual Patient PatientBaby { get; set; }
        [ForeignKey(nameof(PatientWomanId))]
        [InverseProperty(nameof(Patient.PregnantFormPatientWoman))]
        public virtual Patient PatientWoman { get; set; }
        [ForeignKey(nameof(ReferredBy))]
        [InverseProperty(nameof(User.PregnantForm))]
        public virtual User ReferredByNavigation { get; set; }
        [ForeignKey(nameof(ReferredTo))]
        [InverseProperty(nameof(Facility.PregnantFormReferredToNavigation))]
        public virtual Facility ReferredToNavigation { get; set; }
        [ForeignKey(nameof(ReferringFacility))]
        [InverseProperty(nameof(Facility.PregnantFormReferringFacilityNavigation))]
        public virtual Facility ReferringFacilityNavigation { get; set; }
    }
}
