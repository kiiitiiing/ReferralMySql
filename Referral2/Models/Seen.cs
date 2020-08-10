using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Seen
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("tracking_id")]
        public int TrackingId { get; set; }
        [Column("facility_id")]
        public int FacilityId { get; set; }
        [Column("user_md")]
        public int UserMd { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(FacilityId))]
        [InverseProperty("Seen")]
        public virtual Facility Facility { get; set; }
        [ForeignKey(nameof(TrackingId))]
        [InverseProperty("Seen")]
        public virtual Tracking Tracking { get; set; }
        [ForeignKey(nameof(UserMd))]
        [InverseProperty(nameof(User.Seen))]
        public virtual User UserMdNavigation { get; set; }
    }
}
