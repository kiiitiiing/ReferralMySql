using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Referral2.MyModels;
using Referral2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Referral2.Helpers;
using System.Security.Claims;
using Referral2.Models.ViewModels.Doctor;
using Microsoft.Extensions.Options;
using Referral2.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Referral2.MyData;

namespace Referral2.Controllers
{
    //[Authorize(Policy = "Doctor")]
    public class AddPatientsController : Controller
    {
        const string SessionPatientId = "_patient_id";
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;
        private readonly IOptions<TrackingType> _type;

        // Add Patient Constructor
        public AddPatientsController(MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status, IOptions<TrackingType> type)
        {
            _context = context;
            _roles = roles;
            _status = status;
            _type = type;
        }

        #region Add Patient
        //GET: Add patient
        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.Barangays = new SelectList(_context.Barangay.Where(x => x.ProvinceId.Equals(UserProvince)), "Id", "Description");
            ViewBag.Muncities = new SelectList(_context.Muncity.Where(x => x.ProvinceId.Equals(UserProvince)), "Id", "Description");
            ViewBag.CivilStatus = new SelectList(ListContainer.CivilStatus, "Key", "Value");
            ViewBag.PhicStatus = new SelectList(ListContainer.PhicStatus, "Key", "Value");
            return View();
        }

        //POST: Add patient
        [HttpPost]
        public async Task<IActionResult> Add(PatientModel patient)
        {
            ViewBag.Muncities = new SelectList(_context.Muncity, "Id", "Description", patient.MuncityId);
            if(patient.BarangayId != 0)
                ViewBag.Barangays = new SelectList(_context.Barangay, "Id", "Description", patient.BarangayId);
            if (ModelState.IsValid)
            {
                setPatients(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListPatients", "ViewPatients", new {name = patient.Fname, muncityId = patient.MuncityId, barangayId = patient.BarangayId });
            }
            ViewBag.CivilStatus = new SelectList(ListContainer.CivilStatus, "Key", "Value", patient.CivilStatus);
            ViewBag.PhicStatus = new SelectList(ListContainer.PhicStatus, "Key", "Value", patient.PhicStatus);
            return View(patient);
        }
        #endregion

        #region Update Patient

        public async Task<IActionResult> Update(int? id)
        {
            var patient = await _context.Patients.FindAsync(id);
            var muncities = _context.Muncity.Where(x => x.ProvinceId == patient.Province);
            var barangays = _context.Barangay.Where(x => x.MuncityId == patient.Muncity);
            ViewBag.Muncities = new SelectList(muncities, "Id", "Description", patient.Muncity);
            ViewBag.Barangays = new SelectList(barangays, "Id", "Description", patient.Brgy);
            ViewBag.PhicStatus = new SelectList(ListContainer.PhicStatus, "Key", "Value", patient.PhicStatus);
            ViewBag.Sex = new SelectList(ListContainer.Sex, "Key", "Value", patient.Sex);
            ViewBag.CivilStatus = new SelectList(ListContainer.CivilStatus, "Key", "Value", patient.CivilStatus);
            var patientModel = new PatientModel
            {
                PhicStatus = patient.PhicStatus,
                PhicId = patient.PhicStatus == "None"? "" : patient.PhicId,
                Fname = patient.Fname,
                Mname = patient.Mname,
                Lname = patient.Lname,
                DateOfBirth = patient.Dob,
                Sex = patient.Sex,
                CivilStatus = patient.CivilStatus,
                MuncityId = patient.Muncity,
                BarangayId = patient.Brgy
            };
            return PartialView(patientModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PatientModel model)
        {
            var patient = await SetUpdatePatient(model);
            if (ModelState.IsValid)
            {
                _context.Update(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListPatients", "ViewPatients", new { name = model.Fname, muncityId = model.MuncityId, barangayId = model.BarangayId });
            }
            var muncities = _context.Muncity.Where(x => x.ProvinceId == patient.Province);
            var barangays = _context.Barangay.Where(x => x.MuncityId == patient.Muncity);
            ViewBag.Muncities = new SelectList(muncities, "Id", "Description", patient.Muncity);
            ViewBag.Barangays = new SelectList(barangays, "Id", "Description", patient.Brgy);
            ViewBag.PhicStatus = new SelectList(ListContainer.PhicStatus, "Key", "Value", patient.PhicStatus);
            ViewBag.Sex = new SelectList(ListContainer.Sex, "Key", "Value", patient.Sex);
            ViewBag.CivilStatus = new SelectList(ListContainer.CivilStatus, "Key", "Value", patient.CivilStatus);

            return PartialView();
        }

        private async Task<Patients> SetUpdatePatient(PatientModel model)
        {
            var patient = await _context.Patients.FindAsync(model.Id);
            patient.PhicStatus = model.PhicStatus;
            patient.PhicId = model.PhicId;
            patient.Fname = model.Fname;
            patient.Mname = model.Mname;
            patient.Lname = model.Lname;
            patient.Dob = model.DateOfBirth;
            patient.Sex = model.Sex;
            patient.CivilStatus = model.CivilStatus;
            patient.Muncity = model.MuncityId;
            patient.Brgy = model.BarangayId;

            return patient;
        }

        #endregion  

        #region Refer Patient
        //GET: ReferPartial
        public IActionResult Refer(int? id)
        {
            var curPatient = from patient in _context.Patients where patient.Id == id
                             join province in _context.Province on patient.Province equals province.Id
                             join mun in _context.Muncity on patient.Muncity equals mun.Id into MUNCT
                             from muncity in MUNCT.DefaultIfEmpty()
                             join bar in _context.Barangay on patient.Brgy equals bar.Id into BARA
                             from barangay in BARA.DefaultIfEmpty()
                             from facility in _context.Facility
                             where facility.Id == UserFacility
                             join fprovince in _context.Province on facility.Province equals fprovince.Id
                             join fmunc in _context.Muncity on facility.Muncity equals fmunc.Id into FMUNCT
                             from fmuncity in FMUNCT.DefaultIfEmpty()
                             join fbar in _context.Barangay on facility.Brgy equals fbar.Id into FBARA
                             from fbarangay in FBARA.DefaultIfEmpty()
                             select new ReferPatientViewModel
                             {
                                 PatientId = patient.Id,
                                 Name = "".GetFullName(patient.Fname, patient.Mname, patient.Lname),
                                 Age = patient.Dob.ComputeAge(),
                                 Sex = patient.Sex,
                                 CivilStatus = patient.CivilStatus,
                                 PatientBarangay = barangay.Description,
                                 PatientMuncity = muncity.Description,
                                 PatientProvince = province.Description,
                                 PhicStatus = patient.PhicStatus,
                                 PhicId = patient.PhicId,
                                 FacilityName = facility.Name,
                                 FacilityBarangay = fbarangay.Description,
                                 FacilityMuncity = fmuncity.Description,
                                 FacilityProvince = fprovince.Description
                             };

            var referTo = _context.Facility
                .Where(x => x.Id != UserFacility)
                .Where(x => x.Province.Equals(UserProvince));

            ViewBag.ReferredTo = new SelectList(referTo, "Id", "Name");
            ViewBag.ClinicalStatuses = new SelectList(ListContainer.ClinicalStatus, "Key", "Value");
            ViewBag.SurveillanceCategories = new SelectList(ListContainer.SurveillanceCategory, "Key", "Value");

            return PartialView(curPatient.First());
        }



        //POst: ReferPartial Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Refer( ReferPatientViewModel model)
        {
            model.ReferredToMd = model.ReferredToMd == 0 ? 0 : model.ReferredToMd;
            if (ModelState.IsValid && model.Facility != 0 && model.Department != 0)
            {
                var patient = await setNormalPatientForm(model);
                var tracking = setNormalTracking(patient);
                var activity = SetNormalActivity(tracking);
                _context.Add(tracking);
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Referred", "ViewPatients");
            }
            else
            {
                ModelState.AddModelError("ReferredTo", "Please select a Facility.");
                ModelState.AddModelError("Department", "Please select a Department.");
            }
            var facility = _context.Facility.Single(x => x.Id.Equals(UserFacility));
            var referTo = _context.Facility
                .Where(x => x.Id != UserFacility)
                .Where(x => x.Province.Equals(UserProvince));

            ViewBag.ReferredTo = new SelectList(referTo, "Id", "Name", model.Facility);
            ViewBag.ClinicalStatuses = new SelectList(ListContainer.ClinicalStatus, "Key", "Value", model.ClinicalStatus);
            ViewBag.SurveillanceCategories = new SelectList(ListContainer.SurveillanceCategory, "Key", "Value", model.SurveillanceCategory);

            return PartialView(model);
        }
        #endregion

        #region Walkin Patient
        //GET: Walkin patient
        public async Task<IActionResult> Walkin(int? id)
        {
            var curPatient = from patient in _context.Patients
                             where patient.Id == id
                             join province in _context.Province on patient.Province equals province.Id
                             join mun in _context.Muncity on patient.Muncity equals mun.Id into MUNCT
                             from muncity in MUNCT.DefaultIfEmpty()
                             join bar in _context.Barangay on patient.Brgy equals bar.Id into BARA
                             from barangay in BARA.DefaultIfEmpty()
                             from facility in _context.Facility
                             where facility.Id == UserFacility
                             join fprovince in _context.Province on facility.Province equals fprovince.Id
                             join fmunc in _context.Muncity on facility.Muncity equals fmunc.Id into FMUNCT
                             from fmuncity in FMUNCT.DefaultIfEmpty()
                             join fbar in _context.Barangay on facility.Brgy equals fbar.Id into FBARA
                             from fbarangay in FBARA.DefaultIfEmpty()
                             select new ReferPatientViewModel
                             {
                                 PatientId = patient.Id,
                                 Name = "".GetFullName(patient.Fname, patient.Mname, patient.Lname),
                                 Age = patient.Dob.ComputeAge(),
                                 Sex = patient.Sex,
                                 CivilStatus = patient.CivilStatus,
                                 PatientBarangay = barangay.Description,
                                 PatientMuncity = muncity.Description,
                                 PatientProvince = province.Description,
                                 PhicStatus = patient.PhicStatus,
                                 PhicId = patient.PhicId,
                                 FacilityName = facility.Name,
                                 FacilityBarangay = fbarangay.Description,
                                 FacilityMuncity = fmuncity.Description,
                                 FacilityProvince = fprovince.Description
                             };
            var faciliyDepartment = await AvailableDepartments(UserFacility);
            var facilities = _context.Facility
                .Where(x => x.Id != UserFacility)
                .Where(x => x.Province.Equals(UserProvince));
            ViewBag.ReferringFacility = new SelectList(facilities, "Id", "Name");
            ViewBag.Departments = new SelectList(faciliyDepartment, "DepartmentId", "DepartmentName");

            return PartialView(curPatient.First());
        }
        //POST: Walkin Patient
        [HttpPost]
        public async Task<IActionResult> Walkin(ReferPatientViewModel model)
        {
            model.ReferredToMd = model.ReferredToMd == 0 ? 0 : model.ReferredToMd;
            if (ModelState.IsValid && model.Facility != 0 && model.Department != 0)
            {
                var patient = await setNormalPatientForm(model);
                var tracking = setWalkinTracking(patient);
                var activityReferred = SetReferredActivity(tracking);
                var activityAccepted = SetWalkinActivity(tracking);
                _context.Add(tracking);
                _context.Add(activityAccepted);
                _context.Add(activityReferred);
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListPatients", "ViewPatients");
            }
            else
            {
                ModelState.AddModelError("ReferringFacility", "Please select a Facility.");
                ModelState.AddModelError("Department", "Please Select a Department");
            }
            var walkin = await SetPatient(model.PatientId);
            var faciliyDepartment = await AvailableDepartments(UserFacility);
            var facility = _context.Facility.Find(UserFacility);
            var facilities = _context.Facility
                .Where(x => x.Id != UserFacility)
                .Where(x => x.Province.Equals(UserProvince));
            ViewBag.Patient = walkin;
            ViewBag.Facility = facility.Name;
            ViewBag.FacilityAddress = "";
            ViewBag.ReferringFacility = new SelectList(facilities, "Id", "Name", model.Facility);
            ViewBag.Departments = new SelectList(faciliyDepartment, "DepartmentId", "DepartmentName");
            return PartialView(model);
        }
        #endregion

        #region Pregnant Refer Patient
        //GET: Pregnant Refer
        public async Task<IActionResult> PregnantRefer(int? id)
        {
            var patient = await SetPatient(id);
            var facilities = _context.Facility
                .Where(x => x.Id != UserFacility && x.Province == UserProvince);
            ViewBag.Patient = patient;
            ViewBag.Facility = _context.Facility.Find(UserFacility).Name;
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            return PartialView();
        }
        //POST: Pregnant Refer
        [HttpPost]
        public async Task<IActionResult> PregnantRefer([Bind] PregnantReferViewModel model)
        {
            var patient = await SetPatient(model.PatientId);
            var facilities = _context.Facility
                .Where(x => x.Id != UserFacility && x.Province == UserProvince);
            if (ModelState.IsValid)
            {
                var pregnantForm = await SetPregnantForm(model, _type.Value.REFER);
                var tracking = await PregnantTracking(pregnantForm, _type.Value.REFER);
                var activity = await PregnantActivity(tracking, _type.Value.REFER);
                await _context.AddAsync(tracking);
                await _context.AddAsync(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListPatients", "ViewPatients");
            }
            else
            {
                ModelState.AddModelError("ReferredTo", "Please select a Facility.");
                ModelState.AddModelError("Department", "Please select a Department.");
                ModelState.AddModelError("WomanMajorFindings", "This field is required.");
                ModelState.AddModelError("WomanInformationGiven", "This field is required.");
            }
            ViewBag.Patient = patient;
            ViewBag.Facility = _context.Facility.Find(UserId).Name;
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            return PartialView();
        }
        #endregion

        #region Pregnant Walkin Patient
        //GET: Pregnant Walkin
        public async Task<IActionResult> PregnantWalkin(int? id)
        {
            var patient = await SetPatient(id);
            var facility = _context.Facility.Find(UserFacility);
            var facilityDepartment = await AvailableDepartments(UserFacility);
            var facilities = _context.Facility
                .Where(x => x.Id != UserFacility && x.Province == UserProvince);
            ViewBag.Patient = patient;
            ViewBag.Facility = facility.Name;
            ViewBag.FacilityAddress = "";
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            ViewBag.Departments = new SelectList(facilityDepartment, "DepartmentId", "DepartmentName");
            return PartialView();
        }
        //POST: Pregnant Walkin
        [HttpPost]
        public async Task<IActionResult> PregnantWalkin([Bind]PregnantReferViewModel model)
        {
            var patient = await SetPatient(model.PatientId);
            var facilities = _context.Facility
                .Where(x => x.Id != UserFacility && x.Province == UserProvince);
            if (ModelState.IsValid)
            {
                var pregnantForm = await SetPregnantForm(model,_type.Value.WALKIN);
                var tracking = await PregnantTracking(pregnantForm, _type.Value.WALKIN);
                var activity = await PregnantActivity(tracking, _type.Value.WALKIN);
                await _context.AddAsync(tracking);
                await _context.AddAsync(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListPatients", "ViewPatients");
            }
            else
            {
                ModelState.AddModelError("ReferredTo", "Please select a Facility.");
                ModelState.AddModelError("Department", "Please select a Department.");
                ModelState.AddModelError("WomanMajorFindings", "This field is required.");
                ModelState.AddModelError("WomanInformationGiven", "This field is required.");
            }
            ViewBag.Patient = patient;
            ViewBag.Facility = _context.Facility.Find(UserId).Name;
            ViewBag.Facilities = new SelectList(facilities, "Id", "Name");
            return PartialView();
        }
        #endregion

        #region Helpers
        private async Task<Activity> PregnantActivity(Tracking model, string type)
        {
            var walkin = type.Equals(_type.Value.WALKIN);
            if(walkin)
            {
                var referredActivity = new Activity
                {
                    Code = model.Code,
                    PatientId = model.PatientId,
                    DateReferred = model.DateReferred,
                    DateSeen = model.DateSeen,
                    ReferredFrom = model.ReferredFrom,
                    ReferredTo = model.ReferredTo,
                    DepartmentId = model.DepartmentId,
                    ReferringMd = model.ReferringMd,
                    ActionMd = 0,
                    Status = _status.Value.REFERRED,
                    Remarks = model.Remarks,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                await _context.AddAsync(referredActivity);
            }
            var activity = new Activity
            {
                Code = model.Code,
                PatientId = model.PatientId,
                DateReferred = model.DateReferred,
                DateSeen = model.DateSeen,
                ReferredFrom = model.ReferredFrom,
                ReferredTo = model.ReferredTo,
                DepartmentId = model.DepartmentId,
                ReferringMd = model.ReferringMd,
                ActionMd = model.ActionMd,
                Status = model.Status,
                Remarks = walkin? "Walk-In Patient" : model.Remarks,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return activity;
        }
        private Task<Tracking> PregnantTracking(PregnantForm model, string type)
        {
            var walkin = type.Equals(_type.Value.WALKIN);
            var tracking = new Tracking
            {
                Code = model.Code,
                PatientId = model.PatientWomanId,
                DateReferred = model.ReferredDate,
                DateTransferred = default,
                DateAccepted = default,
                DateArrived = default,
                DateSeen = default,
                ReferredFrom = model.ReferringFacility,
                ReferredTo = model.ReferredTo,
                DepartmentId = model.DepartmentId,
                ReferringMd = walkin? 0 : model.ReferredBy,
                ActionMd = walkin? UserId : 0,
                Status = walkin? _status.Value.ACCEPTED : _status.Value.REFERRED,
                Type = _type.Value.PREGNANT,
                Walkin = walkin ? "yes" : "no",
                FormId = model.Id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return Task.FromResult(tracking);
        }
        private async Task<Patients> SetBabyPatient(PregnantReferViewModel model, Patients mother)
        {
            var baby = new Patients
            {
                UniqueId = RemoveWhiteSpace(model.BabyFirstName + model.BabyMiddleName + model.BabyLastName) + RemoveDash(((DateTime)model.BabyDateOfBirth).ToString("yyyy/MM/dd")) + mother.Brgy.ToString(),
                Fname = model.BabyFirstName.Trim(),
                Mname = model.BabyMiddleName.Trim(),
                Lname = model.BabyLastName.Trim(),
                Dob = (DateTime)model.BabyDateOfBirth,
                Sex = "",
                CivilStatus = "Single",
                PhicStatus = null,
                PhicId = "None",
                Brgy = mother.Brgy,
                Muncity = mother.Muncity,
                Province = mother.Province,
                Address = "",
                TsekapPatient = 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _context.AddAsync(baby);
            await _context.SaveChangesAsync();
            return baby;
        }
        private async Task<PregnantForm> SetPregnantForm(PregnantReferViewModel model, string type)
        {
            var walkin = type.Equals(_type.Value.WALKIN);
            Patients mother = _context.Patients.Find(model.PatientId);
            Patients baby = null;
            if(!string.IsNullOrEmpty(model.BabyFirstName))
            {
                baby = await SetBabyPatient(model, mother);
            }
            var pregnantForm = new PregnantForm
            {
                UniqueId = model.PatientId + "-" + UserFacility + "-" + DateTime.Now.ToString("yyMMddhh"),
                Code = DateTime.Now.ToString("yyMMdd") + "-" + UserFacility.ToString().PadLeft(3, '0') + "-" + DateTime.Now.ToString("hhmmss"),
                ReferringFacility = walkin? model.ReferredTo : UserFacility,
                ReferredTo = walkin? UserFacility : model.ReferredTo,
                ReferredBy = UserId,
                RecordNo = model.RecordNumber?? "",
                ReferredDate = DateTime.Now,
                DepartmentId = model.Department,
                ArrivalDate = default,
                HealthWorker = model.HealthWorker?? "",
                PatientWomanId = model.PatientId,
                WomanReason = model.WomanMainReason,
                WomanMajorFindings = model.WomanMajorFindings,
                WomanBeforeTreatment = model.WomanBeforeTreatmentGiven,
                WomanBeforeGivenTime = model.WomanBeforeDateTimeGiven ?? default,
                WomanDuringTransport = model.WomanDuringTreatmentGiven,
                WomanTransportGivenTime = model.WomanDuringDateTimeGiven?? default,
                WomanInformationGiven = model.WomanInformationGiven,
                PatientBabyId = baby == null? 0 : baby.Id,
                BabyReason = model.BabyMainReason,
                BabyMajorFindings = model.BabyMajorFindings,
                BabyLastFeed = model.BabyLastFeed?? default,
                BabyBeforeTreatment = model.BabyBeforeTreatmentGiven,
                BabyBeforeGivenTime = model.BabyBeforeDateTimeGiven?? default,
                BabyDuringTransport = model.BabyDuringTreatmentGiven,
                BabyTransportGivenTime = model.BabyDuringDateTimeGiven?? default,
                BabyInformationGiven = model.BabyInformationGiven,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var babyMother = new Baby
            {
                BabyId = baby == null? 0 : baby.Id,
                MotherId = model.PatientId,
                Weight = model.BabyBirthWeight ?? default,
                GestationalAge = model.GestationalAge ?? default,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _context.AddAsync(babyMother);
            await _context.AddAsync(pregnantForm);
            await _context.SaveChangesAsync();
            return pregnantForm;
        }
        private Task<PatientViewModel> SetPatient(int? id)
        {
            var patient = _context.Patients.Find(id);

            var patientModel = new PatientViewModel
            {
                Id = patient.Id,
                Name = GlobalFunctions.GetFullName(patient),
                Age = patient.Dob.ComputeAge(),
                Sex = patient.Sex,
                CivilStatus = patient.CivilStatus,
                Address = "",
                PhicStatus = patient.PhicStatus,
                PhicId = patient.PhicId
            };
            return Task.FromResult(patientModel);
        }
        private Task<IQueryable<SelectDepartment>> AvailableDepartments(int facilityId)
        {
            var departments = _context.Department
                 .Select(x => new SelectDepartment
                 {
                     DepartmentId = x.Id,
                     DepartmentName = x.Description
                 });
            var availableDepartments = _context.Users
                .Where(x => (x.FacilityId == UserFacility))
                .Select(x => x.DepartmentId)
                .Distinct()
                .Join(
                    _context.Department,
                    user => user,
                    department => department.Id,
                    (user, department) =>
                        new SelectDepartment
                        {
                            DepartmentId = user,
                            DepartmentName = department.Description
                        }
                );
            return Task.FromResult(availableDepartments);
        }
        public PatientForm setNormalPatientForm(WalkinPatientViewModel model)
        {
            PatientForm patient = new PatientForm
            {
                UniqueId = model.PatientId + "-" + UserFacility + "-" + DateTime.Now.ToString("yyMMddhh"),
                Code = DateTime.Now.ToString("yyMMdd") + "-" + UserFacility.ToString().PadLeft(3, '0') + "-" + DateTime.Now.ToString("hhmmss"),
                ReferringFacility = model.Facility,
                ReferredTo = UserFacility,
                DepartmentId = model.Department,
                TimeReferred = DateTime.Now,
                TimeTransferred = default,
                PatientId = model.PatientId,
                CaseSummary = model.CaseSummary,
                RecoSummary = model.SummaryReco,
                Diagnosis = model.Diagnosis,
                Reason = model.Reason,
                ReferringMd = 0,
                ReferredMd = UserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return patient;
        }

        public async Task<PatientForm> setNormalPatientForm(ReferPatientViewModel model)
        {
            PatientForm patient = new PatientForm
            {
                UniqueId = model.PatientId + "-" + UserFacility + "-" + DateTime.Now.ToString("yyMMddhh"),
                Code = DateTime.Now.ToString("yyMMdd") + "-" + UserFacility.ToString().PadLeft(3, '0') + "-" + DateTime.Now.ToString("hhmmss"),
                ReferringFacility = UserFacility,
                ReferredTo = model.Facility,
                DepartmentId = model.Department,
                TimeReferred = DateTime.Now,
                TimeTransferred = default,
                PatientId = model.PatientId,
                CaseSummary = model.CaseSummary,
                RecoSummary = model.SummaryReco,
                Diagnosis = model.Diagnosis,
                Reason = model.Reason,
                ReferringMd = UserId,
                ReferredMd = model.ReferredToMd,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CovidNumber = model.CovidNumber,
                ReferClinicalStatus = model.ClinicalStatus,
                ReferSurCategory = model.SurveillanceCategory
            };
            await _context.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public Tracking setWalkinTracking(PatientForm patientForm)
        {
            Tracking tracking = new Tracking
            {
                Code = patientForm.Code,
                PatientId = patientForm.PatientId,
                DateReferred = patientForm.TimeReferred,
                DateTransferred = patientForm.TimeTransferred,
                DateAccepted = DateTime.Now,
                DateArrived = default,
                DateSeen = DateTime.Now,
                ReferredFrom = patientForm.ReferringFacility,
                ReferredTo = patientForm.ReferredTo,
                DepartmentId = patientForm.DepartmentId,
                ReferringMd = patientForm.ReferringMd,
                ActionMd = patientForm.ReferredMd,
                Remarks = patientForm.Reason,
                Type = "normal",
                Status = _status.Value.ACCEPTED,
                FormId = patientForm.Id,
                Walkin = "yes",
                ModeTransportation = "",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return tracking;
        }

        public Tracking setNormalTracking(PatientForm patientForm)
        {
            var tracking = new Tracking
            {
                Code = patientForm.Code,
                PatientId = patientForm.PatientId,
                DateReferred = patientForm.TimeReferred,
                DateTransferred = patientForm.TimeTransferred,
                DateAccepted = default,
                DateArrived = default,
                DateSeen = default,
                ReferredFrom = patientForm.ReferringFacility,
                ReferredTo = patientForm.ReferredTo,
                DepartmentId = patientForm.DepartmentId,
                ReferringMd = patientForm.ReferringMd,
                ActionMd = patientForm.ReferredMd,
                Remarks = patientForm.Reason,
                Type = "normal",
                Status = _status.Value.REFERRED,
                FormId = patientForm.Id,
                Walkin = "no",
                ModeTransportation = "",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return tracking;
        }

        private Activity SetReferredActivity(Tracking tracking)
        {
            Activity activity = new Activity
            {
                Code = tracking.Code,
                PatientId = tracking.PatientId,
                DateReferred = tracking.DateReferred,
                DateSeen = tracking.DateSeen,
                ReferredFrom = tracking.ReferredFrom,
                ReferredTo = tracking.ReferredTo,
                DepartmentId = tracking.DepartmentId,
                ReferringMd = tracking.ReferringMd,
                ActionMd = 0,
                Remarks = tracking.Status,
                Status = _status.Value.REFERRED,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return activity;
        }

        public Activity SetWalkinActivity(Tracking tracking)
        {
            Activity activity = new Activity
            {
                Code = tracking.Code,
                PatientId = tracking.PatientId,
                DateReferred = tracking.DateReferred,
                DateSeen = tracking.DateSeen,
                ReferredFrom = tracking.ReferredFrom,
                ReferredTo = tracking.ReferredTo,
                DepartmentId = tracking.DepartmentId,
                ReferringMd = tracking.ReferringMd,
                ActionMd = UserId,
                Remarks = "Walk-In Patient",
                Status = tracking.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return activity;
        }


        public Activity SetNormalActivity(Tracking tracking)
        {
            Activity activity = new Activity
            {
                Code = tracking.Code,
                PatientId = tracking.PatientId,
                DateReferred = tracking.DateReferred,
                DateSeen = tracking.DateSeen,
                ReferredFrom = tracking.ReferredFrom,
                ReferredTo = tracking.ReferredTo,
                DepartmentId = tracking.DepartmentId,
                ReferringMd = tracking.ReferringMd,
                ActionMd = UserId,
                Remarks = tracking.Remarks,
                Status = tracking.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return activity;
        }


        public void setPatients(PatientModel patients)
        {
            var currPatient = _context.Patients.FirstOrDefault(x =>
                x.Fname == patients.Fname &&
                x.Mname == patients.Mname &&
                x.Lname == patients.Lname &&
                x.Dob == patients.DateOfBirth &&
                x.Sex == patients.Sex &&
                x.Province == UserProvince &&
                x.Muncity == patients.MuncityId &&
                x.Brgy == patients.BarangayId);

            if (currPatient == null)
            {
                var patient = new Patients
                {
                    UniqueId = RemoveWhiteSpace(patients.Fname + patients.Mname + patients.Lname) + RemoveDash(patients.DateOfBirth.ToString("yyyy/MM/dd")) + patients.BarangayId.ToString(),
                    Fname = patients.Fname.Trim(),
                    Mname = patients.Mname.Trim(),
                    Lname = patients.Lname.Trim(),
                    Dob = patients.DateOfBirth,
                    Sex = patients.Sex,
                    CivilStatus = patients.CivilStatus,
                    PhicId = string.IsNullOrEmpty(patients.PhicId) ? "None" : patients.PhicId,
                    PhicStatus = patients.PhicStatus,
                    Province = UserProvince,
                    Muncity = patients.MuncityId,
                    Brgy = patients.BarangayId,
                    Address = "",
                    TsekapPatient = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(patient);
            }
            
        }

        public string fixString(string name)
        {
            name = name.Trim().ToLower();

            name = name.First().ToString().ToUpper() + name.Substring(1);

            return name;
        }

        public string RemoveWhiteSpace(string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        public string RemoveDash(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));
        public int UserDepartment => int.Parse(User.FindFirstValue("Department"));
        public int UserProvince => int.Parse(User.FindFirstValue("Province"));
        public int UserMuncity =>int.Parse(User.FindFirstValue("Muncity"));
        public int UserBarangay => int.Parse(User.FindFirstValue("Barangay"));
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        #endregion
    }
}