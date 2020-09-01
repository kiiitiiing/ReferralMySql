using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Referral2.Data;
using Referral2.MyModels;
using Referral2.Helpers;
using Referral2.Models.ViewModels.Users;
using Microsoft.EntityFrameworkCore;
using Referral2.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Referral2.MyData;

namespace Referral2.Controllers
{
    public class UsersController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IUserService _userService;

        public UsersController(MySqlReferralContext context, IUserService userService, IOptions<ReferralRoles> roles)
        {
            _context = context;
            _userService = userService;
            _roles = roles;
        }
        #region WHOS ONLINE
        [Authorize]
        public async Task<IActionResult> WhosOnline()
        {
            var logins = _context.Login.Where(x => x.Login1.Date.Equals(DateTime.Now.Date));

            var onlineUsers = from user in _context.Users.Where(x=>x.LoginStatus.Contains("login") && x.Level != _roles.Value.ADMIN && x.LastLogin.Date == DateTime.Now.Date)
                              join facility in _context.Facility on user.FacilityId equals facility.Id
                              join dep in _context.Department on user.DepartmentId equals dep.Id into departments
                              from department in departments.DefaultIfEmpty()
                              select new WhosOnlineModel
                              {
                                  Level = user.Level,
                                  Fname = user.Fname,
                                  Mname = user.Mname,
                                  Lname = user.Lname,
                                  FacilityAbrv = facility.Abbr,
                                  Contact = user.Contact,
                                  Department = department.Description,
                                  LoginStatus = logins.Where(x=>x.UserId == user.Id).Count() == 0 ? false : logins.Where(x => x.UserId == user.Id).OrderByDescending(i => i.Login1).First().Status.Equals("login"),
                                  LoginTime = logins.Where(x => x.UserId == user.Id).Count() == 0 ? default : logins.Where(x => x.UserId == user.Id).OrderByDescending(i => i.Login1).First().Login1
                              };

            var users = _context.Users;

            var onlineFacilities = from facility in _context.Facility.Where(x=>x.Id != 63)
                                   join province in _context.Province on facility.Province equals province.Id
                                   select new FacilitiesOnline
                                   {
                                       Name = facility.Name,
                                       Province = province.Description,
                                       Status = users.Any(x=>x.FacilityId == facility.Id && x.LastLogin.Date >= DateTime.Now.Date && x.LoginStatus.Contains("login"))
                                   };

            var model = new UserFacilityOnline
            {
                Facilities = await onlineFacilities.ToListAsync(),
                Users = await onlineUsers.ToListAsync()
            };

            return View(model);
        }
        #endregion
        #region CHANGE PASSWORD
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return PartialView("~/Views/Users/ChangePassword.cshtml");
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (isValid, user) = await _userService.ValidateUserCredentialsAsync(UserUsername, model.CurrentPassword);


                if (isValid)
                {
                    //_userService.ChangePasswordAsync(user, model.NewPassword);
                    return PartialView("~/Views/Users/ChangePassword.cshtml", model);
                }
                else
                {
                    ModelState.AddModelError("CurrentPassword", "Wrong Password!");
                }
            }

            return PartialView("~/Views/Users/ChangePassword.cshtml", model);
        }
        #endregion

        #region HELPERS
        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));
        public int? UserDepartment => string.IsNullOrEmpty(User.FindFirstValue("Department")) ? null : (int?)int.Parse(User.FindFirstValue("Department"));
        public int UserProvince => int.Parse(User.FindFirstValue("Province"));
        public int UserMuncity => int.Parse(User.FindFirstValue("Muncity"));
        public int UserBarangay => int.Parse(User.FindFirstValue("Barangay"));
        public string UserUsername => User.FindFirstValue(ClaimTypes.Name);
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        #endregion
    }
}