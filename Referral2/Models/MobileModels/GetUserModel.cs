using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.MobileModels
{
    public class GetUserModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public List<UserModel> Groupchat { get; set; }
    }
}
