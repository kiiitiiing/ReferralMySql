using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Devicetoken
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
