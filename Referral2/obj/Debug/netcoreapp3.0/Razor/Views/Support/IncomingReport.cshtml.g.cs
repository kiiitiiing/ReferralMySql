#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed17b6c4823615d7ce5318926eca60d9566d8495"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Support_IncomingReport), @"mvc.1.0.view", @"/Views/Support/IncomingReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed17b6c4823615d7ce5318926eca60d9566d8495", @"/Views/Support/IncomingReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_Support_IncomingReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<IncomingReferralViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
  
    ViewData["Title"] = "Incoming Referrals";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-md-12"">
    <div class=""card card-success card-outline"">
        <div class=""card-header with-border"">
            <h4>Incoming Referrals</h4>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-striped table-hover table-bordered"" width=""100%"" style=""font-size: 14px;"">
                    <thead>
                        <tr class=""bg-black"">
                            <th width=""19%"">Patient Name</th>
                            <th width=""46%"">Referring Facility</th>
                            <th width=""9%"">Department</th>
                            <th width=""19%"">Date Referred</th>
                            <th width=""7%"">Status</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 25 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td><span class=\"text-primary text-bold\">");
#nullable restore
#line 28 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
                                                                    Write(item.PatientName.NameToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                <td><span class=\"facility-color\">");
#nullable restore
#line 29 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
                                                            Write(item.ReferringFacility);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                <td><span class=\"facility-color\">");
#nullable restore
#line 30 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
                                                            Write(item.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                <td><span class=\"text-success\">");
#nullable restore
#line 31 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
                                                          Write(item.DateReferred.GetDate("MMMM d, yyyy h:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                <td><span class=\"text-success\">");
#nullable restore
#line 32 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
                                                          Write(item.Status.FirstToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                            </tr>\r\n");
#nullable restore
#line 34 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <div class=\"card-footer\">\r\n            ");
#nullable restore
#line 40 "D:\Systems\Referral - MySql\Referral2\Views\Support\IncomingReport.cshtml"
       Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_PageList.cshtml", new PageListModel
               {
                   Action = "IncomingReport",
                   HasNextPage = Model.HasNextPage,
                   HasPreviousPage = Model.HasPreviousPage,
                   PageIndex = Model._pageIndex,
                   TotalPages = Model._totalPages,
                   Parameters = new Dictionary<string, string>
                   {
                       { "search", "" }
                   }
               }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<IncomingReferralViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
