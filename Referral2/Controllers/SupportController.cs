﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.MyModels;
using Referral2.Models.ViewModels.Support;
using Referral2.Services;
using Microsoft.Extensions.Options;
using Referral2.Models.ViewModels;
using System.Diagnostics;
using System.IO;
using OfficeOpenXml;
using System.Globalization;
using Referral2.Models.MobileModels;
using Newtonsoft.Json;
using Referral2.MyData;

namespace Referral2.Controllers
{
    [Authorize(Policy = "support")]
    public class SupportController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IUserService _userService;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;


        public SupportController(MySqlReferralContext context, IUserService userService, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _userService = userService;
            _roles = roles;
            _status = status;
        }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        #region ADD USER
        // GET: ADD USER
        [HttpGet]
        public IActionResult AddUser()
        {
            var departments = _context.Department;
            ViewBag.Departments = new SelectList(departments, "Id", "Description");

            return PartialView();
        }
        // POST: ADD USER
        [HttpPost]
        public async Task<IActionResult> AddUser([Bind] AddDoctorViewModel model)
        {
            var departments = _context.Department;
            if (ModelState.IsValid)
            {
                if (await _userService.RegisterDoctorAsync(model, UserFacility))
                {
                    return PartialView(model);
                }
                else
                {
                    ModelState.AddModelError("Username", "Username already exists!");
                }
            }

            ViewBag.Departments = new SelectList(departments, "Id", "Description", model.Department);

            return PartialView(model);
        }
        #endregion
        #region CHAT
        // GET: CHAT
        public async Task<IActionResult> Chat()
        {
            var chats = from feedback in _context.Feedback where feedback.Code == "it-group-chat"
                        join user in
                        (
                            from u in _context.Users
                            join f in _context.Facility on u.FacilityId equals f.Id
                            select new
                            {
                                u.Level,
                                u.Id,
                                f.Name,
                                u.Fname,
                                u.Mname,
                                u.Lname
                            }
                        )
                        on feedback.Sender equals user.Id
                        select new SupportChatViewModel
                        {
                            SupportId = user.Id,
                            SupportFacilityName = user.Name,
                            SupportName = user.Level.GetFullName(user.Fname, user.Mname, user.Lname),
                            Message = feedback.Message,
                            MessageDate = feedback.CreatedAt.Value.DateTime
                        };

            return View(await chats.ToListAsync());
        }
        // POST: CHAT
        [HttpPost]
        public async Task<IActionResult> Chat(FeedbackViewModel model)
        {
            if(ModelState.IsValid)
            {
                var chat = new Feedback
                {
                    Code = model.Code,
                    Sender = model.MdId,
                    Receiver = 0,
                    Message = model.Message,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                };
                await _context.AddAsync(chat);
                await _context.SaveChangesAsync();
            };

            return RedirectToAction("Chat");
        }
        #endregion
        #region DAILY REFERRALS
        // GET: DAILY REFERRALS
        public async Task<IActionResult> DailyReferrals(string daterange, int? page, bool export)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            if(!string.IsNullOrEmpty(daterange))
            {
                StartDate = DateTime.Parse(daterange.Substring(0, daterange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(daterange.Substring(daterange.LastIndexOf(" ")).Trim());
            }
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;
            int size = 20;


            var tract = _context.Tracking
                .Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Join(
                    _context.Activity,
                    t => t.Code,
                    a => a.Code,
                    (t, a) =>
                    new
                    {
                        t.Code,
                        t.DateSeen,
                        t.ReferredTo,
                        t.ReferredFrom,
                        a.ActionMd,
                        a.Status,
                        a.ReferringMd,
                        a.DateReferred
                    }
                );
            var activities = _context.Activity.Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);
            var trackings = _context.Tracking.Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);
            var seens = from seen in _context.Seen
                        join track in _context.Tracking on seen.TrackingId equals track.Id
                        select new
                        {
                            seen.UserMd,
                            track.DateReferred,
                            seen.TrackingId
                        };
            seens = seens.Where(x => x.DateReferred >= StartDate && x.DateReferred < EndDate);

            var users = _context.Users
                .Where(x => x.FacilityId.Equals(UserFacility) && x.Level.Equals(_roles.Value.DOCTOR))
                .OrderBy(x => x.Lname)
                .Select(i => new DailyReferralSupport
                {
                    DoctorName = i.Fname +" "+ (i.Mname ?? "") + " " + i.Lname,
                    OutAccepted = activities.Where(x => x.ReferringMd.Equals(i.Id) && x.Status.Equals(_status.Value.ACCEPTED)).Count(),
                    OutRedirected = tract.Where(x => x.ReferringMd.Equals(i.Id) && x.Status.Equals(_status.Value.REJECTED)).Count(),
                    OutSeen = tract.Where(x => x.ReferringMd.Equals(i.Id) && x.DateSeen == default).Count(),
                    OutTotal = tract.Where(x => x.ReferringMd.Equals(i.Id)).Select(x => x.Code).Distinct().Count(),
                    InAccepted = tract.Where(x => x.ReferredTo.Equals(UserFacility) && x.ActionMd.Equals(i.Id) && x.Status.Equals(_status.Value.ACCEPTED)).Count(),
                    InRedirected = tract.Where(x => x.ReferredTo.Equals(UserFacility) && x.ActionMd.Equals(i.Id) && x.Status.Equals(_status.Value.REJECTED)).Count(),
                    InSeen = seens.Where(x => x.UserMd.Equals(i.Id)).GroupBy(x => x.TrackingId).Select(x => x.Key).Count(),
                });

            if(export)
            {
                string name = $"DailyReferral-{DateTime.Now.ToString("yyyy-MM-dd")}.xlsx";
                return File(ExportDailyReferrals(users), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
            }

            return View(await PaginatedList<DailyReferralSupport>.CreateAsync(users.OrderBy(x=>x.DoctorName), page ?? 1, size));
        }

        private MemoryStream ExportDailyReferrals(IEnumerable<DailyReferralSupport> model)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int x = 1; x <= 10; x++)
                {
                    if (x <= 8)
                    {
                        worksheet.Cells["A" + x + ":J" + x].Merge = true;
                        worksheet.Cells["A" + x + ":J" + x].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
                    worksheet.Cells["A" + x + ":J" + x].Style.Font.Bold = true;
                }
                worksheet.Cells["A9:A10"].Merge = true;
                worksheet.Cells["A9:A10"].Value = "Name of Hospital";
                worksheet.Cells["B9:E9"].Merge = true;
                worksheet.Cells["B9:E9"].Value = "Number of Outgoing Referrals";
                worksheet.Cells["F9:F10"].Merge = true;
                worksheet.Cells["F9"].Value = "TOTAL";
                worksheet.Cells["F9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["F9"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["G9:I9"].Merge = true;
                worksheet.Cells["G9"].Value = "Number of Incoming Referrals";
                worksheet.Cells["J9:J10"].Merge = true;
                worksheet.Cells["J9"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["J9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["J9"].Value = "TOTAL";
                worksheet.Cells["A2"].Value = "Monitoring Tool for Central Visayas Electronic Health Referral System";
                worksheet.Cells["A3"].Value = "Form 2";
                worksheet.Cells["A4"].Value = "DAILY REPORT FOR REFERRALS";
                worksheet.Cells["A6"].Value = "Name of Hospital: " + _context.Facility.Find(UserFacility).Name;
                worksheet.Cells["A6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A7"].Value = "Date: " + StartDate.ToString("MMMM d, yyyy")+" - "+EndDate.ToString("MMMM d, yyyy");
                worksheet.Cells["A7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["F8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["B8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["I8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["I8"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                worksheet.Cells["B10"].Value = "Accepted";
                worksheet.Cells["C10"].Value = "Redirected";
                worksheet.Cells["D10"].Value = "Seen";
                worksheet.Cells["E10"].Value = "Unseen";
                worksheet.Cells["G10"].Value = "Accepted";
                worksheet.Cells["H10"].Value = "Redirected";
                worksheet.Cells["I10"].Value = "Seen";

                worksheet.Cells["A11"].LoadFromCollection(model.ToList(), false).AutoFitColumns();
                package.Save();
            }

            stream.Position = 0;

            return stream;
        }
        #endregion
        #region DAILY USERS
        // GET: DAILY USERS
        public async Task<IActionResult> DailyUsers(string date, int? page, bool export)
        {
            StartDate = DateTime.Now.Date;
            EndDate = StartDate.AddDays(1).AddSeconds(-1);
            if (date != null)
            {
                StartDate = DateTime.Parse(date);
                EndDate = StartDate.AddDays(1).AddSeconds(-1);
            }
            ViewBag.Date = StartDate;

            var logins = _context.Login
                .Where(x => x.CreatedAt >= StartDate.Date && x.CreatedAt <= EndDate);

            var dailyUsers = _context.Users
                .Where(x => x.FacilityId.Equals(UserFacility) && x.Level.Equals(_roles.Value.DOCTOR))
                .OrderBy(x => x.Lname)
                .Select(i => new DailyUsersViewModel
                {
                    Fname = i.Fname,
                    Mname = i.Mname,
                    Lname = i.Lname,
                    OnDuty = i.LastLogin != default ? logins.Where(x => x.UserId == i.Id && x.Login1 >= StartDate && x.Login1 <= EndDate).First().Status : "",
                    LoggedIn = i.LastLogin != default ? logins.Where(x => x.UserId == i.Id && x.Login1 >= StartDate && x.Login1 <= EndDate).First().Login1 != default : false,
                    LoginTime = logins.Where(x => x.UserId == i.Id && x.Login1 >= StartDate && x.Login1 <= EndDate).First().Login1,
                    LogoutTime = logins.Where(x => x.UserId == i.Id && x.Logout != default).OrderByDescending(x => x.UpdatedAt).First().Logout
                });

            int size = 20;

            if(export)
            {
                string name = $"DailyUser-{DateTime.Now.ToString("yyyy-MM-dd")}.xlsx";
                return File(ExportDailyUsers(dailyUsers.ToList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
            }

            return View(await PaginatedList<DailyUsersViewModel>.CreateAsync(dailyUsers.OrderBy(x=>x.Fname), page ?? 1, size));
        }
        private MemoryStream ExportDailyUsers(List<DailyUsersViewModel> model)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int x = 1; x <= 9; x++)
                {
                    if (x <= 8)
                    {
                        worksheet.Cells["A" + x + ":F" + x].Merge = true;
                        worksheet.Cells["A" + x + ":F" + x].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }
                    worksheet.Cells["A" + x + ":F" + x].Style.Font.Bold = true;
                }
                worksheet.Cells["A2"].Value = "Monitoring Tool for Central Visayas Electronic Health Referral System";
                worksheet.Cells["A2"].AutoFitColumns();
                worksheet.Cells["A3"].Value = "Form 1";
                worksheet.Cells["A4"].Value = "DAILY REPORT FOR AVAILABLE USERS";
                worksheet.Cells["A6"].Value = "Name of Hospital: " + _context.Facility.Find(UserFacility).Name;
                worksheet.Cells["A6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A7"].Value = "Date: " + StartDate.ToString("MMMM d, yyyy");
                worksheet.Cells["A7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A8"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["B9:F9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A9"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Justify;
                worksheet.Cells["A9"].Value = "Name of User";
                worksheet.Cells["B9"].Value = "On Duty";
                worksheet.Cells["C9"].Value = "Off Duty";
                worksheet.Cells["D9"].Value = "Login";
                worksheet.Cells["E9"].Value = "Logout";
                worksheet.Cells["F9"].Value = "Remarks";

                for(int r = 0; r < model.Count(); r++)
                {
                    worksheet.Cells["A" + (r + 10)].AutoFitColumns();
                    worksheet.Cells["A" + (r + 10)].Value = model[r].Lname + ", " + model[r].Fname + " " + (model[r].Mname ?? "");
                    worksheet.Cells["B" + (r + 10)].Value = model[r].OnDuty == "login" ? "✓" : "";
                    worksheet.Cells["C" + (r + 10)].Value = model[r].OnDuty == "login off" ? "" : "✓";
                    worksheet.Cells["D" + (r + 10)].Value = model[r].LoginTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    worksheet.Cells["E" + (r + 10)].Value = model[r].LogoutTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    worksheet.Cells["F" + (r + 10)].Value = "";
                }
                package.Save();
            }

            stream.Position = 0;

            return stream;
        }

        public string LoginStatus(Login login)
        {
            if (login == null)
                return "";
            else
                return login.Status;
        }
        #endregion
        #region HOSPITAL INFO
        // GET: HOSPITAL INFO
        [HttpGet]
        public IActionResult HospitalInfo()
        {
            var facility = _context.Facility.Find(UserFacility);

            var currentFacility = new HospitalInfoViewModel
            {
                Id = facility.Id,
                FacilityName = facility.Name,
                Abbreviation = facility.Abbr,
                ProvinceId = facility.Province,
                MuncityId = facility.Muncity,
                BarangayId = facility.Brgy,
                Address = facility.Address,
                Contact = facility.Contact,
                Email = facility.Email,
                Status = (int)facility.Status
            };
            var muncities = _context.Muncity.Where(x => x.ProvinceId.Equals(facility.Province));
            var barangays = _context.Barangay.Where(x => x.ProvinceId.Equals(facility.Province) && x.MuncityId.Equals(facility.Muncity));

            ViewBag.Muncities = new SelectList(muncities, "Id", "Description", currentFacility.MuncityId);
            ViewBag.Barangays = new SelectList(barangays, "Id", "Description", currentFacility.BarangayId);
            ViewBag.Statuses = new SelectList(ListContainer.Status, "Key", "Value");

            return View(currentFacility);
        }
        // POST: HOSPITAL INFO
        [HttpPost]
        public async Task<IActionResult> HospitalInfo([Bind] HospitalInfoViewModel model)
        {
            var facilities = _context.Facility.Where(x => x.Id != UserFacility);
            if (ModelState.IsValid)
            {
                if (!facilities.Any(x => x.Name == model.FacilityName))
                {
                    var updateFacility = UpdateFacility(model);
                    _context.Update(updateFacility);
                    await _context.SaveChangesAsync();
                }
                else
                    ModelState.AddModelError("FacilityName", "Facility name already Exists!");
            }
            var muncities = _context.Muncity.Where(x => x.ProvinceId.Equals(model.ProvinceId));
            var barangays = _context.Barangay.Where(x => x.ProvinceId.Equals(model.ProvinceId) && x.MuncityId.Equals(model.MuncityId));

            ViewBag.Muncities = new SelectList(muncities, "Id", "Description", model.MuncityId);
            ViewBag.Barangays = new SelectList(barangays, "Id", "Description", model.BarangayId);
            ViewBag.Statuses = new SelectList(ListContainer.Status, "Key", "Value", model.Status);
            return View(model);
        }
        #endregion
        #region INCOMING REPORT
        // GET: INCOMING REPORT 
        public async Task<IActionResult> IncomingReport(int? page)
        {
            var incoming = from track in _context.Tracking.Where(x => x.ReferredTo.Equals(UserFacility)).Where(x => x.Status == _status.Value.SEEN || x.Status == _status.Value.REFERRED)
                           join patient in _context.Patients on track.PatientId equals patient.Id
                           join refFrom in _context.Facility on track.ReferredFrom equals refFrom.Id
                           join dep in _context.Department on track.DepartmentId equals dep.Id into DEP
                           from department in DEP.DefaultIfEmpty()
                           select new IncomingReferralViewModel
                           {
                               PatientName = "".GetFullName(patient.Fname, patient.Mname, patient.Lname),
                               ReferringFacility = refFrom.Name,
                               Department = department.Description,
                               DateReferred = track.DateReferred,
                               Status = track.Status
                           };

            int size = 20;

            return View(await PaginatedList<IncomingReferralViewModel>.CreateAsync(incoming.OrderByDescending(x=>x.DateReferred), page ?? 1, size));
        }
        #endregion
        #region MANAGE USERS
        // GET: MANANGE USERS
        public async Task<IActionResult> ManageUsers(int? page, string search)
        {
            ViewBag.SearchString = search;
            var doctors = from user in _context.Users where user.FacilityId == UserFacility && user.Level == _roles.Value.DOCTOR
                          join dep in _context.Department on user.DepartmentId equals dep.Id into DEP
                          from department in DEP.DefaultIfEmpty()
                          select new SupportManageViewModel
                          {
                              Id = user.Id,
                              Fname = user.Fname,
                              Mname = user.Mname,
                              Lname = user.Lname,
                              Contact = string.IsNullOrEmpty(user.Contact) ? "N/A" : user.Contact,
                              DepartmentName = department.Description,
                              Username = user.Username,
                              Status = user.Status,
                              LastLogin = user.LastLogin.Equals(default) ? "Never Login" : user.LastLogin.GetDate("MMM dd, yyyy hh:mm tt")
                          };

            if(!string.IsNullOrEmpty(search))
            {
                doctors = doctors.Where(x => x.Fname.ToUpper().Contains(search) || x.Lname.ToUpper().Contains(search));
            }
            int size = 15;

            return View(await PaginatedList<SupportManageViewModel>.CreateAsync(doctors.OrderByDescending(x=>x.Fname), page ?? 1, size));
        }
        #endregion
        #region DASHBOARD
        // GET: DASHBOARD
        public IActionResult SupportDashboard()
        {
            List<int> accepted = new List<int>();
            List<int> redirected = new List<int>();

            var activities = _context.Activity;
            var totalDoctors = _context.Users
                .Where(x => x.Level.Equals(_roles.Value.DOCTOR) && x.FacilityId.Equals(UserFacility)).Count();
            var onlineDoctors = _context.Users
                .Where(x => x.LoginStatus.Equals("login") && x.FacilityId.Equals(UserFacility) && x.Level == _roles.Value.DOCTOR && x.LastLogin.Date == DateTime.Now.Date).Count();
            var referredPatients = _context.Tracking
                .Where(x => x.ReferredTo.Equals(UserFacility)).Count();
            var dashboard = new SupportDashboadViewModel(
                totalDoctors,
                onlineDoctors,
                referredPatients);

            return View(dashboard);
        }
        #endregion
        #region UPDATE USER
        // GET: UPDATE USER
        [HttpGet]
        public async Task<IActionResult> UpdateUser(int? id)
        {
            var departments = _context.Department;
            var currentMd = await _context.Users.FindAsync(id);
            if(currentMd != null && currentMd.DepartmentId != 0)
            {
                ViewBag.Status = new SelectList(ListContainer.UserStatus, "Key", "Value", currentMd.Status);
                ViewBag.Departments = new SelectList(departments, "Id", "Description", currentMd.DepartmentId);
                currentMd.Password = "";
            }
            ViewBag.Departments = new SelectList(departments, "Id", "Description");

            var doctor = returnDoctorInfo(currentMd);

            return PartialView(doctor);
        }
        // POST: UPDATE USER
        [HttpPost]
        public async Task<IActionResult> UpdateUser([Bind] UpdateDoctorViewModel model)
        {
            var departments = _context.Department;
            var doctor = await SetDoctorViewModel(model);
            if (ModelState.IsValid)
            {
                var doctors = _context.Users.Where(x => x.Id != doctor.Id);
                if(!doctors.Any(x => x.Username.Equals(model.Username)))
                {
                    if (!string.IsNullOrEmpty(model.Password))
                        //_userService.ChangePasswordAsync(doctor, model.Password);
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                    return PartialView("~/Views/Support/UpdateUser.cshtml", model);
                }
                else
                {
                    ModelState.AddModelError("Username", "Username already exists!");
                }
            }
            ViewBag.Status = new SelectList(ListContainer.Status, "Key", "Value", doctor.Status);
            ViewBag.Departments = new SelectList(departments, "Id", "Description", doctor.DepartmentId);
            return PartialView("~/Views/Support/UpdateUser.cshtml",model);
        }
        #endregion

        #region Support Chat Components
        [HttpPost]
        public IActionResult GetList(string list)
        {
            return Json(JsonConvert.DeserializeObject<List<UserModel>>(list));
        }

        [HttpPost]
        public IActionResult GetMessage(string message, string name, string level, string group)
        {
            List<string> useraddress = new List<string>();
            var GetUsers = JsonConvert.DeserializeObject<List<UserModel>>(group);
            var Request = new RequestModel
            {
                InformationType = Constants.MESSAGE_TAG_GC_IT,
                ListUserInformation = GetUsers,
                ClientMessage = new MessageModel
                {
                    Sender = name,
                    Message = message,
                    Receivers = char.ToUpper(level[0]) + level.Substring(1),
                    Sender_Endpoint = "",
                },
            };
            foreach (var client in GetUsers)
            {
                useraddress.Add(client.IPAddress);
            }

            Request.ClientMessage.Receiver_Endpoints = useraddress;

            return Json(Request);
        }

        [HttpPost]
        public IActionResult GetUser(string user)
        {
            var DeserializeUserInformation = JsonConvert.DeserializeObject<UserModel>(user);

            var getfacility = _context.Facility
                .Where(facilityId => facilityId.Id == Convert.ToInt32(DeserializeUserInformation.Facility))
                .Select(facility => facility.Name)
                .FirstOrDefault();

            DeserializeUserInformation.Facility = getfacility;

            var Request = new RequestModel
            {
                InformationType = Constants.INFORMATION_TAG,
                UserInformation = DeserializeUserInformation,
            };

            return Json(Request);
        }


        #endregion
        #region HELPERS

        private async Task<Users> SetDoctorViewModel(UpdateDoctorViewModel model)
        {
            var doctor = await _context.Users.FindAsync(model.Id);

            doctor.Fname = model.Firstname;
            doctor.Mname = model.Middlename;
            doctor.Lname = model.Lastname;
            doctor.Contact = model.ContactNumber;
            doctor.Email = model.Email;
            doctor.Designation = model.Designation;
            doctor.DepartmentId = model.Department;
            doctor.Status = model.Status;
            doctor.Level = model.Level;
            doctor.Username = model.Username;
            doctor.UpdatedAt = DateTime.Now;
            return doctor;
        }


        private UpdateDoctorViewModel returnDoctorInfo(Users doctor)
        {
            var returnDoctor = new UpdateDoctorViewModel
            {
                Id = doctor.Id,
                Firstname = doctor.Fname,
                Middlename = doctor.Mname,
                Lastname = doctor.Lname,
                ContactNumber = doctor.Contact,
                Email = doctor.Email,
                Designation = doctor.Designation,
                Department = (int)doctor.DepartmentId,
                Level = doctor.Level,
                Username = doctor.Username,
                Status = doctor.Status,
            };

            return returnDoctor;
        }
        public Facility UpdateFacility(HospitalInfoViewModel model)
        {
            var facility = _context.Facility.Find(UserFacility);
            facility.Name = model.FacilityName;
            facility.Abbr= model.Abbreviation;
            facility.Muncity = model.MuncityId ?? 0;
            facility.Brgy = model.BarangayId ?? 0;
            facility.Address = model.Address;
            facility.Contact = model.Contact;
            facility.Email = model.Email;
            facility.Status = model.Status;

            return facility;
        }

        public int UserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));

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