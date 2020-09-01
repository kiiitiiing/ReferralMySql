using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int PatientId { get; set; }
        public DateTime DateReferred { get; set; }
        public DateTime DateSeen { get; set; }
        public int ReferredFrom { get; set; }
        public int ReferredTo { get; set; }
        public int DepartmentId { get; set; }
        public int ReferringMd { get; set; }
        public int ActionMd { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
