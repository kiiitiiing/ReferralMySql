﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Referral2.Models.ViewModels.Remarks
{
    public class IssuesModel
    {
        [Required]
        public int TrackingId { get; set; }
        [Required]
        public List<Referral2.MyModels.Issue> Issues { get; set; }
    }
}
