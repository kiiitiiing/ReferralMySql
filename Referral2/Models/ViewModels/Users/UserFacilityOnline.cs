using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Users
{
    public partial class UserFacilityOnline
    {
        public List<WhosOnlineModel> Users { get; set; }
        public List<FacilitiesOnline> Facilities { get; set; }
    }
}
