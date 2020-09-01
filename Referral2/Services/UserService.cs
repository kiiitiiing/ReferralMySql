using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Referral2.Data;
using Referral2.Helpers;
using Referral2.MyModels;
using Referral2.Models.ViewModels;
using Referral2.Models.ViewModels.Admin;
using Referral2.Models.ViewModels.Support;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Referral2.MyData;
using Referral2.Models.ViewModels.Account;

namespace Referral2.Services
{
    public interface IUserService
    {
        Task<(bool, CookiesModel)> ValidateUserCredentialsAsync(string username, string password);
        Task<(bool, CookiesModel)> SwitchUserAsync(int id, string password);
        void ChangePasswordAsync(Users user, string newPassword);


        Task<bool> RegisterSupportAsync(AddSupportViewModel model);

        Task<bool> RegisterDoctorAsync(AddDoctorViewModel model, int facilityId);

    }
    public class UserService : IUserService
    {
        private readonly MySqlReferralContext _context;
        private readonly IOptions<ReferralRoles> _roles;

        public PasswordHasher<CookiesModel> _LoginPassword = new PasswordHasher<CookiesModel>();
        public PasswordHasher<Users> _hashPassword = new PasswordHasher<Users>();



        public UserService(MySqlReferralContext context, IOptions<ReferralRoles> roles)
        {
            _context = context;
            _roles = roles;
        }

        #region VALIDATE LOGIN
        public async Task<(bool, CookiesModel)> ValidateUserCredentialsAsync(string username, string password)
        {
            CookiesModel user = null;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return (false, user);

            user = await _context.Users
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
                            Password = temp4.temp3.temp2.temp1.temp0.user.Password,
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
                .FirstOrDefaultAsync(x => x.Username.Equals(username));

            if (user == null)
                return (false, user);
            /*else//Added temporarily
                return (true, user);*/

            else
            {
                try
                {
                    var loggedinUser = await _context.Users.FindAsync(user.Id);
                    var result = _LoginPassword.VerifyHashedPassword(user, user.Password, password);
                    if (result.Equals(PasswordVerificationResult.Success))
                    {
                        loggedinUser.LoginStatus = "login";
                        loggedinUser.LastLogin = DateTime.Now;
                        loggedinUser.UpdatedAt = DateTime.Now;
                        _context.Update(loggedinUser);
                        return (true, user);
                    }
                    else
                        return (false, user);
                }
                catch
                {
                    return (false, user);
                }
            }
            
        }
        #endregion
        #region CHANGE PASSWORD
        public void ChangePasswordAsync(Users user, string newPassword)
        {
            var hashedPassword = _hashPassword.HashPassword(user, newPassword);

            user.Password = hashedPassword;
            user.UpdatedAt = DateTime.Now;

            _context.Update(user);
            _context.SaveChanges();
        }
        #endregion
        #region REGISTER SUPPORT
        public Task<bool> RegisterSupportAsync(AddSupportViewModel model)
        {
            if (_context.Users.Any(x => x.Username.Equals(model.Username)))
            {
                return Task.FromResult(false);
            }
            else
            {
                var facility = _context.Facility.First(x => x.Id.Equals(model.FacilityId));
                Users newUser = new Users();
                string hashedPass = _hashPassword.HashPassword(newUser, model.Password);
                newUser.Fname = model.Firstname;
                newUser.Mname = model.Middlename;
                newUser.Lname = model.Lastname;
                newUser.Contact= model.ContactNumber;
                newUser.Email = model.Email;
                newUser.FacilityId = model.FacilityId;
                newUser.Designation = model.Designation;
                newUser.Username = model.Username;
                newUser.Password = hashedPass;
                newUser.Level = _roles.Value.SUPPORT;
                newUser.DepartmentId = 0;
                newUser.Title = null;
                newUser.Muncity = facility.Muncity;
                newUser.Province = (int)facility.Province;
                newUser.Designation = model.Designation;
                newUser.Status = "active";
                newUser.LastLogin = default;
                newUser.LoginStatus = "logout";
                newUser.CreatedAt = DateTime.Now;
                newUser.UpdatedAt = DateTime.Now;
                _context.Add(newUser);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
        }
        #endregion
        #region REGISTER DOCTOR
        public Task<bool> RegisterDoctorAsync(AddDoctorViewModel model, int facilityId)
        {
            if (_context.Users.Any(x => x.Username.Equals(model.Username)))
            {
                return Task.FromResult(false);
            }
            else
            {
                var facility = _context.Facility.First(x => x.Id.Equals(facilityId));
                Users newUser = new Users();
                string hashedPass = _hashPassword.HashPassword(newUser, model.Password);
                newUser.Fname = model.Firstname.FixName();
                newUser.Mname = model.Middlename.FixName();
                newUser.Lname = model.Lastname.FixName();
                newUser.Contact = model.ContactNumber;
                newUser.Email = model.Email;
                newUser.FacilityId = facilityId;
                newUser.Designation = model.Designation;
                newUser.Username = model.Username;
                newUser.Password = hashedPass;
                newUser.Level = model.Level;
                newUser.DepartmentId = model.Department;
                newUser.Title = null;
                newUser.Muncity = facility.Muncity;
                newUser.Province = facility.Province;
                newUser.Designation = model.Designation;
                newUser.Status = "active";
                newUser.LastLogin = default;
                newUser.LoginStatus = "logout";
                newUser.CreatedAt = DateTime.Now;
                newUser.UpdatedAt = DateTime.Now;
                _context.Add(newUser);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
        }
        #endregion
        #region SWITCH USER
        async Task<(bool, CookiesModel)> IUserService.SwitchUserAsync(int id, string password)
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
                            Password = temp4.temp3.temp2.temp1.temp0.user.Password,
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
                .FirstOrDefaultAsync(x=>x.Id == id);
            if (user == null)
            {
                return (false, user);
            }

            try
            {
                var loggedInUser = await _context.Users.FindAsync(user.Id);
                var result = _LoginPassword.VerifyHashedPassword(user, user.Password, password);
                if (result.Equals(PasswordVerificationResult.Success))
                {
                    loggedInUser.LoginStatus = "login";
                    loggedInUser.LastLogin = DateTime.Now;
                    loggedInUser.UpdatedAt = DateTime.Now;
                    loggedInUser.Status = "active";
                    _context.Update(loggedInUser);
                    return (true, user);
                }

                else
                    return (false, user);
            }
            catch
            {
                return (false, user);
            }
        }
        #endregion
    }
}
