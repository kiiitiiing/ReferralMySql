using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.Models;
using Referral2.Models.ViewModels;
using System.Security.Claims;
using MoreLinq.Extensions;
using Microsoft.Extensions.Options;
using Referral2.MyData;

namespace Referral2.Controllers
{
    public class NoReloadController : Controller
    {
        //private readonly ReferralDbContext _context;
        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;
        private readonly MySqlReferralContext _context;

        public NoReloadController(MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status)
        {
            _context = context;
            _roles = roles;
            _status = status;
        }

        public partial class SelectAddress
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }

        public partial class SelectAddressDepartment
        {
            public SelectAddressDepartment(string address, IEnumerable<SelectDepartment> departments)
            {
                Address = address;
                Departments = departments;
            }
            public string Address { get; set; }
            public IEnumerable<SelectDepartment> Departments { get; set; }
        }

        public partial class SelectUser
        {
            public int MdId { get; set; }
            public string DoctorName { get; set; }
        }

        [HttpGet]
        public int NumberNotif()
        {
            var incoming = _context.Tracking
                .Where(x => x.ReferredTo == UserFacility && x.UpdatedAt.Value.Date >= DateTimeOffset.Now.Date);

            return incoming.Count();
        }

        [HttpGet] 
        [Route("{controller}/{action}/{facilityId}")]
        public List<SelectDepartment> AvailableDepartments(int facilityId)
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

        [HttpGet]
        public string GetTableCount (string code, string type)
        {
            int ctr = 0;
            if(type == "seen")
            {
                ctr = _context.Seen.Where(x => x.TrackingId == int.Parse(code)).Count();
            }
            else if( type == "call")
            {
                ctr = _context.Activity.Where(x => x.Code.Equals(code) && x.Status.Equals(_status.Value.CALLING)).Count();
            }
            else if( type == "issue")
            {
                ctr = _context.Issue.Where(x => x.TrackingId.Equals(int.Parse(code))).Count();
            }
            else if(type == "feedback")
            {
                ctr = _context.Feedback.Where(x => x.Code.Equals(code)).Count();
            }

            return ctr == 0 ? "" : ctr.ToString();
        }

        [HttpGet]
        [Route("{controller}/{action}/{muncityId}")]
        public List<SelectAddress> FilteredBarangay(int? muncityId)
        {
            var filteredBarangay =  _context.Barangay.Where(x => x.MuncityId.Equals(muncityId))
                                                     .Select(y => new SelectAddress
                                                     {
                                                         Id = y.Id,
                                                         Description = y.Description
                                                     }).ToList();

            return filteredBarangay;
        }
        
        [HttpGet]
        [Route("{controller}/{action}/{status}")]
        public void ChangeLoginStatus(string status)
        {
            var currentUser = _context.Users.Find(UserId);
            var login = new Login
            {
                UserId = UserId,
                Login1 = DateTime.Now,
                Status = status == "onDuty" ? "login" : "login_off",
                Logout = default,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            currentUser.LoginStatus = status == "onDuty" ? "login" : "login_off";
            currentUser.UpdatedAt = DateTime.Now;
            _context.Add(login);
            _context.Update(currentUser);
            _context.SaveChanges();
        }

        //  FilterDepartment?facilityId=
        [HttpGet]
        [Route("{controller}/{action}/{facilityId}")]
        public SelectAddressDepartment FilterDepartment(int? facilityId)
        {
            var facility = _context.Facility
                .Join(
                    _context.Province,
                    f => f.Province,
                    p => p.Id,
                    (f, p) => new { f = f, p = p })
                .Join(
                    _context.Muncity,
                    temp0 => temp0.f.Muncity,
                    m => m.Id,
                    (temp0, m) => new { temp0 = temp0, m = m })
                .Join(
                    _context.Barangay,
                    temp1 => temp1.temp0.f.Brgy,
                    b => b.Id,
                    (temp1, b) => new { temp1 = temp1, b = b })
                .FirstOrDefault(x => x.temp1.temp0.f.Id == facilityId);
            if (facility == null)
                return null;
            string facilityAddress = facility.temp1.temp0.f.Address == null ? "" : facility.temp1.temp0.f.Address + ", ";
            string address = facilityAddress +
                (string.IsNullOrEmpty(facility.b.Description) ? "" : facility.b.Description + " ,") +
                (string.IsNullOrEmpty(facility.temp1.m.Description) ? "" : facility.temp1.m.Description + " ,") +
                (string.IsNullOrEmpty(facility.temp1.temp0.p.Description) ? "" : facility.temp1.temp0.p.Description);


            var departments = _context.Department.Select(x => new SelectDepartment
            {
                DepartmentId = x.Id,
                DepartmentName = x.Description
            });

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

            SelectAddressDepartment selectAddress = new SelectAddressDepartment(address, faciliyDepartment);

            return selectAddress;
        }

        public async Task<int> SupportReport()
        {
            var incomingCtr = await _context.Tracking
                .Where(x=>x.Status == _status.Value.SEEN || x.Status == _status.Value.REFERRED)
                .Where(x => x.ReferredTo == UserFacility && x.DateReferred >= DateTime.Now.AddDays(-3)).CountAsync();

            return incomingCtr;
        }

        public async Task<string> GetFaciliyAddress(int? id)
        {
            var facility = await _context.Facility
                .Join( 
                    _context.Province,
                    f => f.Province,
                    p => p.Id,
                    (f, p) => new { f = f, p = p })
                .Join(
                    _context.Muncity,
                    temp0 => temp0.f.Muncity,
                    m => m.Id,
                    (temp0, m) => new { temp0 = temp0, m = m })
                .Join(
                    _context.Barangay,
                    temp1 => temp1.temp0.f.Brgy,
                    b => b.Id,
                    (temp1, b) => new { temp1 = temp1, b = b })
                .FirstOrDefaultAsync(x => x.temp1.temp0.f.Id == id);
            if (facility == null)
                return null;
            string facilityAddress = facility.temp1.temp0.f.Address == null ? "" : facility.temp1.temp0.f.Address + ", ";
            string address = facilityAddress +
                (string.IsNullOrEmpty(facility.b.Description) ? "" : facility.b.Description + " ,") +
                (string.IsNullOrEmpty(facility.temp1.m.Description) ? "" : facility.temp1.m.Description + " ,") +
                (string.IsNullOrEmpty(facility.temp1.temp0.p.Description) ? "" : facility.temp1.temp0.p.Description);

            return address;
        }

        [HttpGet]
        [Route("{controller}/{action}/{id}")]
        public async Task<List<SelectAddress>> GetMuncities(int? id)
        {
            var muncities = await _context.Muncity
                .Where(x => x.ProvinceId.Equals(id))
                .Select(x => new SelectAddress
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .ToListAsync();

            return muncities;
        }

        public async Task<List<SelectAddress>> GetBarangays(int? id)
        {
            var barangays = await _context.Barangay
                .Where(x => x.MuncityId.Equals(id))
                .Select(x => new SelectAddress
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .ToListAsync();

            return barangays;
        }

        [HttpGet]
        [Route("{controller}/{action}/{facilityId}/{departmentId}")]
        public List<SelectUser> FilterUser(int facilityId, int departmentId)
        {
            var getUser = _context.Users.Where(x => x.FacilityId.Equals(facilityId) && x.DepartmentId.Equals(departmentId) && x.Level.Equals(_roles.Value.DOCTOR))
                .Select(y => new SelectUser
                {
                    MdId = y.Id,
                    DoctorName = ("Dr. " + y.Fname.CheckName() + " " + y.Mname.CheckName() + " " + y.Lname).NameToUpper() + " - " + y.Contact.CheckName()
                }); ;

            return getUser.ToList();
        }

        public List<SelectUser> FilterUsersWalkin(int? departmentId)
        {
            var getUser = _context.Users.Where(x => x.FacilityId.Equals(UserFacility) && x.DepartmentId.Equals(departmentId) && x.Level.Equals(_roles.Value.DOCTOR))
                .Select(y => new SelectUser
                {
                    MdId = y.Id,
                    DoctorName = string.IsNullOrEmpty(y.Contact) ? "Dr. " + y.Fname + " " + y.Mname + " " + y.Lname + " - N/A" : "Dr. " + y.Fname + " " + y.Mname + " " + y.Lname + " - " + y.Contact
                });

            return getUser.ToList();
        }

        [HttpGet]
        [Route("{controller}/{action}/{code}")]
        public async Task<int> RecoCount(string code)
        {
            var recoCtr = await _context.Feedback.Where(x => x.Code == code).CountAsync();

            return recoCtr;
        }

        [HttpGet]
        [Route("{controller}/{action}/{level}")]
        public DashboardViewModel DashboardValues(string level)
        {
            var referred = new int[12];
            var accepted = new int[12];
            var redirected = new int[12];
            int month = 1;
            IQueryable<MyModels.Activity> activities = null;

            if(!level.Equals(_roles.Value.ADMIN))
                activities = _context.Activity.Where(x => x.DateReferred.Year.Equals(DateTime.Now.Year) && x.ReferredTo.Equals(UserFacility));
            else
                activities = _context.Activity.Where(x => x.DateReferred.Year.Equals(DateTime.Now.Year));
            for (int x = 0; x < 12; x++)
            {
                referred[x] = (activities.Where(i => i.DateReferred.Month.Equals(month) && (i.Status.Equals(_status.Value.REFERRED))).Count());
                accepted[x] = (activities.Where(i => i.DateReferred.Month.Equals(month) && (i.Status.Equals(_status.Value.ACCEPTED) || i.Status.Equals(_status.Value.ARRIVED) || i.Status.Equals(_status.Value.ADMITTED))).Count());
                redirected[x] = (activities.Where(i => i.DateReferred.Month.Equals(month) && (i.Status.Equals(_status.Value.REJECTED) || i.Status.Equals(_status.Value.TRANSFERRED))).Count());
                month++;
            }
            var adminDashboard = new DashboardViewModel(accepted, redirected, referred);
            return adminDashboard;
        }

        #region HELPERS

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