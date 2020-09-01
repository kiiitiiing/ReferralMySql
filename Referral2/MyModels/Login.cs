using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Login
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Login1 { get; set; }
        public DateTime Logout { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
