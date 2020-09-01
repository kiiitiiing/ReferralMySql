using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.Models;
using Referral2.Models.ViewModels;
using Referral2.Models.ViewModels.ViewPatients;
using Microsoft.Extensions.Options;
using Referral2.Models.ViewModels.Doctor;
using MoreLinq.Extensions;
using Newtonsoft.Json;
using Referral2.Models.MobileModels;
using Microsoft.AspNetCore.Authorization;
using Referral2.MyData;

namespace Referral2.Controllers
{
    [Authorize(Policy = "Doctor")]
    public class ViewPatientsController : Controller
    {
        public const string SessionKeySearch = "_search";
        public const string SessionKeyCode = "_code";
        public const string SessionKeyDateRange = "_dateRange";
        public const string SessionKeyStatus = "_status";
        public const string SessionKeyFacility = "_facility";
        public const string SessionKeyDepartment = "_department";
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;

        public ViewPatientsController(MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _roles = roles;
            _status = status;
        }

        public string Search { get; set; }
        public string DateRange { get; set; }
        public string Status { get; set; }
        public int? FacilityId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #region LIST PATIENTS
        //GET: List Patients
        [HttpGet]
        public async Task<IActionResult> ListPatients(string name, int? muncityId, int? barangayId, int? page)
        {
            ViewBag.CurrentFilter = name;

            var muncities = _context.Muncity.Where(x => x.ProvinceId.Equals(UserProvince));

            if (muncityId == null)  
                ViewBag.Muncities = new SelectList(muncities, "Id", "Description");
            else
            {
                var barangays = _context.Barangay.Where(x => x.MuncityId.Equals(muncityId));
                ViewBag.Muncities = new SelectList(muncities, "Id", "Description", muncityId);
                ViewBag.Barangays = new SelectList(barangays, "Id", "Description", barangayId);
            }



            var patients = _context.Patients
                .Join(
                    _context.Province,
                    p => p.Province,
                    province => province.Id,
                    (p, province) =>
                        new
                        {
                            p = p,
                            province = province
                        }
                )
                .Join(
                    _context.Muncity,
                    temp0 => temp0.p.Muncity,
                    muncity => muncity.Id,
                    (temp0, muncity) =>
                        new
                        {
                            temp0 = temp0,
                            muncity = muncity
                        }
                )
                .Join(
                    _context.Barangay,
                    temp1 => temp1.temp0.p.Brgy,
                    barangay => barangay.Id,
                    (temp1, barangay) =>
                        new PatientsViewModel
                        {
                            PatientId = temp1.temp0.p.Id,
                            Fname = temp1.temp0.p.Fname,
                            Mname = temp1.temp0.p.Mname,
                            Lname = temp1.temp0.p.Lname,
                            PatientSex = temp1.temp0.p.Sex,
                            PatientAge = temp1.temp0.p.Dob.ComputeAge(),
                            DateofBirth = temp1.temp0.p.Dob,
                            MuncityId = temp1.temp0.p.Muncity,
                            Muncity = (temp1.temp0.p.Muncity == 0) ? "" : temp1.muncity.Description,
                            BarangayId = temp1.temp0.p.Brgy,
                            Barangay = (temp1.temp0.p.Brgy == 0) ? "" : barangay.Description,
                            CreatedAt = temp1.temp0.p.CreatedAt
                        }
                )
                .Where(x=>x.Fname.ToUpper() == name || x.Lname.ToUpper() == name)
                .Where(x => x.MuncityId.Equals(muncityId) && x.BarangayId.Equals(barangayId));


            int size = 15;


            return View(await PaginatedList<PatientsViewModel>.CreateAsync(patients.OrderBy(x => x.Lname), page ?? 1, size));
        }
        #endregion
        #region ACCEPTED
        //GET: Accepted patients
        public async Task<IActionResult> Accepted(string search, string dateRange, int? page)
        {
            #region Variable initialize
            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.ParseExact(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                EndDate = DateTime.ParseExact(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1).AddSeconds(-1);
            }
            else
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                EndDate = new DateTime(DateTime.Now.Year, 12, 31);
            }


            ViewBag.StartDate = StartDate.Date.ToString("dd/MM/yyyy");
            ViewBag.EndDate = EndDate.Date.ToString("dd/MM/yyyy");
            #endregion
            #region Query
            var activity = _context.Activity;
            var accepted = _context.Tracking
                .Where(x => x.ReferredTo == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Where(x => x.Status == _status.Value.ACCEPTED || x.Status == _status.Value.ARRIVED || x.Status == _status.Value.ADMITTED)
                .Join(
                    _context.Facility,
                    t => t.ReferredFrom,
                    f => f.Id,
                    (t, f) => new { t = t, f = f })
                .Join(
                    _context.Patients,
                    temp0 => temp0.t.PatientId,
                    p => p.Id,
                    (temp0, p) => new AcceptedViewModel
                    {
                        ReferredTo = temp0.t.ReferredTo,
                        ReferringFacility = temp0.f.Name,
                        Type = temp0.t.Type == "normal" ? "Non-Pregnant" : "Pregnant",
                        Fname = p.Fname,
                        Mname = p.Mname??"",
                        Lname = p.Lname,
                        PatientCode = temp0.t.Code,
                        DateAction = temp0.t.DateAccepted,
                        Status = activity.OrderByDescending(x => x.DateReferred).FirstOrDefault(x => x.Code == temp0.t.Code).Status
                    });
            #endregion

            ViewBag.Total = accepted.Count();

            if (!string.IsNullOrEmpty(search))
            {
                accepted = accepted.Where(s => s.PatientCode.Equals(search) || s.Fname.ToUpper().Contains(search) || s.Lname.ToUpper().Contains(search));
                ViewBag.Total = accepted.Count();
            }
            else
            {
                ViewBag.Total = accepted.Count();
            }


            int size = 15;

            return View(await PaginatedList<AcceptedViewModel>.CreateAsync(accepted.OrderByDescending(x => x.DateAction), page ?? 1, size));
        }
        #endregion
        #region DISCHARGED
        //GET: Dischagred Patients
        public async Task<IActionResult> Discharged(string search, string dateRange, int? page)
        {
            #region Variable initialize
            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.ParseExact(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                EndDate = DateTime.ParseExact(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1).AddSeconds(-1);
            }
            else
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                EndDate = new DateTime(DateTime.Now.Year, 12, 31);
            }
            ViewBag.StartDate = StartDate.Date.ToString("dd/MM/yyyy");
            ViewBag.EndDate = EndDate.Date.ToString("dd/MM/yyyy");
            #endregion
            #region Query
            var activities = _context.Activity;
            var discharge = _context.Tracking
                .Where(x => x.ReferredTo == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Where(x => x.Status == _status.Value.DISCHARGED || x.Status == _status.Value.TRANSFERRED)
                .Join(
                    _context.Facility,
                    t => t.ReferredFrom,
                    f => f.Id,
                    (t, f) => new { t = t, f = f })
                .Join(
                    _context.Patients,
                    temp0 => temp0.t.PatientId,
                    p => p.Id,
                    (temp0, p) => new DischargedViewModel
                    {
                        ReferringFacility = temp0.f.Name,
                        Type = temp0.t.Type == "normal" ? "Non-Pregnant" : "Pregnant",
                        Fname = p.Fname,
                        Mname = p.Mname ?? "",
                        Lname = p.Lname,
                        Code = temp0.t.Code,
                        DateAction = (DateTimeOffset)temp0.t.UpdatedAt,
                        Status = activities.Where(c => c.Code == temp0.t.Code && c.Status == temp0.t.Status).FirstOrDefault().Status
                    });
            #endregion

            ViewBag.Total = discharge.Count();

            if (!string.IsNullOrEmpty(search))
            {
                discharge = discharge.Where(s => s.Code.Contains(search) || s.Fname.ToUpper().Contains(search) || s.Lname.ToUpper().Contains(search));
                ViewBag.Total = discharge.Count();
            }

            int size = 15;

            return View(await PaginatedList<DischargedViewModel>.CreateAsync(discharge.OrderByDescending(x => x.DateAction), page ?? 1, size));
        }
        #endregion
        #region CANCELLED
        //GET: Cancelled Patients
        public async Task<IActionResult> Cancelled(string search, string dateRange, int? page)
        {
            #region Initialize variables
            ViewBag.CurrentSearch = search;


            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.Parse(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim()).AddDays(1).AddSeconds(-1);
            }
            else
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                EndDate = new DateTime(DateTime.Now.Year, 12, 31);
            }

            ViewBag.StartDate = StartDate.Date.ToString("yyyy/MM/dd");
            ViewBag.EndDate = EndDate.Date.ToString("yyyy/MM/dd");
            #endregion
            #region Query
            var cancelled = _context.Tracking.Where(x => x.ReferredTo == UserFacility && x.Status == _status.Value.CANCELLED)
                .Join(
                    _context.Facility,
                    t => t.ReferredFrom,
                    f => f.Id,
                    (t, f) => new { t = t, f = f })
                .Join(
                    _context.Patients,
                    temp0 => temp0.t.PatientId,
                    p => p.Id,
                    (temp0, p) => new CancelledViewModel
                    {
                        ReferringFacility = temp0.f.Name,
                        PatientType = temp0.t.Type == "pregnant" ? "Pregnant" : "Non-Pregnant",
                        Fname = p.Fname,
                        Mname = p.Mname ?? "",
                        Lname = p.Lname,
                        PatientCode = temp0.t.Code,
                        DateCancelled = temp0.t.UpdatedAt,
                        ReasonCancelled = _context.Activity.Where(c => c.Code == temp0.t.Code && c.Status == temp0.t.Status).FirstOrDefault().Remarks
                    })
                .Where(x => x.DateCancelled >= StartDate && x.DateCancelled <= EndDate);
            #endregion

            if (!string.IsNullOrEmpty(search))
            {
                cancelled = cancelled.Where(s => s.PatientCode.Contains(search) || s.Fname.ToUpper().Contains(search) || s.Lname.ToUpper().Contains(search));
            }

            int size = 15;
            ViewBag.Total = cancelled.Count();
            return View(await PaginatedList<CancelledViewModel>.CreateAsync(cancelled.OrderByDescending(x => x.DateCancelled), page ?? 1, size));
        }
        #endregion
        #region ARCHIVED
        //GET: Archived patients
        public async Task<IActionResult> Archived(string search, string dateRange, int? page)
        {
            #region Initialize variables
            ViewBag.CurrentSearch = search;
            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.Parse(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim()).AddDays(1).AddSeconds(-1);
            }
            else
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                EndDate = new DateTime(DateTime.Now.Year, 12, 31);
            }
            ViewBag.StartDate = StartDate.Date.ToString("yyyy/MM/dd");
            ViewBag.EndDate = EndDate.Date.ToString("yyyy/MM/dd");
            #endregion
            #region Query
            var activities = _context.Activity
                .Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);
            var archivedPatients = _context.Tracking
                .Where(x => x.ReferredTo == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Where(x => x.Status == _status.Value.REFERRED || x.Status == _status.Value.SEEN || x.Status == _status.Value.ARCHIVED)
                .Where(x => DateTime.Now > x.DateReferred.AddDays(3))
                .Join(
                    _context.Facility,
                    t => t.ReferredFrom,
                    f => f.Id,
                    (t, f) => new { t = t, f = f })
                .Join(
                    _context.Patients,
                    temp0 => temp0.t.PatientId,
                    p => p.Id,
                    (temp0, p) => new ArchivedViewModel
                    {
                        ReferringFacility = temp0.f.Name,
                        Type = temp0.t.Type == "normal" ? "Non-Pregnant" : "Pregnant",
                        Fname = p.Fname,
                        Mname = p.Mname ?? "",
                        Lname = p.Lname,
                        Code = temp0.t.Code,
                        DateArchive = temp0.t.DateReferred.AddDays(3),
                        Reason = _context.Activity.Where(c => c.Code == temp0.t.Code).FirstOrDefault().Remarks
                    });
            #endregion

            ViewBag.Total = archivedPatients.Count();

            if (!string.IsNullOrEmpty(search))
            {
                archivedPatients = archivedPatients.Where(s => s.Code.Equals(search) || s.Fname.ToUpper().Contains(search) || s.Lname.ToUpper().Contains(search));
                ViewBag.Total = archivedPatients.Count();
            }

            int pageSize = 15;

            return View(await PaginatedList<ArchivedViewModel>.CreateAsync(archivedPatients.OrderByDescending(x => x.DateArchive), page ?? 1, pageSize));

        }
        #endregion
        #region INCOMING
        //GET: Incoming patients
        [HttpGet]
        public async Task<IActionResult> Incoming(string search, string dateRange, int? department, string status, int? page)
        {
            #region Initialize variables
            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.Parse(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim());
            }
            else
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                EndDate = DateTime.Now;
            }

            var faciliyDepartment = _context.Users
                .Where(x => x.FacilityId.Equals(UserFacility) && x.Level.Equals(_roles.Value.DOCTOR) && x.DepartmentId != 0)
                .Select(y => y.DepartmentId)
                .Distinct()
                .Join(
                    _context.Department,
                    u => u,
                    d => d.Id,
                    (u, d) => new SelectDepartment
                    {
                        DepartmentId = (int)d.Id,
                        DepartmentName = d.Description
                    });

            ViewBag.Departments = new SelectList(faciliyDepartment, "DepartmentId", "DepartmentName");
            ViewBag.StartDate = StartDate.Date.ToString("yyyy/MM/dd");
            ViewBag.EndDate = EndDate.Date.ToString("yyyy/MM/dd");
            ViewBag.IncomingStatus = new SelectList(ListContainer.IncomingStatus, "Key", "Value");
            #endregion
            #region Query
            var activities = _context.Activity;
            var seens = _context.Seen;
            var feedbacks = _context.Feedback;
            var incoming = _context.Tracking
                        .Where(t => t.DateReferred >= StartDate && t.DateReferred <= EndDate)
                        .Where(t => t.ReferredTo == UserFacility)
                        .Join(
                            _context.Department,
                            t => t.DepartmentId,
                            d => (Int32?)(d.Id),
                            (t, d) =>
                                new
                                {
                                    t = t,
                                    d = d
                                }
                        )
                        .Join(
                            _context.Facility,
                            temp0 => temp0.t.ReferredFrom,
                            f => f.Id,
                            (temp0, f) =>
                                new
                                {
                                    temp0 = temp0,
                                    f = f
                                }
                        )
                        .Join(
                            _context.Facility,
                            temp1 => temp1.temp0.t.ReferredTo,
                            ftoo => ftoo.Id,
                            (temp1, ftoo) =>
                                new
                                {
                                    temp1 = temp1,
                                    ftoo = ftoo
                                }
                        )
                        .Join(
                            _context.Patients,
                            temp2 => temp2.temp1.temp0.t.PatientId,
                            p => p.Id,
                            (temp2, p) =>
                                new
                                {
                                    temp2 = temp2,
                                    p = p
                                }
                        )
                        .GroupJoin(
                            _context.Users,
                            temp3 => temp3.temp2.temp1.temp0.t.ReferringMd,
                            rmd => rmd.Id,
                            (temp3, RMD) =>
                                new
                                {
                                    temp3 = temp3,
                                    RMD = RMD
                                }
                        )
                        .SelectMany(
                            temp4 => temp4.RMD.DefaultIfEmpty(),
                            (temp4, refMd) =>
                                new
                                {
                                    temp4 = temp4,
                                    refMd = refMd
                                }
                        )
                        .GroupJoin(
                            _context.Users,
                            temp5 => temp5.temp4.temp3.temp2.temp1.temp0.t.ActionMd,
                            amd => amd.Id,
                            (temp5, AMD) =>
                                new
                                {
                                    temp5 = temp5,
                                    AMD = AMD
                                }
                        )
                        .SelectMany(
                            temp6 => temp6.AMD.DefaultIfEmpty(),
                            (temp6, actMd) =>
                                new IncomingViewModel()
                                {
                                    Pregnant = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.Type == "pregnant",
                                    TrackingId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.Id,
                                    Code = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.Code,
                                    Fname = temp6.temp5.temp4.temp3.p.Fname,
                                    Mname = temp6.temp5.temp4.temp3.p.Mname,
                                    Lname = temp6.temp5.temp4.temp3.p.Lname,
                                    PatientSex = temp6.temp5.temp4.temp3.p.Sex,
                                    PatientAge = temp6.temp5.temp4.temp3.p.Dob.ComputeAge(),
                                    Status = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.Status,
                                    ReferringMd = temp6.temp5.refMd.GetMDFullName() /*((((temp6.temp5.refMd.Fname + " ") + temp6.temp5.refMd.Mname) + " ") +
                                        temp6.temp5.refMd.Lname)*/,
                                    ActionMd = actMd.GetMDFullName() /*((((actMd.Fname + " ") + actMd.Mname) + " ") + actMd.Lname)*/,
                                    ReferredFrom = temp6.temp5.temp4.temp3.temp2.temp1.f.Name,
                                    ReferredFromId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.ReferredFrom,
                                    ReferredTo = temp6.temp5.temp4.temp3.temp2.ftoo.Name,
                                    ReferredToId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.ReferredTo,
                                    Department = temp6.temp5.temp4.temp3.temp2.temp1.temp0.d.Description,
                                    DepartmentId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.DepartmentId,
                                    DateAction = temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.DateReferred,
                                    SeenCount = seens.Where(x=>x.TrackingId == temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.Id).Count(),
                                    CallCount = activities.Where(x=>x.Code == temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.Code && x.Status == _status.Value.CALLING).Count(),
                                    FeedbackCount = feedbacks.Where(x=>x.Code == temp6.temp5.temp4.temp3.temp2.temp1.temp0.t.Code).Count()
                                }
                        );
                    /*(department, depId) => new IncomingViewModel()
                    {
                        Pregnant = department.tracking.refMd.facility.tracking.Type.Equals("pregnant"),
                        TrackingId = department.tracking.refMd.facility.tracking.Id,
                        Code = department.tracking.refMd.facility.tracking.Code,
                        PatientName = department.patient.GetFullName(),
                        PatientSex = department.patient.Sex,
                        PatientAge = department.patient.Dob.ComputeAge(),
                        Status = department.tracking.refMd.facility.tracking.Status,
                        ReferringMd = department.tracking.user.GetMDFullName().NameToUpper(),
                        ActionMd = "",
                        SeenCount = 0,//seens.Where(x=>x.TrackingId == muncity.province.patients.department.tracking.refMd.facility.tracking.Id).Count(),
                        CallCount = 0,//activities.Where(x => x.Code.Equals(muncity.province.patients.department.tracking.refMd.facility.tracking.Code) && x.Status.Equals(_status.Value.CALLING)).Count(),
                        FeedbackCount = 0,//feedbacks.Where(x => x.Code.Equals(muncity.province.patients.department.tracking.refMd.facility.tracking.Code)).Count(),//feedback
                        DateAction = default, //activities.OrderByDescending(x => x.DateReferred).Where(x => x.Code.Equals(department.tracking.refMd.facility.tracking.Code)).First().DateReferred,
                        ReferredFrom = department.tracking.refMd.facility.from.Name,
                        ReferredFromId = department.tracking.refMd.facility.tracking.ReferredFrom,
                        ReferredTo = department.tracking.refMd.to.Name,
                        ReferredToId = department.tracking.refMd.facility.tracking.ReferredTo,
                        Department = depId.Description,
                        DepartmentId = department.tracking.refMd.facility.tracking.DepartmentId
                    });*/

            #endregion
            if (department != null)
            {
                incoming = incoming.Where(x => x.DepartmentId.Equals(department));
                ViewBag.Departments = new SelectList(faciliyDepartment, "DepartmentId", "DepartmentName", department);
                ViewBag.SelectedDepartment = department.ToString();
            }

            if (!string.IsNullOrEmpty(search))
            {
                incoming = incoming.Where(s => s.Code.Equals(search) || s.Fname.ToUpper().Contains(search) || s.Lname.ToUpper().Contains(search));
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status.Equals(_status.Value.ACCEPTED))
                    incoming = incoming.Where(x => x.Status != _status.Value.REFERRED);
                else
                    incoming = incoming.Where(x => x.Status.Equals(_status.Value.REFERRED));
                ViewBag.IncomingStatus = new SelectList(ListContainer.IncomingStatus, "Key", "Value", status);
                ViewBag.SelectedStatus = status;
            }

            int size = 5;

            ViewBag.Total = incoming.Count();
            return View(await PaginatedList<IncomingViewModel>.CreateAsync(incoming.OrderByDescending(x => x.DateAction), page ?? 1, size));
        }
        #endregion
        #region REFERRED
        public async Task<IActionResult> Referred(string search, string dateRange, int? facilityId, string status, int? page)
        {
            #region Initialize variables
            if (!string.IsNullOrEmpty(dateRange))
            {
                StartDate = DateTime.Parse(dateRange.Substring(0, dateRange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(dateRange.Substring(dateRange.LastIndexOf(" ")).Trim());
            }
            else
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                EndDate = new DateTime(DateTime.Now.Year, 12, 31, 0, 0, 0);
            }

            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;
            #endregion
            #region Query
            var seens = _context.Seen;
            var issues = _context.Issue;
            var activities = _context.Activity.Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var feedbacks = _context.Feedback.Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var facilities = _context.Facility.Where(x => x.Id != UserFacility);
            var referred = _context.Tracking.OrderByDescending(x=>x.UpdatedAt)
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
            #endregion
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            ViewBag.ListStatus = new SelectList(ListContainer.ListStatus, "Key", "Value");


            if (!string.IsNullOrEmpty(search))
            {
                referred = referred.Where(x => x.Code == search || x.Fname.ToUpper().Contains(search) || x.Lname.ToUpper().Contains(search));
                ViewBag.Total = referred.Count();
                ViewBag.CurrentSearch = search;
            }

            if (!string.IsNullOrEmpty(status))
            {
                referred = referred.Where(x => x.Status == status);
                ViewBag.Total = referred.Count();
                ViewBag.ListStatus = new SelectList(ListContainer.ListStatus, "Key", "Value", status);
                ViewBag.SelectedStatus = status;
            }

            if (facilityId != null)
            {
                referred = referred.Where(x => x.ReferredToId == facilityId);
                ViewBag.Total = referred.Count();
                ViewBag.Facilities = new SelectList(facilities, "Id", "Name", facilityId);
                ViewBag.SelectedFacility = facilityId.ToString();
            }

            int size = 3;

            return View(await PaginatedList<ReferredViewModel>.CreateAsync(referred, page ?? 1, size));
        }
        #endregion

        #region View Patients Socket Components

        [HttpPost]
        public IActionResult GetUserInformation(string user)
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

        [HttpPost]
        public IActionResult GetPatientInformation(string patient)
        {
            RequestModel Request = new RequestModel();
            if (!string.IsNullOrEmpty(patient))
            {
                var DeserializePatientInformation = JsonConvert.DeserializeObject<NotificationModel>(patient);
                Console.WriteLine();

                var GetPatientInfo = _context.Tracking
                    .Join( // GET PATIENT ID
                        _context.Patients,
                        tracking => tracking.PatientId,
                        patient => patient.Id,
                        (tracking, patient) => new { tracking, patient })

                    .Join( // GET NAME OF REFERRING MD
                        _context.Users,
                        pr => pr.tracking.ReferringMd,
                        referringuser => referringuser.Id,
                        (referringmdId, referringuser) => new { referringmdId, referringuser })

                    .Join( // GET NAME OF ACTION MD
                        _context.Users,
                        pa => pa.referringmdId.tracking.ActionMd,
                        actionmdUser => actionmdUser.Id,
                        (actionmdId, actionmdUser) => new { actionmdId, actionmdUser })

                    .Join( // GET FACILITY OF ACTION MD
                        _context.Facility,
                        pactionmd => pactionmd.actionmdUser.FacilityId,
                        actionmdfacility => actionmdfacility.Id,
                        (actionmdfacility, pactionmd) => new { actionmdfacility, pactionmd })

                    .Join( // GET FACILITY OF REFERRING MD
                        _context.Facility,
                        preferringmd => preferringmd.actionmdfacility.actionmdId.referringuser.FacilityId,
                        referringfacility => referringfacility.Id,
                        (referring_facility, referring_md) => new { referring_facility, referring_md})

                    .Where(patientcode => patientcode.referring_facility.actionmdfacility.actionmdId.referringmdId.tracking.Code == DeserializePatientInformation.PatientCode)
                    .Select(notification => new NotificationModel
                    {
                        PatientCode = DeserializePatientInformation.PatientCode,
                        PatientName = notification.referring_facility.actionmdfacility.actionmdId.referringmdId.patient.GetFullName(),
                        TrackStatus = DeserializePatientInformation.TrackStatus,
                        ReferringDoctor = notification.referring_facility.actionmdfacility.actionmdId.referringuser.GetMDFullName(),
                        ReferringDoctorFacility = notification.referring_md.Name,
                        ReferredDoctor = notification.referring_facility.actionmdfacility.actionmdUser.GetMDFullName(),
                        ReferredDoctorFacility = notification.referring_facility.pactionmd.Name,
                        UpdatedAt = DeserializePatientInformation.UpdatedAt,
                    })
                    .FirstOrDefault();

                if (GetPatientInfo != null)
                {
                    Request = new RequestModel
                    {
                        InformationType = Constants.NOTIFICATION_TAG,
                        PatientNotification = GetPatientInfo,
                    };
                    return Json(Request);
                }
                Console.WriteLine();
            }
            return Json(Request);
        }

        //public NotificationModel GetFinalStatus(NotificationModel patient, string status)
        //{
        //    var _patient = patient;
        //    switch (status)
        //    {
        //        case "referred":
        //            _patient.SeenStatus = 1; 
        //                break;

        //        case "seen":
        //            _patient.AcceptedStatus = 1;
        //            break;

        //        case "accepted":
        //            _patient.ArrivedStatus = 1;
        //            break;

        //        case "arrived":
        //            _patient.AdmittedStatus = 1;
        //            break;

        //        case "admitted":
        //            _patient.DischargedStatus = 1;
        //            break;

        //        case "discharged":
        //            _patient.DischargedStatus = 2;
        //            break;
        //    }
        //    return _patient;
        //}

        #endregion

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