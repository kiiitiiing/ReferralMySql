using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.MobileModels
{
    public class NotificationModel
    {
        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public string TrackStatus { get; set; }
        public string DisplayNotification { get; set; }
        public string ReferringDoctor { get; set; }
        public string ReferringDoctorFacility { get; set; }
        public string ReferredDoctor { get; set; }
        public string ReferredDoctorFacility { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
