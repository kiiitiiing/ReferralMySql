﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Province
    {
        public Province()
        {
            Barangay = new HashSet<Barangay>();
            Facility = new HashSet<Facility>();
            Muncity = new HashSet<Muncity>();
            Patient = new HashSet<Patient>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Province")]
        public virtual ICollection<Barangay> Barangay { get; set; }
        [InverseProperty("Province")]
        public virtual ICollection<Facility> Facility { get; set; }
        [InverseProperty("Province")]
        public virtual ICollection<Muncity> Muncity { get; set; }
        [InverseProperty("Province")]
        public virtual ICollection<Patient> Patient { get; set; }
        [InverseProperty("Province")]
        public virtual ICollection<User> User { get; set; }
    }
}
