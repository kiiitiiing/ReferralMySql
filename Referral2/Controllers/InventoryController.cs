using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Referral2.Data;
using Referral2.Models;
using Referral2.Models.ViewModels.Inventory;

namespace Referral2.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly ReferralDbContext _context;

        public InventoryController(ReferralDbContext context)
        {
            _context = context;
        }

        #region INVENTORY
        [HttpGet]
        public async Task<IActionResult> FacilityInventory(string name, int? page)
        {
            ViewBag.Search = name;

            var inventory = _context.Inventory
                .Where(x => x.FacilityId == UserFacility)
                .Select(x => new InventoryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Capacity = x.Capacity,
                    Occupied = x.Occupied,
                    Available = x.Capacity - x.Occupied
                });

            if(!string.IsNullOrEmpty(name))
            {
                inventory = inventory.Where(x => x.Name.Contains(name));
            }

            int size = 10;


            return View(await PaginatedList<InventoryModel>.CreateAsync(inventory, page ?? 1, size));
        }
        #endregion
        #region UPDATE INVENTORY
        [HttpGet]
        public async Task<IActionResult> UpdateInventory(int id)
        {
            var inventory = await _context.Inventory.FirstOrDefaultAsync(x => x.Id == id);

            return PartialView(GetInventory(inventory));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInventory(InventoryModel model)
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors);
            if(ModelState.IsValid)
            {
                await SetInventory(model);
                return PartialView(model);
            }
            ViewBag.Errors = errors;

            return PartialView(model);
        }
        #endregion

        #region HELPERS
        public InventoryModel GetInventory(Inventory model)
        {
            var item = new InventoryModel
            {
                Id = model.Id,
                Name = model.Name,
                Capacity = model.Capacity,
                Occupied = model.Occupied
            };

            return item;
        }
        public async Task SetInventory(InventoryModel model)
        {
            var inventory = _context.Inventory.Find(model.Id);
            var logs = new InventoryLogs
            {
                FacilityId = inventory.FacilityId,
                EncodedBy = UserId,
                InventoryId = inventory.Id,
                Capacity = model.Capacity,
                Occupied = model.Occupied,
                Available = model.Capacity - model.Occupied,
                TimeCreated = DateTime.Now.TimeOfDay,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            inventory.Capacity = model.Capacity;
            inventory.Occupied = model.Occupied;
            inventory.FacilityId = UserFacility;
            inventory.EncodedBy = UserId;
            inventory.UpdatedAt = DateTime.Now;

            _context.Add(logs);
            _context.Update(inventory);
            await _context.SaveChangesAsync();
        }

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
