using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.MobileModels
{
    public class UserModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Level { get; set; }
        public string Department { get; set; }
        public string Facility { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public bool LoginStatus { get; set; }
        public string IPAddress { get; set; }
        public string Origin { get; set; }
    }
}
