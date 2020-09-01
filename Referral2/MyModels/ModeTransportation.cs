using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class ModeTransportation
    {
        public int Id { get; set; }
        public string Transportation { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
