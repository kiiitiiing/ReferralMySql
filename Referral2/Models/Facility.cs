using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Facility
    {
        public Facility()
        {
            ActivityReferredFromNavigation = new HashSet<Activity>();
            ActivityReferredToNavigation = new HashSet<Activity>();
            Inventory = new HashSet<Inventory>();
            InventoryLogs = new HashSet<InventoryLogs>();
            PatientFormReferredToNavigation = new HashSet<PatientForm>();
            PatientFormReferringFacilityNavigation = new HashSet<PatientForm>();
            PregnantFormReferredToNavigation = new HashSet<PregnantForm>();
            PregnantFormReferringFacilityNavigation = new HashSet<PregnantForm>();
            Seen = new HashSet<Seen>();
            TrackingReferredFromNavigation = new HashSet<Tracking>();
            TrackingReferredToNavigation = new HashSet<Tracking>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("facility_code")]
        [StringLength(100)]
        public string FacilityCode { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("abbr")]
        [StringLength(255)]
        public string Abbr { get; set; }
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Column("barangay_id")]
        public int? BarangayId { get; set; }
        [Column("muncity_id")]
        public int? MuncityId { get; set; }
        [Column("province_id")]
        public int ProvinceId { get; set; }
        [Column("contact_no")]
        [StringLength(255)]
        public string ContactNo { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("picture")]
        [StringLength(255)]
        public string Picture { get; set; }
        [Column("chief_hospital")]
        [StringLength(100)]
        public string ChiefHospital { get; set; }
        [Column("level")]
        [StringLength(50)]
        public string Level { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(BarangayId))]
        [InverseProperty("Facility")]
        public virtual Barangay Barangay { get; set; }
        [ForeignKey(nameof(MuncityId))]
        [InverseProperty("Facility")]
        public virtual Muncity Muncity { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty("Facility")]
        public virtual Province Province { get; set; }
        [InverseProperty(nameof(Activity.ReferredFromNavigation))]
        public virtual ICollection<Activity> ActivityReferredFromNavigation { get; set; }
        [InverseProperty(nameof(Activity.ReferredToNavigation))]
        public virtual ICollection<Activity> ActivityReferredToNavigation { get; set; }
        [InverseProperty("Facility")]
        public virtual ICollection<Inventory> Inventory { get; set; }
        [InverseProperty("Facility")]
        public virtual ICollection<InventoryLogs> InventoryLogs { get; set; }
        [InverseProperty(nameof(PatientForm.ReferredToNavigation))]
        public virtual ICollection<PatientForm> PatientFormReferredToNavigation { get; set; }
        [InverseProperty(nameof(PatientForm.ReferringFacilityNavigation))]
        public virtual ICollection<PatientForm> PatientFormReferringFacilityNavigation { get; set; }
        [InverseProperty(nameof(PregnantForm.ReferredToNavigation))]
        public virtual ICollection<PregnantForm> PregnantFormReferredToNavigation { get; set; }
        [InverseProperty(nameof(PregnantForm.ReferringFacilityNavigation))]
        public virtual ICollection<PregnantForm> PregnantFormReferringFacilityNavigation { get; set; }
        [InverseProperty("Facility")]
        public virtual ICollection<Seen> Seen { get; set; }
        [InverseProperty(nameof(Tracking.ReferredFromNavigation))]
        public virtual ICollection<Tracking> TrackingReferredFromNavigation { get; set; }
        [InverseProperty(nameof(Tracking.ReferredToNavigation))]
        public virtual ICollection<Tracking> TrackingReferredToNavigation { get; set; }
        [InverseProperty("Facility")]
        public virtual ICollection<User> User { get; set; }
    }
}
