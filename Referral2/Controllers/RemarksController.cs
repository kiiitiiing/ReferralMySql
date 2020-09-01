﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.MyModels;
using Referral2.Models.ViewModels;
using Referral2.Resources;
using Microsoft.Extensions.Options;
using Referral2.Models.ViewModels.Remarks;
using Microsoft.EntityFrameworkCore;
using MoreLinq.Extensions;
using Referral2.MyData;

namespace Referral2.Controllers
{
    [Authorize]
    public class RemarksController : Controller
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;


        public RemarksController(MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _roles = roles;
            _status = status;
        }

        public string Code { get; set; }

        public int Id { get; set; }

        #region REFER TO OTHER FACILITY
        public IActionResult ReferOther(string code)
        {
            var facilities = _context.Facility.Where(x => x.Id != UserFacility);
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ReferOther([Bind] ReferOtherModel model)
        {
            if(ModelState.IsValid)
            {
                //UPDATE TRACKING
                var tracking = await _context.Tracking.FirstOrDefaultAsync(x => x.Code.Equals(model.Code));
                tracking.Status = _status.Value.REFERRED;
                tracking.ReferredFrom = UserFacility;
                tracking.ReferredTo = model.FacilityId;
                tracking.DepartmentId = model.DepartmentId;
                tracking.DateAccepted = default;
                tracking.DateArrived = default;
                tracking.DateSeen = default;
                tracking.DateTransferred = default;
                tracking.UpdatedAt = DateTime.Now;
                //NEW FACILITY
                var activity = new Activity
                {
                    Code = tracking.Code,
                    PatientId = tracking.PatientId,
                    DateReferred = DateTime.Now,
                    DateSeen = default,
                    ReferredFrom = UserFacility,
                    ReferredTo = model.FacilityId,
                    DepartmentId = default,
                    ReferringMd = UserId,
                    ActionMd = default,
                    Remarks = "",
                    Status = _status.Value.REDIRECTED,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Update(tracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return PartialView();
            }
            return PartialView(model);
        }
        #endregion

        #region REDIRECT

        /*public IActionResult Redirect(string code)
        {
            return PartialView();
        }
*/
        #endregion

        #region CALL
        [HttpGet]
        [Route("{controller}/{action}/{code}")]
        public void RequestCall(string code)
        {
            var tracking = _context.Tracking.SingleOrDefault(x => x.Code == code);
            var activity = new Activity
            {
                Code = code,
                PatientId = tracking.PatientId,
                DateReferred = DateTime.Now,
                DateSeen = default,
                ReferredFrom = tracking.ReferredFrom,
                ReferredTo = tracking.ReferredTo,
                DepartmentId = 0,
                ReferringMd = 0,
                ActionMd = UserId,
                Remarks = "N/A",
                Status = _status.Value.CALLING,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Add(activity);
            _context.SaveChanges();
        }

        #endregion

        #region ISSUES AND CONCERN

        public IActionResult Issues(int? id)
        {
            var issues = _context.Issue
                .Where(x => x.TrackingId == id);
            var issueModel = new IssuesModel
            {
                TrackingId = (int)id,
                Issues = issues.ToList()
            };
            return PartialView(issueModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Issues([FromForm]IssuesModel model)
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors);
            if (ModelState.IsValid)
            {
                foreach (var item in model.Issues)
                {
                    if (item.Id != 0)
                    {
                        var currIssue = _context.Issue.Find(item.Id);
                        currIssue.Issue1 = item.Issue1;
                        currIssue.UpdatedAt = DateTime.Now;
                        _context.Update(currIssue);
                    }
                    else
                    {
                        item.CreatedAt = DateTime.Now;
                        item.UpdatedAt = DateTime.Now;
                        _context.Add(item);
                    }
                }
                await _context.SaveChangesAsync();
                var issues = new IssuesModel()
                {
                    Issues = _context.Issue.Where(x => x.TrackingId == model.TrackingId).ToList(),
                    TrackingId = model.TrackingId
                };
                return PartialView(issues);
            }

            ViewBag.Errors = errors;

            return PartialView(model);
        }

        #endregion

        #region TRAVEL

        public IActionResult Travel(int? id)
        {
            var transportations = _context.ModeTransportation;
            ViewBag.TrackingId = id;
            ViewBag.Transpo = new SelectList(transportations, "Id", "Transportation1");
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Travel([Bind]TravelViewModel model)
        {
            if(ModelState.IsValid)
            {
                var tracking = TravelTracking(model);
                var activity = TravelActivity(tracking);
                _context.Update(tracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Referred", "ViewPatients");
            }
            return PartialView();
        }

        

        #endregion

        #region ACCEPTED
        [HttpGet]
        public IActionResult AcceptedRemark(string code)
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AcceptedRemark([Bind] RemarksViewModel model, string code)
        {
            if (ModelState.IsValid)
            {
                var tracking = AcceptedTracking(model, _status.Value.ACCEPTED);
                var activity = NewActivity(tracking, DateTime.Now);
                _context.Update(tracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Incoming", "ViewPatients");
            }
            return PartialView(model);
        }
        #endregion

        #region ARRIVED
        [HttpGet]
        public IActionResult ArrivedRemark(string code)
        {
            var Arrived = new RemarksViewModel
            {
                Code = code,
            };
            return PartialView(Arrived);
        }

        [HttpPost]
        public async Task<IActionResult> ArrivedRemark([Bind] RemarksViewModel model, string code)
        {
            if (ModelState.IsValid)
            {
                var tracking = ArrivedTracking(model, _status.Value.ARRIVED);
                var activity = NewActivity(tracking, DateTime.Now);
                _context.Update(tracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Accepted", "ViewPatients");
            }
            return PartialView(model);
        }
        #endregion

        #region DIDNT ARRIVE
        [HttpGet]
        public IActionResult DidntArrivedRemark(string code)
        {
            var model = new RemarksViewModel
            {
                Code = code
            };
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> DidntArrivedRemark( RemarksViewModel model, string code)
        {
            if (ModelState.IsValid)
            {
                var tracking = ArrivedTracking(model, _status.Value.ARCHIVED);
                var activity = NewActivity(tracking, DateTime.Now);
                _context.Update(tracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Accepted", "ViewPatients");
            }
            return PartialView(model);
        }
        #endregion

        #region ADMITTED
        [HttpGet]
        public IActionResult AdmittedRemark(string code)
        {
            var Admitted = new AdmittedViewModel
            {
                Code = code,
            };
            return PartialView(Admitted);
        }

        [HttpPost]
        public async Task<IActionResult> AdmittedRemark([Bind] AdmittedViewModel model, string code)
        {
            if (ModelState.IsValid)
            {
                var tracking = AdmittedTracking(model, _status.Value.ADMITTED);
                var activity = NewActivity(tracking, model.DateAdmitted);

                _context.Update(tracking);
                _context.Add(activity);

                await _context.SaveChangesAsync();
                return RedirectToAction("Accepted", "ViewPatients");
            }
            return PartialView(model);
        }
        #endregion

        #region CALLED
        [HttpGet]
        public IActionResult CallRequest(string code)
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CallRequest([Bind] RemarksViewModel model, string code)
        {
            if (ModelState.IsValid)
            {
                var tracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
                NewActivity(tracking, DateTime.Now);
                await _context.SaveChangesAsync();
                return RedirectToAction("Incoming", "ViewPatients");
            }

            return PartialView(model);
        }
        #endregion

        #region REJECTED
        [HttpGet]
        public IActionResult RejectRemarks(string code)
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> RejectRemarks([Bind] RemarksViewModel model, string code)
        {
            if (ModelState.IsValid)
            {
                var tracking = RejectedTracking(model, _status.Value.REJECTED);
                var activity = NewActivity(tracking, DateTime.Now);
                _context.Update(tracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Incoming", "ViewPatients");
            }
            return PartialView(model);
        }
        #endregion

        #region REFER
        [HttpGet]
        public IActionResult ReferRemark(string code)
        {
            ViewBag.Facility = new SelectList(_context.Facility.Where(x=>x.Id != UserFacility),"Id","Name");
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ReferRemark([Bind] ReferViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tracking = ReferTracking(model, _status.Value.TRANSFERRED);
                var activity = NewActivity(tracking, DateTime.Now);
                var newTracking = NewTracking(tracking, model);
                
                _context.Update(tracking);
                _context.Add(newTracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Accepted", "ViewPatients");
            }
            ViewBag.Facility = new SelectList(_context.Facility.Where(x=>x.Id != UserFacility), "Id", "Name", model.FacilityId);
            ViewBag.Department = new SelectList(AvailableDepartments(UserFacility), "Id", "Description", model.DepartmentId);
            return PartialView(model);
        }
        #endregion

        #region CANCEL

        [HttpGet]
        public IActionResult CancelRemark(string code)
        {
            ViewBag.Code = code;
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelRemark([Bind]RemarksViewModel model)
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors);
            if(ModelState.IsValid)
            {
                var tracking = CancelTracking(model, _status.Value.CANCELLED);
                var activity = NewActivity(tracking, DateTime.Now);
                await _context.AddAsync(activity);
                _context.Update(tracking);
                await _context.SaveChangesAsync();
                return RedirectToAction("Cancelled", "ViewPatients");
            }
            ViewBag.Errors = errors;
            return PartialView(model);
        }

        #endregion

        #region DISCHARGED
        [HttpGet]
        public IActionResult DischargedRemark(string code)
        {
            var Discharge = new DischargeRemarkViewModel
            {
                Code = code,
            };
            return PartialView(Discharge);
        }

        [HttpPost]
        public async Task<IActionResult> DischargedRemark([Bind] DischargeRemarkViewModel model, string code)
        {
            if (ModelState.IsValid)
            {
                var tracking = DischargedTracking(model, _status.Value.DISCHARGED);
                _context.Update(tracking);
                var activity = NewActivity(tracking, model.DateDischarged);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Accepted", "ViewPatients");
            }
            return PartialView(model);
        }
        #endregion

        #region RECO
        [HttpGet]
        public IActionResult Recommend(string code)
        {
            var feedback = _context.Feedback.Where(c => c.Code.Equals(code));

            return PartialView(feedback.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Recommend([Bind] Feedback model, string code)
        {
            var currentTracking = _context.Tracking.FirstOrDefault(c => c.Code.Equals(code));
            if (model != null)
            {
                var newFeedback = new Feedback();
                newFeedback.Code = code;
                newFeedback.Sender = UserId;;
                newFeedback.Receiver = currentTracking.ReferringMd;
                newFeedback.Message = model.Message;
                newFeedback.CreatedAt = DateTime.Now;
                newFeedback.UpdatedAt = DateTime.Now;

                _context.Add(newFeedback);
                await _context.SaveChangesAsync();

                return RedirectToAction("Recommend", "Remarks");
            }
            return PartialView(model);
        }
        #endregion

        #region Helpers
        private List<SelectDepartment> AvailableDepartments(int facilityId)
        {
            var availableDepartments = _context.Users
                .Where(x => x.FacilityId.Equals(facilityId) && x.Level.Equals(_roles.Value.DOCTOR) && x.DepartmentId != 0)
                .DistinctBy(d => d.DepartmentId)
                .Join(
                    _context.Department,
                    u => u.DepartmentId,
                    d => d.Id,
                    (u, d) => new SelectDepartment
                    {
                        DepartmentId = u.DepartmentId,
                        DepartmentName = d.Description
                    });
            return availableDepartments.ToList();
        }

        private Tracking TravelTracking(TravelViewModel model)
        {
            
            var tracking = _context.Tracking.Find(model.TrackingId);

            if (model.TranspoId != 5)
                tracking.ModeTransportation = model.TranspoId.ToString();
            else
                tracking.ModeTransportation = model.TranspoId + " - " + model.Other;

            tracking.UpdatedAt = DateTime.Now;

            return tracking;
        }



        private Tracking NewTracking(Tracking tracking, ReferViewModel model)
        {
            var newTracking = new Tracking();

            newTracking.Code = tracking.Code;   
            newTracking.PatientId = tracking.PatientId;
            newTracking.ModeTransportation = null;
            newTracking.ReferredFrom = UserFacility;
            newTracking.ReferredTo = model.FacilityId;
            newTracking.DepartmentId = model.DepartmentId;
            newTracking.ReferringMd = UserId;;
            newTracking.ActionMd = UserId;
            newTracking.DateReferred = DateTime.Now;
            newTracking.DateAccepted = default;
            newTracking.DateArrived = default;
            newTracking.DateSeen = default;
            newTracking.DateTransferred = default;
            newTracking.Remarks = model.Remarks;
            newTracking.Status = _status.Value.REFERRED;
            newTracking.Type = tracking.Type;
            newTracking.Walkin = tracking.Walkin;
            newTracking.FormId = tracking.FormId;
            newTracking.CreatedAt = DateTime.Now;
            newTracking.UpdatedAt = DateTime.Now;

            return newTracking;
        }

        private Tracking CancelTracking(RemarksViewModel model, string status)
        {
            var currentTracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
            currentTracking.Status = status;
            currentTracking.Remarks = model.Remarks;
            currentTracking.UpdatedAt = DateTime.Now;
            return currentTracking;
        }

        private Tracking RejectedTracking(RemarksViewModel model, string status)
        {
            var currentTracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
            currentTracking.Status = status;
            currentTracking.Remarks = model.Remarks;
            currentTracking.UpdatedAt = DateTime.Now;
            return currentTracking;
        }

        private Tracking ArrivedTracking(RemarksViewModel model, string status)
        {
            var currentTracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
            currentTracking.Remarks = model.Remarks;
            currentTracking.Status = status;
            currentTracking.DateArrived = DateTime.Now;
            currentTracking.UpdatedAt = DateTime.Now;

            return currentTracking;
        }

        public Tracking DischargedTracking(DischargeRemarkViewModel model, string status)
        {
            var currentTracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
            currentTracking.Remarks = model.Remarks;
            currentTracking.Status = status;
            currentTracking.UpdatedAt = DateTime.Now;

            return currentTracking;
        }

        public Tracking ReferTracking(ReferViewModel model, string status)
        {
            var currentTracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
            currentTracking.DateTransferred = DateTime.Now;
            currentTracking.Remarks = model.Remarks;
            currentTracking.ActionMd = UserId;;
            currentTracking.Status = status;
            currentTracking.DateTransferred = DateTime.Now;
            currentTracking.UpdatedAt = DateTime.Now;

            return currentTracking;
        }


        public Tracking AdmittedTracking(AdmittedViewModel model, string status)
        {
            var currentTracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
            currentTracking.Remarks =_status.Value.ADMITTED;
            currentTracking.Status = status;
            currentTracking.UpdatedAt = DateTime.Now;

            return currentTracking;
        }

        public Tracking AcceptedTracking(RemarksViewModel model , string status)
        {
            var updateTracking = _context.Tracking.FirstOrDefault(x => x.Code.Equals(model.Code));
            updateTracking.Remarks = model.Remarks;
            updateTracking.Status = status;
            updateTracking.DateAccepted = DateTime.Now;
            updateTracking.UpdatedAt = DateTime.Now;

            return updateTracking;
        }

        private Activity TravelActivity(Tracking tracking)
        {
            Activity activity = new Activity();
            activity.Code = tracking.Code;
            activity.PatientId = tracking.PatientId;
            activity.DateReferred = DateTime.Now;
            activity.DateSeen = default;
            activity.CreatedAt = DateTime.Now;
            activity.UpdatedAt = DateTime.Now;
            activity.ReferredFrom = UserFacility;
            activity.ReferredTo = UserFacility;
            activity.DepartmentId = UserDepartment;
            activity.ReferringMd = UserId;
            activity.ActionMd = UserId;
            activity.Remarks = tracking.ModeTransportation;
            activity.Status = _status.Value.TRAVEL;
            return activity;
        }



        private Activity NewActivity(Tracking tracking, DateTime dateAction)
        {
            Activity activity = new Activity();
            var facility = _context.Facility.Find(tracking.ReferredFrom);
            activity.Code = tracking.Code;
            activity.PatientId = tracking.PatientId;
            activity.DateReferred = dateAction;
            activity.DateSeen = default;
            activity.CreatedAt = DateTime.Now;
            activity.UpdatedAt = DateTime.Now;

            switch (tracking.Status)
            {
                case "referred":
                    {
                        break;
                    }
                case "seen":
                    {
                        break;
                    }
                case "admitted":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.DateSeen = default;
                        activity.ReferredFrom = tracking.ReferredTo;
                        activity.ReferredTo = 0;
                        activity.DepartmentId = tracking.DepartmentId;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }
                case "accepted":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.DateSeen = default;
                        activity.ReferredFrom = tracking.ReferredFrom;
                        activity.ReferredTo = tracking.ReferredTo;
                        activity.DepartmentId = tracking.DepartmentId;
                        activity.ReferringMd = tracking.ReferringMd;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }
                case "arrived":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.DateSeen = default;
                        activity.ReferredFrom = tracking.ReferredTo;
                        activity.ReferredTo = 0;
                        activity.DepartmentId = tracking.DepartmentId;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }
                case "calling":
                    {
                        activity.Remarks = UserName+" called " + facility.Name;
                        activity.DateSeen = default;
                        activity.ReferredFrom = tracking.ReferredFrom;
                        activity.ReferredTo = tracking.ReferredTo;
                        activity.DepartmentId = tracking.DepartmentId;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }
                case "discharged":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.DateSeen = default;
                        activity.ReferredFrom = tracking.ReferredTo;
                        activity.ReferredTo = 0;
                        activity.DepartmentId = 0;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }
                case "transferred":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.DateSeen = default;
                        activity.ReferredFrom = tracking.ReferredTo;
                        activity.ReferredTo = tracking.ReferredFrom;
                        activity.DepartmentId = 0;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }
                case "cancelled":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.DateSeen = default;
                        activity.ReferredFrom = tracking.ReferredFrom;
                        activity.ReferredTo = 0;
                        activity.DepartmentId = 0;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }
                case "rejected":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.ReferredFrom = tracking.ReferredFrom;
                        activity.ReferredTo = tracking.ReferredTo;
                        activity.DepartmentId = 0;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId;;
                        activity.Status = tracking.Status;
                        break;
                    }

                case "archived":
                    {
                        activity.Remarks = tracking.Remarks;
                        activity.ReferredFrom = UserFacility;
                        activity.ReferredTo = 0;
                        activity.DepartmentId = 0;
                        activity.ReferringMd = 0;
                        activity.ActionMd = UserId; ;
                        activity.Status = tracking.Status;
                        break;
                    }
            }
            return activity;
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