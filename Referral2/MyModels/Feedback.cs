using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Message { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
