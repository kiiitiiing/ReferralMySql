using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.ViewPatients
{
    public partial class DischargedViewModel
    {
        public string ReferringFacility { get; set; }
        public string Type { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Code { get; set; }
        public DateTimeOffset DateAction { get; set; }
        public string Status { get; set; }
    }
}
