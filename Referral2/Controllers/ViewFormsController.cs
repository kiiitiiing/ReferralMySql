using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.MyModels;
using Referral2.Models.ViewModels;
using Referral2.Models.ViewModels.Forms;
using Referral2.MyData;

namespace Referral2.Controllers
{
    public class ViewFormsController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;

        public ViewFormsController(MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _roles = roles;
            _status = status;
        }
        #region PATIENT FORM
        public async Task<IActionResult> PatientForm(string code)
        {
            if (code == null)
                return NotFound();

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


            var patientForm = form.First();

            if (patientForm == null)
                return NotFound();

            var tracking = await _context.Tracking.FirstOrDefaultAsync(x => x.Code.Equals(code));
            var activity = await _context.Activity.FirstOrDefaultAsync(x => x.Code.Equals(code) && x.Status.Equals(_status.Value.REFERRED));

            if (!activity.Status.Equals(_status.Value.REFERRED))
                activity.Status = _status.Value.REFERRED;

            tracking.DateSeen = DateTime.Now;
            tracking.Status = _status.Value.SEEN;
            tracking.UpdatedAt = DateTime.Now;
            activity.DateSeen = DateTime.Now;
            _context.Update(tracking);
            _context.Update(activity);

            var seen = new Seen();
            seen.FacilityId = UserFacility();
            seen.TrackingId = _context.Tracking.Single(x => x.Code.Equals(patientForm.Code)).Id;
            seen.UpdatedAt = DateTime.Now;
            seen.CreatedAt = DateTime.Now;
            seen.UserMd = UserId();
            _context.Add(seen);
            await _context.SaveChangesAsync();
            return PartialView(patientForm);
        }
        #endregion
        #region PREGNANT FORM
        public async Task<IActionResult> PregnantForm(string code)
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

            var pregnantForm = form.First();

            var tracking = _context.Tracking.Single(x => x.Code.Equals(code));
            var activity = _context.Activity.Single(x => x.Code.Equals(code) && x.Status.Equals(_status.Value.REFERRED));

            if (!activity.Status.Equals(_status.Value.REFERRED))
                activity.Status = _status.Value.REFERRED;

            tracking.DateSeen = DateTime.Now;
            tracking.Status = _status.Value.SEEN;
            activity.DateSeen = DateTime.Now;
            tracking.UpdatedAt = DateTime.Now;
            _context.Update(tracking);
            _context.Update(activity);

            var seen = new Seen
            {
                FacilityId = UserFacility(),
                TrackingId = _context.Tracking.First(x => x.Code.Equals(pregnantForm.Code)).Id,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                UserMd = UserId()
            };

            await _context.AddAsync(seen);
            await _context.SaveChangesAsync();
            return PartialView(pregnantForm);
        }
        #endregion
        #region PRINT NORMAL FORM
        public async Task<IActionResult> PrintableNormalForm(string code)
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

            return PartialView(patientForm);
        }
        #endregion
        #region PRINT PREGNANT FORM
        public async Task<IActionResult> PrintablePregnantForm(string code)
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

            return PartialView(pregnantForm);
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