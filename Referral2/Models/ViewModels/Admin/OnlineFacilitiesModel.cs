using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Admin
{
    public class OnlineFacilitiesModel
    {
        public string Province { get; set; }
        public string Name { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public string Status { get; set; }
    }
}
