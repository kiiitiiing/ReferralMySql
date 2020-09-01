using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.ViewPatients
{
    public partial class ReferredViewModel
    {
        public int PatientId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string PatientSex { get; set; }
        public int PatientAge { get; set; } 
        public int TrackingId { get; set; }
        public int SeenCount { get; set; }
        public int CallerCount { get; set; }
        public int IssueCount { get; set; }
        public bool Travel { get; set; }
        public int ReCoCount { get; set; }
        public string Barangay { get; set; }
        public string Muncity { get; set; }
        public string Province { get; set; }
        public string PatientAddress { get { return Barangay + ", " + Muncity + ", " + Province; } }
        public string ReferredBy { get; set; }
        public string ReferredTo { get; set; }
        public int? ReferredToId { get; set; }
        public int? ReferredFromId { get; set; }
        public string FacilityFrom { get; set; }
        public string FacilityTo { get; set; }
        public bool Pregnant { get; set; }
        public bool Seen { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public bool Walkin { get; set; }
        public IEnumerable<ActivityLess> Activities { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
