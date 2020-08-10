using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Issue
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("tracking_id")]
        public int TrackingId { get; set; }
        [Required]
        [Column("issue")]
        [StringLength(255)]
        public string Issue1 { get; set; }
        [Required]
        [Column("status")]
        [StringLength(255)]
        public string Status { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(TrackingId))]
        [InverseProperty("Issue")]
        public virtual Tracking Tracking { get; set; }
    }
}
