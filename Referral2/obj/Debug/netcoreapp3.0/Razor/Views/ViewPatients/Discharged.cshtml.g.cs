#pragma checksum "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f21a45299e3534ec591ef0cdbfb9b406d110e83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViewPatients_Discharged), @"mvc.1.0.view", @"/Views/ViewPatients/Discharged.cshtml")]
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
#line 1 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Support;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Doctor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Remarks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.ViewPatients;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Consolidated;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Mcc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.MobileModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f21a45299e3534ec591ef0cdbfb9b406d110e83", @"/Views/ViewPatients/Discharged.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15693769c079e05a982c91dec78c1a398448498", @"/Views/_ViewImports.cshtml")]
    public class Views_ViewPatients_Discharged : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<DischargedViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Track", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
  
    ViewData["Title"] = "Discharged/Transferred Patients";
    var dateRange = ViewBag.StartDate + " - " + ViewBag.EndDate;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"col-md-12\">\r\n\r\n    <!-- CARD START-->\r\n    <div class=\"card\">\r\n        <!-- CARD DANGER HEADER -->\r\n        <div class=\"card-header\">\r\n            ");
#nullable restore
#line 15 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
       Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_PatientSearchFilter.cshtml", new SearchModel
            {
                Action = "Discharged",
                StartDate = ViewBag.StartDate,
                EndDate = ViewBag.EndDate,
                Search = ViewBag.CurrentSearch
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div>\r\n                <h3 class=\"card-title\">Discharged/Transferred Patients</h3><br />\r\n                <span class=\"text-sm text-muted\">TOTAL: ");
#nullable restore
#line 24 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                                   Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n            <div class=\"clearfix\"></div>\r\n        </div>\r\n        <!-- CARD DANGER BODY -->\r\n        <div class=\"card-body\">\r\n");
#nullable restore
#line 30 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
             if (Model.Count() > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table table-striped"" width=""100%"">
                    <thead>
                        <tr class=""bg-gray"">
                            <th width=""20%"">
                                <p>Referring Facility</p>
                            </th>
                            <th width=""30%"">
                                <p>Patient Name/Code</p>
                            </th>
                            <th width=""22%"">
                                <p>Date Discharged</p>
                            </th>
                            <th width=""14%"">
                                <p>Status</p>
                            </th>
                            <th width=""14%"">
                                <p>Record</p>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 53 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                         foreach (var item in Model)
                        {
                            var facility = item.ReferringFacility.Length > 25 ? new string(item.ReferringFacility.Take(25).ToArray()) + "..." : item.ReferringFacility;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <span class=\"facility-color\"");
            BeginWriteAttribute("title", " title=\"", 2321, "\"", 2352, 1);
#nullable restore
#line 58 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
WriteAttributeValue("", 2329, item.ReferringFacility, 2329, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 59 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                   Write(facility);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </span>\r\n                                    <br />\r\n                                    <p class=\"small text-muted\">");
#nullable restore
#line 62 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                                           Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 65 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                     if (item.Type.Equals("Non-Pregnant"))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" data-toggle=\"ajax-modal\" data-target=\"#normal-form-modal\" data-url=\"");
#nullable restore
#line 67 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                                                                                                   Write(Url.Action("PrintableNormalForm","ViewForms", new { code = item.Code }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                            ");
#nullable restore
#line 68 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                       Write(item.PatientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </a>\r\n");
#nullable restore
#line 70 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" data-toggle=\"ajax-modal\" data-target=\"#print-pregnant-form-modal\" data-url=\"");
#nullable restore
#line 73 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                                                                                                           Write(Url.Action("PrintablePregnantForm","ViewForms", new { code = item.Code }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                            ");
#nullable restore
#line 74 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                       Write(item.PatientName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </a>\r\n");
#nullable restore
#line 76 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p class=\"small text-muted\">\r\n                                        ");
#nullable restore
#line 78 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                   Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </p>\r\n                                </td>\r\n                                <td>\r\n                                    <span>");
#nullable restore
#line 82 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                     Write(item.DateAction.GetDate("MMMM dd, yyyy hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 85 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                               Write(item.Status.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f21a45299e3534ec591ef0cdbfb9b406d110e8315638", async() => {
                WriteLiteral("\r\n                                        <i class=\"fa fa-stethoscope\"></i>\r\n                                        &nbsp;Track\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-code", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                                                                                             WriteLiteral(item.Code);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["code"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-code", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["code"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 94 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 97 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""alert alert-warning"">
                    <span class=""text-warning"" style=""font-weight: bold; font-size: 1.2em;"">
                        <i class=""fa fa-exclamation-triangle""></i>
                        &nbsp;No data found!
                    </span>
                </div>
");
#nullable restore
#line 106 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n            <!-- CARD FOOTER -->\r\n            <div class=\"card-footer\">\r\n                ");
#nullable restore
#line 110 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewPatients\Discharged.cshtml"
           Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_PageList.cshtml", new PageListModel
               {
                   Action = "Discharged",
                   HasNextPage = Model.HasNextPage,
                   HasPreviousPage = Model.HasPreviousPage,
                   PageIndex = Model._pageIndex,
                   TotalPages = Model._totalPages,
                   Parameters = new Dictionary<string, string>
                    {
                       { "page", Model._pageIndex.ToString() },
                       { "search", ViewBag.CurrentSearch },
                       { "dateRange", dateRange }
                    }
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<DischargedViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
