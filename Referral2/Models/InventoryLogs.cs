using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    [Table("Inventory_Logs")]
    public partial class InventoryLogs
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("facility_id")]
        public int FacilityId { get; set; }
        [Column("encoded_by")]
        public int EncodedBy { get; set; }
        [Column("inventory_id")]
        public int InventoryId { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }
        [Column("occupied")]
        public int Occupied { get; set; }
        [Column("available")]
        public int Available { get; set; }
        [Column("time_created")]
        public TimeSpan TimeCreated { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(EncodedBy))]
        [InverseProperty(nameof(User.InventoryLogs))]
        public virtual User EncodedByNavigation { get; set; }
        [ForeignKey(nameof(FacilityId))]
        [InverseProperty("InventoryLogs")]
        public virtual Facility Facility { get; set; }
        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("InventoryLogs")]
        public virtual Inventory Inventory { get; set; }
    }
}
