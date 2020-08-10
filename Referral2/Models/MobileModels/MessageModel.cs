using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.MobileModels
{
    public class MessageModel
    {
        public int ID { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsSeen { get; set; }
        public bool IsSent { get; set; }
        public int Sender_UserID { get; set; }
        public int Receiver_UserID { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public string Receiver { get; set; }
        public string Receivers { get; set; }
        public string Sender_Endpoint { get; set; }
        public string Receiver_Endpoint { get; set; }
        public List<string> Receiver_Endpoints { get; set; }
        public DateTime Date_Delivered { get; set; }
        public DateTime Date_Seen { get; set; }
        public DateTime Date_Sent { get; set; }
        public bool IsSelf { get; set; }
    }
}
