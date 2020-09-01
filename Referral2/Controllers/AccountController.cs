using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Referral2.Data;
using Referral2.Services;
using Referral2.MyModels;
using Referral2.Models.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Referral2.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Referral2.MyData;

namespace Referral2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        private readonly MySqlReferralContext _context;

        private readonly IOptions<ReferralRoles> _roles;
        private readonly IOptions<ReferralStatus> _status;

        public AccountController(IUserService userService, IConfiguration configuration, MySqlReferralContext context, IOptions<ReferralRoles> roles, IOptions<ReferralStatus> status )
        {
            _userService = userService;
            _configuration = configuration;
            _context = context;
            _roles = roles;
            _status = status;
        }

        public partial class ChangeLoginViewModel
        {
            public int Id { get; set; }
            public string UserLastname { get; set; }
        }

        public IActionResult ModalLoading()
        {
            return PartialView();
        }
        #region SWITCH USER
        [Authorize(Policy = "Doctor")]
        public IActionResult SwitchUser()
        {
            var users = _context.Users
                .Where(x => x.FacilityId.Equals(UserFacility) && x.Id != UserId && x.Level.Equals(_roles.Value.DOCTOR))
                .Select(x => new ChangeLoginViewModel
                {
                    Id = x.Id,
                    UserLastname = x.GetFullName()  
                });

            ViewBag.Users = new SelectList(users, "Id", "UserLastname", UserId);
            return PartialView("~/Views/Account/SwitchUser.cshtml");
        }

        [Authorize(Policy = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> SwitchUser([Bind] SwitchUserModel model)
        {
            var users = _context.Users
                .Where(x => x.FacilityId.Equals(UserFacility) && x.Level == _roles.Value.DOCTOR)
                .Select(x => new ChangeLoginViewModel
                {
                    Id = x.Id,
                    UserLastname = x.GetFullName()
                });
            if (ModelState.IsValid)
            {
                var (isValid, user) = await _userService.SwitchUserAsync(model.Id, model.Password);

                if (isValid)
                {
                    await ChangeUser();
                    await LoginAsync(user, false);
                    CreateLogin(user.Id);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("Password", "Wrong Password.");
                }
            }
            ViewBag.Users = new SelectList(users, "Id", "UserLastname", UserId);
            return PartialView("~/Views/Account/SwitchUser.cshtml", model);
        }
        #endregion
        #region LOGIN
        // GET
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return View(new LoginViewModel
                {
                    ReturnUrl = returnUrl
                });
            }
            else
            {
                if (User.FindFirstValue(ClaimTypes.Role).Equals(_roles.Value.ADMIN))
                    return RedirectToAction("AdminDashboard", "Admin");
                else if (User.FindFirstValue(ClaimTypes.Role).Equals(_roles.Value.DOCTOR))
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (User.FindFirstValue(ClaimTypes.Role).Equals(_roles.Value.SUPPORT))
                {
                    return RedirectToAction("SupportDashboard", "Support");
                }
                else if (User.FindFirstValue(ClaimTypes.Role).Equals(_roles.Value.MCC))
                {
                    return RedirectToAction("MccDashboard", "MedicalCenterChief");
                }
                else if (User.FindFirstValue(ClaimTypes.Role).Equals(_roles.Value.EOC))
                {
                    return RedirectToAction("Dashboard", "Eoc");
                }
                else
                    return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var (isValid, user) = await _userService.ValidateUserCredentialsAsync(model.Username, model.Password);

                if(isValid)
                {
                    await LoginAsync(user, model.RememberMe);
                    CreateLogin(user.Id);


                    await _context.SaveChangesAsync();
                    if(user.Level.Equals(_roles.Value.ADMIN))
                        return RedirectToAction("AdminDashboard", "Admin");
                    else if (user.Level.Equals(_roles.Value.DOCTOR))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (user.Level.Equals(_roles.Value.SUPPORT))
                    {
                        return RedirectToAction("SupportDashboard", "Support");
                    }
                    else if (user.Level.Equals(_roles.Value.MCC))
                    {
                        return RedirectToAction("MccDashboard", "MedicalCenterChief");
                    }
                    else if (user.Level.Equals(_roles.Value.EOC))
                    {
                        return RedirectToAction("Dashboard", "Eoc");
                    }
                }
                else
                {
                    if (user == null)
                    {
                        ModelState.AddModelError("Username", "User does not exists");
                        ViewBag.Username = "invalid";
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "Wrong Password");
                        ViewBag.Password = "invalid";
                    }
                }
            }
            ViewBag.Result = false;
            return View(model);
        }
        #endregion
        #region BACK AS ADMIN
        [Authorize]
        public async Task<ActionResult> BackAsAdmin()
        {
            var realRole = User.FindFirstValue("RealRole");
            var realFacility = int.Parse(User.FindFirstValue("RealFacility"));
            await LoginAsAsync(realFacility, realRole);

            if (realRole.Equals(_roles.Value.ADMIN))
                return RedirectToAction("AdminDashboard", "Admin");
            else if (realRole.Equals(_roles.Value.DOCTOR))
            {
                return RedirectToAction("Index", "Home");
            }
            else if (realRole.Equals(_roles.Value.SUPPORT))
            {
                return RedirectToAction("SupportDashboard", "Support");
            }
            else //if (level.Equals(_roles.Value.MCC))
            {
                return RedirectToAction("MccDashboard", "MedicalCenterChief");
            }
        }
        #endregion
        #region AUTHORIZE
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult Cancel(string returnUrl)
        {
            if(isUrlValid(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region LOGOUT
        public async Task<IActionResult> Logout(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!_configuration.GetValue<bool>("Account:ShowLogoutPrompt"))
            {
                return await Logout();
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if(User.Identity.IsAuthenticated)
            {
                UpdateLogin(UserId);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Helpers
        private bool isUrlValid(string returnUrl)
        {
            return !string.IsNullOrWhiteSpace(returnUrl) && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
        }

        private async Task LoginAsAsync(int facilityId, string level)
        {
            var user = await _context.Users
                .GroupJoin(
                    _context.Department,
                    user => user.DepartmentId,
                    dep => dep.Id,
                    (user, DEPARTMENT) =>
                        new
                        {
                            user = user,
                            DEPARTMENT = DEPARTMENT
                        }
                )
                .SelectMany(
                    temp0 => temp0.DEPARTMENT.DefaultIfEmpty(),
                    (temp0, department) =>
                        new
                        {
                            temp0 = temp0,
                            department = department
                        }
                )
                .Join(
                    _context.Facility,
                    temp1 => temp1.temp0.user.FacilityId,
                    facility => facility.Id,
                    (temp1, facility) =>
                        new
                        {
                            temp1 = temp1,
                            facility = facility
                        }
                )
                .GroupJoin(
                    _context.Muncity,
                    temp2 => temp2.temp1.temp0.user.Muncity,
                    mnct => mnct.Id,
                    (temp2, MUNCITY) =>
                        new
                        {
                            temp2 = temp2,
                            MUNCITY = MUNCITY
                        }
                )
                .SelectMany(
                    temp3 => temp3.MUNCITY.DefaultIfEmpty(),
                    (temp3, muncity) =>
                        new
                        {
                            temp3 = temp3,
                            muncity = muncity
                        }
                )
                .Join(
                    _context.Province,
                    temp4 => temp4.temp3.temp2.temp1.temp0.user.Province,
                    province => province.Id,
                    (temp4, province) =>
                        new CookiesModel
                        {
                            Id = temp4.temp3.temp2.temp1.temp0.user.Id,
                            Username = temp4.temp3.temp2.temp1.temp0.user.Username,
                            Fname = temp4.temp3.temp2.temp1.temp0.user.Fname,
                            Mname = temp4.temp3.temp2.temp1.temp0.user.Mname,
                            Lname = temp4.temp3.temp2.temp1.temp0.user.Lname,
                            Email = temp4.temp3.temp2.temp1.temp0.user.Email,
                            Province = temp4.temp3.temp2.temp1.temp0.user.Province,
                            Muncity = temp4.temp3.temp2.temp1.temp0.user.Muncity,
                            Contact = temp4.temp3.temp2.temp1.temp0.user.Contact,
                            Level = temp4.temp3.temp2.temp1.temp0.user.Level,
                            FacilityId = temp4.temp3.temp2.temp1.temp0.user.FacilityId,
                            DepartmentId = temp4.temp3.temp2.temp1.temp0.user.DepartmentId,
                            FacilityName = temp4.temp3.temp2.facility.Name,
                            DepartmentName = temp4.temp3.temp2.temp1.department.Description
                        }
                )
                .FirstOrDefaultAsync(x => x.Id == UserId);
            var properties = new AuthenticationProperties
            {
                AllowRefresh = false,
                IsPersistent = false
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.Fname),
                new Claim(ClaimTypes.Surname, user.Lname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Contact),
                new Claim(ClaimTypes.Role, level),
                new Claim("Facility", facilityId.ToString()),
                new Claim("FacilityName", user.FacilityName),
                new Claim("Department", user.DepartmentId.ToString()),
                new Claim("DepartmentName", user.DepartmentId != 0? user.DepartmentName: ""),
                new Claim("Province", user.Province.ToString()),
                new Claim("Muncity", user.Muncity.ToString()),
                new Claim("RealRole", user.Level),
                new Claim("RealFacility", user.FacilityId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }


        private async Task LoginAsync(CookiesModel user, bool rememberMe)
        {
            var properties = new AuthenticationProperties
            {
                AllowRefresh = false,
                IsPersistent = rememberMe
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.Fname),
                new Claim(ClaimTypes.Surname, user.Lname),
                new Claim(ClaimTypes.Role, user.Level),
                new Claim("Facility", user.FacilityId.ToString()),
                new Claim("FacilityName", user.FacilityName),
                new Claim("Department", user.DepartmentId.ToString()),
                new Claim("DepartmentName", user.DepartmentId != 0? user.DepartmentName: ""),
                new Claim("Province", user.Province.ToString()),
                new Claim("Muncity", user.Muncity.ToString()),
                new Claim("RealRole", user.Level),
                new Claim("RealFacility", user.FacilityId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }
        public void CreateLogin(int userId)
        {
            var newLogin = new Login();

            newLogin.Login1 = DateTime.Now;
            newLogin.Logout = default;
            newLogin.Status = "login";
            newLogin.UserId = userId;
            newLogin.CreatedAt = DateTime.Now;
            newLogin.UpdatedAt = DateTime.Now;
            _context.Add(newLogin);
        }

        public async Task<bool> ChangeUser()
        {
            UpdateLogin(UserId);
            await HttpContext.SignOutAsync();
            return true;
        }

        public void UpdateLogin(int userId)
        {
            Login logout = null;
            try
            {
                logout = _context.Login.Where(x=>x.UserId == userId && x.Logout == default).OrderByDescending(x=>x.UpdatedAt).First();
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            if(logout!=null)
            {
                var currentUser = _context.Users.Find(userId);
                logout.Logout = DateTime.Now;
                currentUser.LoginStatus = "logout";
                currentUser.UpdatedAt = DateTime.Now;
                _context.Update(currentUser);
                _context.Update(logout);
                _context.SaveChanges();
            }
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