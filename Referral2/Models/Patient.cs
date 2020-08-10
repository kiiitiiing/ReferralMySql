using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Activity = new HashSet<Activity>();
            BabyBabyNavigation = new HashSet<Baby>();
            BabyMother = new HashSet<Baby>();
            PatientForm = new HashSet<PatientForm>();
            PregnantFormPatientBaby = new HashSet<PregnantForm>();
            PregnantFormPatientWoman = new HashSet<PregnantForm>();
            Tracking = new HashSet<Tracking>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("unique_id")]
        [StringLength(50)]
        public string UniqueId { get; set; }
        [Required]
        [Column("fname")]
        [StringLength(50)]
        public string Fname { get; set; }
        [Column("mname")]
        [StringLength(50)]
        public string Mname { get; set; }
        [Column("lname")]
        [StringLength(50)]
        public string Lname { get; set; }
        [Column("dob", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Column("sex")]
        [StringLength(50)]
        public string Sex { get; set; }
        [Required]
        [Column("civil_status")]
        [StringLength(50)]
        public string CivilStatus { get; set; }
        [Column("phic_id")]
        [StringLength(50)]
        public string PhicId { get; set; }
        [Column("phic_status")]
        [StringLength(50)]
        public string PhicStatus { get; set; }
        [Column("barangay_id")]
        public int? BarangayId { get; set; }
        [Column("muncity_id")]
        public int? MuncityId { get; set; }
        [Column("province_id")]
        public int? ProvinceId { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("tsekap_patient")]
        public int? TsekapPatient { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(BarangayId))]
        [InverseProperty("Patient")]
        public virtual Barangay Barangay { get; set; }
        [ForeignKey(nameof(MuncityId))]
        [InverseProperty("Patient")]
        public virtual Muncity Muncity { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty("Patient")]
        public virtual Province Province { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<Activity> Activity { get; set; }
        [InverseProperty(nameof(Baby.BabyNavigation))]
        public virtual ICollection<Baby> BabyBabyNavigation { get; set; }
        [InverseProperty(nameof(Baby.Mother))]
        public virtual ICollection<Baby> BabyMother { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<PatientForm> PatientForm { get; set; }
        [InverseProperty(nameof(PregnantForm.PatientBaby))]
        public virtual ICollection<PregnantForm> PregnantFormPatientBaby { get; set; }
        [InverseProperty(nameof(PregnantForm.PatientWoman))]
        public virtual ICollection<PregnantForm> PregnantFormPatientWoman { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<Tracking> Tracking { get; set; }
    }
}
