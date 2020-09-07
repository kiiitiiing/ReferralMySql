using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Referral2.MyModels
{
    public partial class Issue
    {
        public int Id { get; set; }
        public int TrackingId { get; set; }
        [Required]
        public string Issue1 { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
