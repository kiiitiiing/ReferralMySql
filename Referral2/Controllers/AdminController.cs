#region REFERRENCE
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.MyModels;
using Referral2.Models.ViewModels;
using Referral2.Models.ViewModels.Admin;
using Referral2.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Referral2.Models.ViewModels.Consolidated;
using Referral2.Models.ViewModels.ViewPatients;
using MoreLinq.Extensions;
using System.IO;
using OfficeOpenXml;
using System.Drawing;
using Referral2.Models.ViewModels.Users;
using Referral2.MyData;
using Referral2.Models.ViewModels.Account;
#endregion
namespace Referral2.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;

        public AdminController(MySqlReferralContext context, IUserService userService, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _userService = userService;
            _roles = roles;
            _status = status;
        }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime Date { get; set; }
        #region ADMIN DASHBOARD
        // DASHBOARD
        public IActionResult AdminDashboard()
        {
            var activities = _context.Activity.Where(x=>x.DateReferred.Year.Equals(DateTime.Now.Year));
            var totalDoctors = _context.Users.Where(x => x.Level.Equals("doctor")).Count();
            var onlineDoctors = _context.Users.Where(x => x.LastLogin.Date == DateTime.Now.Date && x.LoginStatus.Contains("login") && x.Level == _roles.Value.DOCTOR).Count();
            var activeFacility = _context.Facility.Count();
            var referredPatients = _context.Tracking.Where(x => x.DateReferred != default || x.DateAccepted != default || x.DateArrived != default).Count();

            var adminDashboard = new AdminDashboardViewModel(totalDoctors, onlineDoctors, activeFacility, referredPatients);

            return View(adminDashboard);
        }
        #endregion
        #region ADD FACILITY
        // GET: ADD FACILITY    
        public IActionResult AddFacility()
        {
            var provinces = _context.Province;
            ViewBag.Provinces = new SelectList(provinces, "Id", "Description");
            ViewBag.HospitalLevels = new SelectList(ListContainer.HospitalLevel, "Key", "Value");
            ViewBag.HospitalTypes = new SelectList(ListContainer.HospitalType, "Key", "Value");
            ViewBag.HospitalStatus = new SelectList(ListContainer.HospitalStatus, "Key", "Value");
            return PartialView();
        }

        // POST: ADD FACILITY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFacility([Bind] FacilityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var faciliy = await SetFacilityViewModelAsync(model);
                await _context.AddAsync(faciliy);
                await _context.SaveChangesAsync();
                return PartialView();
            }
            else
            {
                if (model.Province == null)
                    ModelState.AddModelError("Province", "Please select a province.");
                if (model.Muncity == null)
                    ModelState.AddModelError("Muncity", "Please select a municipality/city.");
                if (model.Barangay == null)
                    ModelState.AddModelError("Barangay", "Please select a barangay.");
                if (model.Level == null)
                    ModelState.AddModelError("Level", "Please select hospital level.");
                if (model.Type == null)
                    ModelState.AddModelError("Type", "Plase select hospital type.");
            }
            var provinces = _context.Province;
            ViewBag.Provinces = new SelectList(provinces, "Id", "Description", model.Province);
            if(model.Province != null)
            {
                var muncities = _context.Muncity.Where(x => x.ProvinceId == model.Province);
                ViewBag.Muncities = new SelectList(muncities, "Id", "Description", model.Muncity);
            }
            if(model.Muncity != null)
            {
                var barangays = _context.Barangay.Where(x => x.ProvinceId == model.Province && x.MuncityId == model.Muncity);
                ViewBag.Barangays = new SelectList(barangays, "Id", "Description", model.Barangay);
            }
            ViewBag.HospitalLevels = new SelectList(ListContainer.HospitalLevel, "Key", "Value");
            ViewBag.HospitalTypes = new SelectList(ListContainer.HospitalType, "Key", "Value");
            ViewBag.HospitalStatus = new SelectList(ListContainer.HospitalStatus, "Key", "Value");
            return PartialView(model);
        }
        #endregion
        #region ADD SUPPORT
        // GET: ADD SUPPORT
        public IActionResult AddSupport()
        {
            ViewBag.Facilities = new SelectList(_context.Facility.Where(x => x.Name.Contains("")), "Id", "Name");
            return PartialView();
        }
        // POST: ADD SUPPORT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSupport([Bind] AddSupportViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.RegisterSupportAsync(model))
                {
                    return PartialView();
                }

            }
            ViewBag.Facilities = new SelectList(_context.Facility, "Id", "Name");
            return PartialView(model);
        }
        #endregion
        #region DAILY REFERRAL
        // DAILY REFERRAL
        public async Task<IActionResult> DailyReferral(int? page, string dateRange, bool export)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.Parse(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim());
            }
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;


            var tracking = _context.Tracking.Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);
            var activity = _context.Activity.Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);
            var rejected = tracking
               .Join(
                  activity,
                  t => t.Code,
                  a => a.Code,
                  (t, a) =>
                     new
                     {
                         Code = t.Code,
                         ReferredTo = t.ReferredTo,
                         Status = a.Status,
                         DateReferred = a.DateReferred
                     });

            var seen = _context.Seen
                .Join(
                    _context.Tracking,
                    seen => seen.TrackingId,
                    track => track.Id,
                    (seen, track) =>
                        new
                        {
                            track.DateReferred,
                            track.ReferredTo,
                            track.ReferredFrom,
                            seen.TrackingId
                        }
                )
                .Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);


            var facilities = _context.Facility
                .Select(i => new DailyReferralViewModel
                {
                    Facility = i.Name,
                    AcceptedTo = activity.Where(x => x.ReferredTo.Equals(i.Id) && x.DateReferred >= StartDate && x.DateReferred <= EndDate && x.Status.Equals(_status.Value.ACCEPTED)).Count(),
                    RedirectedTo = rejected.Where(x => x.ReferredTo.Equals(i.Id) && x.Status.Equals(_status.Value.REJECTED) && x.DateReferred >= StartDate && x.DateReferred <= EndDate).Select(x=>x.Code).Distinct().Count(),
                    SeenTo = seen.Where(x => x.ReferredTo.Equals(i.Id)).Select(x=>x.TrackingId).Distinct().Count(),
                    IncomingTotal = tracking.Where(x=>x.ReferredTo.Equals(i.Id)).Count(),
                    AcceptedFrom = activity.Where(x => x.ReferredFrom.Equals(i.Id) && x.Status.Equals(_status.Value.ACCEPTED) && x.DateReferred >= StartDate && x.DateReferred <= EndDate).Count(),
                    RedirectedFrom = activity.Where(x => x.ReferredFrom.Equals(i.Id) && x.Status.Equals(_status.Value.REJECTED) && x.DateReferred >= StartDate && x.DateReferred <= EndDate).Select(x=>x.Code).Distinct().Count(),
                    SeenFrom = seen.Where(x => x.ReferredFrom.Equals(i.Id)).Select(x=>x.TrackingId).Distinct().Count()
                })
                .OrderBy(x => x.Facility);

            if(export)
            {
                string name = $"Daily_Referral-{StartDate.ToString("yyyy-MM-dd")}.xlsx";
                return File(ExportDailyReferral(facilities), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
            }

            int size = 20;

            return View(await PaginatedList<DailyReferralViewModel>.CreateAsync(facilities, page ?? 1, size));
        }

        public MemoryStream ExportDailyReferral(IEnumerable<DailyReferralViewModel> model)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int x = 1; x <= 9; x++)
                {
                    if (x <= 7)
                    {
                        worksheet.Cells["A" + x + ":J" + x].Merge = true;
                        worksheet.Cells["A" + x + ":J" + x].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
                    worksheet.Cells["A" + x + ":J" + x].Style.Font.Bold = true;
                }
                worksheet.Cells["A8:A9"].Merge = true;
                worksheet.Cells["A8:A9"].Value = "Name of Hospital";
                worksheet.Cells["B8:E8"].Merge = true;
                worksheet.Cells["B8:E8"].Value = "Number of Referrals To";
                worksheet.Cells["F8:F9"].Merge = true;
                worksheet.Cells["F8"].Value = "TOTAL";
                worksheet.Cells["F8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["F8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["G8:I8"].Merge = true;
                worksheet.Cells["G8"].Value = "Number of Referrals From";
                worksheet.Cells["A2"].Value = "Monitoring Tool for Central Visayas Electronic Health Referral System";
                worksheet.Cells["A3"].Value = "Form 2";
                worksheet.Cells["A4"].Value = "DAILY REPORT FOR REFERRALS";
                worksheet.Cells["A6"].Value = "Date: " + StartDate.ToString("MMMM d, yyyy");
                worksheet.Cells["A6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["F8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["B8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["I8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["I8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["B9"].Value = "Accepted";
                worksheet.Cells["C9"].Value = "Redirected";
                worksheet.Cells["D9"].Value = "Seen";
                worksheet.Cells["E9"].Value = "Unseen";
                worksheet.Cells["G9"].Value = "Accepted";
                worksheet.Cells["H9"].Value = "Redirected";
                worksheet.Cells["I9"].Value = "Seen";
                worksheet.Cells["J8:J9"].Merge = true;
                worksheet.Cells["J8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["J8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["J8"].Value = "TOTAL";

                worksheet.Cells["A10"].LoadFromCollection(model.ToList(), false).AutoFitColumns();
                package.Save();
            }

            stream.Position = 0;

            return stream;
        }
        #endregion
        #region DAILY USERS
        // DAILY USERS
        public async Task<IActionResult> DailyUsers(int? page, string date)
        {
            Date = DateTime.Now.Date;

            if (!string.IsNullOrEmpty(date))
            {
                Date = DateTime.Parse(date).Date;
            }

            ViewBag.Date = Date;

            var logins = from user in _context.Users
                         join log in _context.Login on user.Id equals log.Id into loginss
                         from login in loginss.DefaultIfEmpty()
                         select new
                         {
                             UserId = user.Id,
                             user.FacilityId,
                             user.Level,
                             login.Status,
                             Login = login.Login1
                         };

            var users = _context.Users;

             var dailyUsers = _context.Facility
                .Select(i => new DailyUsersAdminModel
                {
                    Facility = i.Name,
                    OnDutyHP = logins.Where(x=>x.FacilityId == i.Id && x.Login.Date == Date && x.Level == _roles.Value.DOCTOR && x.Status == "login").Select(x=>x.UserId).Distinct().Count(),
                    OffDutyHP = logins.Where(x => x.FacilityId == i.Id && x.Login.Date == Date && x.Level == _roles.Value.DOCTOR && x.Status == "login_off").Select(x => x.UserId).Distinct().Count(),
                    OfflineHP = users.Where(x=>x.FacilityId == i.Id && x.Level == _roles.Value.DOCTOR).Count(),
                    OnlineIT = logins.Where(x => x.FacilityId == i.Id && x.Login.Date == Date && x.Level == _roles.Value.SUPPORT).Select(x => x.UserId).Distinct().Count(),
                    OfflineIT = users.Where(x => x.FacilityId == i.Id && x.Level == _roles.Value.SUPPORT).Count(),
                })
                .OrderBy(x => x.Facility);

            int size = 20;
            return View(await PaginatedList<DailyUsersAdminModel>.CreateAsync(dailyUsers, page ?? 1, size));
        }

        // EXPORT DAILY USERS
        public async Task<IActionResult> ExportDailyUsers(string date)
        {
            Date = DateTime.Parse(date).Date;
            var logins = _context.Login
                .Where(x => x.CreatedAt.Value.Date == Date)
                .Join(
                    _context.Users,
                    login => login.UserId,
                    user => user.Id,
                    (login, user) =>
                        new
                        {
                            UserId = user.Id,
                            UserFacility = user.FacilityId,
                            Level = user.Level,
                            Status = login.Status,
                            Login = login.Login1
                        }
                );

            var users = _context.Users;

            var facilities = await _context.Facility
                .Select(i => new DailyUsersAdminModel
                {
                    Facility = i.Name,
                    OnDutyHP = logins.Where(x => x.UserFacility == i.Id && x.Login.Date == Date && x.Level == _roles.Value.DOCTOR && x.Status == "login").Select(x => x.UserId).Distinct().Count(),
                    OffDutyHP = logins.Where(x => x.UserFacility == i.Id && x.Login.Date == Date && x.Level == _roles.Value.DOCTOR && x.Status == "login_off").Select(x => x.UserId).Distinct().Count(),
                    OfflineHP = users.Where(x => x.FacilityId == i.Id && x.Level == _roles.Value.DOCTOR).Count(),
                    OnlineIT = logins.Where(x => x.UserFacility == i.Id && x.Login.Date == Date && x.Level == _roles.Value.SUPPORT).Select(x => x.UserId).Distinct().Count(),
                    OfflineIT = users.Where(x => x.FacilityId == i.Id && x.Level == _roles.Value.SUPPORT).Count(),
                })
                .OrderBy(x => x.Facility)
                .ToListAsync();

            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for(int x = 1; x <= 9; x++)
                {
                    if(x<=7)
                    {
                        worksheet.Cells["A" + x + ":i" + x].Merge = true;
                        worksheet.Cells["A" + x + ":i" + x].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
                    worksheet.Cells["A" + x + ":I" + x].Style.Font.Bold = true;
                }
                worksheet.Cells["A8:A9"].Merge = true;
                worksheet.Cells["A8:A9"].Value = "Name of Hospital";
                worksheet.Cells["B8:E8"].Merge = true;
                worksheet.Cells["B8:E8"].Value = "Health Professional";
                worksheet.Cells["F8:H8"].Merge = true;
                worksheet.Cells["F8:H8"].Value = "IT";
                worksheet.Cells["I8:I9"].Merge = true;
                worksheet.Cells["I8:I9"].Value = "TOTAL";
                worksheet.Cells["A8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A2"].Value = "Monitoring Tool for Central Visayas Electronic Health Referral System";
                worksheet.Cells["A3"].Value = "Form 1";
                worksheet.Cells["A4"].Value = "DAILY REPORT FOR AVAILABLE USERS";
                worksheet.Cells["A6"].Value = "Date: " + Date.ToString("MMMM d, yyyy");
                worksheet.Cells["A6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["F8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["B8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["I8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["I8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["B9"].Value = "On Duty";
                worksheet.Cells["C9"].Value = "Off Duty";
                worksheet.Cells["D9"].Value = "Offline";
                worksheet.Cells["E9"].Value = "Subtotal";
                worksheet.Cells["F9"].Value = "Online";
                worksheet.Cells["G9"].Value = "Offline";
                worksheet.Cells["H9"].Value = "Subtotal";

                worksheet.Cells["A10"].LoadFromCollection(facilities, false).AutoFitColumns();
                package.Save();
            }

            stream.Position = 0;
            string name = $"Daily_Users-{Date.ToString("yyyy-MM-dd")}.xlsx";

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
        }
        #endregion
        #region FACILITIES
        // FACILITIES
        public async Task<IActionResult> Facilities(int? page, string search)
        {
            ViewBag.Filter = search;
            int size = 10;

            var facilities = _context.Facility
                .Join(
                    _context.Province,
                    facility => facility.Province,
                    province => province.Id,
                    (facility, province) =>
                        new
                        {
                            facility = facility,
                            province = province
                        }
                )
                .GroupJoin(
                    _context.Muncity,
                    temp0 => temp0.facility.Muncity,
                    munct => munct.Id,
                    (temp0, MUNCT) =>
                        new
                        {
                            temp0 = temp0,
                            MUNCT = MUNCT
                        }
                )
                .SelectMany(
                    temp1 => temp1.MUNCT.DefaultIfEmpty(),
                    (temp1, muncity) =>
                        new
                        {
                            temp1 = temp1,
                            muncity = muncity
                        }
                )
                .GroupJoin(
                    _context.Barangay,
                    temp2 => temp2.temp1.temp0.facility.Brgy,
                    brgy => brgy.Id,
                    (temp2, BRGY) =>
                        new
                        {
                            temp2 = temp2,
                            BRGY = BRGY
                        }
                )
                .SelectMany(
                    temp3 => temp3.BRGY.DefaultIfEmpty(),
                    (temp3, barangay) =>
                        new FacilitiesViewModel
                        {
                            Id = temp3.temp2.temp1.temp0.facility.Id,
                            Facility = temp3.temp2.temp1.temp0.facility.Name,
                            Barangay = temp3.temp2.temp1.temp0.facility.Brgy == 0 ? "" : barangay.Description + ", ",
                            Muncity = temp3.temp2.temp1.temp0.facility.Muncity == 0 ? "" : temp3.temp2.muncity.Description + ", ",
                            Province = temp3.temp2.temp1.temp0.province.Description,
                            Contact = temp3.temp2.temp1.temp0.facility.Contact,
                            Email = temp3.temp2.temp1.temp0.facility.Email,
                            Chief = temp3.temp2.temp1.temp0.facility.ChiefHospital,
                            Level = temp3.temp2.temp1.temp0.facility.Level,
                            Type = temp3.temp2.temp1.temp0.facility.HospitalType,
                            Status = temp3.temp2.temp1.temp0.facility.Status == 1
                        }
                );


            if(!string.IsNullOrEmpty(search))
            {
                facilities = facilities.Where(x => x.Facility.Contains(search));
            }

            return View(await PaginatedList<FacilitiesViewModel>.CreateAsync(facilities.OrderBy(x=>x.Facility), page ?? 1, size));
        }
        #endregion
        #region GRAPH
        // GRAPH
        public async Task<IActionResult> Graph(string year, string daterange)
        {
            if (!string.IsNullOrEmpty(daterange))
            {
                StartDate = DateTime.Parse(daterange.Substring(0, daterange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(daterange.Substring(daterange.LastIndexOf(" ")).Trim());
            }
            else
            {
                var dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                StartDate = new DateTime(dateNow.Year, 1, 1);
                EndDate = new DateTime(dateNow.Year, 12, 31);
            }
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;
            var trackings = _context.Tracking
                .Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var activities = _context.Activity
                .Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var facilities = await trackings
               .Select(t => t.ReferredTo)
               .Union(
                  trackings
                     .Select(t => t.ReferredFrom)
               )
               .Select(i => new GraphValuesModel
               {
                   Facility = _context.Facility.SingleOrDefault(x=>x.Id == i).Name,
                   Incoming = trackings.Where(x => x.ReferredTo == i).Count(),
                   Accepted = trackings.Where(x => x.ReferredTo == i && x.DateAccepted != default).Count(),
                   Outgoing = trackings.Where(x => x.ReferredFrom == i).Count()
               })
                .AsNoTracking()
                .ToListAsync();
                

            return View(facilities.OrderByDescending(x=>x.Incoming).ToList());
        }
        #endregion
        #region LOGIN AS
        // GET: LOGIN AS
        public ActionResult Login()
        {
            var facilities = _context.Facility.Where(x => x.Status.Equals(1));
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            return View();
        }

        // POST: LOGIN AS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(int facility, string level)
        {
            await LoginAsAsync(facility, level);
            if (level.Equals(_roles.Value.ADMIN))
                return RedirectToAction("AdminDashboard", "Admin");
            else if (level.Equals(_roles.Value.DOCTOR))
            {
                return RedirectToAction("Index", "Home");
            }
            else if (level.Equals(_roles.Value.SUPPORT))
            {
                return RedirectToAction("SupportDashboard", "Support");
            }
            else //if (level.Equals(_roles.Value.MCC))
            {
                return RedirectToAction("MccDashboard", "MedicalCenterChief");
            }
        }
        #endregion
        #region REFERRAL STATUS
        // REFERRAL STATUS
        public async Task<IActionResult> ReferralStatus(int? page, string dateRange)
        {
            var culture = CultureInfo.InvariantCulture;
            int size = 20;
            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.Parse(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim());
            }
            else
            {
                StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                EndDate = StartDate.AddMonths(1).AddDays(-1);
            }
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;

            var referrals = _context.Tracking
                .Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Join(
                    _context.Facility,
                    track => track.ReferredFrom,
                    refFrom => refFrom.Id,
                    (track, refFrom) =>
                        new
                        {
                            track = track,
                            refFrom = refFrom
                        }
                )
                .Join(
                    _context.Facility,
                    temp0 => temp0.track.ReferredTo,
                    refTo => refTo.Id,
                    (temp0, refTo) =>
                        new
                        {
                            temp0 = temp0,
                            refTo = refTo
                        }
                )
                .Join(
                    _context.Patients,
                    temp1 => temp1.temp0.track.PatientId,
                    patient => patient.Id,
                    (temp1, patient) =>
                        new
                        {
                            temp1 = temp1,
                            patient = patient
                        }
                )
                .GroupJoin(
                    _context.Department,
                    temp2 => temp2.temp1.temp0.track.DepartmentId,
                    dep => dep.Id,
                    (temp2, DEP) =>
                        new
                        {
                            temp2 = temp2,
                            DEP = DEP
                        }
                )
                .SelectMany(
                    temp3 => temp3.DEP.DefaultIfEmpty(),
                    (temp3, department) =>
                        new ReferralStatusViewModel
                        {
                            DateReferred = temp3.temp2.temp1.temp0.track.DateReferred,
                            FacilityFrom = temp3.temp2.temp1.temp0.refFrom.Name,
                            FacilityTo = temp3.temp2.temp1.refTo.Name,
                            Department = department.Description,
                            Fname = temp3.temp2.patient.Fname,
                            Lname = temp3.temp2.patient.Lname,
                            Status = temp3.temp2.temp1.temp0.track.Status
                        }
                )
                .OrderByDescending(x => x.DateReferred);

            return View(await PaginatedList<ReferralStatusViewModel>.CreateAsync(referrals, page ?? 1, size));
        }
        #endregion
        #region REMOVE FACILITY
        // REMOVE FACILITY
        [HttpPost]
        [Route("{controller}/{action}/{id}")]
        public void RemoveFacility(int? id)
        {
            var facility = _context.Facility.Find(id);
            _context.Facility.Remove(facility);
            _context.SaveChanges();
        }
        #endregion
        #region SUPPORT USERS
        // SUPPORT USERS
        public async Task<IActionResult> SupportUsers(int? page, string search)
        {
            ViewBag.Filter = search;
            int size = 10;

            var support = _context.Users.Where(x => x.Level.Equals(_roles.Value.SUPPORT))
                .Join(
                    _context.Facility,
                    user => user.FacilityId,
                    facility => facility.Id,
                    (user, facility) =>
                        new SupportUsersViewModel
                        {
                            Id = user.Id,
                            Fname = user.Fname,
                            Mname = user.Mname,
                            Lname = user.Mname,
                            Facility = facility.Name,
                            Contact = user.Contact ?? "N/A",
                            Email = user.Email ?? "N/A",
                            Username = user.Username,
                            Status = user.LoginStatus,
                            LastLogin = user.LastLogin == null ? default : user.LastLogin
                        }
                );
            if (!string.IsNullOrEmpty(search))
                support = support.Where(x => x.Fname.ToUpper().Contains(search) || x.Mname.ToUpper().Contains(search) || x.Lname.ToUpper().Contains(search));

            return View(await PaginatedList<SupportUsersViewModel>.CreateAsync(support.OrderBy(x=>x.Fname), page ?? 1, size));
        }
        #endregion
        #region UPDATE FACILITY
        // GET: UPDATE FACILITY
        [HttpGet]
        public async Task<IActionResult> UpdateFacility(int? id)
        {
            var facilityModel = await _context.Facility.FindAsync(id);

            var facility = await SetFacilityModel(facilityModel);

            var province = _context.Province;
            var muncity = _context.Muncity.Where(x => x.ProvinceId.Equals(facility.Province));
            var barangay = _context.Barangay.Where(x => x.MuncityId.Equals(facility.Muncity));

            ViewBag.Provinces = new SelectList(province, "Id", "Description", facility.Province);
            ViewBag.Muncities = new SelectList(muncity, "Id", "Description", facility.Muncity);
            ViewBag.Barangays = new SelectList(barangay, "Id", "Description", facility.Barangay);
            ViewBag.Levels = new SelectList(ListContainer.HospitalLevel, "Key", "Value", facility.Level);
            ViewBag.Types = new SelectList(ListContainer.HospitalType, "Key", "Value", facility.Type);
            ViewBag.Status = new SelectList(ListContainer.HospitalStatus, "Key", "Value", facility.Status);

            return PartialView("~/Views/Admin/UpdateFacility.cshtml", facility);
        }

        // POST: UPDATE FACILITY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFacility([Bind] FacilityViewModel model)
        {
            if (string.IsNullOrEmpty(model.Chief))
                model.Chief = "";
            if (ModelState.IsValid)
            {
                var facilities = _context.Facility.Where(x => x.Id != model.Id);
                if (!facilities.Any(x => x.Name.Equals(model.Name)))
                {
                    var saveFacility = await SaveFacilityAsync(model);
                    _context.Update(saveFacility);
                    await _context.SaveChangesAsync();
                    return PartialView("~/Views/Admin/UpdateFacility.cshtml", model);
                }
                else
                {
                    ModelState.AddModelError("Name", "Facility name already exists!");
                }
            }

            var province = _context.Province;
            var muncity = _context.Muncity.Where(x => x.ProvinceId.Equals(model.Province));
            var barangay = _context.Barangay.Where(x => x.MuncityId.Equals(model.Barangay));

            ViewBag.Provinces = new SelectList(province, "Id", "Description", model.Province);
            ViewBag.Muncities = new SelectList(muncity, "Id", "Description", model.Muncity);
            ViewBag.Barangays = new SelectList(barangay, "Id", "Description", model.Barangay);
            ViewBag.Levels = new SelectList(ListContainer.HospitalLevel, "Key", "Value", model.Level);
            ViewBag.Types = new SelectList(ListContainer.HospitalType, "Key", "Value", model.Type);
            ViewBag.Status = new SelectList(ListContainer.HospitalStatus, "Key", "Value", model.Status);

            return PartialView("~/Views/Admin/UpdateFacility.cshtml", model);
        }
        #endregion
        #region UPDATE SUPPORT
        // GET: UPDATE SUPPORT
        [HttpGet]
        public async Task<IActionResult> UpdateSupport(int? id)
        {
            var facility = _context.Facility;
            var currentSupport = await _context.Users.FindAsync(id);
            if (currentSupport != null)
            {
                ViewBag.Status = new SelectList(ListContainer.UserStatus, "Key", "Value", currentSupport.Status);
                ViewBag.Facility = new SelectList(facility, "Id", "Name", currentSupport.FacilityId);
                currentSupport.Password = "";
            }

            var support = ReturnSupportInfo(currentSupport);
            return PartialView(support);
        }

        // POST: UPDATE SUPPORT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSupport([Bind] UpdateSupportViewModel model)
        {
            var facilities = _context.Facility;
            var support = await SetSupportViewModel(model);
            if (ModelState.IsValid)
            {
                var supports = _context.Users.Where(x => x.Id != support.Id);
                if (!supports.Any(x => x.Username.Equals(model.Username)))
                {
                    if (!string.IsNullOrEmpty(model.Password))
                        //_userService.ChangePasswordAsync(support, model.Password);
                    _context.Update(support);
                    await _context.SaveChangesAsync();
                    return PartialView();
                }
                else
                {
                    ModelState.AddModelError("Username", "Username already exist");
                }
            }
            ViewBag.Status = new SelectList(ListContainer.UserStatus, "Key", "Value", support.Status);
            ViewBag.Facility = new SelectList(facilities, "Id", "Name", support.FacilityId);
            return PartialView(model);
        }
        #endregion
        #region VIEWED ONLY
        public async Task<IActionResult> ViewedOnly(int? page, int? facility, string startDate, string endDate, string type)
        {
            StartDate = DateTime.Parse(startDate);
            EndDate = DateTime.Parse(endDate);
            #region Query
            var seens = _context.Seen;
            var issues = _context.Issue;
            var activities = _context.Activity.Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var feedbacks = _context.Feedback.Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var facilities = _context.Facility.Where(x => x.Id != UserFacility);
            var referred = _context.Tracking
                .Where(x => x.ReferredFrom == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Join(
                    _context.Users,
                    track => track.ReferringMd,
                    refMd => refMd.Id,
                    (track, refMd) =>
                        new
                        {
                            track = track,
                            refMd = refMd
                        }
                )
                .Join(
                    _context.Users,
                    temp0 => temp0.track.ActionMd,
                    actMd => actMd.Id,
                    (temp0, actMd) =>
                        new
                        {
                            temp0 = temp0,
                            actMd = actMd
                        }
                )
                .Join(
                    _context.Facility,
                    temp1 => temp1.temp0.track.ReferredFrom,
                    refFrom => refFrom.Id,
                    (temp1, refFrom) =>
                        new
                        {
                            temp1 = temp1,
                            refFrom = refFrom
                        }
                )
                .Join(
                    _context.Facility,
                    temp2 => temp2.temp1.temp0.track.ReferredTo,
                    refTo => refTo.Id,
                    (temp2, refTo) =>
                        new
                        {
                            temp2 = temp2,
                            refTo = refTo
                        }
                )
                .Join(
                    _context.Patients,
                    temp3 => temp3.temp2.temp1.temp0.track.PatientId,
                    patient => patient.Id,
                    (temp3, patient) =>
                        new
                        {
                            temp3 = temp3,
                            patient = patient
                        }
                )
                .Join(
                    _context.Province,
                    temp4 => temp4.patient.Province,
                    province => province.Id,
                    (temp4, province) =>
                        new
                        {
                            temp4 = temp4,
                            province = province
                        }
                )
                .Join(
                    _context.Muncity,
                    temp5 => temp5.temp4.patient.Muncity,
                    muncity => muncity.Id,
                    (temp5, muncity) =>
                        new
                        {
                            temp5 = temp5,
                            muncity = muncity
                        }
                )
                .Join(
                    _context.Barangay,
                    temp6 => temp6.temp5.temp4.patient.Brgy,
                    barangay => barangay.Id,
                    (temp6, barangay) =>
                        new ReferredViewModel
                        {
                            PatientId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.PatientId,
                            Fname = temp6.temp5.temp4.patient.Fname,
                            Mname = temp6.temp5.temp4.patient.Mname ?? "",
                            Lname = temp6.temp5.temp4.patient.Lname,
                            PatientSex = temp6.temp5.temp4.patient.Sex,
                            PatientAge = temp6.temp5.temp4.patient.Dob.ComputeAge(),
                            Barangay = barangay.Description,
                            Muncity = temp6.muncity.Description,
                            Province = temp6.temp5.province.Description,
                            ReferredBy = temp6.temp5.temp4.temp3.temp2.temp1.temp0.refMd.GetMDFullName(),
                            ReferredTo = temp6.temp5.temp4.temp3.temp2.temp1.actMd.GetMDFullName(),
                            ReferredToId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.ReferredTo,
                            FacilityFrom = temp6.temp5.temp4.temp3.temp2.refFrom.Name,
                            FacilityTo = temp6.temp5.temp4.temp3.refTo.Name,
                            TrackingId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Id,
                            SeenCount = seens.Where(x => x.TrackingId == temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Id).Count(),
                            CallerCount = activities.Where(x => x.Code.Equals(temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Code) && x.Status.Equals(_status.Value.CALLING)).Count(),
                            IssueCount = issues.Where(x => x.TrackingId.Equals(temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Id)).Count(),
                            ReCoCount = feedbacks.Where(x => x.Code.Equals(temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Code)).Count(),
                            Travel = string.IsNullOrEmpty(temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.ModeTransportation),
                            Code = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Code,
                            Status = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Status,
                            Pregnant = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Type.Equals("pregnant"),
                            Seen = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.DateSeen != default,
                            Walkin = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Walkin.Equals("yes"),
                            UpdatedAt = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.DateReferred,
                            Activities = activities.Where(x => x.Code == temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Code).OrderByDescending(x => x.CreatedAt)
                                .Join(
                                    _context.Facility,
                                    act => act.ReferredFrom,
                                    refFrom => refFrom.Id,
                                    (act, refFrom) =>
                                        new
                                        {
                                            act = act,
                                            refFrom = refFrom
                                        }
                                )
                                .GroupJoin(
                                    _context.Facility,
                                    temp0 => temp0.act.ReferredTo,
                                    rto => rto.Id,
                                    (temp0, RTO) =>
                                        new
                                        {
                                            temp0 = temp0,
                                            RTO = RTO
                                        }
                                )
                                .SelectMany(
                                    temp1 => temp1.RTO.DefaultIfEmpty(),
                                    (temp1, refTo) =>
                                        new
                                        {
                                            temp1 = temp1,
                                            refTo = refTo
                                        }
                                )
                                .GroupJoin(
                                    _context.Users,
                                    temp2 => temp2.temp1.temp0.act.ReferringMd,
                                    rmd => rmd.Id,
                                    (temp2, RMD) =>
                                        new
                                        {
                                            temp2 = temp2,
                                            RMD = RMD
                                        }
                                )
                                .SelectMany(
                                    temp3 => temp3.RMD.DefaultIfEmpty(),
                                    (temp3, refMd) =>
                                        new
                                        {
                                            temp3 = temp3,
                                            refMd = refMd
                                        }
                                )
                                .GroupJoin(
                                    _context.Users,
                                    temp4 => temp4.temp3.temp2.temp1.temp0.act.ActionMd,
                                    amd => amd.Id,
                                    (temp4, AMD) =>
                                        new
                                        {
                                            temp4 = temp4,
                                            AMD = AMD
                                        }
                                )
                                .SelectMany(
                                    temp5 => temp5.AMD.DefaultIfEmpty(),
                                    (temp5, actMd) =>
                                        new ActivityLess
                                        {
                                            Status = temp5.temp4.temp3.temp2.temp1.temp0.act.Status,
                                            DateAction = temp5.temp4.temp3.temp2.temp1.temp0.act.DateReferred.ToString("MMM dd, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                                            FacilityFrom = (temp5.temp4.temp3.temp2.temp1.temp0.act.ReferredFrom == 0) ? "" : temp5.temp4.temp3.temp2.temp1.temp0.refFrom.Name,
                                            FacilityFromContact = (temp5.temp4.temp3.temp2.temp1.temp0.act.ReferredFrom == 0) ? "" : temp5.temp4.temp3.temp2.temp1.temp0.refFrom.Contact,
                                            FacilityTo = temp5.temp4.temp3.temp2.refTo.Name,
                                            ActionMd = actMd.GetMDFullName(),
                                            ReferringMd = temp5.temp4.refMd.GetMDFullName(),
                                            Remarks = temp5.temp4.temp3.temp2.temp1.temp0.act.Remarks
                                        }
                                )
                            ,
                            ReferredFromId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.ReferredFrom
                        }
                );

            if (type.Equals("incoming"))
            {
                referred = referred.Where(x => x.ReferredToId == facility);
            }
            else if(type.Equals("outgoing"))
            {
                referred = referred.Where(x => x.ReferredFromId == facility);
            }
            #endregion

            int size = 10;
            return View(await PaginatedList<ReferredViewModel>.CreateAsync(referred.OrderByDescending(x=>x.UpdatedAt), page ?? 1, size));
        }
        #endregion
        #region WHOS ONLINE
        public async Task<IActionResult> WhosOnline()
        {
            var logins = _context.Login.Where(x => x.Login1.Date.Equals(DateTime.Now.Date));
            var onlineUsers = await _context.Users
                .Where(x => x.LoginStatus.Contains("login") && x.Level.Equals(_roles.Value.DOCTOR) && x.LastLogin.Date.Equals(DateTime.Now.Date))
                .Join(
                    _context.Facility,
                    user => user.FacilityId,
                    facility => facility.Id,
                    (user, facility) =>
                        new
                        {
                            user = user,
                            facility = facility
                        }
                )
                .Join(
                    _context.Department,
                    temp0 => temp0.user.DepartmentId,
                    department => (Int32?)(department.Id),
                    (temp0, department) =>
                        new
                        {
                            temp0 = temp0,
                            department = department
                        }
                )
                .GroupJoin(
                    _context.Login,
                    temp1 => temp1.temp0.user.Id,
                    login => login.UserId,
                    (temp1, logins) =>
                        new WhosOnlineModel
                        {
                            Fname = temp1.temp0.user.Fname,
                            Mname = temp1.temp0.user.Mname,
                            Lname = temp1.temp0.user.Lname,
                            FacilityAbrv = temp1.temp0.facility.Abbr,
                            Contact = temp1.temp0.user.Contact,
                            Department = temp1.department.Description,
                            LoginStatus = logins == null? false : logins
                                .OrderByDescending(i => i.Login1)
                                .First().Status
                                .Equals("login"),
                            LoginTime = logins == null? default : logins  
                                .OrderByDescending(i => i.Login1)
                                .First().Login1
                        }
                )
                .ToListAsync();

            var onlineFacilities = await _context.Facility
                .GroupJoin(
                    _context.Users,
                    facility => facility.Id,
                    user => user.FacilityId,
                    (facility, users) =>
                        new
                        {
                            facility = facility,
                            users = users
                        }
                )
                .Join(
                    _context.Province,
                    temp0 => temp0.facility.Province,
                    province => province.Id,
                    (temp0, province) =>
                        new FacilitiesOnline
                        {
                            Name = temp0.facility.Name,
                            Province = province.Description,
                            Status = temp0.users
                            .Any(x => ((x.LastLogin >= DateTime.Now.Date) && (x.LoginStatus == "login")))
                        }
                )
                .ToListAsync();


            var model = new UserFacilityOnline
            {
                Facilities = onlineFacilities,
                Users = onlineUsers
            };

            return View(model);
        }
        #endregion
        #region HELPERS
        private async Task<Facility> SaveFacilityAsync(FacilityViewModel model)
        {
            var facility = await _context.Facility.FindAsync(model.Id);
            facility.Name = model.Name;
            facility.Abbr = model.Abbrevation;
            facility.Province = model.Province;
            facility.Muncity = model.Muncity ?? 0;
            facility.Brgy = model.Barangay ?? 0;
            facility.Address = model.Address;
            facility.Contact = model.Contact;
            facility.Email = model.Email;
            facility.ChiefHospital = model.Chief;
            facility.Level = model.Level;
            facility.HospitalType = model.Type;

            return facility;
        }

        private async Task LoginAsAsync(int facilityId, string level)
        {
            var user = await _context.Users
                .GroupJoin(
                    _context.Department,
                    user => user.DepartmentId,
                    dep => dep.Id,
                    (user, DEPARTMENT) =>
                        new
                        {
                            user = user,
                            DEPARTMENT = DEPARTMENT
                        }
                )
                .SelectMany(
                    temp0 => temp0.DEPARTMENT.DefaultIfEmpty(),
                    (temp0, department) =>
                        new
                        {
                            temp0 = temp0,
                            department = department
                        }
                )
                .Join(
                    _context.Facility,
                    temp1 => temp1.temp0.user.FacilityId,
                    facility => facility.Id,
                    (temp1, facility) =>
                        new
                        {
                            temp1 = temp1,
                            facility = facility
                        }
                )
                .GroupJoin(
                    _context.Muncity,
                    temp2 => temp2.temp1.temp0.user.Muncity,
                    mnct => mnct.Id,
                    (temp2, MUNCITY) =>
                        new
                        {
                            temp2 = temp2,
                            MUNCITY = MUNCITY
                        }
                )
                .SelectMany(
                    temp3 => temp3.MUNCITY.DefaultIfEmpty(),
                    (temp3, muncity) =>
                        new
                        {
                            temp3 = temp3,
                            muncity = muncity
                        }
                )
                .Join(
                    _context.Province,
                    temp4 => temp4.temp3.temp2.temp1.temp0.user.Province,
                    province => province.Id,
                    (temp4, province) =>
                        new CookiesModel
                        {
                            Id = temp4.temp3.temp2.temp1.temp0.user.Id,
                            Username = temp4.temp3.temp2.temp1.temp0.user.Username,
                            Fname = temp4.temp3.temp2.temp1.temp0.user.Fname,
                            Mname = temp4.temp3.temp2.temp1.temp0.user.Mname,
                            Lname = temp4.temp3.temp2.temp1.temp0.user.Lname,
                            Email = temp4.temp3.temp2.temp1.temp0.user.Email,
                            Province = temp4.temp3.temp2.temp1.temp0.user.Province,
                            Muncity = temp4.temp3.temp2.temp1.temp0.user.Muncity,
                            Contact = temp4.temp3.temp2.temp1.temp0.user.Contact,
                            Level = temp4.temp3.temp2.temp1.temp0.user.Level,
                            FacilityId = temp4.temp3.temp2.temp1.temp0.user.FacilityId,
                            DepartmentId = temp4.temp3.temp2.temp1.temp0.user.DepartmentId,
                            FacilityName = temp4.temp3.temp2.facility.Name,
                            DepartmentName = temp4.temp3.temp2.temp1.department.Description
                        }
                )
                .FirstOrDefaultAsync(x => x.Id == UserId);
            var properties = new AuthenticationProperties
            {
                AllowRefresh = false,
                IsPersistent = false
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.Fname),
                new Claim(ClaimTypes.Surname, user.Lname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Contact),
                new Claim(ClaimTypes.Role, level),
                new Claim("Facility", facilityId.ToString()),
                new Claim("FacilityName", _context.Facility.Find(facilityId).Name),
                new Claim("Department", user.DepartmentId.ToString()),
                new Claim("DepartmentName", user.DepartmentId != 0? user.DepartmentName : ""),
                new Claim("Province", user.Province.ToString()),
                new Claim("Muncity", user.Muncity.ToString()),
                new Claim("RealRole", user.Level),
                new Claim("RealFacility", user.FacilityId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }


        private Task<FacilityViewModel> SetFacilityModel(Facility facility)
        {
            var facilityModel = new FacilityViewModel
            {
                Id = facility.Id,
                Name = facility.Name,
                Abbrevation = facility.Abbr,
                Province = facility.Province,
                Muncity = facility.Muncity,
                Barangay = facility.Brgy,
                Address = facility.Address,
                Contact = facility.Contact,
                Email = facility.Email,
                Chief = facility.ChiefHospital,
                Level = facility.Level,
                Type = facility.HospitalType,
                Status = facility.Status
            };

            return Task.FromResult(facilityModel);
        }
        private Task<Facility> SetFacilityViewModelAsync(FacilityViewModel model)
        {
            var facility = new Facility
            {
                Name = model.Name,
                Abbr = model.Abbrevation,
                Address = model.Address,
                Brgy = model.Barangay ?? 0,
                Muncity = model.Muncity ?? 0,
                Province = model.Province,
                Contact = model.Contact,
                Email = model.Email,
                Status = 1,
                Picture = "",
                ChiefHospital = model.Chief,
                Level = model.Level,
                HospitalType = model.Type
            };

            return Task.FromResult(facility);
        }
        private UpdateSupportViewModel ReturnSupportInfo(Users currentSupport)
        {
            var support = new UpdateSupportViewModel
            {
                Id = currentSupport.Id,
                Firstname = currentSupport.Fname,
                Middlename = currentSupport.Mname,
                Lastname = currentSupport.Lname,
                ContactNumber = currentSupport.Contact,
                Email = currentSupport.Email,
                Facility = currentSupport.FacilityId,
                Designation = currentSupport.Designation,
                Status = currentSupport.Status,
                Username = currentSupport.Username
            };
            return support;
        }
        private async Task<Users> SetSupportViewModel(UpdateSupportViewModel model)
        {
            var support = await _context.Users.FindAsync(model.Id);

            support.Fname = model.Firstname;
            support.Mname = model.Middlename;
            support.Lname = model.Lastname;
            support.Contact = model.ContactNumber;
            support.Email = model.Email;
            support.Designation = model.Designation;
            support.FacilityId = model.Facility;
            support.Status = model.Status;
            support.Username = model.Username;
            support.UpdatedAt = DateTime.Now;
            return support;
        }

        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));
        public int UserDepartment => int.Parse(User.FindFirstValue("Department"));
        public int UserProvince => int.Parse(User.FindFirstValue("Province"));
        public int UserMuncity => int.Parse(User.FindFirstValue("Muncity"));
        public int UserBarangay => int.Parse(User.FindFirstValue("Barangay"));
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        #endregion
    }
}