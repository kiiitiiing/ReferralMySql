using System;

namespace Referral2.Models.ViewModels.Users
{
    public partial class WhosOnlineModel
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public string Level { get; set; }
        public int FacilityId { get; set; }
        public string FacilityAbrv { get; set; }
        public string Contact { get; set; }
        public string Department { get; set; }
        public bool LoginStatus { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
