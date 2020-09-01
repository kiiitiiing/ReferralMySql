using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.Models.ViewModels.ViewPatients;
using Referral2.MyData;

namespace Referral2.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralStatus> _status;
        private readonly IOptions<ReferralRoles> _roles;

        public TransactionsController(MySqlReferralContext context, IOptions<ReferralStatus> status, IOptions<ReferralRoles> roles)
        {
            _context = context;
            _status = status;
            _roles = roles;
        }

        #region TRACK
        //GET: Track patients
        [HttpGet]
        public async Task<IActionResult> Track(string code)
        {
            if(UserRole == _roles.Value.DOCTOR || UserRole == _roles.Value.MCC)
            {

                ViewBag.CurrentCode = code;
                var seens = _context.Seen;
                var activities = _context.Activity;
                var feedbacks = _context.Feedback;
                var facilities = _context.Facility.Where(x => x.Id != UserFacility);
                var issues = _context.Issue;
                var track = await _context.Tracking
                    .Where(x => x.Code.Equals(code))
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
                                SeenCount = seens.Where(x=>x.TrackingId == temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Id).Count(),
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
                                Activities = activities.Where(x=>x.Code == temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.Code).OrderByDescending(x=>x.CreatedAt)
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
                                                FacilityFrom = (temp5.temp4.temp3.temp2.temp1.temp0.act.ReferredFrom == 0)? "": temp5.temp4.temp3.temp2.temp1.temp0.refFrom.Name,
                                                FacilityFromContact = (temp5.temp4.temp3.temp2.temp1.temp0.act.ReferredFrom == 0)? "": temp5.temp4.temp3.temp2.temp1.temp0.refFrom.Contact,
                                                FacilityTo = temp5.temp4.temp3.temp2.refTo.Name,
                                                ActionMd = actMd.GetMDFullName(),
                                                ReferringMd = temp5.temp4.refMd.GetMDFullName(),
                                                Remarks = temp5.temp4.temp3.temp2.temp1.temp0.act.Remarks
                                            }
                                    )
                                ,
                                ReferredFromId = temp6.temp5.temp4.temp3.temp2.temp1.temp0.track.ReferredFrom
                            }
                    )
                    .OrderByDescending(x => x.UpdatedAt)
                    .FirstOrDefaultAsync();
                    /*.Select(t => new ReferredViewModel
                    {
                        PatientId = t.PatientId,
                        PatientName = t.Patient.Fname + " " + t.Patient.Mname + " " + t.Patient.Lname,
                        PatientSex = t.Patient.Sex,
                        PatientAge = t.Patient.Dob.ComputeAge(),
                        Barangay = t.Patient.Barangay.Description,
                        Muncity = t.Patient.Muncity.Description,
                        Province = t.Patient.Province.Description,
                        ReferredBy = t.ReferringMdNavigation.GetMDFullName(),
                        ReferredTo = t.ActionMdNavigation.GetMDFullName(),
                        ReferredToId = t.ReferredTo,
                        TrackingId = t.Id,
                        SeenCount = t.Seen.Count(),
                        CallerCount = activities.Where(x => x.Code.Equals(t.Code) && x.Status.Equals(_status.Value.CALLING)).Count(),
                        IssueCount = _context.Issue.Where(x => x.TrackingId.Equals(t.Id)).Count(),
                        ReCoCount = feedbacks.Where(x => x.Code.Equals(t.Code)).Count(),
                        Travel = string.IsNullOrEmpty(t.ModeTransportation),
                        Code = t.Code,
                        Status = t.Status,
                        Pregnant = t.Type.Equals("pregnant"),
                        Seen = t.DateSeen != default,
                        Walkin = t.Walkin.Equals("yes"),
                        UpdatedAt = t.DateReferred,
                        Activities = activities.Where(x => x.Code.Equals(t.Code) && x.Status != _status.Value.CALLING).OrderByDescending(x => x.CreatedAt)
                            .Select(i => new ActivityLess
                            {
                                Status = i.Status,
                                DateAction = i.DateReferred.ToString("MMM dd, yyyy hh:mm tt", CultureInfo.InvariantCulture),
                                FacilityFrom = i.ReferredFromNavigation == null ? "" : i.ReferredFromNavigation.Name,
                                FacilityFromContact = i.ReferredFromNavigation == null ? "" : i.ReferredFromNavigation.ContactNo,
                                FacilityTo = t.ReferredToNavigation.Name,
                                PatientName = i.Patient.Fname + " " + i.Patient.Mname + " " + i.Patient.Lname,
                                ActionMd = i.ActionMdNavigation.GetMDFullName(),
                                ReferringMd = i.ReferringMdNavigation.GetMDFullName(),
                                Remarks = i.Remarks
                            })
                    })  */


                if (track != null)
                {
                    ViewBag.Code = track.Code;
                }


                return View(track);
            }
            else
            {
                return RedirectToAction("NotFound", "Account");
            }
        }
        #endregion

        #region HELPERS
        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));
        public int? UserDepartment => string.IsNullOrEmpty(User.FindFirstValue("Department")) ? null : (int?)int.Parse(User.FindFirstValue("Department"));
        public int UserProvince => int.Parse(User.FindFirstValue("Province"));
        public int UserMuncity => int.Parse(User.FindFirstValue("Muncity"));
        public int UserBarangay => int.Parse(User.FindFirstValue("Barangay"));
        public string UserRole => User.FindFirstValue(ClaimTypes.Role);
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        #endregion
    }
}
