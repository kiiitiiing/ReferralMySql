﻿using System;
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

namespace Referral2.Controllers
{
    //[Authorize(Policy = "Doctor")]
    public class ViewPatientsController : Controller
    {
        public const string SessionKeySearch = "_search";
        public const string SessionKeyCode = "_code";
        public const string SessionKeyDateRange = "_dateRange";
        public const string SessionKeyStatus = "_status";
        public const string SessionKeyFacility = "_facility";
        public const string SessionKeyDepartment = "_department";
        private readonly ReferralDbContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;

        public ViewPatientsController(ReferralDbContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
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

        //GET: List Patients
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



            var patients = _context.Patient
            .Select(x => new PatientsViewModel
            {
                PatientId = x.Id,
                PatientName = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                PatientSex = x.Sex,
                PatientAge = x.DateOfBirth.ComputeAge(),
                DateofBirth = x.DateOfBirth,
                MuncityId = x.MuncityId,
                Muncity = x.Muncity == null ? "" : x.Muncity.Description,
                BarangayId = x.BarangayId,
                Barangay = x.Barangay == null ? "" : x.Barangay.Description,
                CreatedAt = (DateTime)x.CreatedAt
            })
            .Where(x => x.PatientName.ToUpper().Contains(name) &&
            x.MuncityId.Equals(muncityId) &&
            x.BarangayId.Equals(barangayId));


            int size = 15;


            return View(await PaginatedList<PatientsViewModel>.CreateAsync(patients.OrderBy(x => x.PatientName), page ?? 1, size));
        }

        //GET: Accepted patients
        public async Task<IActionResult> Accepted(string search, string dateRange, int? page)
        {
            #region Variable initialize
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
            var accepted = _context.Tracking
                .Where(x => x.ReferredTo == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Where(x => x.Status == _status.Value.ACCEPTED || x.Status == _status.Value.ARRIVED || x.Status == _status.Value.ADMITTED)
                .Select(x => new AcceptedViewModel
                {
                    ReferredTo = (int)x.ReferredTo,
                    ReferringFacility = x.ReferredFromNavigation.Name,
                    Type = x.Type == "normal" ? "Non-Pregnant" : "Pregnant",
                    PatientName = x.Patient.FirstName + " " + x.Patient.MiddleName + " " + x.Patient.LastName,
                    PatientCode = x.Code,
                    DateAction = x.DateAccepted,
                    Status = _context.Activity.Where(c => c.Code == x.Code).OrderByDescending(x => x.DateReferred).FirstOrDefault().Status
                });
            #endregion

            ViewBag.Total = accepted.Count();

            if (!string.IsNullOrEmpty(search))
            {
                accepted = accepted.Where(s => s.PatientCode.Equals(search) || s.PatientName.Contains(search));
                ViewBag.Total = accepted.Count();
            }
            else
            {
                ViewBag.Total = accepted.Count();
            }


            int size = 15;

            return View(await PaginatedList<AcceptedViewModel>.CreateAsync(accepted.OrderByDescending(x => x.DateAction), page ?? 1, size));
        }

        //GET: Dischagred Patients
        public async Task<IActionResult> Discharged(string search, string dateRange, int? page)
        {
            #region Variable initialize
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
            var discharge = _context.Tracking
                .Where(x => x.ReferredTo == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Where(x => x.Status == _status.Value.DISCHARGED || x.Status == _status.Value.TRANSFERRED)
                .Select(x => new DischargedViewModel
                {
                    ReferringFacility = x.ReferredFromNavigation.Name,
                    Type = x.Type == "normal" ? "Non-Pregnant" : "Pregnant",
                    PatientName = x.Patient.FirstName + " " + x.Patient.MiddleName + " " + x.Patient.LastName,
                    Code = x.Code,
                    DateAction = _context.Activity.Where(c => c.Code == x.Code && c.Status == x.Status).FirstOrDefault().DateReferred,
                    Status = _context.Activity.Where(c => c.Code == x.Code && c.Status == x.Status).FirstOrDefault().Status
                });
            #endregion

            ViewBag.Total = discharge.Count();

            if (!string.IsNullOrEmpty(search))
            {
                discharge = discharge.Where(s => s.Code.Contains(search) || s.PatientName.Contains(search));
                ViewBag.Total = discharge.Count();
            }

            int size = 15;

            return View(await PaginatedList<DischargedViewModel>.CreateAsync(discharge.OrderByDescending(x => x.DateAction), page ?? 1, size));
        }

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
                .Select(x => new CancelledViewModel
                {
                    ReferringFacility = x.ReferredFromNavigation.Name,
                    PatientType = x.Type == "pregnant" ? "Pregnant" : "Non-Pregnant",
                    PatientName = x.Patient.FirstName + " " + x.Patient.MiddleName + " " + x.Patient.LastName,
                    PatientCode = x.Code,
                    DateCancelled = _context.Activity.Where(c => c.Code == x.Code && c.Status == x.Status).FirstOrDefault().DateReferred,
                    ReasonCancelled = _context.Activity.Where(c => c.Code == x.Code && c.Status == x.Status).FirstOrDefault().Remarks
                })
                .Where(x => x.DateCancelled >= StartDate && x.DateCancelled <= EndDate);
            #endregion

            if (!string.IsNullOrEmpty(search))
            {
                cancelled = cancelled.Where(s => s.PatientCode.Contains(search) || s.PatientName.Contains(search));
            }

            int size = 15;
            ViewBag.Total = cancelled.Count();
            return View(await PaginatedList<CancelledViewModel>.CreateAsync(cancelled.OrderByDescending(x => x.DateCancelled), page ?? 1, size));
        }

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
                .Where(x => x.Status == _status.Value.REFERRED || x.Status == _status.Value.SEEN)
                .Where(x => DateTime.Now > x.DateReferred.AddDays(3))
                .Select(x => new ArchivedViewModel
                {
                    ReferringFacility = x.ReferredFromNavigation.Name,
                    Type = x.Type == "normal" ? "Non-Pregnant" : "Pregnant",
                    PatientName = x.Patient.FirstName + " " + x.Patient.MiddleName + " " + x.Patient.LastName,
                    Code = x.Code,
                    DateArchive = x.DateReferred.AddDays(3),
                    Reason = _context.Activity.Where(c => c.Code == x.Code).FirstOrDefault().Remarks
                });
            #endregion

            ViewBag.Total = archivedPatients.Count();

            if (!string.IsNullOrEmpty(search))
            {
                archivedPatients = archivedPatients.Where(s => s.Code.Equals(search) || s.PatientName.Contains(search));
                ViewBag.Total = archivedPatients.Count();
            }

            int pageSize = 15;

            return View(await PaginatedList<ArchivedViewModel>.CreateAsync(archivedPatients.OrderByDescending(x => x.DateArchive), page ?? 1, pageSize));

        }

        //GET: Track patients
        public async Task<IActionResult> Track(string code)
        {

            ViewBag.CurrentCode = code;
            var activities = _context.Activity;
            var feedbacks = _context.Feedback;
            var facilities = _context.Facility.Where(x => x.Id != UserFacility);
            var track = await _context.Tracking
                .Include(x => x.ReferredToNavigation)
                .Include(x => x.ReferredFromNavigation)
                .Include(x => x.Patient).ThenInclude(x => x.Barangay)
                .Include(x => x.Patient).ThenInclude(x => x.Muncity)
                .Include(x => x.Patient).ThenInclude(x => x.Province)
                .Where(x => x.Code.Equals(code))
                .Select(t => new ReferredViewModel
                {
                    PatientId = t.PatientId,
                    PatientName = t.Patient.FirstName + " " + t.Patient.MiddleName + " " + t.Patient.LastName,
                    PatientSex = t.Patient.Sex,
                    PatientAge = t.Patient.DateOfBirth.ComputeAge(),
                    PatientAddress = t.Patient.Barangay.Description.CheckAddress() + t.Patient.Muncity.Description.CheckAddress() + t.Patient.Province.Description,
                    ReferredBy = GlobalFunctions.GetMDFullName(t.ReferringMdNavigation),
                    ReferredTo = GlobalFunctions.GetMDFullName(t.ActionMdNavigation),
                    ReferredToId = t.ReferredTo,
                    TrackingId = t.Id,
                    SeenCount = t.Seen.Count(),
                    CallerCount = activities.Where(x => x.Code.Equals(t.Code) && x.Status.Equals(_status.Value.CALLING)).Count(),
                    IssueCount = _context.Issue.Where(x => x.TrackingId.Equals(t.Id)).Count(),
                    ReCoCount = feedbacks.Where(x => x.Code.Equals(t.Code)).Count(),
                    Travel = string.IsNullOrEmpty(t.Transportation),
                    Code = t.Code,
                    Status = t.Status,
                    Pregnant = t.Type.Equals("pregnant"),
                    Seen = t.DateSeen != default,
                    Walkin = t.WalkIn.Equals("yes"),
                    UpdatedAt = t.DateReferred,
                    Activities = activities.Where(x => x.Code.Equals(t.Code) && x.Status != _status.Value.CALLING).OrderByDescending(x => x.CreatedAt)
                        .Select(i => new ActivityLess
                        {
                            Status = i.Status,
                            DateAction = i.DateReferred.ToString("MMM dd, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                            FacilityFrom = i.ReferredFromNavigation == null ? "" : i.ReferredFromNavigation.Name,
                            FacilityFromContact = i.ReferredFromNavigation == null ? "" : i.ReferredFromNavigation.Contact,
                            FacilityTo = t.ReferredToNavigation.Name,
                            PatientName = i.Patient.FirstName + " " + i.Patient.MiddleName + " " + i.Patient.LastName,
                            ActionMd = i.ActionMdNavigation.GetMDFullName(),
                            ReferringMd = i.ReferringMdNavigation.GetMDFullName(),
                            Remarks = i.Remarks
                        })
                })
                .OrderByDescending(x => x.UpdatedAt)
                .FirstOrDefaultAsync();


            if (track != null)
            {
                ViewBag.Code = track.Code;
            }


            return View(track);
        }


        //GET: Incoming patients
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

            var faciliyDepartment = _context.User
                .Include(x => x.Department)
                .Where(x => x.FacilityId.Equals(UserFacility) && x.Level.Equals(_roles.Value.DOCTOR) && x.DepartmentId != null)
                .Select(y => y.Department)
                .Distinct()
                .Select(x => new SelectDepartment
                {
                    DepartmentId = (int)x.Id,
                    DepartmentName = x.Description
                });

            ViewBag.Departments = new SelectList(faciliyDepartment, "DepartmentId", "DepartmentName");
            ViewBag.StartDate = StartDate.Date.ToString("yyyy/MM/dd");
            ViewBag.EndDate = EndDate.Date.ToString("yyyy/MM/dd");
            ViewBag.IncomingStatus = new SelectList(ListContainer.IncomingStatus, "Key", "Value");
            #endregion
            #region Query
            var activities = _context
                .Activity.Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);

            var incoming = _context.Tracking
                .Where(t => t.DateReferred >= StartDate && t.DateReferred <= EndDate)
                .Where(t => t.ReferredTo == UserFacility)
                .Select(t => new IncomingViewModel()
                {
                    Pregnant = t.Type.Equals("pregnant"),
                    TrackingId = t.Id,
                    Code = t.Code,
                    PatientName = t.Patient.GetFullName().NameToUpper(),
                    PatientSex = t.Patient.Sex,
                    PatientAge = t.Patient.DateOfBirth.ComputeAge(),
                    Status = t.Status,
                    ReferringMd = t.ReferringMdNavigation.GetMDFullName().NameToUpper(),
                    ActionMd = activities.OrderByDescending(x => x.DateReferred).Where(x => x.Status == t.Status && x.Code == t.Code).First().ActionMdNavigation.GetMDFullName().NameToUpper(),
                    SeenCount = t.Seen.Count(),//Seen
                    CallCount = _context.Activity.Where(x => x.Code.Equals(t.Code) && x.Status.Equals(_status.Value.CALLING)).Count(),
                    FeedbackCount = _context.Feedback.Where(x => x.Code.Equals(t.Code)).Count(),//feedback
                    DateAction = activities.OrderByDescending(x => x.DateReferred).Where(x => x.Code == t.Code).First().DateReferred,
                    ReferredFrom = t.ReferredFromNavigation.Name,
                    ReferredFromId = (int)t.ReferredFrom,
                    ReferredTo = t.ReferredToNavigation.Name,
                    ReferredToId = (int)t.ReferredTo,
                    Department = t.Department.Description,
                    DepartmentId = (int)t.DepartmentId
                });

            #endregion

            if (department != null)
            {
                incoming = incoming.Where(x => x.DepartmentId.Equals(department));
                ViewBag.Departments = new SelectList(faciliyDepartment, "DepartmentId", "DepartmentName", department);
                ViewBag.SelectedDepartment = department.ToString();
            }

            if (!string.IsNullOrEmpty(search))
            {
                incoming = incoming.Where(s => s.Code.Equals(search));
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
        // GET: Referred
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
            var activities = _context.Activity.Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var feedbacks = _context.Feedback.Where(x => x.CreatedAt >= StartDate && x.CreatedAt <= EndDate);
            var facilities = _context.Facility.Where(x => x.Id != UserFacility);
            var referred = _context.Tracking
                .Include(x=>x.Patient)
                .Where(x => x.ReferredFrom == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                .Select(t => new ReferredViewModel
                {
                    PatientId = t.PatientId,
                    PatientName = t.Patient.FirstName + " " + t.Patient.MiddleName + " " + t.Patient.LastName,
                    PatientSex = t.Patient.Sex,
                    PatientAge = t.Patient.DateOfBirth.ComputeAge(),
                    PatientAddress = /*t.Patient.Barangay.Description+", "+(t.Patient.Barangay.Muncity.Description)+", "+t.Patient.Province.Description, //*/t.Patient.GetAddress(),
                    ReferredBy = GlobalFunctions.GetMDFullName(t.ReferringMdNavigation),
                    ReferredTo = GlobalFunctions.GetMDFullName(t.ActionMdNavigation),
                    ReferredToId = t.ReferredTo,
                    TrackingId = t.Id,
                    SeenCount = _context.Seen.Where(x => x.TrackingId.Equals(t.Id)).Count(),
                    CallerCount = activities.Where(x => x.Code.Equals(t.Code) && x.Status.Equals(_status.Value.CALLING)).Count(),
                    IssueCount = _context.Issue.Where(x => x.TrackingId.Equals(t.Id)).Count(),
                    ReCoCount = feedbacks.Where(x => x.Code.Equals(t.Code)).Count(),
                    Travel = string.IsNullOrEmpty(t.Transportation),
                    Code = t.Code,
                    Status = t.Status,
                    Pregnant = t.Type.Equals("pregnant"),
                    Seen = t.DateSeen != default,
                    Walkin = t.WalkIn.Equals("yes"),
                    UpdatedAt = t.UpdatedAt,
                    Activities = activities.Where(x => x.Code.Equals(t.Code)).OrderByDescending(x => x.CreatedAt)
                        .Select(i => new ActivityLess
                        {
                            Status = i.Status,
                            DateAction = i.DateReferred.ToString("MMM dd, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                            FacilityFrom = i.ReferredFromNavigation == null ? "" : i.ReferredFromNavigation.Name,
                            FacilityFromContact = i.ReferredFromNavigation == null ? "" : i.ReferredFromNavigation.Contact,
                            FacilityTo = t.ReferredToNavigation.Name,
                            PatientName = i.Patient.FirstName + " " + i.Patient.MiddleName + " " + i.Patient.LastName,
                            ActionMd = GlobalFunctions.GetMDFullName(i.ActionMdNavigation),
                            ReferringMd = GlobalFunctions.GetMDFullName(i.ReferringMdNavigation),
                            Remarks = i.Remarks
                        })
                });
            #endregion
            ViewBag.Total = referred.Count();
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            ViewBag.ListStatus = new SelectList(ListContainer.ListStatus, "Key", "Value");


            if (!string.IsNullOrEmpty(search))
            {
                referred = referred.Where(x => x.Code == search || x.PatientName.Contains(search));
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

            return View(await PaginatedList<ReferredViewModel>.CreateAsync(referred.OrderByDescending(x => x.UpdatedAt), page ?? 1, size));
        }

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
                        _context.Patient,
                        tracking => tracking.PatientId,
                        patient => patient.Id,
                        (tracking, patient) => new { tracking, patient })

                    .Join( // GET NAME OF REFERRING MD
                        _context.User,
                        pr => pr.tracking.ReferringMd,
                        referringuser => referringuser.Id,
                        (referringmdId, referringuser) => new { referringmdId, referringuser })

                    .Join( // GET NAME OF ACTION MD
                        _context.User,
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