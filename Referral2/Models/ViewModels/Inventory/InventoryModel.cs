using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.ViewModels.Inventory
{
    public partial class InventoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        [Required]
        public int Occupied { get; set; }
        [Required]
        public int Available { get; set; }
    }
}
