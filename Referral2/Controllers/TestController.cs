﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Referral2.MyModels;
using Referral2.MyData;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Referral2.Helpers;
using Referral2.Models.ViewModels.ViewPatients;
using Referral2.Data;
using Referral2.Models.ViewModels.Admin;

namespace Referral2.Controllers
{
    public class TestController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly ReferralDbContext _contextToo;
        private readonly IOptions<ReferralStatus> _status;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }

        public TestController(MySqlReferralContext context, ReferralDbContext contexttoo, IOptions<ReferralStatus> status)
        {
            _context = context;
            _contextToo = contexttoo;
            _status = status;
        }
        public ActionResult<List<Activity>> Index()
        {
            return _context.Activity.Take(10).ToList();
        }

        public ActionResult<List<DailyUsersAdminModel>> AcceptedPatient()
        {
            Date = DateTime.Now.Date;
            var logins = _contextToo.User
                .Join(
                    _contextToo.Login,
                    user => user.Id,
                    login => login.UserId,
                    (user, login) =>
                        new
                        {
                            UserId = user.Id,
                            UserFacility = user.FacilityId,
                            Level = user.Level,
                            Status = login.Status,
                            Login = login.Login1
                        }
                );

            var users = _contextToo.User;

            var dailyUsers = _contextToo.Facility
                .Select(i => new DailyUsersAdminModel
                {
                    Facility = i.Name,
                    OnDutyHP = logins.Where(x => x.UserFacility == i.Id && x.Login.Date == Date && x.Level == "doctor" && x.Status == "login").Select(x => x.UserId).Distinct().Count(),
                    OffDutyHP = logins.Where(x => x.UserFacility == i.Id && x.Login.Date == Date && x.Level == "doctor" && x.Status == "login_off").Select(x => x.UserId).Distinct().Count(),
                    OfflineHP = users.Where(x => x.FacilityId == i.Id && x.Level == "doctor").Count(),
                    OnlineIT = logins.Where(x => x.UserFacility == i.Id && x.Login.Date == Date && x.Level == "support").Select(x => x.UserId).Distinct().Count(),
                    OfflineIT = users.Where(x => x.FacilityId == i.Id && x.Level == "support").Count(),
                })
               .Take(10)
                .ToList();

            return dailyUsers;
        }

        #region HELPERS
        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));
        public int? UserDepartment => string.IsNullOrEmpty(User.FindFirstValue("Department")) ? null : (int?)int.Parse(User.FindFirstValue("Department"));
        public int UserProvince => int.Parse(User.FindFirstValue("Province"));
        public int UserMuncity => int.Parse(User.FindFirstValue("Muncity"));
        public int UserBarangay => int.Parse(User.FindFirstValue("Barangay"));
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);

        #endregion
    }
}
