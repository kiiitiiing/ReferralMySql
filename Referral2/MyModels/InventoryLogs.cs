﻿using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class InventoryLogs
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int EncodedBy { get; set; }
        public int InventoryId { get; set; }
        public int Capacity { get; set; }
        public int Occupied { get; set; }
        public int Available { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
