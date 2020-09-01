using System;
using System.Collections.Generic;

namespace Referral2.MyModels
{
    public partial class Baby
    {
        public int Id { get; set; }
        public int BabyId { get; set; }
        public int MotherId { get; set; }
        public int Weight { get; set; }
        public int GestationalAge { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
