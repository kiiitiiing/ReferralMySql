using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.Models;
using Referral2.Models.ViewModels;
using Microsoft.Extensions.Options;

namespace Referral2.Controllers
{
    [Authorize(Policy = "doctor")]
    public class HomeController : Controller
    {
        public readonly ReferralDbContext _context;
        private readonly IOptions<ReferralStatus> _status;


        public HomeController( ReferralDbContext context, IOptions<ReferralStatus> status)
        {
            _context = context;
            _status = status;
        }
/*
        public HomeController()
        {

        }*/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region HELPERS

        #endregion
    }
}
