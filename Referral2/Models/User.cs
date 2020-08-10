using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class User
    {
        public User()
        {
            ActivityActionMdNavigation = new HashSet<Activity>();
            ActivityReferringMdNavigation = new HashSet<Activity>();
            FeedbackReciever = new HashSet<Feedback>();
            FeedbackSender = new HashSet<Feedback>();
            Inventory = new HashSet<Inventory>();
            InventoryLogs = new HashSet<InventoryLogs>();
            Login = new HashSet<Login>();
            PatientFormReferredMdNavigation = new HashSet<PatientForm>();
            PatientFormReferringMdNavigation = new HashSet<PatientForm>();
            PregnantForm = new HashSet<PregnantForm>();
            Seen = new HashSet<Seen>();
            TrackingActionMdNavigation = new HashSet<Tracking>();
            TrackingReferringMdNavigation = new HashSet<Tracking>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [Column("level")]
        [StringLength(50)]
        public string Level { get; set; }
        [Column("facility_id")]
        public int FacilityId { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Required]
        [Column("fname")]
        [StringLength(50)]
        public string Fname { get; set; }
        [Column("mname")]
        [StringLength(50)]
        public string Mname { get; set; }
        [Required]
        [Column("lname")]
        [StringLength(50)]
        public string Lname { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [Column("contact_no")]
        [StringLength(50)]
        public string ContactNo { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("muncity_id")]
        public int? MuncityId { get; set; }
        [Column("province_id")]
        public int ProvinceId { get; set; }
        [Column("accreditation_no")]
        [StringLength(255)]
        public string AccreditationNo { get; set; }
        [Column("accreditation_validity")]
        [StringLength(255)]
        public string AccreditationValidity { get; set; }
        [Column("license_no")]
        [StringLength(255)]
        public string LicenseNo { get; set; }
        [Column("prefix")]
        [StringLength(255)]
        public string Prefix { get; set; }
        [Column("picture")]
        [StringLength(255)]
        public string Picture { get; set; }
        [Column("designation")]
        [StringLength(255)]
        public string Designation { get; set; }
        [Column("status")]
        [StringLength(255)]
        public string Status { get; set; }
        [Column("last_login")]
        public DateTime LastLogin { get; set; }
        [Column("login_status")]
        [StringLength(255)]
        public string LoginStatus { get; set; }
        [Column("remember_token")]
        [StringLength(255)]
        public string RememberToken { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("User")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(FacilityId))]
        [InverseProperty("User")]
        public virtual Facility Facility { get; set; }
        [ForeignKey(nameof(MuncityId))]
        [InverseProperty("User")]
        public virtual Muncity Muncity { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        [InverseProperty("User")]
        public virtual Province Province { get; set; }
        [InverseProperty(nameof(Activity.ActionMdNavigation))]
        public virtual ICollection<Activity> ActivityActionMdNavigation { get; set; }
        [InverseProperty(nameof(Activity.ReferringMdNavigation))]
        public virtual ICollection<Activity> ActivityReferringMdNavigation { get; set; }
        [InverseProperty(nameof(Feedback.Reciever))]
        public virtual ICollection<Feedback> FeedbackReciever { get; set; }
        [InverseProperty(nameof(Feedback.Sender))]
        public virtual ICollection<Feedback> FeedbackSender { get; set; }
        [InverseProperty("EncodedByNavigation")]
        public virtual ICollection<Inventory> Inventory { get; set; }
        [InverseProperty("EncodedByNavigation")]
        public virtual ICollection<InventoryLogs> InventoryLogs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Login> Login { get; set; }
        [InverseProperty(nameof(PatientForm.ReferredMdNavigation))]
        public virtual ICollection<PatientForm> PatientFormReferredMdNavigation { get; set; }
        [InverseProperty(nameof(PatientForm.ReferringMdNavigation))]
        public virtual ICollection<PatientForm> PatientFormReferringMdNavigation { get; set; }
        [InverseProperty("ReferredByNavigation")]
        public virtual ICollection<PregnantForm> PregnantForm { get; set; }
        [InverseProperty("UserMdNavigation")]
        public virtual ICollection<Seen> Seen { get; set; }
        [InverseProperty(nameof(Tracking.ActionMdNavigation))]
        public virtual ICollection<Tracking> TrackingActionMdNavigation { get; set; }
        [InverseProperty(nameof(Tracking.ReferringMdNavigation))]
        public virtual ICollection<Tracking> TrackingReferringMdNavigation { get; set; }
    }
}
