using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Tracking
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int PatientId { get; set; }
        public DateTime DateReferred { get; set; }
        public DateTime DateTransferred { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateArrived { get; set; }
        public DateTime DateSeen { get; set; }
        public string ModeTransportation { get; set; }
        public int ReferredFrom { get; set; }
        public int ReferredTo { get; set; }
        public int DepartmentId { get; set; }
        public int ReferringMd { get; set; }
        public int ActionMd { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Walkin { get; set; }
        public int FormId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
