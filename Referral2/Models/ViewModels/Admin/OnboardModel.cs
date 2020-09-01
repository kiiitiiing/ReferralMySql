using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Admin
{
    public partial class OnboardModel
    {
        public string Name { get; set; }
        public string Chief { get; set; }
        public string ContactNo { get; set; }
        public string Type { get; set; }
        public string Province { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LoginAt { get; set; }
        public bool ActivitiesFrom { get; set; }
        public bool ActivitiesTo { get; set; }
    }
}
