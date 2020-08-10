using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.Models;
using Referral2.Models.ViewModels.Users;

namespace Referral2.Controllers
{
    [Authorize(Policy = "EOC")]
    public class EocController : Controller
    {
        private readonly ReferralDbContext _context;
        private readonly IOptions<ReferralRoles> _roles;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public partial class GraphModel
        {
            public int[] Facilities { get; set; }
            public string DateRange { get; set; }
        }

        public EocController(ReferralDbContext context, IOptions<ReferralRoles> roles)
        {
            _context = context;
            _roles = roles;
        }
        #region DASHBOARD
        public async Task<IActionResult> Dashboard()
        {
            var inventories = await _context.Inventory
                .Include(x => x.Facility)
                .ToListAsync();
            return View(inventories);
        }
        #endregion
        #region GRAPH
        [HttpGet]
        public async Task<IActionResult> Graph()
        {
            StartDate = DateTime.Now.Date;
            EndDate = StartDate.AddDays(1).AddSeconds(-1);
            var selFacilities = await _context.Facility.Where(x => !x.Name.Contains("RHU")).ToListAsync();
            ViewBag.Facilties = new SelectList(selFacilities, "Id", "Name");
            ViewBag.StartDate = StartDate.ToString("MM/dd/yyyy");
            ViewBag.EndDate = EndDate.ToString("MM/dd/yyyy");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GraphPartial(GraphModel model)
        {
            StartDate = DateTime.ParseExact(model.DateRange.Substring(0, model.DateRange.IndexOf(" ") + 1).Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            EndDate = DateTime.ParseExact(model.DateRange.Substring(model.DateRange.LastIndexOf(" ")).Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1).AddSeconds(-1);

            var logs = await _context.InventoryLogs
                .Include(x => x.Facility)
                .Include(x=>x.Inventory)
                .ToListAsync();

            var inventories = new List<InventoryLogs>();

            foreach(var id in model.Facilities)
            {
                inventories.AddRange(logs.Where(x => x.FacilityId == id && x.CreatedAt >= StartDate && x.CreatedAt < EndDate));
            }

            ViewBag.Colspan = (int)EndDate.Subtract(StartDate).TotalDays;
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;
            return PartialView(inventories);
        }
        #endregion
        #region WHOS ONLINE
        public async Task<IActionResult> WhosOnline()
        {
            var onlineUsers = await _context.User
                .Where(x=>x.Level != "admin" && x.Level != "eoc")
                .Where(x=>x.Login.Any(x=>x.Login1 >=DateTime.Now.Date && x.Logout != default))
                .Select(x => new WhosOnlineModel
                {
                    DoctorName = x.Level.Equals(_roles.Value.DOCTOR)? x.GetMDFullName() : x.GetFullName(),
                    FacilityAbrv = x.Facility.Abbr,
                    Contact = x.ContactNo,
                    Department = x.Department.Description,
                    LoginStatus = x.Login.OrderByDescending(x=>x.UpdatedAt).FirstOrDefault().Status.Equals("login"),
                    LoginTime = x.Login.OrderByDescending(x=>x.UpdatedAt).FirstOrDefault().Login1
                })
                .ToListAsync();

            var onlineFacilities = await _context.Facility
                .Include(x => x.Province)
                .Include(x => x.User)
                .Where(x => x.ProvinceId == 2 && x.Id != 63)
                .Select(x => new FacilitiesOnline
                {
                    Name = x.Name,
                    Province = x.Province.Description,
                    Status = x.User.Any(x => x.Login.Any(x=>x.Login1 >= DateTime.Now.Date && x.Status == "login"))
                })
                .OrderBy(x=>x.Name)
                .ToListAsync();

            var model = new UserFacilityOnline
            {
                Facilities = onlineFacilities,
                Users = onlineUsers
            };

            return View(model);
        }
        #endregion
        #region HELPERS
        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public int UserFacility => int.Parse(User.FindFirstValue("Facility"));
        public int? UserDepartment => string.IsNullOrEmpty(User.FindFirstValue("Department")) ? null : (int?)int.Parse(User.FindFirstValue("Department"));
        public int UserProvince => int.Parse(User.FindFirstValue("Province"));
        public int UserMuncity => int.Parse(User.FindFirstValue("Muncity"));
        public int UserBarangay => int.Parse(User.FindFirstValue("Barangay"));
        public string UserUsername => User.FindFirstValue(ClaimTypes.Name);
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        #endregion
    }
}
