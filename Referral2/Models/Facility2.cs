using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    [Table("facility2")]
    public partial class Facility2
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("facility_code")]
        [StringLength(100)]
        public string FacilityCode { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("abbr")]
        [StringLength(255)]
        public string Abbr { get; set; }
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Column("barangay_id")]
        public int? BarangayId { get; set; }
        [Column("muncity_id")]
        public int? MuncityId { get; set; }
        [Column("province_id")]
        public int ProvinceId { get; set; }
        [Column("contact_no")]
        [StringLength(255)]
        public string ContactNo { get; set; }
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("picture")]
        [StringLength(255)]
        public string Picture { get; set; }
        [Column("chief_hospital")]
        [StringLength(100)]
        public string ChiefHospital { get; set; }
        [Column("level")]
        [StringLength(50)]
        public string Level { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
