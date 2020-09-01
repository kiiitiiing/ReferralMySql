using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoreLinq;
using OfficeOpenXml;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.Models.ViewModels.Admin;
using Referral2.Models.ViewModels.Consolidated;
using Referral2.MyData;

namespace Referral2.Controllers
{
    [Authorize]
    public class UserReportController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public UserReportController(MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _roles = roles;
            _status = status;
        }
        #region ONBOARD USERS
        [HttpGet]
        public IActionResult OnboardUsers(string date)
        {
            if (Role.CheckRole())
            {
                if (!string.IsNullOrEmpty(date))
                {
                    StartDate = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    EndDate = StartDate.AddDays(1).AddSeconds(1);
                }
                else
                {
                    StartDate = DateTime.Now.Date;
                    EndDate = StartDate.AddDays(1).AddSeconds(1);
                }

                ViewBag.Date = StartDate.ToString("MM/dd/yyyy");


                var onlineUsers = _context.Login
                    .Where(login => login.Login1 >= StartDate && login.Login1 < EndDate)
                    .Join(
                        _context.Users
                            .Where(x=>x.Level != _roles.Value.ADMIN)
                            .GroupJoin(
                            _context.Department,
                            u => u.DepartmentId,
                            d => d.Id,
                            (u, D) =>
                                new
                                {
                                    u = u,
                                    D = D
                                }
                            )
                            .SelectMany(
                            temp0 => temp0.D.DefaultIfEmpty(),
                            (temp0, department) =>
                                new
                                {
                                    temp0 = temp0,
                                    department = department
                                }
                            )
                            .Join(
                            _context.Facility,
                            temp1 => temp1.temp0.u.FacilityId,
                            f => f.Id,
                            (temp1, f) =>
                                new
                                {
                                    Id = temp1.temp0.u.Id,
                                    FullName = temp1.temp0.u.GetFullName(),
                                    Level = temp1.temp0.u.Level,
                                    FacilityName = f.Name,
                                    DepartmentName = temp1.department.Description,
                                    Status = temp1.temp0.u.LoginStatus
                                }
                            ),
                        login => login.UserId,
                        user => user.Id,
                        (login, user) =>
                            new OnlineAdminViewModel
                            {
                                UserId = user.Id,
                                FacilityName = user.FacilityName,
                                UserFullName = user.FullName,
                                UserLevel = user.Level,
                                UserDepartment = user.DepartmentName,
                                UserStatus = user.Status,
                                UserLoginTime = login.Login1
                            }
                    )

                    .OrderBy(x => x.FacilityName)
                    .DistinctBy(x => x.UserId);

                return View(onlineUsers);
            }
            else
                return NotFound();
        }
        #endregion
        #region ONLINE FACILITIES
        [HttpGet]
        public IActionResult OnlineFacilities(string date)
        {
            if (Role.CheckRole())
            {
                if (!string.IsNullOrEmpty(date))
                {
                    StartDate = DateTime.Parse(date);
                    EndDate = StartDate.AddDays(1).AddSeconds(1);
                }
                else
                {
                    StartDate = DateTime.Now.Date;
                    EndDate = StartDate.AddDays(1).AddSeconds(1);
                }

                ViewBag.Date = StartDate.ToString("MM/dd/yyyy");

                var logins = _context.Login
                    .Where(x=>x.Login1 >= StartDate && x.Login1 < EndDate)
                    .Join(
                        _context.Users
                            .Join(
                            _context.Facility,
                            u => u.FacilityId,
                            f => f.Id,
                            (u, f) =>
                                new
                                {
                                    u = u,
                                    f = f
                                }
                            )
                            .Join(
                            _context.Province,
                            temp0 => temp0.u.Province,
                            p => p.Id,
                            (temp0, p) =>
                                new
                                {
                                    temp0.f.Name,
                                    temp0.u.Id,
                                    FacilityId = temp0.f.Id,
                                    temp0.u.Status,
                                    Province = p.Description
                                }
                            ),
                        login => login.UserId,
                        user => user.Id,
                        (login, user) =>
                            new OnlineFacilitiesModel
                            {
                                Name = user.Name,
                                LoginTime = login.Login1,
                                LogoutTime = login.Logout,
                                Status = user.Status,
                                Province = user.Province
                            }
                    );


                /*var onlineFacilities = _context.Facility
                    .Join(
                        _context.Province,
                        facility => facility.Province,
                        province => province.Id,
                        (facility, province) =>
                            new OnlineFacilitiesModel
                            {
                                Name = facility.Name,
                                LoginTime = logins.Where(x => x.FacilityId == facility.Id && x.LoginTime >= StartDate && x.LoginTime <= EndDate).OrderBy(x => x.LoginTime).FirstOrDefault().LoginTime,
                                LogoutTime = logins.Where(x => x.FacilityId == facility.Id && x.LogoutTime >= StartDate && x.LogoutTime <= EndDate).OrderByDescending(x => x.LogoutTime).FirstOrDefault().LogoutTime,
                                Status = logins.Where(x => x.FacilityId == facility.Id && x.LoginTime >= StartDate && x.LoginTime <= EndDate).OrderBy(x => x.LoginTime).FirstOrDefault().Status,
                                Province = province.Description
                            }
                    );*/

                return View(logins);
            }
            else
                return NotFound();
        }
        #endregion
        #region OFFLINE FACILITIES
        [HttpGet]
        public async Task<IActionResult> OfflineFacilities(string date)
        {
            if (Role.CheckRole())
            {
                if (!string.IsNullOrEmpty(date))
                {
                    StartDate = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                }
                else
                {
                    StartDate = DateTime.Now.Date;
                }
                EndDate = StartDate.AddDays(1).AddSeconds(-1);

                var facilities = await _context.Login
                    .Join(
                        _context.Users
                            .Join(
                            _context.Facility,
                            u => u.FacilityId,
                            f => f.Id,
                            (u, f) =>
                                new
                                {
                                    u = u,
                                    f = f
                                }
                            )
                            .Where(temp0 => !(temp0.f.Name.Contains("RHU")))
                            .Join(
                            _context.Province,
                            temp0 => temp0.u.Province,
                            p => p.Id,
                            (temp0, p) =>
                                new
                                {
                                    temp0.f.Name,
                                    Chief_hospital = temp0.f.ChiefHospital,
                                    Type = temp0.f.HospitalType,
                                    temp0.u.Id,
                                    temp0.u.Status,
                                    Province = p.Description,
                                    temp0.f.Contact

                                }
                            ),
                        login => login.UserId,
                        user => user.Id,
                        (login, user) =>
                            new OnboardModel
                            {
                                ContactNo = user.Contact,
                                Name = user.Name,
                                Chief = user.Chief_hospital,
                                Province = user.Province,
                                Type = user.Type,
                                ActivitiesTo = ((login.Login1 >= StartDate) && (login.Login1 < EndDate))
                            }
                    )
                    .ToListAsync();


                    /*.Where(x => !x.Name.Contains("RHU"))
                    .Select(x => new OnboardModel
                    {
                        Name = x.Name,
                        Chief = x.ChiefHospital,
                        Province = x.Province.Description,
                        Type = x.Type,
                        ActivitiesTo = x.User.Any(x => x.Login.Any(x => x.Login1 >= StartDate && x.Login1 < EndDate))
                    })
                    .Where(x=>x.ActivitiesTo == false)
                    .OrderBy(x => x.Name)
                    .ToListAsync();*/

                ViewBag.Date = StartDate.ToString("MM/dd/yyyy");
                return View(facilities);
            }
            else
                return NotFound();
        }
        #endregion
        #region ONBOARD FACILITIES
        [HttpGet]
        public async Task<IActionResult> OnboardFacilities()
        {
            if (Role.CheckRole())
            {
                var activities = _context.Activity;
                var users = _context.Users;
                var facilities = await _context.Facility
                    .Where(facility => facility.FacilityCode == null)
                    .Where(x=>x.Name != "Department of Health - RO7")
                    .Join(
                        _context.Province,
                        facility => facility.Province,
                        province => province.Id,
                        (facility, province) =>
                            new OnboardModel
                            {
                                Name = facility.Name,
                                Chief = facility.ChiefHospital,
                                ContactNo = facility.Contact,
                                Type = facility.HospitalType,
                                LoginAt = users.Where(x=>x.FacilityId == facility.Id && x.LastLogin != default).OrderByDescending(x=>x.LastLogin).First().LastLogin,
                                Province = province.Description,
                                RegisteredAt = facility.CreatedAt.Value.DateTime,
                                ActivitiesFrom = activities.Where(x=>x.ReferredFrom == facility.Id).Count() != 0,
                                ActivitiesTo = activities.Where(x => x.ReferredTo == facility.Id).Count() != 0
                            }
                    )
                    .ToListAsync();



               /* .Where(x => !x.Name.Contains("RHU"))
                .Select(x => new OnboardModel
                {
                    Name = x.Name,
                    Chief = x.ChiefHospital,
                    ContactNo = x.ContactNo,
                    Type = x.Type,
                    Province = x.Province.Description,
                    RegisteredAt = x.CreatedAt,
                    LoginAt = x.User.Where(x => x.LastLogin != default).OrderByDescending(x => x.LastLogin).First().LastLogin,
                    ActivitiesFrom = x.ActivityReferredFromNavigation.Count() != 0,
                    ActivitiesTo = x.ActivityReferredToNavigation.Count() != 0
                })
                .OrderBy(x => x.Name)
                .ToListAsync();*/

                return View(facilities);
            }
            else
                return NotFound();
        }
        #endregion
        /*#region CONSOLIDATED    
        // CONSOLIDATED
        public async Task<IActionResult> Consolidated(string dateRange, bool export, bool inexport, bool outexport)
        {
            if (Role.CheckRole())
            {
                if (!string.IsNullOrEmpty(dateRange))
                {
                    
                    StartDate = DateTime.ParseExact(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    EndDate = DateTime.ParseExact(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    var dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    StartDate = new DateTime(dateNow.Year, 1, 1);
                    EndDate = dateNow.AddMonths(1).AddDays(-1);
                }
                ViewBag.StartDate = StartDate;
                ViewBag.EndDate = EndDate;

                // TABLES

                var patientForms = _context.PatientForm
                    .Where(x => x.TimeReferred >= StartDate && x.TimeReferred <= EndDate);

                var pregnantForms = _context.PregnantForm
                    .Where(x => x.ReferredDate >= StartDate && x.ReferredDate <= EndDate);

                var facilities = _context.Facility;

                var trackings = _context.Tracking
                    .Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);

                var activities = _context.Activity
                    .Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);

                var trans = _context.ModeTransportation;

                var departments = _context.Department;

                var doctors = _context.User;

                var consolidated = new List<ConsolidatedViewModel>();

                var activeFacilities = trackings
                   .Select(t => t.ReferredTo)
                   .Union(
                      trackings
                        .Select(t => t.ReferredFrom)
                   );

                foreach (var item in activeFacilities)
                {
                    // --------------------- INCOMING ---------------------
                    #region INCOMING
                    // INCOMING: INCOMING
                    var inIncoming = await trackings
                        .Where(x => x.ReferredTo.Equals(item) && x.Status != _status.Value.REJECTED && x.Status != _status.Value.CANCELLED).CountAsync();
                    // INCOMING: ACCEPTED
                    var inAccepted = await _context.Tracking
                        .Where(x => x.ReferredTo == item && x.DateAccepted != default && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                        .CountAsync();
                    // INCOMING: REFERRING FACILITY
                    var inReferringFac = await trackings
                        .Where(x => x.ReferredTo == item)
                        .GroupBy(x => x.ReferredFrom)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName = facilities.FirstOrDefault(x => x.Id == i.Key).Name
                        })
                        .ToListAsync();
                    // INCOMING: REFERRING DOCTOS
                    var inReferringDoc = await trackings
                        .Where(x => x.ReferredTo == item && x.ReferringMd != null)
                        .GroupBy(x => x.ReferringMd)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName ="Dr. "+ doctors.FirstOrDefault(c=>c.Id == i.Key).Fname.NameToUpper()+" "
                            +doctors.FirstOrDefault(c => c.Id == i.Key).Mname.NameToUpper() + " "
                            + doctors.FirstOrDefault(c => c.Id == i.Key).Lname.NameToUpper()
                        })
                        .ToListAsync();


                    // INCOMING: DIAGNOSIS
                    var inDiagnosis = patientForms
                       .Where(p => p.ReferredTo == item)
                       .Select(p => p.Diagnosis)
                       .AsEnumerable()
                       .Concat(
                          pregnantForms
                             .Where(pf => pf.ReferredTo == item)
                             .Select(pf => pf.WomanMajorFindings)
                       )
                       .GroupBy(u => u)
                       .Select(
                          x =>
                             new ListItem
                             {
                                 NoItem = x.Count(),
                                 ItemName = x.Key
                             })
                       .OrderByDescending(x => x.NoItem)
                       .ToList();

                    // INCOMING: REASONS
                    var inReason = patientForms
                       .Where(p => p.ReferredTo == item)
                       .Select(p => p.Reason)
                       .AsEnumerable()
                       .Concat(
                          pregnantForms
                             .Where(pf => pf.ReferredTo == item)
                             .Select(pf => pf.WomanReason)
                       )
                       .GroupBy(u => u)
                       .Select(
                          x =>
                             new ListItem
                             {
                                 NoItem = x.Count(),
                                 ItemName = x.Key
                             })
                       .OrderByDescending(x => x.NoItem)
                       .ToList();
                    // INCOMING: TRANSPORTATIONS
                    var inTransportation = await trackings
                        .Where(x => x.ReferredTo == item && !string.IsNullOrEmpty(x.ModeTransportation))
                        .GroupBy(x => x.ModeTransportation)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName = string.IsNullOrEmpty(i.Key) ? "" : i.Key
                        })
                       .ToListAsync();
                    // INCOMING: DEPARTMENT
                    var inDepartment = await trackings
                        .Where(x => x.ReferredTo == item)
                        .GroupBy(x => x.DepartmentId)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName = departments.SingleOrDefault(x => x.Id.Equals(i.Key)).Description
                        })
                       .ToListAsync();

                    var inRemarks = await _context.Issue
                        .Where(x => x.Tracking.ReferredTo == item && x.Tracking.DateReferred >= StartDate && x.Tracking.DateReferred <= EndDate)
                        .Select(i => new ListItem
                        {
                            ItemName = i.Issue1
                        })
                        .ToListAsync();
                    #endregion

                    // --------------------- OUTGOING ---------------------
                    #region OUTGOING
                    // OUTGOING: OUTGOING
                    var outOutgoing = await trackings
                        .Where(x => x.ReferredFrom.Equals(item) && x.Status != _status.Value.REJECTED && x.Status != _status.Value.CANCELLED).CountAsync();
                    // OUTGOING: ACCEPTED
                    var outAccepted = await trackings
                        .Where(x => x.ReferredFrom == item && x.DateAccepted != default)
                        .CountAsync();
                    // OUTGOING: REDIRECTED
                    var outRedirected = await activities
                        .Where(x => x.ReferredFrom.Equals(item) && x.Status.Equals(_status.Value.REJECTED))
                        .CountAsync();
                    // OUTGOING: ARCHIVED
                    var outArchived = await trackings
                        .Where(x => x.ReferredFrom.Equals(item))
                        .Where(x => x.Status.Equals(_status.Value.REFERRED) || x.Status.Equals(_status.Value.SEEN))
                        .Where(x => DateTime.Now > x.DateReferred.AddDays(3))
                        .CountAsync();
                    // OUTGOING: REFERRING FACILITY
                    var outReferringFac = await trackings
                        .Where(x => x.ReferredFrom == item)
                        .GroupBy(x => x.ReferredTo)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName = facilities.SingleOrDefault(x => x.Id == i.Key).Name
                        })
                        .OrderByDescending(x => x.NoItem)
                        .ToListAsync();
                    // OUTGOING: REFERRING DOCTOS
                    var outReferringDoc = await trackings
                        .Where(x => x.ReferredFrom == item)
                        .GroupBy(x => x.ReferringMd)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName = "Dr. " + doctors.FirstOrDefault(c => c.Id == i.Key).Fname.NameToUpper() + " "
                            + doctors.FirstOrDefault(c => c.Id == i.Key).Mname.NameToUpper() + " "
                            + doctors.FirstOrDefault(c => c.Id == i.Key).Lname.NameToUpper()
                        })
                        .ToListAsync();


                    // OUTGOING: DIAGNOSIS

                    var outDiagnosis = patientForms
                       .Where(p => p.ReferringFacility == item)
                       .Select(p => p.Diagnosis)
                       .AsEnumerable()
                       .Concat(
                          pregnantForms
                             .Where(pf => pf.ReferringFacility == item)
                             .Select(pf => pf.WomanMajorFindings)
                       )
                       .GroupBy(u => u)
                       .Select(
                          x =>
                             new ListItem
                             {
                                 NoItem = x.Count(),
                                 ItemName = x.Key
                             })
                       .OrderByDescending(x => x.NoItem)
                       .ToList();

                    // OUTGOING: REASONS
                    var outReason = patientForms
                       .Where(p => p.ReferringFacility == item)
                       .Select(p => p.Reason)
                       .AsEnumerable()
                       .Concat(
                          pregnantForms
                             .Where(pf => pf.ReferringFacility == item)
                             .Select(pf => pf.WomanReason)
                       )
                       .GroupBy(u => u)
                       .Select(
                          x =>
                             new ListItem
                             {
                                 NoItem = x.Count(),
                                 ItemName = x.Key
                             })
                       .OrderByDescending(x => x.NoItem)
                       .ToList();
                    // OUTGOING: TRANSPORTATIONS
                    var outTransportation = await trackings
                        .Where(x => x.ReferredFrom == item && !string.IsNullOrEmpty(x.ModeTransportation))
                        .GroupBy(x => x.ModeTransportation)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName = string.IsNullOrEmpty(i.Key) ? "" : i.Key
                        })
                       .ToListAsync();
                    // OUTGOING: DEPARTMENT
                    var outDepartment = await trackings
                        .Where(x => x.ReferredFrom == item)
                        .GroupBy(x => x.DepartmentId)
                        .Select(i => new ListItem
                        {
                            NoItem = i.Count(),
                            ItemName = departments.SingleOrDefault(x => x.Id.Equals(i.Key)).Description
                        })
                       .ToListAsync();

                    var outRemarks = await _context.Issue
                        .Where(x => x.Tracking.ReferredFrom == item && x.Tracking.DateReferred >= StartDate && x.Tracking.DateReferred <= EndDate)
                        .Select(i => new ListItem
                        {
                            ItemName = i.Issue1
                        })
                        .ToListAsync();
                    #endregion

                    var inAcceptance = trackings
                        .Where(x => x.ReferredTo == item && x.DateAccepted != default)
                        .Select(x => new
                        {
                            mins = x.DateAccepted.Subtract(x.DateReferred).TotalMinutes
                        }).ToList();

                    var inHorizontal = await trackings
                        .Where(x => x.ReferredTo.Equals(item) && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                        .Where(x => x.ReferredFromNavigation.Level == x.ReferredToNavigation.Level)
                        .CountAsync();

                    var inVertical = inIncoming - inHorizontal;

                    var outHorizontal = await trackings
                        .Where(x => x.ReferredFrom.Equals(item))
                        .Where(x => x.ReferredFromNavigation.Level == x.ReferredToNavigation.Level)
                        .CountAsync();

                    var outVertical = outOutgoing - outHorizontal;

                    var inAcc = inAcceptance.Count() > 0 ? inAcceptance.Average(x => x.mins) : 0;

                    var inArrival = trackings
                        .Where(x => x.ReferredTo == item && x.DateArrived != default)
                        .Select(x => new
                        {
                            mins = x.DateArrived.Subtract(x.DateReferred).TotalMinutes
                        }).ToList();

                    var inArr = inArrival.Count() > 0 ? inArrival.Average(x => x.mins) : 0;

                    consolidated.Add(new ConsolidatedViewModel
                    {
                        FacilitId = (int)item,
                        FacilityLogo = facilities.Find(item).Picture,
                        FacilityName = facilities.Find(item).Name,
                        InIncoming = inIncoming,
                        InAccepted = inAccepted,
                        InViewed = inIncoming - inAccepted,
                        InReferringFacilities = inReferringFac.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        InReferringDoctors = inReferringDoc.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        InDiagnosis = inDiagnosis.Take(10).ToList(),
                        InReason = inReason.Take(10).ToList(),
                        InTransportation = inTransportation.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        InDepartment = inDepartment.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        InRemarks = inRemarks.Take(10).ToList(),
                        InAcceptance = inAcc,
                        InArrival = inArr,
                        InHorizontal = inHorizontal,
                        InVertical = inVertical,
                        OutOutgoing = outOutgoing,
                        OutAccepted = outAccepted,
                        OutViewed = outOutgoing - outAccepted,
                        OutRedirected = outRedirected,
                        OutArchived = outArchived,
                        OutViewedAcceptance = 0,
                        OutViewedRedirection = 0,
                        OutAcceptance = 0,
                        OutRedirection = 0,
                        OutTransport = 0,
                        OutHorizontal = outHorizontal,
                        OutVertical = outVertical,
                        OutReferredFacility = outReferringFac.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        OutReferredDoctor = outReferringDoc.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        OutDiagnosis = outDiagnosis.Take(10).ToList(),
                        OutReason = outReason.Take(10).ToList(),
                        OutTransportation = outTransportation.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        OutDepartment = outDepartment.OrderByDescending(x => x.NoItem).Take(10).ToList(),
                        OutRemarks = outRemarks.Take(10).ToList()

                    });
                }

                if (export)
                {
                    string name = $"Consolidated_Report.xlsx";
                    return File(ExportConsolidated(consolidated.OrderByDescending(x => x.InIncoming).ToList(), "all"), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
                }
                if (inexport)
                {
                    string name = $"Incoming_Report.xlsx";
                    return File(ExportConsolidated(consolidated.OrderByDescending(x => x.InIncoming).ToList(), "incoming"), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
                }
                if (outexport)
                {
                    string name = $"Outgoing_Report.xlsx";
                    return File(ExportConsolidated(consolidated.OrderByDescending(x => x.InIncoming).ToList(), "outgoing"), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
                }

                return View(consolidated.OrderByDescending(x => x.InIncoming).ToList());
            }
            else
                return NotFound();
        }


        private (ExcelWorksheet, int) IncomingWS(ExcelWorksheet worksheet, List<ConsolidatedViewModel> models, int row)
        {
            worksheet.Cells["B" + row].Value = "Total Incoming Referrals";
            worksheet.Cells["E" + row].Value = "Common Sources(Facility)";
            worksheet.Cells["F" + row].Value = "Common Referring Doctor HCW/MD (Top 10)";
            worksheet.Cells["G" + row].Value = "Average Referral Acceptance Turnaround time";
            worksheet.Cells["H" + row].Value = "Average Referral Arrival Turnaround Time";
            worksheet.Cells["I" + row].Value = "Diagnoses (Top 10)";
            worksheet.Cells["J" + row].Value = "Reasons (Top 10)";
            worksheet.Cells["K" + row].Value = "Number of Horizontal referrals";
            worksheet.Cells["L" + row].Value = "Number of Vertical Referrals";
            worksheet.Cells["M" + row].Value = "Common Methods of ModeTransportation";
            worksheet.Cells["N" + row].Value = "Department";
            worksheet.Cells["O" + row].Value = "Remarks";
            worksheet.Cells["A" + row + ":O" + row].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells["A" + row + ":O" + row].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
            foreach (var item in models)
            {
                row++;
                var maxRow = row;
                worksheet.Cells[row, 1].Value = item.FacilityName;  // FACILITY NAME
                worksheet.Cells[row, 2].Value = item.InIncoming.ToString();    // INCOMING
                worksheet.Cells[row, 3].Value = item.InViewed.ToString();      // VIEWED ONLY
                worksheet.Cells[row, 4].Value = item.InAccepted.ToString();    // ACCEPTED
                                                                               // REFERRING FACILITIES
                var ctr1 = row;
                foreach (var items in item.InReferringFacilities)
                {
                    worksheet.Cells[ctr1, 5].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                //REFERRING DOCTOR
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.InReferringDoctors)
                {
                    worksheet.Cells[ctr1, 6].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                worksheet.Cells[row, 7].Value = item.InAcceptance.ToString("##.##") + " mins"; //AVERAGE ACCEPTANCE TIME
                worksheet.Cells[row, 8].Value = item.InArrival.ToString("##.##") + " mins"; //AVERAGE ARRIVAL TIME
                                                                                            //DIAGNOSES
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.InDiagnosis)
                {
                    worksheet.Cells[ctr1, 9].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                //REASON
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.InReason)
                {
                    worksheet.Cells[ctr1, 10].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                worksheet.Cells[row, 11].Value = "Under development this column"; // HORIZONTAL REFERRAL
                worksheet.Cells[row, 12].Value = "Under development this column"; // VERTICAL REFERRAL
                                                                                  //TRANSPO
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.InTransportation)
                {
                    if (!string.IsNullOrEmpty(items.ItemName))
                    {
                        worksheet.Cells[ctr1, 13].Value = ListContainer.TranspoMode[int.Parse(items.ItemName[0].ToString()) - 1] + " - " + items.NoItem;
                        ctr1++;
                    }
                }
                //DEPARTMENT
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.InDepartment)
                {
                    worksheet.Cells[ctr1, 14].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                //REMARKS
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.InRemarks)
                {
                    worksheet.Cells[ctr1, 15].Value = items.ItemName;
                    ctr1++;
                }
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                row = maxRow;
            }

            return (worksheet, row);
        }

        private (ExcelWorksheet, int) OutgoingWS(ExcelWorksheet worksheet, List<ConsolidatedViewModel> models, int row)
        {
            string underdev = "This Column is under development";

            worksheet.Cells["B" + row].Value = "Total Outgoing Referrals";
            worksheet.Cells["E" + row].Value = "Total Archived Referrals";
            worksheet.Cells["F" + row].Value = "Total Redirected Referrals";
            worksheet.Cells["G" + row].Value = "Common Sources(Facility)";
            worksheet.Cells["H" + row].Value = "Common Referring Doctor HCW/MD (Top 10)";
            worksheet.Cells["I" + row].Value = "Average Referral Viewed Only Acceptance Turnaround time ";
            worksheet.Cells["J" + row].Value = "Average Referral Viewed Only Redirection Turnaround time ";
            worksheet.Cells["K" + row].Value = "Average Referral Acceptance Turnaround time ";
            worksheet.Cells["L" + row].Value = "Average Referral Redirection Turnaround Time";
            worksheet.Cells["M" + row].Value = "Average Referral to Transport Turnaround Time";
            worksheet.Cells["N" + row].Value = "Diagnoses for Outgoing Referral(Top 10)";
            worksheet.Cells["O" + row].Value = "Reasons for Referral(Top 10)";
            worksheet.Cells["P" + row].Value = "Reasons for Redirection(Top 10)";
            worksheet.Cells["Q" + row].Value = "Number of Horizontal referrals";
            worksheet.Cells["R" + row].Value = "Number of Vertical Referrals";
            worksheet.Cells["S" + row].Value = "Common Methods of ModeTransportation";
            worksheet.Cells["T" + row].Value = "Department";
            worksheet.Cells["U" + row].Value = "Remarks";
            worksheet.Cells["A" + row + ":U" + row].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells["A" + row + ":U" + row].Style.Fill.BackgroundColor.SetColor(Color.Yellow);

            foreach (var item in models)
            {
                row++;
                var maxRow = row;
                worksheet.Cells[row, 1].Value = item.FacilityName;  // FACILITY NAME
                worksheet.Cells[row, 2].Value = item.OutOutgoing.ToString();    // INCOMING
                worksheet.Cells[row, 3].Value = item.OutViewed.ToString();      // VIEWED ONLY
                worksheet.Cells[row, 4].Value = item.OutAccepted.ToString();    // ACCEPTED
                worksheet.Cells[row, 5].Value = underdev;    // ARCHIVED
                worksheet.Cells[row, 6].Value = underdev;    // REDIRECTED

                // REFERRED FACILITIES
                var ctr1 = row;
                foreach (var items in item.OutReferredFacility)
                {
                    worksheet.Cells[ctr1, 7].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                //REFERRED DOCTOR
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.OutReferredDoctor)
                {
                    worksheet.Cells[ctr1, 8].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                worksheet.Cells[row, 9].Value = underdev; //AVERAGE ACCEPTANCE TIME
                worksheet.Cells[row, 10].Value = underdev; //AVERAGE ARRIVAL TIME
                worksheet.Cells[row, 11].Value = underdev; //AVERAGE ACCEPTANCE TIME
                worksheet.Cells[row, 12].Value = underdev; //AVERAGE ARRIVAL TIME
                worksheet.Cells[row, 13].Value = underdev; //AVERAGE ARRIVAL TIME
                                                           //DIAGNOSES
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.OutDiagnosis)
                {
                    worksheet.Cells[ctr1, 14].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                //REASON
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.OutReason)
                {
                    worksheet.Cells[ctr1, 15].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                worksheet.Cells[row, 16].Value = underdev; //AVERAGE ACCEPTANCE TIME
                worksheet.Cells[row, 17].Value = underdev; //AVERAGE ARRIVAL TIME
                worksheet.Cells[row, 18].Value = underdev; //AVERAGE ARRIVAL TIME
                                                           //TRANSPO
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.OutTransportation)
                {
                    if (!string.IsNullOrEmpty(items.ItemName))
                    {
                        worksheet.Cells[ctr1, 19].Value = ListContainer.TranspoMode[int.Parse(items.ItemName[0].ToString()) - 1] + " - " + items.NoItem;
                        ctr1++;
                    }
                }
                //DEPARTMENT
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.OutDepartment)
                {
                    worksheet.Cells[ctr1, 20].Value = items.ItemName + " - " + items.NoItem;
                    ctr1++;
                }
                //REMARKS
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                ctr1 = row;
                foreach (var items in item.OutRemarks)
                {
                    worksheet.Cells[ctr1, 21].Value = items.ItemName;
                    ctr1++;
                }
                maxRow = ctr1 > maxRow ? ctr1 : maxRow;
                row = maxRow;
            }
            return (worksheet, row);
        }

        public MemoryStream ExportConsolidated(List<ConsolidatedViewModel> models, string type)
        {
            var stream = new MemoryStream();
            //string underdev = "This Column is under development";

            using (var package = new ExcelPackage(stream))
            {
                int row = 1;

                if (type.Equals("all"))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Incoming Consolidated Report");
                    worksheet.Cells.Style.Font.Size = 11;
                    worksheet.Cells["A" + row].Value = "Name of Facility";
                    worksheet.Cells["C" + row].Value = "Total Viewed Only Referrals";
                    worksheet.Cells["D" + row].Value = "Total Accepted Referrals";
                    worksheet.Cells["A1:U" + row].Style.Font.Bold = true;
                    worksheet.Cells["A1:U" + row].Style.Font.Name = "Arial";
                    worksheet = IncomingWS(worksheet, models, row).Item1;
                    worksheet.Cells.AutoFitColumns();
                    worksheet = package.Workbook.Worksheets.Add("Outgoing Consolidated Report");
                    worksheet = OutgoingWS(worksheet, models, row).Item1;
                    worksheet.Cells.AutoFitColumns();
                }
                else if (type.Equals("incoming"))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Incoming Consolidated Report");
                    worksheet.Cells.Style.Font.Size = 11;
                    worksheet.Cells["A" + row].Value = "Name of Facility";
                    worksheet.Cells["C" + row].Value = "Total Viewed Only Referrals";
                    worksheet.Cells["D" + row].Value = "Total Accepted Referrals";
                    worksheet.Cells["A1:U" + row].Style.Font.Bold = true;
                    worksheet.Cells["A1:U" + row].Style.Font.Name = "Arial";

                    worksheet = IncomingWS(worksheet, models, row).Item1;

                    worksheet.Cells.AutoFitColumns();
                }
                else
                {
                    var worksheet = package.Workbook.Worksheets.Add("Outgoing Consolidated Report");
                    worksheet.Cells.Style.Font.Size = 11;
                    worksheet.Cells["A" + row].Value = "Name of Facility";
                    worksheet.Cells["C" + row].Value = "Total Viewed Only Referrals";
                    worksheet.Cells["D" + row].Value = "Total Accepted Referrals";
                    worksheet.Cells["A1:U" + row].Style.Font.Bold = true;
                    worksheet.Cells["A1:U" + row].Style.Font.Name = "Arial";

                    worksheet = OutgoingWS(worksheet, models, row).Item1;

                    worksheet.Cells.AutoFitColumns();
                }

                package.Save();
            }

            stream.Position = 0;

            return stream;
        }
        #endregion*/

        #region HELPERS
        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));
        public int UserDepartment => int.Parse(User.FindFirstValue("Department"));
        public int UserProvince => int.Parse(User.FindFirstValue("Province"));
        public int UserMuncity => int.Parse(User.FindFirstValue("Muncity"));
        public int UserBarangay => int.Parse(User.FindFirstValue("Barangay"));
        public string Role => User.FindFirstValue("RealRole");
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        #endregion
    }
}
