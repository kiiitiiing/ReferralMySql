﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Doctor
{
    public partial class PatientsViewModel
    {
        public int PatientId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string PatientSex { get; set; }
        public int PatientAge { get; set; }
        public DateTime DateofBirth { get; set; }
        public int? MuncityId { get; set; }
        public string Muncity { get; set; }
        public int? BarangayId { get; set; }
        public string Barangay { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
