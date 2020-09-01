using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Seen
    {
        public int Id { get; set; }
        public int TrackingId { get; set; }
        public int FacilityId { get; set; }
        public int UserMd { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
