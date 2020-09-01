using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Bed
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int EncodedBy { get; set; }
        public string Name { get; set; }
        public string Temporary { get; set; }
        public int AllowableNo { get; set; }
        public int ActualNo { get; set; }
        public string Status { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
