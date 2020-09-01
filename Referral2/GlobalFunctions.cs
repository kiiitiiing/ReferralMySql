using Referral2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace Referral2
{
    public static class GlobalFunctions
    {
        private static string FullName;
        public static string FixName(this string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static string FirstToUpper(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Trim().ToLower();

                text = text.First().ToString().ToUpper() + text.Substring(1);

                return text;
            }
            else
                return "";
        }

        public static bool CheckRole(this string role)
        {
            if (role == "doctor" || role == "support" || role == "admin")
                return true;
            else
                return false;
        }

        public static string NameToUpper(this string name)
        {
            if(!string.IsNullOrEmpty(name))
            {
                string[] names = name.Split(null);
                string fullname = "";
                foreach (var item in names)
                {
                    fullname += item.FirstToUpper() + " ";
                }
                return fullname;
            }
            else
            {
                return "";
            }
        }

        public static string Minimize(this string text, int length)
        {
            return text.Length > length ? new string(text.Take(length).ToArray()) + "..." : text;
        }


        public static string ComputeTimeFrame(this double minutes)
        {
            var min = Math.Floor(minutes);
            var minute = min == 0 ? "" : min + "m";
            var sec = Math.Round((minutes - min) * 60);
            var seconds = sec == 0 ? "" : sec + "s";
            var total = minute + " " + seconds;
            return total;
        }

        public static int ComputeAge(this DateTime dob)
        {
            var today = DateTime.Today;

            var age = today.Year - dob.Year;

            if (dob.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public static int ComputeAge(this DateTime? dob)
        {
            var realDob = (DateTime)dob;
            var today = DateTime.Today;

            var age = today.Year - realDob.Year;

            if (realDob.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public static double ArchivedTime(DateTime date)
        {
            return Convert.ToInt32(DateTime.Now.Subtract(date).TotalMinutes);
        }

        public static string GetDate(this DateTime date, string format)
        {
            if (date != default)
            {
                if (!format.Contains("tt"))
                {
                    return date.ToString(format);
                }
                else
                    return date.ToString(format, CultureInfo.InvariantCulture);
            }
            else
                return "";
        }

        public static string GetDate(this DateTime? date, string format)
        {
            var realDate = (DateTime)date;

            if (realDate != default)
            {
                if (!format.Contains("tt"))
                {
                    return realDate.ToString(format);
                }
                else
                    return realDate.ToString(format, CultureInfo.InvariantCulture);
            }
            else
                return "";
        }

        public static string CheckAddress(this string address)
        {
            return string.IsNullOrEmpty(address) ? "" : address + ", ";
        }

        public static string GetFullName(this string level, params string[] names)
        {
            var name = level == "doctor"? "Dr. " : "";
            for(int x = 0; x<names.Length; x++)
            {
                name = name + " " + names[x];
            }
            return name;
        }

        public static string GetAddress(params string[] addresses)
        {
            var address = "";
            for (int x = 0; x < address.Length; x++)
            {
                address = address + ", " + address[x];
            }
            return address;
        }

        public static string CheckString(this string text)
        {
            return string.IsNullOrEmpty(text) ? "" : text;
        }

        public static string HoursOnline(this double hours)
        {
            if(hours > 0)
            {
                var time = new double[2];
                time[0] = Math.Floor(hours);
                time[1] = Math.Ceiling(Math.Abs(hours - time[0]) * 60);

                return time[0] + " hours " + time[1] + " minutes";
            }
            else
            {
                return "";
            }
        }

        public static string GetAddress(this Facility facility)
        {
            string address = string.IsNullOrEmpty(facility.Address) ? "" : facility.Address + ", ";
            string barangay = facility.Barangay == null ? "" : facility.Barangay.Description + ", ";
            string muncity = facility.Muncity == null ? "" : facility.Muncity.Description + ", ";
            string province = facility.Province == null ? "" : facility.Province.Description;

            return address + barangay + muncity + province;
        }

        public static string GetAddress(Barangay barangay, Muncity muncity, Province province)
        {
            string barangays = barangay == null ? "" : barangay.Description + ", ";
            string muncitys = muncity == null ? "" : muncity.Description + ", ";
            string provinces = muncity == null ? "" : province.Description;

            return barangays + muncitys + provinces;
        }

        public static string GetAddress(this Patient patient)
        {
            string barangay = patient.Barangay == null ? "" : patient.Barangay.Description + ", ";
            string muncity = patient.Muncity == null ? "" : patient.Muncity.Description + ", ";
            string province = patient.Province == null ? "" : patient.Province.Description;

            return barangay + muncity + province;
        }

        public static string GetFullName(this MyModels.Patients patient)
        {
            if (patient != null)
                return patient.Fname.CheckName() + " " + patient.Mname.CheckName() + " " + patient.Lname.CheckName();
            else
                return "";
        }

        public static string GetFullName(this Patient patient)
        {
            if (patient != null)
                return patient.Fname.CheckName() + " " + patient.Mname.CheckName() + " " + patient.Lname.CheckName();
            else
                return "";
        }

        public static string GetFullLastName(User user)
        {
            if (user != null)
                return user.Lname.CheckName() + ", " + user.Fname.CheckName() + " " + user.Mname.CheckName();
            else
                return "";
        }
        public static string GetFullLastName(this Patient patient)
        {
            if (patient != null)
                return patient.Lname.CheckName() + ", " + patient.Fname.CheckName() + " " + patient.Mname.CheckName();
            else
                return "";
        }


        public static string GetFullName(this MyModels.Users user)
        {
            if (user != null)
                return user.Fname.CheckName() + " " + user.Mname.CheckName() + " " + user.Lname.CheckName();
            else
                return "";
        }

        public static string GetFullName(this User user)
        {
            if (user != null)
                return user.Fname.CheckName() + " " + user.Mname.CheckName() + " " + user.Lname.CheckName();
            else
                return "";
        }

        public static string WordCut(this string text, int limit)
        {
            var cut = text.Length > limit ? new string(text.Take(limit).ToArray()) + "..." : text;
            return cut;
        }

        public static string GetMDFullName(this MyModels.Users doctor)
        {
            if (doctor != null)
                FullName = "Dr. " + doctor.Fname.CheckName() + " " + doctor.Mname.CheckName() + " " + doctor.Lname.CheckName();
            else
                FullName = "";

            return FullName;
        }

        public static string GetMDFullName(this User doctor)
        {
            if (doctor != null)
                FullName = "Dr. " + doctor.Fname.CheckName() + " " + doctor.Mname.CheckName() + " " + doctor.Lname.CheckName();
            else
                FullName = "";

            return FullName;
        }

        public static string CheckName(this string name)
        {
            return string.IsNullOrEmpty(name) ? "" : name;
        }
    }
}
