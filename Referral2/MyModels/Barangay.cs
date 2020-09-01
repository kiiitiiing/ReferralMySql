using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Barangay
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int MuncityId { get; set; }
        public string Description { get; set; }
        public int OldTarget { get; set; }
        public int Target { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
