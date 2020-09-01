using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels
{
    public class RecoViewModel
    {
        public string Code { get; set; }
        public int Sender { get; set; }
        public string SenderName { get; set; }
        public string FacilityName { get; set; }
        public int Receiver { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
