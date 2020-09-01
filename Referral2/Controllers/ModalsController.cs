using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.MyModels;
using Referral2.Models.ViewModels;
using Referral2.MyData;

namespace Referral2.Controllers
{
    public class ModalsController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;

        public ModalsController(MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _roles = roles;
            _status = status;
        }

        #region SEEN
        // Get Seens
        public async Task<IActionResult> ViewSeens(int trackingId)
        {
            var seens = from seen in _context.Seen.Where(x => x.TrackingId.Equals(trackingId))
                        join user in _context.Users on seen.UserMd equals user.Id
                        select new SeenCallViewModel
                        {
                            MdName = user.Level.GetFullName(user.Fname, user.Mname, user.Lname),
                            MdContact = user.Contact,
                            SeenDate = seen.CreatedAt.Value.DateTime
                        };

            return PartialView(await seens.AsNoTracking().ToListAsync());
        }
        #endregion
        #region CALLS
        // Get calls
        public async Task<IActionResult> ViewCalls(string code)
        {
            var calls = from activity in _context.Activity.Where(x => x.Code.Equals(code) && x.Status.Equals(_status.Value.CALLING))
                        join user in _context.Users on activity.ActionMd equals user.Id
                        select new SeenCallViewModel
                        {
                            MdName = user.Level.GetFullName(user.Fname, user.Mname, user.Lname),
                            SeenDate = activity.DateReferred,
                            MdContact = user.Contact
                        };

            return PartialView(await calls.AsNoTracking().ToListAsync());
        }
        #endregion
        #region RECO
        // Get Feedback
        public IActionResult ViewReco(string code)
        {
            var feedbacks = from feedback in _context.Feedback.Where(x => x.Code.Equals(code)).ToList()
                            join sender in _context.Users on feedback.Sender equals sender.Id
                            join faciity in _context.Facility on sender.FacilityId equals faciity.Id
                            select new RecoViewModel
                            {
                                Code = feedback.Code,
                                Sender = feedback.Sender,
                                Receiver = feedback.Receiver,
                                FacilityName = faciity.Name,
                                Message = feedback.Message,
                                SenderName = sender.Level.GetFullName(sender.Fname, sender.Mname, sender.Lname),
                                CreatedAt = feedback.CreatedAt.Value.DateTime,
                                UpdatedAt = feedback.UpdatedAt.Value.DateTime
                            };

            var chats = new ChatsModel
            {
                Chats = feedbacks.ToList(),
                Code = code
            };

            return PartialView(chats);
        }
        // POST Feedback
        [HttpPost]
        public async Task<IActionResult> ViewReco(ChatsModel model)
        {
            if (ModelState.IsValid)
            {
                var feedback = new Feedback
                {
                    Code = model.Code,
                    Sender = model.Sender,
                    Receiver = 0,
                    Message = model.Message,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                  _context.Add(feedback);
                  await _context.SaveChangesAsync();
                ViewBag.IsValid = true;
            }

            var feedbacks = from feedback in _context.Feedback.Where(x => x.Code.Equals(model.Code)).ToList()
                            join sender in _context.Users on feedback.Sender equals sender.Id
                            join faciity in _context.Facility on sender.FacilityId equals faciity.Id
                            select new RecoViewModel
                            {
                                Code = feedback.Code,
                                Sender = feedback.Sender,
                                Receiver = feedback.Receiver,
                                FacilityName = faciity.Name,
                                Message = feedback.Message,
                                SenderName = sender.Level.GetFullName(sender.Fname, sender.Mname, sender.Lname),
                                CreatedAt = feedback.CreatedAt.Value.DateTime,
                                UpdatedAt = feedback.UpdatedAt.Value.DateTime
                            };

            var chatsModel = new ChatsModel()
            {
                Chats = feedbacks.ToList(),
                Code = model.Code,
                Message = ""
            };
            ViewBag.IsValid = false;
            return PartialView(chatsModel);
        }
        #endregion

        #region HELPERS

        public int UserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public int UserFacility()
        {
            return int.Parse(User.FindFirstValue("Facility"));
        }
        public int UserDepartment()
        {
            return int.Parse(User.FindFirstValue("Department"));
        }
        public int UserProvince()
        {
            return int.Parse(User.FindFirstValue("Province"));
        }
        public int UserMuncity()
        {
            return int.Parse(User.FindFirstValue("Muncity"));
        }
        public int UserBarangay()
        {
            return int.Parse(User.FindFirstValue("Barangay"));
        }
        public string UserName()
        {
            return "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        }


        #endregion
    }
}