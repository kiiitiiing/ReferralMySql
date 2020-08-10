using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryLogs = new HashSet<InventoryLogs>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("facility_id")]
        public int FacilityId { get; set; }
        [Column("encoded_by")]
        public int? EncodedBy { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }
        [Column("occupied")]
        public int Occupied { get; set; }
        [Column("available")]
        public int Available { get; set; }
        [Required]
        [Column("status")]
        [StringLength(255)]
        public string Status { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(EncodedBy))]
        [InverseProperty(nameof(User.Inventory))]
        public virtual User EncodedByNavigation { get; set; }
        [ForeignKey(nameof(FacilityId))]
        [InverseProperty("Inventory")]
        public virtual Facility Facility { get; set; }
        [InverseProperty("Inventory")]
        public virtual ICollection<InventoryLogs> InventoryLogs { get; set; }
    }
}
