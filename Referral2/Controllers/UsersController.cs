﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Referral2.Data;
using Referral2.Models;
using Referral2.Helpers;
using Referral2.Models.ViewModels.Users;
using Microsoft.EntityFrameworkCore;
using Referral2.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace Referral2.Controllers
{
    public class UsersController : Controller
    {
        private readonly ReferralDbContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IUserService _userService;

        public UsersController(ReferralDbContext context, IUserService userService, IOptions<ReferralRoles> roles)
        {
            _context = context;
            _userService = userService;
            _roles = roles;
        }
        #region WHOS ONLINE
        [Authorize(Policy = "Doctor")]
        public async Task<IActionResult> WhosOnline(string nameSearch, int? facilitySearch)
        {
            ViewBag.CurrentSearch = nameSearch;
            ViewBag.Facilities = new SelectList(_context.Facility.Where(x => x.ProvinceId.Equals(UserProvince)), "Id", "Name");
            var logins = _context.Login.Where(x => x.Login1.Date.Equals(DateTime.Now.Date));
            var onlineUsers = await _context.User
                .Where(x => x.LoginStatus.Contains("login") && x.Level.Equals(_roles.Value.DOCTOR) && x.LastLogin.Date.Equals(DateTime.Now.Date) && x.FacilityId.Equals(UserFacility))
                .Select(x => new WhosOnlineModel
                {
                    DoctorName = GlobalFunctions.GetMDFullName(x),
                    FacilityAbrv = x.Facility.Abbr,
                    Contact = x.ContactNo,
                    Department = x.Department.Description,
                    LoginStatus = logins.Where(i => i.UserId.Equals(x.Id)).OrderByDescending(i => i.Login1).First().Status.Equals("login"),
                    LoginTime = logins.Where(i => i.UserId.Equals(x.Id)).OrderByDescending(i => i.Login1).First().Login1
                })
                .ToListAsync();

            var onlineFacilities = await _context.Facility
                .Include(x => x.Province)
                .Include(x => x.User)
                .Where(x => x.User.Any(x => x.Level == "doctor" && x.LastLogin >= DateTime.Now.Date))
                .Select(x => new FacilitiesOnline
                {
                    Name = x.Name,
                    Province = x.Province.Description,
                    Status = x.User.Any(x => x.LastLogin >= DateTime.Now.Date && x.LoginStatus == "login")
                })
                .ToListAsync();


            if (!string.IsNullOrEmpty(nameSearch))
            {
                onlineUsers.Where(x => x.DoctorName.Contains(nameSearch));
            }
            if (facilitySearch != 0)
            {
                onlineUsers.Where(x => x.FacilityId.Equals(facilitySearch));
            }

            var model = new UserFacilityOnline
            {
                Facilities = onlineFacilities,
                Users = onlineUsers
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
                    _userService.ChangePasswordAsync(user, model.NewPassword);
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