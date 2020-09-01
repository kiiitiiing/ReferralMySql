using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.ViewPatients
{
    public partial class CancelledViewModel
    {
        public string ReferringFacility { get; set; }
        public string PatientType { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string PatientCode { get; set; }
        public DateTimeOffset? DateCancelled { get; set; }
        public string ReasonCancelled { get; set; }
    }
}
