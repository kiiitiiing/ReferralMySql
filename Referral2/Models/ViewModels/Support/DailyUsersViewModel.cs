using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Support
{
    public partial class DailyUsersViewModel
    {
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string OnDuty { get; set; }
        public bool LoggedIn { get;set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
    }
}
