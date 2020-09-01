using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Province
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
