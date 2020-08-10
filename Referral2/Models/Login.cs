using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Login
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("login")]
        public DateTime Login1 { get; set; }
        [Column("logout")]
        public DateTime Logout { get; set; }
        [Required]
        [Column("status")]
        [StringLength(255)]
        public string Status { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Login")]
        public virtual User User { get; set; }
    }
}
