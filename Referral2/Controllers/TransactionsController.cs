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
                if(!string.IsNullOrEmpty(code))
                {
                #region Track Code
                ViewBag.CurrentCode = code;
                var seens = _context.Seen;
                var activities = await _context.Activity.Where(x => x.Code == code).OrderByDescending(x => x.CreatedAt)
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
                        .ToListAsync();
                var feedbacks = _context.Feedback;
                var facilities = _context.Facility.Where(x => x.Id != UserFacility);
                var issues = _context.Issue;
                var users = _context.Users.Where(x => x.Level.Equals(_roles.Value.DOCTOR));
                var track = await _context.Tracking.Where(x=>x.Code == code)
                    .Join(
                        _context.Users,
                        tracking => tracking.ReferringMd,
                        refMd => refMd.Id,
                        (tracking, refMd) =>
                            new
                            {
                                tracking = tracking,
                                refMd = refMd
                            }
                    )
                    .GroupJoin(
                        _context.Users,
                        temp0 => temp0.tracking.ActionMd,
                        act => act.Id,
                        (temp0, ACT) =>
                            new
                            {
                                temp0 = temp0,
                                ACT = ACT
                            }
                    )
                    .SelectMany(
                        temp1 => temp1.ACT.DefaultIfEmpty(),
                        (temp1, actMd) =>
                            new
                            {
                                temp1 = temp1,
                                actMd = actMd
                            }
                    )
                    .Join(
                        _context.Facility,
                        temp2 => temp2.temp1.temp0.tracking.ReferredFrom,
                        refFrom => refFrom.Id,
                        (temp2, refFrom) =>
                            new
                            {
                                temp2 = temp2,
                                refFrom = refFrom
                            }
                    )
                    .Join(
                        _context.Facility,
                        temp3 => temp3.temp2.temp1.temp0.tracking.ReferredTo,
                        refTo => refTo.Id,
                        (temp3, refTo) =>
                            new
                            {
                                temp3 = temp3,
                                refTo = refTo
                            }
                    )
                    .Join(
                        _context.Patients,
                        temp4 => temp4.temp3.temp2.temp1.temp0.tracking.PatientId,
                        pat => pat.Id,
                        (temp4, pat) =>
                            new
                            {
                                temp4 = temp4,
                                pat = pat
                            }
                    )
                    .Join(
                        _context.Province,
                        temp5 => temp5.pat.Province,
                        province => province.Id,
                        (temp5, province) =>
                            new
                            {
                                temp5 = temp5,
                                province = province
                            }
                    )
                    .GroupJoin(
                        _context.Muncity,
                        temp6 => temp6.temp5.pat.Muncity,
                        munct => munct.Id,
                        (temp6, MUNCT) =>
                            new
                            {
                                temp6 = temp6,
                                MUNCT = MUNCT
                            }
                    )
                    .SelectMany(
                        temp7 => temp7.MUNCT.DefaultIfEmpty(),
                        (temp7, muncity) =>
                            new
                            {
                                temp7 = temp7,
                                muncity = muncity
                            }
                    )
                    .GroupJoin(
                        _context.Barangay,
                        temp8 => temp8.temp7.temp6.temp5.pat.Brgy,
                        brgy => brgy.Id,
                        (temp8, BRGY) =>
                            new
                            {
                                temp8 = temp8,
                                BRGY = BRGY
                            }
                    )
                    .SelectMany(
                        temp9 => temp9.BRGY.DefaultIfEmpty(),
                        (temp9, barangay) =>
                            new ReferredViewModel
                            {
                                PatientId = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.PatientId,
                                Fname = temp9.temp8.temp7.temp6.temp5.pat.Fname,
                                Mname = (temp9.temp8.temp7.temp6.temp5.pat.Mname ?? ""),
                                Lname = temp9.temp8.temp7.temp6.temp5.pat.Lname,
                                PatientSex = temp9.temp8.temp7.temp6.temp5.pat.Sex,
                                PatientAge = temp9.temp8.temp7.temp6.temp5.pat.Dob.ComputeAge(),
                                Barangay = barangay.Description,
                                Muncity = temp9.temp8.muncity.Description,
                                Province = temp9.temp8.temp7.temp6.province.Description,
                                ReferredBy = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.refMd.GetMDFullName(),
                                ReferredTo = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.actMd.GetMDFullName(),
                                ReferredToId = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.ReferredTo,
                                FacilityFrom = temp9.temp8.temp7.temp6.temp5.temp4.temp3.refFrom.Name,
                                FacilityTo = temp9.temp8.temp7.temp6.temp5.temp4.refTo.Name,
                                TrackingId = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Id,
                                SeenCount = seens.Where(x => x.TrackingId == temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Id).Count(),
                                CallerCount = _context.Activity.Where(x => x.Code.Equals(code) && x.Status.Equals(_status.Value.CALLING)).Count(),
                                IssueCount = issues.Where(x => x.TrackingId.Equals(temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Id)).Count(),
                                ReCoCount = feedbacks.Where(x => x.Code.Equals(code)).Count(),
                                Travel = string.IsNullOrEmpty(temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.ModeTransportation),
                                Code = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Code,
                                Status = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Status,
                                Pregnant = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Type.Equals("pregnant"),
                                Seen = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.DateSeen != default,
                                Walkin = string.IsNullOrEmpty(temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Walkin) ? false : temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.Walkin.Equals("yes"),
                                UpdatedAt = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.DateReferred,
                                ReferredFromId = temp9.temp8.temp7.temp6.temp5.temp4.temp3.temp2.temp1.temp0.tracking.ReferredFrom
                            })
                            .OrderByDescending(x=>x.UpdatedAt)
                            .FirstOrDefaultAsync();
                track.Activities = activities;

                if (track != null)
                {
                    ViewBag.Code = track.Code;
                }


                return View(track);
                    #endregion
                }
                else
                {
                    return View();
                }
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
