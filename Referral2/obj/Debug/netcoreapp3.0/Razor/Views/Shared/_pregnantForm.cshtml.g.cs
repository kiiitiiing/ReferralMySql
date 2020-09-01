#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5847d6e966f9a65f94514f0a48570ccf407f1cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__pregnantForm), @"mvc.1.0.view", @"/Views/Shared/_pregnantForm.cshtml")]
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
#line 1 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Support;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Doctor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Remarks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.ViewPatients;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Consolidated;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Mcc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.MobileModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Systems\Referral - MySql\Referral2\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5847d6e966f9a65f94514f0a48570ccf407f1cf", @"/Views/Shared/_pregnantForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__pregnantForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PregnantFormModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <tbody>\r\n        <tr>\r\n            <th colspan=\"4\">REFERRAL RECORD</th>\r\n        </tr>\r\n        <tr>\r\n            <td>Who is Referring</td>\r\n            <td>Record Number: <span class=\"record_no\">");
#nullable restore
#line 10 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                  Write(Model.RecordNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n            <td colspan=\"2\">Referred Date: <span class=\"referred_date\">");
#nullable restore
#line 11 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                  Write(Model.ReferredDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"2\">Name of referring MD/HCW: <span class=\"md_referring\">");
#nullable restore
#line 14 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                            Write(Model.ReferringMdName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n            <td colspan=\"2\">Arrival Date: <span class=\"arrival_date\">");
#nullable restore
#line 15 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                Write(Model.ArrivalDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"4\">Contact # of referring MD/HCW: <span class=\"referring_md_contact\">");
#nullable restore
#line 18 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                         Write(Model.ReferringMdContact);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"4\">Facility: <span class=\"referring_facility\">");
#nullable restore
#line 21 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                  Write(Model.ReferringFacilityName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"4\">Facility Contact #: <span class=\"referring_contact\">");
#nullable restore
#line 24 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                           Write(Model.ReferringFacilityContact);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"4\">Accompanied by the Health Worker: <span class=\"health_worker\">");
#nullable restore
#line 27 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                     Write(Model.HealthWorker);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"2\">Referred To: <span class=\"referred_name\">");
#nullable restore
#line 30 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                Write(Model.ReferredToName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n            <td colspan=\"2\">Department: <span class=\"department_name\">");
#nullable restore
#line 31 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                 Write(Model.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n        </tr>\r\n        <tr>\r\n            <td colspan=\"4\">Address: <span class=\"referred_address\">");
#nullable restore
#line 34 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                               Write(Model.ReferredToAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
        </tr>
    </tbody>
</table>
<div class=""row"">
    <div class=""col-sm-6"">
        <table class=""table pregnant-bg-warning"">
            <thead>
                <tr class=""bg-gray-light"">
                    <th colspan=""4"">WOMAN</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan=""3"">Name: <span class=""woman_name"">");
#nullable restore
#line 48 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                              Write(Model.PatientName.NameToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                    <td>Age: <span class=\"woman_age\">");
#nullable restore
#line 49 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                Write(Model.PatientDob.ComputeAge());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"4\">Address: <span class=\"woman_address\">");
#nullable restore
#line 52 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                    Write(Model.PatientAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"4\">\r\n                        Main Reason for Referral: <span class=\"woman_reason\">");
#nullable restore
#line 56 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                        Write(Model.WomanReason);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </td>
                </tr>
                <tr>
                    <td colspan=""4"">
                        Major Findings (Clinica and BP,Temp,Lab)
                        <br>
                        <span class=""woman_major_findings"">");
#nullable restore
#line 63 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                      Write(Model.WomanMajorFindings);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </td>
                </tr>
                <tr class=""bg-gray-light"">
                    <td colspan=""4"">Treatments Give Time</td>
                </tr>
                <tr>
                    <td colspan=""4"">Before Referral: <span class=""woman_before_treatment"">");
#nullable restore
#line 70 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                     Write(Model.WomanBeforeTreatment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> - <span class=\"woman_before_given_time\">");
#nullable restore
#line 70 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                                                                                                Write(Model.WomanBeforeGivenTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"4\">During Transport: <span class=\"woman_during_transport\">");
#nullable restore
#line 73 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                      Write(Model.WomanDuringTransport);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> - <span class=\"woman_transport_given_time\">");
#nullable restore
#line 73 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                                                                                                    Write(Model.WomanTransportGivenTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
                </tr>
                <tr>
                    <td colspan=""4"">
                        Information Given to the Woman and Companion About the Reason for Referral
                        <br>
                        <span class=""woman_information_given"">");
#nullable restore
#line 79 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                         Write(Model.WomanInformationGiven);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class=""col-sm-6"">
        <table class=""table pregnant-bg-warning"">
            <thead>
                <tr class=""bg-gray-light"">
                    <th colspan=""4"">BABY</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan=""2"">Name: <span class=""baby_name"">");
#nullable restore
#line 94 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                             Write(Model.BabyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                    <td>Date of Birth: <span class=\"baby_dob\">");
#nullable restore
#line 95 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                         Write(Model.BabyDob);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"2\">Birth Weight: <span class=\"weight\">");
#nullable restore
#line 98 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                  Write(Model.BabyWeight);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                    <td>Gestational Age: <span class=\"gestational_age\">");
#nullable restore
#line 99 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                  Write(Model.BabyGestationAge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"4\">\r\n                        Main Reason for Referral: <span class=\"baby_reason\">");
#nullable restore
#line 103 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                       Write(Model.BabyReason);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                    </td>
                </tr>
                <tr>
                    <td colspan=""4"">
                        Major Findings (Clinica and BP,Temp,Lab)
                        <br>
                        <span class=""baby_major_findings"">");
#nullable restore
#line 110 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                     Write(Model.BabyMajorFindings);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"4\">Last (Breast) Feed (Time): <span class=\"baby_last_feed\">");
#nullable restore
#line 114 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                       Write(Model.BabyLastFeed);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
                </tr>
                <tr class=""bg-gray-light"">
                    <td colspan=""4"">Treatments Give Time</td>
                </tr>
                <tr>
                    <td colspan=""4"">Before Referral: <span class=""baby_before_treatment"">");
#nullable restore
#line 120 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                    Write(Model.BabyBeforeTreatment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> - <span class=\"baby_before_given_time\">");
#nullable restore
#line 120 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                                                                                             Write(Model.BabyBeforeGivenTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td colspan=\"4\">During Transport: <span class=\"baby_during_transport\">");
#nullable restore
#line 123 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                     Write(Model.BabyDuringTransport);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> - <span class=\"baby_transport_given_time\">");
#nullable restore
#line 123 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                                                                                                                                 Write(Model.BabyTransportGivenTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
                </tr>
                <tr>
                    <td colspan=""4"">
                        Information Given to the Woman and Companion About the Reason for Referral
                        <br>
                        <span class=""baby_information_given"">");
#nullable restore
#line 129 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_pregnantForm.cshtml"
                                                        Write(Model.BabyInformationGiven);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PregnantFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
