using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
        public int FacilityId { get; set; }
        public int DepartmentId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Title { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int Muncity { get; set; }
        public int Province { get; set; }
        public string AccreditationNo { get; set; }
        public string AccreditationValidity { get; set; }
        public string LicenseNo { get; set; }
        public string Prefix { get; set; }
        public string Picture { get; set; }
        public string Designation { get; set; }
        public string Status { get; set; }
        public DateTime LastLogin { get; set; }
        public string LoginStatus { get; set; }
        public string RememberToken { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
