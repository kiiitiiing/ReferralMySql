#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaf9387f6e55cd691a10686c30194581fa6c0942"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DailyReferral), @"mvc.1.0.view", @"/Views/Admin/DailyReferral.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aaf9387f6e55cd691a10686c30194581fa6c0942", @"/Views/Admin/DailyReferral.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_DailyReferral : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<DailyReferralViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DailyReferral", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-sm bg-gradient-orange"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/PartialViews/_LinksPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
  
    ViewData["Title"] = "Daily Referrals";
    var firstDayOfMonth = ViewBag.StartDate;
    var lastDayOfMonth = ViewBag.EndDate;
    var startDate = firstDayOfMonth.ToString("dd/MM/yyyy");
    var endDate = lastDayOfMonth.ToString("dd/MM/yyyy");
    var dateRange = startDate + " - " + endDate;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content"">
    <div class=""container"">
        <div class=""row"">
            <!-- CARD DANGER -->
            <div class=""col-md-3"">
                <!-- SELECT DATE -->
                <div class=""card card-green"">
                    <!-- CARD DANGER HEADER -->
                    <div class=""card-header"">
                        Select Date
                    </div>
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaf9387f6e55cd691a10686c30194581fa6c09428858", async() => {
                WriteLiteral("\r\n                        <!-- CARD DANGER BODY -->\r\n                        <div class=\"card-body\">\r\n                            <input class=\"form-control form-control-sm\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 1006, "\"", 1024, 1);
#nullable restore
#line 26 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
WriteAttributeValue("", 1014, dateRange, 1014, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" id=""daterange"" name=""daterange"" autocomplete=""off"">
                        </div>
                        <div class=""card-footer"">
                            <div class=""form-group"">
                                <button type=""submit"" class=""btn btn-block btn-sm bg-gradient-success"">
                                    <i class=""fa fa-calendar-alt""></i>&nbsp;
                                    Change Date
                                </button>
                            </div>
                            <div class=""form-group"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aaf9387f6e55cd691a10686c30194581fa6c094210282", async() => {
                    WriteLiteral("\r\n                                    <i class=\"far fa-file-excel\"></i>&nbsp;\r\n                                    Export Data\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-export", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                                    WriteLiteral(true);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["export"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-export", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["export"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                                                                WriteLiteral(dateRange);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["daterange"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-daterange", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["daterange"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aaf9387f6e55cd691a10686c30194581fa6c094215101", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""col-md-9"">
                <!-- DAILY USERS -->
                <div class=""card card-success card-outline"">
                    <!-- DAILY USERS HEADER -->
                    <div class=""card-header with-border"">
                        <h4>
                            Daily Referral
                            <br />
                            <small class=""text-success"">
                                ");
#nullable restore
#line 55 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                           Write(firstDayOfMonth.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 55 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                                        Write(lastDayOfMonth.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </small>
                        </h4>
                    </div>
                    <!-- DAILY USERS BODY -->
                    <div class=""card-body cust-font-14"">
                        <div class=""table-responsive"">
                            <table class=""table table-striped table-hover table-bordered"">
                                <thead>
                                    <tr class=""bg-black"">
                                        <th rowspan=""2"" style=""vertical-align: middle;"">Name of Hospital</th>
                                        <th class=""text-center"" colspan=""5"">Number of Referrals To</th>
                                        <th class=""text-center"" colspan=""4"">Number of Referrals From</th>
                                    </tr>
                                    <tr class=""bg-black"">
                                        <th class=""text-center"">Accepted</th>
                                        <th class=""text-center"">Redi");
            WriteLiteral(@"rected</th>
                                        <th class=""text-center"">Seen</th>
                                        <th class=""text-center"">Unseen</th>
                                        <th class=""text-center"">TOTAL</th>
                                        <th class=""text-center"">Accepted</th>
                                        <th class=""text-center"">Redirected</th>
                                        <th class=""text-center"">Seen</th>
                                        <th class=""text-center"">TOTAL</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 82 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                     foreach (var item in Model)
                                    {
                                        var facility = item.Facility.Length > 25 ? new string(item.Facility.Take(25).ToArray()) + "..." : item.Facility;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <th style=\"text-align: left;white-space: nowrap;\"");
            BeginWriteAttribute("title", " title=\"", 4771, "\"", 4793, 1);
#nullable restore
#line 86 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
WriteAttributeValue("", 4779, item.Facility, 4779, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                ");
#nullable restore
#line 87 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                           Write(facility);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </th>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 89 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.AcceptedTo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 90 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.RedirectedTo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 91 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.SeenTo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 92 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.UnseenTo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 93 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.IncomingTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 95 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.AcceptedFrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 96 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.RedirectedFrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 97 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.SeenFrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td class=\"text-center\">");
#nullable restore
#line 98 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                                               Write(item.OutgoingTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 100 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer\">\r\n                        ");
#nullable restore
#line 106 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                   Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_PageList.cshtml", new PageListModel
                       {
                           Action = "DailyReferral",
                           HasNextPage = Model.HasNextPage,
                           HasPreviousPage = Model.HasPreviousPage,
                           PageIndex = Model._pageIndex,
                           TotalPages = Model._totalPages,
                           Parameters = new Dictionary<string, string>
                           {
                               { "page", Model._pageIndex.ToString() },
                               { "daterange", dateRange }
                           }
                       }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<script type=""text/javascript"">
    $(document).ready(function () {
        $('input[name=""daterange""]').daterangepicker({
            format: 'DD/MM/YYYY',
            startDate: '");
#nullable restore
#line 131 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                   Write(startDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            endDate: \'");
#nullable restore
#line 132 "D:\Systems\Referral - MySql\Referral2\Views\Admin\DailyReferral.cshtml"
                 Write(endDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            opens: \'right\'\r\n        });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<DailyReferralViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
