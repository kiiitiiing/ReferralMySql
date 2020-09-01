using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Account
{
    public partial class CookiesModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public int Province { get; set; }
        public int Muncity { get; set; }
        public string Contact { get; set; }
        public string Level { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
