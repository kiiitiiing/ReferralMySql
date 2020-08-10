using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Tracking
    {
        public Tracking()
        {
            Issue = new HashSet<Issue>();
            Seen = new HashSet<Seen>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("date_referred")]
        public DateTime DateReferred { get; set; }
        [Column("date_transferred")]
        public DateTime DateTransferred { get; set; }
        [Column("date_accepted")]
        public DateTime DateAccepted { get; set; }
        [Column("date_arrived")]
        public DateTime DateArrived { get; set; }
        [Column("date_seen")]
        public DateTime DateSeen { get; set; }
        [Column("mode_transportation")]
        [StringLength(50)]
        public string ModeTransportation { get; set; }
        [Column("referred_from")]
        public int ReferredFrom { get; set; }
        [Column("referred_to")]
        public int ReferredTo { get; set; }
        [Column("department_id")]
        public int? DepartmentId { get; set; }
        [Column("referring_md")]
        public int? ReferringMd { get; set; }
        [Column("action_md")]
        public int? ActionMd { get; set; }
        [Column("remarks", TypeName = "text")]
        public string Remarks { get; set; }
        [Required]
        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Column("walkin")]
        [StringLength(255)]
        public string Walkin { get; set; }
        [Column("form_id")]
        public int? FormId { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(ActionMd))]
        [InverseProperty(nameof(User.TrackingActionMdNavigation))]
        public virtual User ActionMdNavigation { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Tracking")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Tracking")]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(ReferredFrom))]
        [InverseProperty(nameof(Facility.TrackingReferredFromNavigation))]
        public virtual Facility ReferredFromNavigation { get; set; }
        [ForeignKey(nameof(ReferredTo))]
        [InverseProperty(nameof(Facility.TrackingReferredToNavigation))]
        public virtual Facility ReferredToNavigation { get; set; }
        [ForeignKey(nameof(ReferringMd))]
        [InverseProperty(nameof(User.TrackingReferringMdNavigation))]
        public virtual User ReferringMdNavigation { get; set; }
        [InverseProperty("Tracking")]
        public virtual ICollection<Issue> Issue { get; set; }
        [InverseProperty("Tracking")]
        public virtual ICollection<Seen> Seen { get; set; }
    }
}
