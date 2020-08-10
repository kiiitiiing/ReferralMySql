using Referral2.Models.ViewModels.ViewPatients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.MobileModels
{
    public class RequestModel
    {
        public string InformationType { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public List<UserModel> ListUserInformation { get; set; }
        public UserModel UserInformation { get; set; }
        public MessageModel ClientMessage { get; set; }
        public NotificationModel PatientNotification { get; set; }
    }
}
