#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77c59fd1ec219c601bf85da82adaaf83a5057140"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_OutgoingReport), @"mvc.1.0.view", @"/Views/Report/OutgoingReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77c59fd1ec219c601bf85da82adaaf83a5057140", @"/Views/Report/OutgoingReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_OutgoingReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<OutgoingReportViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control select2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "facility", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "department", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OutgoingReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/PartialViews/_MainMenuPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
  
    ViewData["Title"] = "Outgoing Referral Report";
    var startDate = ViewBag.StartDate;
    var endDate = ViewBag.EndDate;
    var dateRange = startDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy");

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
                <div class=""card card-danger card-green"">
                    <!-- CARD DANGER HEADER -->
                    <div class=""card-header"">
                        <h3 class=""card-title"">
                            Filter Result
                        </h3>
                        <small class=""badge bg-gradient-orange fa-pull-right"">
                            Result: ");
#nullable restore
#line 23 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                               Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </small>\r\n                    </div>\r\n                    <!-- CARD DANGER BODY -->\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77c59fd1ec219c601bf85da82adaaf83a505714010696", async() => {
                WriteLiteral(@"
                        <div class=""card-body"">
                            <!-- DATE RANGE FILTER -->
                            <div class=""form-group"">
                                <input type=""text"" class=""form-control bg-white"" name=""daterange""");
                BeginWriteAttribute("value", " value=\"", 1314, "\"", 1332, 1);
#nullable restore
#line 31 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
WriteAttributeValue("", 1322, dateRange, 1322, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"cursor:pointer;\" readonly />\r\n                            </div>\r\n                            <!-- FACILITY -->\r\n                            <div class=\"form-group\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77c59fd1ec219c601bf85da82adaaf83a505714011807", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77c59fd1ec219c601bf85da82adaaf83a505714012112", async() => {
                        WriteLiteral("All Facility");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 35 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Facilities;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                            <!-- DEPARTMENT -->\r\n                            <div class=\"form-group\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77c59fd1ec219c601bf85da82adaaf83a505714015119", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77c59fd1ec219c601bf85da82adaaf83a505714015424", async() => {
                        WriteLiteral("All Department");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 41 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Departments;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div>
                            <div class=""form-group hide""></div>
                            <!-- BUTTONS -->
                            <div class=""form-group"">
                                <!-- FILTER -->
                                <button type=""submit"" value=""Filter"" class=""btn btn-block btn-success"">
                                    <i class=""fa fa-filter""></i>
                                    &nbsp;Filter Result
                                </button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "77c59fd1ec219c601bf85da82adaaf83a505714020290", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
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
                <!-- PATIENT LIST -->
                <div class=""card card-success card-outline"">
                    <!-- DAILY USERS HEADER -->
                    <div class=""card-header with-border"">
                        <h4>
                            Outgoing Referral Report
                            <small class=""text-success fa-pull-right"">");
#nullable restore
#line 66 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                 Write(startDate.ToString("MMMM d, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" to ");
#nullable restore
#line 66 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                                                        Write(endDate.ToString("MMMM d, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                        </h4>\r\n                    </div>\r\n                    <!-- DAILY USERS BODY -->\r\n                    <div class=\"card-body\">\r\n");
#nullable restore
#line 71 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                         if (Model.Count() > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <!-- TABLE START -->
                            <div class=""table-responsive"">
                                <table class=""table table-striped table-hover table-bordered"">
                                    <!-- TABLE HEADER -->
                                    <thead>
                                        <tr class=""bg-black"">
                                            <th class=""text-center"" rowspan=""2"">Patient Code</th>
                                            <th class=""text-center"" rowspan=""2"">Date<br>Referred</th>
                                            <th class=""text-center"" colspan=""4"">Status</th>
                                            <th class=""text-center"" rowspan=""2"">No Action</th>
                                        </tr>
                                        <tr class=""bg-black"">
                                            <th class=""text-center"">Seen</th>
                                            <th class=""text-center"">Acc");
            WriteLiteral(@"epted</th>
                                            <th class=""text-center"">Arrived</th>
                                            <th class=""text-center"">Redirected</th>
                                        </tr>
                                    </thead>
                                    <!-- TABLE BODY -->
                                    <tbody>
");
#nullable restore
#line 93 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                         foreach (var item in Model)
                                        {
                                            var code = item.Code;
                                            var dateReferred = item.DateReferred.ToString("dd/MM/yy HH:mm");
                                            var seen = item.Seen.ComputeTimeFrame();
                                            var accepted = item.Accepted.ComputeTimeFrame();
                                            var arrived = item.Arrived.ComputeTimeFrame();
                                            var redirected = item.Redirected.ComputeTimeFrame();
                                            var noAction = item.NoAction < 0 ? "" : item.NoAction.ComputeTimeFrame();

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <th><small class=\"custom-warning\">");
#nullable restore
#line 103 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                             Write(code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></th>\r\n                                                <th><small class=\"text-gray\">");
#nullable restore
#line 104 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                        Write(dateReferred);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></th>\r\n                                                <th><small class=\"text-danger\">");
#nullable restore
#line 105 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                          Write(seen);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></th>\r\n                                                <th><small class=\"text-danger\">");
#nullable restore
#line 106 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                          Write(accepted);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></th>\r\n                                                <th><small class=\"text-danger\">");
#nullable restore
#line 107 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                          Write(arrived);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></th>\r\n                                                <th><small class=\"text-danger\">");
#nullable restore
#line 108 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                          Write(redirected);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></th>\r\n                                                <th><small class=\"text-danger\">");
#nullable restore
#line 109 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                                                          Write(noAction);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></th>\r\n                                            </tr>\r\n");
#nullable restore
#line 111 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n");
#nullable restore
#line 115 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""alert alert-warning"">
                                <span class=""text-lg"">
                                    <i class=""fa fa-exclamation-triangle""></i>
                                    &nbsp;No data found!
                                </span>
                            </div>
");
#nullable restore
#line 124 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"card-footer\">\r\n                        ");
#nullable restore
#line 127 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                   Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_PageList.cshtml",new PageListModel
                       {
                            Action= "OutgoingReport",
                            HasNextPage = Model.HasNextPage,
                            HasPreviousPage = Model.HasPreviousPage,
                            PageIndex = Model._pageIndex,
                            TotalPages = Model._totalPages,
                            Parameters = new Dictionary<string, string>
                            {
                                { "page", Model._pageIndex.ToString() }
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
#line 150 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                   Write(startDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            endDate: \'");
#nullable restore
#line 151 "D:\Systems\Referral - MySql\Referral2\Views\Report\OutgoingReport.cshtml"
                 Write(endDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            opens: \'right\'\r\n        });\r\n        $(\'.select2\').select2({\r\n            theme: \"bootstrap4\"\r\n        });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<OutgoingReportViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
