using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class ReferenceNumber
    {
        public int ReferenceNumber1 { get; set; }
        public int? EncodedBy { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
