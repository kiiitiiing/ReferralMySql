using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Activity
    {
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
        [Column("date_seen")]
        public DateTime DateSeen { get; set; }
        [Column("referred_from")]
        public int ReferredFrom { get; set; }
        [Column("referred_to")]
        public int? ReferredTo { get; set; }
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
        [StringLength(255)]
        public string Status { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(ActionMd))]
        [InverseProperty(nameof(User.ActivityActionMdNavigation))]
        public virtual User ActionMdNavigation { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Activity")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Activity")]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(ReferredFrom))]
        [InverseProperty(nameof(Facility.ActivityReferredFromNavigation))]
        public virtual Facility ReferredFromNavigation { get; set; }
        [ForeignKey(nameof(ReferredTo))]
        [InverseProperty(nameof(Facility.ActivityReferredToNavigation))]
        public virtual Facility ReferredToNavigation { get; set; }
        [ForeignKey(nameof(ReferringMd))]
        [InverseProperty(nameof(User.ActivityReferringMdNavigation))]
        public virtual User ReferringMdNavigation { get; set; }
    }
}
