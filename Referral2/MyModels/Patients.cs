using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Patients
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string PhicId { get; set; }
        public string PhicStatus { get; set; }
        public int Brgy { get; set; }
        public int Muncity { get; set; }
        public int Province { get; set; }
        public string Address { get; set; }
        public int TsekapPatient { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
