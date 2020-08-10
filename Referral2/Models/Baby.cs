using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Baby
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("baby_id")]
        public int? BabyId { get; set; }
        [Column("mother_id")]
        public int MotherId { get; set; }
        [Column("weight")]
        public int Weight { get; set; }
        [Column("gestational_age")]
        public int GestationalAge { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(BabyId))]
        [InverseProperty(nameof(Patient.BabyBabyNavigation))]
        public virtual Patient BabyNavigation { get; set; }
        [ForeignKey(nameof(MotherId))]
        [InverseProperty(nameof(Patient.BabyMother))]
        public virtual Patient Mother { get; set; }
    }
}
