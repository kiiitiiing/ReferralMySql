using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral2.Models
{
    public partial class Feedback
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("code")]
        [StringLength(255)]
        public string Code { get; set; }
        [Column("sender_id")]
        public int SenderId { get; set; }
        [Column("reciever_id")]
        public int? RecieverId { get; set; }
        [Required]
        [Column("message", TypeName = "text")]
        public string Message { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(RecieverId))]
        [InverseProperty(nameof(User.FeedbackReciever))]
        public virtual User Reciever { get; set; }
        [ForeignKey(nameof(SenderId))]
        [InverseProperty(nameof(User.FeedbackSender))]
        public virtual User Sender { get; set; }
    }
}
