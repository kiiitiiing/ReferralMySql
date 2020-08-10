using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Referral2.Models.MobileModels
{
    public class LoginModel
    {
        public bool Authenticated { get; set; }
        public int UserId { get; set; }
    }
}
