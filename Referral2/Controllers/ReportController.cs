using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.MyModels;
using Referral2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using MoreLinq.Extensions;
using System.Text;
using DinkToPdf.Contracts;
using DinkToPdf;
using System.IO;
using Referral2.Services;
using Referral2.MyData;
using Referral2.Models.ViewModels.Forms;
using SQLitePCL;

namespace Referral2.Controllers
{
    [Authorize(Policy = "Doctor")]
    public class ReportController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;
        private IConverter _converter;


        public ReportController(MySqlReferralContext context, IConverter converter, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _converter = converter;
            _roles = roles;
            _status = status;
        }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        #region INCOMING REPORT
        [HttpGet]
        public async Task<IActionResult> IncomingReport(string daterange, int? page, int? facility, int? department)
        {
            var currentDate = DateTime.Now;
            if(string.IsNullOrEmpty(daterange))
            {
                StartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                EndDate = StartDate.AddMonths(1).AddDays(-1);
            }
            else
            {
                StartDate = DateTime.Parse(daterange.Substring(0, daterange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(daterange.Substring(daterange.LastIndexOf(" ")).Trim());
            }
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;

            int size = 20;

            var activities = _context.Activity
                .Where(x => x.DateReferred >= StartDate && x.DateReferred <= EndDate);
            var tracking = from track in _context.Tracking.Where(x => x.ReferredTo == UserFacility && x.DateReferred >= StartDate && x.DateReferred <= EndDate)
                           join refFrom in _context.Facility on track.ReferredFrom equals refFrom.Id
                           select new IncomingReportViewModel
                           {
                               ReferredTo = track.ReferredTo,
                               ReferredFrom = track.ReferredFrom,
                               Department = track.DepartmentId,
                               Code = track.Code,
                               Facility = refFrom.Name,
                               DateReferred = track.DateReferred,
                               DateAdmitted = activities.First(x => x.Code == track.Code && x.Status.Equals(_status.Value.ADMITTED)).DateReferred,
                               DateArrived = activities.First(x => x.Code == track.Code && x.Status.Equals(_status.Value.ARRIVED)).DateReferred,
                               DateDischarged = activities.First(x => x.Code == track.Code && x.Status.Equals(_status.Value.DISCHARGED)).DateReferred,
                               DateCancelled = activities.First(x => x.Code == track.Code && x.Status.Equals(_status.Value.CANCELLED)).DateReferred,
                               DateTransferred = activities.First(x => x.Code == track.Code && x.Status.Equals(_status.Value.TRANSFERRED)).DateReferred
                           };

            var facilities = _context.Facility.Where(x => x.Id != UserFacility).ToList();
            var departments = await AvailableDepartments(UserFacility);
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.Total = tracking.Count();


            if (facility != null)
            {
                tracking = tracking.Where(x => x.ReferredFrom.Equals(facility));
                ViewBag.Facilities = new SelectList(facilities, "Id", "Name", facility);
                ViewBag.Total = tracking.Count();
            }
            if(department != null)
            {
                tracking = tracking.Where(x => x.Department.Equals(department));
                ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName", department);
                ViewBag.Total = tracking.Count();
            }

            return View(await PaginatedList<IncomingReportViewModel>.CreateAsync(tracking.OrderByDescending(x=>x.DateReferred), page ?? 1, size));
        }
        #endregion
        #region OUTGOING REPORT
        [HttpGet]
        public async Task<IActionResult> OutgoingReport(string daterange, int? page, int? facility, int? department)
        {
            var currentDate = DateTime.Now;
            if (string.IsNullOrEmpty(daterange))
            {
                StartDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                EndDate = StartDate.AddMonths(1).AddDays(-1);
            }
            else
            {
                StartDate = DateTime.Parse(daterange.Substring(0, daterange.IndexOf(" ") + 1).Trim());
                EndDate = DateTime.Parse(daterange.Substring(daterange.LastIndexOf(" ")).Trim());
            }
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;

            int size = 20;

            var outgoing = _context.Tracking
                .Where(x => x.ReferredFrom == UserFacility && x.DateReferred>= StartDate && x.DateReferred <= EndDate)
                .Select(t => new OutgoingReportViewModel
                {
                    Department = t.DepartmentId,
                    ReferredTo = t.ReferredTo,
                    ReferredFrom = t.ReferredFrom,
                    Code = t.Code,
                    DateReferred = t.DateReferred,
                    Seen = t.DateSeen == default ? default : t.DateSeen.Subtract(t.DateReferred).TotalMinutes,
                    Accepted = t.DateAccepted == default ? 0 : t.DateAccepted.Subtract(t.DateReferred).TotalMinutes,
                    Arrived = t.DateArrived == default ? 0 : t.DateArrived.Subtract(t.DateReferred).TotalMinutes,
                    Redirected = t.DateTransferred == default ? 0 : t.DateTransferred.Subtract(t.DateReferred).TotalMinutes,
                    NoAction = t.DateSeen == default ? 0 : t.DateReferred.Subtract(DateTime.Now).TotalMinutes
                });

            var facilities = _context.Facility
                .Where(x=>x.Id != UserFacility);
            var departments = await AvailableDepartments(UserFacility);
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.Total = outgoing.Count();


            if (facility != null)
            {
                outgoing = outgoing.Where(x => x.ReferredTo.Equals(facility));
                ViewBag.Facilities = new SelectList(facilities, "Id", "Name", facility);
                ViewBag.Total = outgoing.Count();
            }
            if (department != null)
            {
                outgoing = outgoing.Where(x => x.Department.Equals(department));
                ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName", department);
                ViewBag.Total = outgoing.Count();
            }

            return View(await PaginatedList<OutgoingReportViewModel>.CreateAsync(outgoing.OrderBy(x=>x.Code), page ?? 1, size));
        }
        #endregion
        #region NORMAL FORM PDF
        public async Task<IActionResult> NormalFormPdf(string code)
        {
            var form = from patForm in _context.PatientForm.Where(x => x.Code == code)
                       join patient in _context.Patients on patForm.PatientId equals patient.Id
                       join patBrgy in _context.Barangay on patient.Brgy equals patBrgy.Id into PBRGY
                       from pBarangay in PBRGY.DefaultIfEmpty()
                       join patMunct in _context.Muncity on patient.Muncity equals patMunct.Id into PMUNCT
                       from pMuncity in PMUNCT.DefaultIfEmpty()
                       join pProvince in _context.Province on patient.Province equals pProvince.Id
                       join refFrom in _context.Facility on patForm.ReferringFacility equals refFrom.Id
                       join fromBrgy in _context.Barangay on refFrom.Brgy equals fromBrgy.Id into FBRGY
                       from fromBarangay in FBRGY.DefaultIfEmpty()
                       join fromMunct in _context.Muncity on refFrom.Muncity equals fromMunct.Id into FMUNCT
                       from fromMuncity in FMUNCT.DefaultIfEmpty()
                       join fromProvince in _context.Province on refFrom.Province equals fromProvince.Id
                       join refTo in _context.Facility on patForm.ReferredTo equals refTo.Id
                       join toBrgy in _context.Barangay on refFrom.Brgy equals toBrgy.Id into TBRGY
                       from toBarangay in TBRGY.DefaultIfEmpty()
                       join toMunct in _context.Muncity on refFrom.Muncity equals toMunct.Id into TMUNCT
                       from toMuncity in TMUNCT.DefaultIfEmpty()
                       join toProvince in _context.Province on refFrom.Province equals toProvince.Id
                       join refMd in _context.Users on patForm.ReferringMd equals refMd.Id into REFMD
                       from referringMd in REFMD.DefaultIfEmpty()
                       join refdMd in _context.Users on patForm.ReferredMd equals refdMd.Id into REFDMD
                       from referredMd in REFDMD.DefaultIfEmpty()
                       join dep in _context.Department on patForm.DepartmentId equals dep.Id into DEP
                       from department in DEP.DefaultIfEmpty()
                       select new PatientFormModel
                       {
                           UniqueId = patForm.UniqueId,
                           Code = patForm.Code,
                           ReferringFacility = patForm.ReferringFacility,
                           ReferringFacilityName = refFrom.Name,
                           ReferringFacilityAddress = GlobalFunctions.GetAddress(refFrom.Address, fromBarangay.Description, fromMuncity.Description, fromProvince.Description),
                           ReferringFacilityContact = refFrom.Contact,
                           ReferredTo = patForm.ReferredTo,
                           ReferredToName = refTo.Name,
                           ReferredToAddress = GlobalFunctions.GetAddress(refTo.Address, toBarangay.Description, toMuncity.Description, toProvince.Description),
                           ReferredToContact = refTo.Contact,
                           DepartmentId = patForm.DepartmentId,
                           Department = department.Description,
                           CovidNumber = patForm.CovidNumber,
                           ReferClinicalStatus = patForm.ReferClinicalStatus,
                           ReferSurCategory = patForm.ReferSurCategory,
                           DisClinicalStatus = patForm.DisClinicalStatus,
                           DisSurCategory = patForm.DisSurCategory,
                           TimeReferred = patForm.TimeReferred,
                           TimeTransferred = patForm.TimeTransferred,
                           PatientId = patForm.PatientId,
                           PatientName = "".GetFullName(patient.Fname, patient.Mname, patient.Lname),
                           PatientAddress = GlobalFunctions.GetAddress(pBarangay.Description, pMuncity.Description, pProvince.Description),
                           PatientSex = patient.Sex,
                           PatientDob = patient.Dob,
                           PatientStatus = patient.CivilStatus,
                           PhicId = patient.PhicId,
                           PhicStatus = patient.PhicStatus,
                           CaseSummary = patForm.CaseSummary,
                           RecoSummary = patForm.RecoSummary,
                           Diagnosis = patForm.Diagnosis,
                           Reason = patForm.Reason,
                           ReferringMd = patForm.ReferringMd,
                           ReferringMdName = referringMd.Level.GetFullName(referringMd.Fname, referringMd.Mname, referringMd.Lname),
                           ReferringMdContact = referringMd.Contact,
                           ReferredMd = patForm.ReferredMd,
                           ReferredMdName = referredMd.Level.GetFullName(referredMd.Fname, referredMd.Mname, referredMd.Lname),
                           ReferredMdContact = referredMd.Contact,
                           CreatedAt = patForm.CreatedAt.Value.DateTime,
                           UpdatedAt = patForm.UpdatedAt.Value.DateTime
                       };


            var patientForm = await form.FirstAsync();

            var file = SetPDF(patientForm);
            return File(file, "application/pdf");
        }
        #endregion

        public async Task<IActionResult> PregnantFromPdf(string code)
        {
            var form = from patForm in _context.PregnantForm.Where(x => x.Code == code)
                       join patient in _context.Patients on patForm.PatientWomanId equals patient.Id
                       join bb in _context.Patients on patForm.PatientBabyId equals bb.Id into BB
                       from baby in BB.DefaultIfEmpty()
                       join bbb in _context.Baby on baby.Id equals bbb.Id into BBB
                       from babyInfo in BBB.DefaultIfEmpty()
                       join patBrgy in _context.Barangay on patient.Brgy equals patBrgy.Id into PBRGY
                       from pBarangay in PBRGY.DefaultIfEmpty()
                       join patMunct in _context.Muncity on patient.Muncity equals patMunct.Id into PMUNCT
                       from pMuncity in PMUNCT.DefaultIfEmpty()
                       join pProvince in _context.Province on patient.Province equals pProvince.Id
                       join refFrom in _context.Facility on patForm.ReferringFacility equals refFrom.Id
                       join fromBrgy in _context.Barangay on refFrom.Brgy equals fromBrgy.Id into FBRGY
                       from fromBarangay in FBRGY.DefaultIfEmpty()
                       join fromMunct in _context.Muncity on refFrom.Muncity equals fromMunct.Id into FMUNCT
                       from fromMuncity in FMUNCT.DefaultIfEmpty()
                       join fromProvince in _context.Province on refFrom.Province equals fromProvince.Id
                       join refTo in _context.Facility on patForm.ReferredTo equals refTo.Id
                       join toBrgy in _context.Barangay on refFrom.Brgy equals toBrgy.Id into TBRGY
                       from toBarangay in TBRGY.DefaultIfEmpty()
                       join toMunct in _context.Muncity on refFrom.Muncity equals toMunct.Id into TMUNCT
                       from toMuncity in TMUNCT.DefaultIfEmpty()
                       join toProvince in _context.Province on refFrom.Province equals toProvince.Id
                       join refMd in _context.Users on patForm.ReferredBy equals refMd.Id into REFMD
                       from referringMd in REFMD.DefaultIfEmpty()
                       join dep in _context.Department on patForm.DepartmentId equals dep.Id into DEP
                       from department in DEP.DefaultIfEmpty()
                       select new PregnantFormModel
                       {
                           UniqueId = patForm.UniqueId,
                           Code = patForm.Code,
                           ReferringFacility = patForm.ReferringFacility,
                           ReferringFacilityName = refFrom.Name,
                           ReferringFacilityAddress = GlobalFunctions.GetAddress(refFrom.Address, fromBarangay.Description, fromMuncity.Description, fromProvince.Description),
                           ReferringFacilityContact = refFrom.Contact,
                           ReferredTo = patForm.ReferredTo,
                           ReferredToName = refTo.Name,
                           ReferredToAddress = GlobalFunctions.GetAddress(refTo.Address, toBarangay.Description, toMuncity.Description, toProvince.Description),
                           ReferredToContact = refTo.Contact,
                           DepartmentId = patForm.DepartmentId,
                           Department = department.Description,
                           TimeReferred = default,
                           TimeTransferred = default,
                           ReferredDate = patForm.ReferredDate,
                           ArrivalDate = patForm.ArrivalDate,
                           PatientId = patForm.PatientWomanId,
                           PatientName = "".GetFullName(patient.Fname, patient.Mname, patient.Lname),
                           PatientAddress = GlobalFunctions.GetAddress(pBarangay.Description, pMuncity.Description, pProvince.Description),
                           PatientSex = patient.Sex,
                           WomanBeforeGivenTime = patForm.WomanBeforeGivenTime,
                           WomanBeforeTreatment = patForm.WomanBeforeTreatment,
                           WomanDuringTransport = patForm.WomanDuringTransport,
                           WomanInformationGiven = patForm.WomanInformationGiven,
                           WomanMajorFindings = patForm.WomanMajorFindings,
                           WomanReason = patForm.WomanReason,
                           WomanTransportGivenTime = patForm.WomanTransportGivenTime,
                           HealthWorker = patForm.HealthWorker,
                           BabyBeforeGivenTime = patForm.BabyBeforeGivenTime,
                           BabyBeforeTreatment = patForm.BabyBeforeTreatment,
                           BabyDob = baby.Dob,
                           BabyDuringTransport = patForm.BabyDuringTransport,
                           BabyGestationAge = babyInfo.GestationalAge,
                           BabyInformationGiven = patForm.BabyInformationGiven,
                           BabyLastFeed = patForm.BabyLastFeed,
                           BabyMajorFindings = patForm.BabyMajorFindings,
                           BabyName = "".GetFullName(baby.Fname, baby.Mname, baby.Lname),
                           BabyReason = patForm.BabyReason,
                           BabyTransportGivenTime = patForm.BabyTransportGivenTime,
                           BabyWeight = babyInfo.Weight,
                           PatientBabyId = patForm.PatientBabyId,
                           PatientDob = patient.Dob,
                           PatientStatus = patient.CivilStatus,
                           PhicId = patient.PhicId,
                           PhicStatus = patient.PhicStatus,
                           ReferringMd = patForm.ReferredBy,
                           ReferringMdName = referringMd.Level.GetFullName(referringMd.Fname, referringMd.Mname, referringMd.Lname),
                           ReferringMdContact = referringMd.Contact,
                           CreatedAt = patForm.CreatedAt.Value.DateTime,
                           UpdatedAt = patForm.UpdatedAt.Value.DateTime
                       };

            var pregnantForm = await form.FirstAsync();
            var file = SetPDF(pregnantForm);
            return File(file, "application/pdf");
        }

        #region HELPERS

        public async Task<List<SelectDepartment>> AvailableDepartments(int facilityId)
        {
            var deps = _context.Users
                .Where(x => x.FacilityId.Equals(facilityId) && x.Level.Equals(_roles.Value.DOCTOR) && x.DepartmentId != 0)
                .Select(x => x.DepartmentId)
                .Distinct();
            var departments = from userDep in deps
                              join department in _context.Department on userDep equals department.Id
                              select new SelectDepartment
                              {
                                  DepartmentId = userDep,
                                  DepartmentName = department.Description
                              };

            return await departments.ToListAsync();
        }

        public byte[] SetPDF(PatientFormModel form)
        {
            new CustomAssemblyLoadContext().LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 1.54, Bottom = 1.34, Left = 1.34, Right = 1.34, Unit = Unit.Centimeters },
                DocumentTitle = form.PatientName
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = NormalPdf(form),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "site.css") }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return _converter.Convert(pdf);
        }
        public byte[] SetPDF(PregnantFormModel form)
        {
            new CustomAssemblyLoadContext().LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 1.54, Bottom = 1.34, Left = 1.34, Right = 1.34, Unit = Unit.Centimeters },
                DocumentTitle = form.PatientName
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PregnantPdf(form),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "dist", "css", "custom-adminlte.css") }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return _converter.Convert(pdf);
        }

        public string DTR()
        {
            var pdf = new StringBuilder();

            pdf.Append(@"
<html>
    <head></head>
    <body>
    <div class='row'>
  <div class='col-md-3'>
    <table>
    <tr>
      <td colspan='8'>
        <small>Civil Service Form No. 48 <span class='fa-pull-right'>Printed: 2020-03-05</span></small>
      </td>
    </tr>
    <tr>
      <td colspan = '8' class='text-center'>
          DAILY TIME RECORD
      </td>
    </tr>
    <tr>
      <td colspan = '8' class='text-center text-bold'>
          <u>DAMANDAMAN, KEITH JOSEPH</u>
      </td>
    </tr>
    <tr>
      <td colspan = '8'>
        <small> For the month of: Mar 03 to Apr 15, 2020  ID No: 0978</small> 
      </td>
    </tr>
    <tr>
      <td colspan = '8'>
        <small> Official Hours for (days A.M.P.M.arrival and departure)</small> 
      </td>
    </tr>
    <tr>
      <td colspan = '2' class='text-center'>
        &nbsp;
      </td>
      <td colspan = '2' class='text-center'>
        <small>AM</small>
      </td>
      <td colspan = '2' class='text-center'>
        <small>PM</small>
      </td>
      <td colspan = '2' class='text-center'>
        <small>MINUTES</small>
      </td>
    </tr>
    <tr>
      <td colspan = '2' class='text-center'>
        <small>DAY</small>
      </td>
      <td>
        <small>ARRIVAL</small>
      </td>
      <td>
        <small>DEPARTURE</small>
      </td>
      <td>
        <small>ARRIVAL</small>
      </td>
      <td>
        <small>DEPARTURE</small>
      </td>
      <td>
        <small>LATE</small>
      </td>
      <td>
        <small>UT</small>
      </td>
    </tr>
    <!-- DAYS -->
    <tr>
      <td>
        03
      </td>
      <td>
        Tue
      </td>
      <td>
        07:46:34
      </td>
      <td>
        12:27:25
      </td>
      <td>
        12:27:30
      </td>
      <td>
        19:07:37
      </td>
      <td>
        &nbsp;
      </td>
      <td>
        &nbsp;
      </td>
    </tr>
    <!-- DAYS -->
    <tr>
      <td>
        04
      </td>
      <td>
        Wed
      </td>
      <td>
        07:44:46
      </td>
      <td>
        12:47:33
      </td>
      <td>
        12:47:38
      </td>
      <td>
        17:45:44
      </td>
      <td>
        &nbsp;
      </td>
      <td>
        &nbsp;
      </td>
    </tr>
    <!-- DAYS -->
    <tr>
      <td>
        05
      </td>
      <td>
        Thu
      </td>
      <td>
        07:54:58
      </td>
      <td>
        12:07:28 
      </td>
      <td>
        12:07:32 
      </td>
      <td>
        &nbsp;
      </td>
      <td>
        &nbsp;
      </td>
      <td>
        &nbsp;
      </td>
    </tr>
    <!-- DAYS -->
    <tr>
      <td>
        06
      </td>
      <td>
        Fri
      </td>
      <td colspan = '4' class='text-center text-bold'>
        <u><i>ABSENT</i></u>
      </td>
      <td>
        480
      </td>
      <td>
        &nbsp;
      </td>
    </tr>
    <!-- DAYS -->
    <tr>
      <td>
        07
      </td>
      <td>
        Sat
      </td>
      <td colspan = '4' class='text-center text-bold'>
        <u><i>DAY OFF</i></u>
      </td>
      <td>
        &nbsp;
      </td>
      <td>
        &nbsp;
      </td>
    </tr>
    <!-- DAYS -->
    <tr>
      <td>
        08
      </td>
      <td>
        Sun
      </td>
      <td colspan = '4' class='text-center text-bold'>
        <u><i>DAY OFF</i></u>
      </td>
      <td>
        &nbsp;
      </td>
      <td>
        &nbsp;
      </td>
    </tr>
  </table>
  </div>
  <div class='col-md-3'>
    
    <table>
      <tr>
        <td colspan='8'>
          <small>Civil Service Form No. 48 <span class='fa-pull-right'>Printed: 2020-03-05</span></small>
        </td>
      </tr>
      <tr>
        <td colspan = '8' class='text-center'>
            DAILY TIME RECORD
        </td>
      </tr>
      <tr>
        <td colspan = '8' class='text-center text-bold'>
            <u>DAMANDAMAN, KEITH JOSEPH</u>
        </td>
      </tr>
      <tr>
        <td colspan = '8'>
          <small> For the month of: Mar 03 to Apr 15, 2020  ID No: 0978</small> 
        </td>
      </tr>
      <tr>
        <td colspan = '8'>
          <small> Official Hours for (days A.M.P.M.arrival and departure)</small> 
        </td>
      </tr>
      <tr>
        <td colspan = '2' class='text-center'>
          &nbsp;
        </td>
        <td colspan = '2' class='text-center'>
          <small>AM</small>
        </td>
        <td colspan = '2' class='text-center'>
          <small>PM</small>
        </td>
        <td colspan = '2' class='text-center'>
          <small>MINUTES</small>
        </td>
      </tr>
      <tr>
        <td colspan = '2' class='text-center'>
          <small>DAY</small>
        </td>
        <td>
          <small>ARRIVAL</small>
        </td>
        <td>
          <small>DEPARTURE</small>
        </td>
        <td>
          <small>ARRIVAL</small>
        </td>
        <td>
          <small>DEPARTURE</small>
        </td>
        <td>
          <small>LATE</small>
        </td>
        <td>
          <small>UT</small>
        </td>
      </tr>
      <!-- DAYS -->
      <tr>
        <td>
          03
        </td>
        <td>
          Tue
        </td>
        <td>
          07:46:34
        </td>
        <td>
          12:27:25
        </td>
        <td>
          12:27:30
        </td>
        <td>
          19:07:37
        </td>
        <td>
          &nbsp;
        </td>
        <td>
          &nbsp;
        </td>
      </tr>
      <!-- DAYS -->
      <tr>
        <td>
          04
        </td>
        <td>
          Wed
        </td>
        <td>
          07:44:46
        </td>
        <td>
          12:47:33
        </td>
        <td>
          12:47:38
        </td>
        <td>
          17:45:44
        </td>
        <td>
          &nbsp;
        </td>
        <td>
          &nbsp;
        </td>
      </tr>
      <!-- DAYS -->
      <tr>
        <td>
          05
        </td>
        <td>
          Thu
        </td>
        <td>
          07:54:58
        </td>
        <td>
          12:07:28 
        </td>
        <td>
          12:07:32 
        </td>
        <td>
          &nbsp;
        </td>
        <td>
          &nbsp;
        </td>
        <td>
          &nbsp;
        </td>
      </tr>
      <!-- DAYS -->
      <tr>
        <td>
          06
        </td>
        <td>
          Fri
        </td>
        <td colspan = '4' class='text-center text-bold'>
          <u><i>ABSENT</i></u>
        </td>
        <td>
          480
        </td>
        <td>
          &nbsp;
        </td>
      </tr>
      <!-- DAYS -->
      <tr>
        <td>
          07
        </td>
        <td>
          Sat
        </td>
        <td colspan = '4' class='text-center text-bold'>
          <u><i>DAY OFF</i></u>
        </td>
        <td>
          &nbsp;
        </td>
        <td>
          &nbsp;
        </td>
      </tr>
      <!-- DAYS -->
      <tr>
        <td>
          08
        </td>
        <td>
          Sun
        </td>
        <td colspan = '4' class='text-center text-bold'>
          <u><i>DAY OFF</i></u>
        </td>
        <td>
          &nbsp;
        </td>
        <td>
          &nbsp;
        </td>
      </tr>
    </table>
  </div>
</div>
    </body>
</html>
");
            return pdf.ToString();
        }

        public string NormalPdf(PatientFormModel form)
        {
            var pdf = new StringBuilder();
            pdf.AppendFormat(@"
                <html>
                    <head></head>
                    <body>
                        <div>
                            <center>    
                                <h2>
                                    CENTRAL VISAYAS HEALTH REFERRAL SYSTEM <br>
                                    <small>
                                        Clinical Referral Form
                                    </small>
                                </h2>
                            </center>
                        </div>
                        <div>
                            <table>
                                <tbody>
                                    <tr>
                                         <br> <br> 
                                        <td colspan = '6'><b>Patient Code:</b><i class='item-color'>{22}</i></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'></td>
                                    </tr>
                                    <tr>
                                         <br> 
                                        <td colspan = '6'><b>Name of Referring Facility:</b><i class='item-color'>{0}</i></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'><b>Facility Contact #:</b><i class='item-color'>{1}</i></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'><b>Address:</b><i class='item-color'>{2}</i></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '3'><b>Referred to:</b><i class='item-color'>{3}</i></td>
                                        <td colspan = '3'><b>Department:</b><i class='item-color'>{4}</i></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'><b>Address:</b><i class='item-color'>{5}</i></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '3'>
                                            <b>Date / Time Referred(ReCo):</b>
                                            <i class='item-color'>
                                                {6}
                                            </i>
                                        </td>
                                        <td colspan = '3'>
                                            <b>Date / Time Transferred:</b>
                                            <i class='item-color'>
                                                {7}
                                            </i>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '3'>
                                            <b>Name of Patient:</b>
                                            <i class='item-color'>
                                                {8}
                                            </i>
                                        </td>
                                        <td>
                                            <b>Age:</b>
                                            <i class='item-color'>
                                                {9}
                                            </i>
                                        </td>
                                        <td>
                                            <b>Sex:</b>
                                            <i class='item-color'>
                                                {10}
                                            </i>
                                        </td>
                                        <td>
                                            <b>Status:</b>
                                            <i class='item-color'>
                                                {11}
                                            </i>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'>
                                            <b>Address:</b>
                                            <i class='item-color'>
                                                {12}
                                            </i>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '3'>
                                            <b>PhilHealth status:</b>
                                            <i class='item-color'>
                                                {13}
                                            </i>
                                        </td>
                                        <td colspan = '3'>
                                            <b>PhilHealth #:</b>
                                            <i class='item-color'>
                                                {14}
                                            </i><br>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan='6'>
                                            <b>Case Summary(pertinent Hx/PE, including meds, labs, course etc.):</b>
                                            <br>
                                            <i class='item-color'>
                                                {15}
                                            </i>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'>
                                            <b>Summary of ReCo(pls.refer to ReCo Guide in Referring Patients Checklist):</b>
                                            <br>
                                            <i class='item-color'>
                                                {16} 
                                            </i> <br> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'>
                                            <b>Diagnosis / Impression:</b>
                                            <br>
                                            <i class='item-color'>
                                                {17}
                                            </i>
                                             <br> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'>
                                            <b>Reason for referral:</b>
                                            <br>
                                            <i class='item-color'>
                                                {18}
                                            </i> <br> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'></td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'>
                                            <b>Name of referring MD/HCW:</b>
                                            <i class='item-color'>
                                                {19}
                                            </i>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan = '6'>
                                            <b>Contact # of referring MD/HCW:</b>
                                            <i class='item-color'>
                                                {20}
                                            </i>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan='6'>
                                            <b>Name of referred MD/HCW- Mobile Contact # (ReCo):</b>
                                            <i class='item-color'>
                                                {21}
                                            </i>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </body>
                </html>",
                form.ReferringFacilityName,
                form.ReferringFacilityContact,
                form.ReferringFacilityAddress,
                form.ReferredToName,
                form.Department,
                form.ReferredToAddress,
                form.TimeReferred.GetDate("MMMM d, yyyy h:mm tt"),
                form.TimeTransferred == default? "" : form.TimeTransferred.GetDate("MMMM d, yyyy h:mm tt"),
                form.PatientName,
                form.PatientDob.ComputeAge(),
                form.PatientSex,
                form.PatientStatus,
                form.PatientAddress,
                form.PhicStatus,
                form.PhicId,
                form.CaseSummary,
                form.RecoSummary,
                form.Diagnosis,
                form.Reason,
                form.ReferringMdName,
                form.ReferringMdContact,
                form.ReferredMdName,
                form.Code);
            return pdf.ToString();
        }

        public string PregnantPdf(PregnantFormModel form)
        {
            var pdf = new StringBuilder();
            pdf.Append(@"
                <html>
                    <head></head>
                    <body>
                        <div>
                            <center>    
                                <h4>
                                    BEmONC/ CEmONC REFERRAL FORM
                                </h4>
                            </center>
                        </div>
                        <div>");
            pdf.AppendFormat(@"
                <table>
                    <tbody>
                        <tr><td> </td></tr>
                        <tr><td> </td></tr>
                        <tr>
                            <td colspan = '5''><b>Patient Code:</b> <span class='item-color'>{0}</th>
                        </tr>
                        <tr><td> </td></tr>
                        <tr>
                            <td colspan = '5'><b>REFERRAL RECORD</b> </th>
                        </tr>
                        <tr>
                            <td><b>Who is Referring</b> </td>
                            <td colspan = '3'><b>Record Number:</b> <span class='item-color'>{1}</span></td>
                            <td colspan = '1'><b>Referred Date:</b> <span class='item-color'>{2}</span></td>
                        </tr>
                        <tr>
                            <td colspan = '4'><b>Name of referring MD/HCW:</b> <span class='item-color'>{3}</span></td>
                            <td colspan = '1'><b>Arrival Date:</b> <span class='item-color'>{4}</span></td>
                        </tr>
                        <tr>
                            <td colspan = '5'><b>Contact # of referring MD/HCW:</b> <span class='item-color'>{5}</span></td>
                        </tr>
                        <tr>
                            <td colspan='5'><b>Facility:</b> <span class='item-color'>{6}</span></td>
                        </tr>
                        <tr>
                            <td colspan = '5'><b>Facility Contact #:</b> <span class='item-color'>{7}</span></td>
                        </tr>
                        <tr>
                            <td colspan = '5'><b>Accompanied by the Health Worker:</b> <span class='item-color'>{8}</span></td>
                        </tr>
                        <tr>
                            <td colspan = '4'><b>Referred To:</b> <span class='item-color'>{9}</span></td>
                            <td colspan = '1'><b>Department:</b> <span class='item-color'>{10}</span></td>
                        </tr>
                        <tr>
                            <td colspan = '5'><b>Address:</b> <span class='item-color'>{11}</span></td>
                        </tr>
                        <tr><td></td></tr>
                    </tbody>
                </table>",
                form.Code,
                form.RecordNo,
                form.ReferredDate.ToString("MMMM d, yyyy hh:mm tt",CultureInfo.InvariantCulture),
                form.ReferringMdName,
                form.ArrivalDate == default ? "" : form.ArrivalDate.ToString("MMMM d, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                form.ReferringMdContact,
                form.ReferringFacilityName,
                form.ReferringFacilityContact,
                form.HealthWorker,
                form.ReferredToName,
                form.Department,
                form.ReferredToAddress);

            pdf.AppendFormat(@"
            <table class='table table-bordered'>
                <tbody>
                    <tr class='bg-gray-light'>
                        <td colspan = '4'><b>WOMAN</b></ th>
                    </ tr>
                    <tr>
                        <td colspan='3'><b>Name:</b> <span class='text-success'>{0}</span></td>
                    </tr>
                    <tr>
                        <td><b>Age:</b> <span class='text-success'>{1}</span></td>
                    </tr>
                    <tr>
                        <td colspan = '4'><b>Address:</b> <span class='text-success'>{2}</span></td>
                    </tr>
                    <tr>
                        <td colspan = '4'>
                            <b>Main Reason for Referral:</b>    
                            <br>
                            <span class='text-success'>{3}</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan = '4'>
                            <b>Major Findings(Clinica and BP, Temp, Lab)</b>
                            <br>
                            <span class='text-success'>{4}</span>
                        </td>
                    </tr>
                    <tr class='bg-gray-light'>
                        <td colspan = '4'><b>Treatments Give Time</b></td>
                    </tr>
                    <tr>
                        <td colspan = '4'><b>Before Referral:</b> <span class='text-success'>{5}</span> - <span class='woman_before_given_time'>{6}</span></td>
                    </tr>
                    <tr>
                        <td colspan = '4'><b>During Transport:</b> <span class='text-success'>{7}</span> - <span class='woman_transport_given_time'>{8}</span></td>
                    </tr>
                    <tr>
                        <td colspan = '4'>
                            <b>Information Given to the Woman and Companion About the Reason for Referral</b>
                            <br>
                            <span class='text-success'>{9}</span>
                        </td>
                    </tr>
                </tbody>
            </table>",
            form.PatientName,
            form.PatientDob.ComputeAge(),
            form.PatientAddress,
            form.WomanReason,
            form.WomanMajorFindings,
            (form.WomanBeforeGivenTime) == default ? "" : (form.WomanBeforeGivenTime).ToString("MMMM d, yyyy hh:mm tt", CultureInfo.InvariantCulture),
            form.WomanBeforeTreatment,
            (form.WomanTransportGivenTime) == default ? "" : (form.WomanTransportGivenTime).ToString("MMMM d, yyyy hh:mm tt", CultureInfo.InvariantCulture),
            form.WomanDuringTransport,
            form.WomanInformationGiven);


            if(form.PatientBabyId != 0)
            {
                var baby = _context.Baby.SingleOrDefault(x => x.BabyId == form.PatientBabyId);
                pdf.AppendFormat(@"
                <table class='table table-bordered'>
                    <tbody>
                        <tr class='bg-gray-light'>
                            <td><b>BABY</b></ th>
                        </ tr>
                        <tr>
                            <td><b>Name:</b> <span class='text-success'>{0}</span></td>
                        </tr>
                        <tr>
                            <td><b>Date of Birth:</b> <span class='text-success'>{1}</span></td>
                        </tr>
                        <tr>
                            <td><b>Birth Weigth:</b> <span class='text-success'>{2}</span></td>
                        </tr>
                        <tr>
                            <td><b>Gestational Age:</b> <span class='text-success'>{3}</span></td>
                        </tr>
                        <tr>
                            <td>
                                <b>Main Reason for Referral:</b>    
                                <br>
                                <span class='text-success'>{4}</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Major Findings(Clinica and BP, Temp, Lab)</b>
                                <br>
                                <span class='text-success'>{5}</span>
                            </td>
                        </tr>
                        <tr>
                            <td><b>Last (Breast) Feed (Time):</b> <span class='text-success'>{6}</span></td>
                        </tr>
                        <tr class='bg-gray-light'>
                            <td><b>Treatments Give Time</b></td>
                        </tr>
                        <tr>
                            <td><b>Before Referral:</b> <span class='text-success'>{7}</span> - <span class='text-success'>{8}</span></td>
                        </tr>
                        <tr>
                            <td><b>During Transport:</b> <span class='text-success'>{9}</span> - <span class='text-success'>{10}</span></td>
                        </tr>
                        <tr>
                            <td>
                                <b>Information Given to the Woman and Companion About the Reason for Referral</b>
                                <br>
                                <span class='text-success'>{11}</span>
                            </td>
                        </tr>
                    </tbody>
                </table>",
                form.BabyName,
                form.BabyDob.ToString("MMMM d, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                baby.Weight,
                baby.GestationalAge,
                form.BabyReason,
                form.BabyMajorFindings,
                (form.BabyLastFeed) == default ? "" : (form.BabyLastFeed).ToString("MMMM d, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                form.WomanBeforeTreatment,
                (form.WomanBeforeGivenTime) == default ? "" : (form.WomanBeforeGivenTime).ToString("MMMM d, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                form.WomanDuringTransport,
                (form.WomanTransportGivenTime) == default ? "" : (form.WomanTransportGivenTime).ToString("MMMM d, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                form.WomanInformationGiven);
            }
            

            pdf.Append(@"
                        </div>
                    </body>
                </html>");

            return pdf.ToString();
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