#pragma checksum "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d87a987734bde3a511a0e3397e25dabdc39ed85f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Eoc_WhosOnline), @"mvc.1.0.view", @"/Views/Eoc/WhosOnline.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Support;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Doctor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Remarks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.ViewPatients;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Consolidated;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Mcc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.MobileModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d87a987734bde3a511a0e3397e25dabdc39ed85f", @"/Views/Eoc/WhosOnline.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15693769c079e05a982c91dec78c1a398448498", @"/Views/_ViewImports.cshtml")]
    public class Views_Eoc_WhosOnline : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserFacilityOnline>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
  
    ViewData["Title"] = "Online Doctors";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-8"">
                <!-- ONLINE DOCTORS -->
                <div class=""card card-outline"" style=""background: rgba(255, 255, 255, 0.4)"">
                    <!-- DAILY USERS HEADER -->
                    <div class=""card-header with-border"">
                        <h5>
                            Online Doctors
                            <span class=""badge bg-blue"">");
#nullable restore
#line 16 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                   Write(Model.Users.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </h5>\r\n                    </div>\r\n                    <!-- DAILY USERS BODY -->\r\n                    <div class=\"card-body\">\r\n                        <div class=\"row\">\r\n");
#nullable restore
#line 22 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                             foreach (var item in Model.Users)
                            {
                                var abbrv = item.FacilityAbrv ?? "";
                                var contact = string.IsNullOrEmpty(item.Contact) ? "N/A" : item.Contact;
                                var dutyTime = item.LoginTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                                string status;
                                string widgetBg;
                                if (item.LoginStatus)
                                {
                                    status = "ON DUTY";
                                    widgetBg = "bg-gradient-success";
                                }
                                else
                                {
                                    status = "OFF DUTY";
                                    widgetBg = "bg-gradient-warning";
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-md-4\">\r\n                                    <div class=\"card card-widget widget-user-2\">\r\n                                        <div");
            BeginWriteAttribute("class", " class=\"", 1966, "\"", 2002, 2);
            WriteAttributeValue("", 1974, "widget-user-header", 1974, 18, true);
#nullable restore
#line 41 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
WriteAttributeValue(" ", 1992, widgetBg, 1993, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 160px;\">\r\n                                            <small class=\"widget-user-username\" style=\"margin-left: 0px!important;\">");
#nullable restore
#line 42 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                                                                               Write(item.DoctorName.NameToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                                            <small class=\"widget-user-desc badge bg-maroon\" style=\"position:absolute; bottom:45%; right:5%;\" >");
#nullable restore
#line 43 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                                                                                                         Write(abbrv);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                                        </div>
                                        <div class=""card-footer p-0"">
                                            <ul class=""nav flex-column"">
                                                <li class=""nav-item"">
                                                    <a href=""#"" class=""nav-link"">
                                                        ");
#nullable restore
#line 49 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                   Write(contact);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        <span class=""float-right badge bg-primary"">
                                                            <i class=""fa fa-phone""></i>
                                                        </span>
                                                    </a>
                                                </li>
                                                <li class=""nav-item"">
                                                    <a href=""#"" class=""nav-link"">
                                                        ");
#nullable restore
#line 57 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                   Write(item.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        <span class=""float-right badge bg-info"">
                                                            <i class=""fa fa-hospital""></i>
                                                        </span>
                                                    </a>
                                                </li>
                                                <li class=""nav-item"">
                                                    <a href=""#"" class=""nav-link"">
                                                        ");
#nullable restore
#line 65 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                   Write(status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <span class=\"float-right badge bg-success\">\r\n                                                            ");
#nullable restore
#line 67 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                       Write(dutyTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        </span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
");
#nullable restore
#line 75 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""card card-success"">
                    <div class=""card-header"">
                        <h5>
                            Online Hospitals
                            <span class=""badge bg-blue"">");
#nullable restore
#line 85 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                   Write(Model.Facilities.Where(x=>x.Status == true).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </h5>\r\n                    </div>\r\n                    <div class=\"card-body\" style=\"height: 500px; overflow-y: auto;\">\r\n");
#nullable restore
#line 89 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                         if (Model.Facilities.Count() != 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"list-group\">\r\n");
#nullable restore
#line 92 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                 foreach(var facility in Model.Facilities)
                                {
                                    var status = facility.Status ? "text-success" : "text-danger";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a href=\"#\" class=\"list-group-item clearfix \"");
            BeginWriteAttribute("title", " title=\"", 5511, "\"", 5533, 1);
#nullable restore
#line 95 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
WriteAttributeValue("", 5519, facility.Name, 5519, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 96 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                   Write(facility.Name.Minimize(28));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <br><small class=\"text-yellow\">(");
#nullable restore
#line 97 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                                                   Write(facility.Province);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</small>\r\n                                        <span class=\"fa-pull-right\">\r\n                                            <i");
            BeginWriteAttribute("class", " class=\"", 5823, "\"", 5851, 3);
            WriteAttributeValue("", 5831, "fa", 5831, 2, true);
            WriteAttributeValue(" ", 5833, "fa-circle", 5834, 10, true);
#nullable restore
#line 99 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
WriteAttributeValue(" ", 5843, status, 5844, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                        </span>\r\n                                    </a>\r\n");
#nullable restore
#line 102 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n");
#nullable restore
#line 104 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Eoc\WhosOnline.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserFacilityOnline> Html { get; private set; }
    }
}
#pragma warning restore 1591