#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "047e43c2d4ce750afbce3a3fa0f260f4c015f1c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_IncomingReport), @"mvc.1.0.view", @"/Views/Report/IncomingReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"047e43c2d4ce750afbce3a3fa0f260f4c015f1c4", @"/Views/Report/IncomingReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_IncomingReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<IncomingReportViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control select2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "facility", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "department", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IncomingReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
  
    ViewData["Title"] = "Incoming Referral Report";
    var startDate = ViewBag.StartDate;
    var endDate = ViewBag.EndDate;
    var dateRange = startDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy");
    var facility = ViewBag.Facilities.SelectedValue == null ? "" : ViewBag.Facilities.SelectedValue.ToString();
    var department = ViewBag.Departments.SelectedValue == null ? "" : ViewBag.Departments.SelectedValue.ToString();

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
#line 25 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                               Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </small>\r\n                    </div>\r\n                    <!-- CARD DANGER BODY -->\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "047e43c2d4ce750afbce3a3fa0f260f4c015f1c410926", async() => {
                WriteLiteral(@"
                        <div class=""card-body"">
                            <!-- DATE RANGE FILTER -->
                            <div class=""form-group"">
                                <input type=""text"" class=""form-control bg-white"" name=""daterange""");
                BeginWriteAttribute("value", " value=\"", 1544, "\"", 1562, 1);
#nullable restore
#line 33 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
WriteAttributeValue("", 1552, dateRange, 1552, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"cursor:pointer;\" readonly />\r\n                            </div>\r\n                            <!-- FACILITY -->\r\n                            <div class=\"form-group\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "047e43c2d4ce750afbce3a3fa0f260f4c015f1c412037", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "047e43c2d4ce750afbce3a3fa0f260f4c015f1c412342", async() => {
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
#line 37 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "047e43c2d4ce750afbce3a3fa0f260f4c015f1c415349", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "047e43c2d4ce750afbce3a3fa0f260f4c015f1c415654", async() => {
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
#line 43 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "047e43c2d4ce750afbce3a3fa0f260f4c015f1c420520", async() => {
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
                <div class=""card card-outline card-success"">
                    <!-- DAILY USERS HEADER -->
                    <div class=""card-header with-border"">
                        <h4>
                            Incoming Referral Report
                            <small class=""text-success fa-pull-right"">");
#nullable restore
#line 68 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                 Write(startDate.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" to ");
#nullable restore
#line 68 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                                                         Write(endDate.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                        </h4>\r\n                    </div>\r\n                    <!-- DAILY USERS BODY -->\r\n                    <div class=\"card-body\">\r\n");
#nullable restore
#line 73 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                         if (Model.Count() > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""table-responsive"">
                                <table class=""table table-striped table-hover table-bordered"">
                                    <!-- TABLE HEADER -->
                                    <thead>
                                        <tr class=""bg-black"">
                                            <th class=""text-center"" rowspan=""2"">Patient Code</th>
                                            <th class=""text-center"" rowspan=""2"">Referring Facility</th>
                                            <th class=""text-center"" colspan=""5"">Status</th>
                                        </tr>
                                        <tr class=""bg-black"">
                                            <th class=""text-center"">Arrived</th>
                                            <th class=""text-center"">Admitted</th>
                                            <th class=""text-center"">Discharged</th>
                                            ");
            WriteLiteral(@"<th class=""text-center"">Transferred</th>
                                            <th class=""text-center"">Cancelled</th>
                                        </tr>
                                    </thead>
                                    <!-- TABLE BODY -->
                                    <tbody>
");
#nullable restore
#line 94 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                         foreach (var item in Model)
                                        {
                                            var code = item.Code;
                                            var length = item.Facility.Length > 20;
                                            var referredFrom = length ? new string(item.Facility.Take(20).ToArray()) + "..." : item.Facility;
                                            var arrived = item.DateArrived == default ? "" : item.DateArrived.ToString("MM/dd/yy HH:mm");
                                            var admitted = item.DateAdmitted == default ? "" : item.DateAdmitted.ToString("MM/dd/yy HH:mm");
                                            var discharged = item.DateDischarged == default ? "" : item.DateDischarged.ToString("MM/dd/yy HH:mm");
                                            var transferred = item.DateTransferred == default ? "" : item.DateTransferred.ToString("MM/dd/yy HH:mm");
                                            var cancelled = item.DateCancelled == default ? "" : item.DateCancelled.ToString("MM/dd/yy HH:mm");

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 105 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                               Write(code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td class=\"text-success\"");
            BeginWriteAttribute("title", " title=\"", 6472, "\"", 6494, 1);
#nullable restore
#line 106 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
WriteAttributeValue("", 6480, item.Facility, 6480, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 106 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                                           Write(referredFrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td><small class=\"text-success\">");
#nullable restore
#line 107 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                           Write(arrived);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></td>\r\n                                                <td><small class=\"text-success\">");
#nullable restore
#line 108 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                           Write(admitted);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></td>\r\n                                                <td><small class=\"text-success\">");
#nullable restore
#line 109 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                           Write(discharged);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></td>\r\n                                                <td><small class=\"text-success\">");
#nullable restore
#line 110 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                           Write(transferred);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></td>\r\n                                                <td><small class=\"text-success\">");
#nullable restore
#line 111 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                                                           Write(cancelled);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></td>\r\n                                            </tr>\r\n");
#nullable restore
#line 113 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n");
#nullable restore
#line 117 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
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
#line 126 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"card-footer\">\r\n                        ");
#nullable restore
#line 129 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                   Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_PageList.cshtml", new PageListModel
                       {
                           Action = "IncomingReport",
                           HasNextPage = Model.HasNextPage,
                           HasPreviousPage = Model.HasPreviousPage,
                           PageIndex = Model._pageIndex,
                           TotalPages = Model._totalPages,
                           Parameters = new Dictionary<string, string>
                                {
                                    { "page", Model._pageIndex.ToString() },
                                    { "daterange", dateRange },
                                    { "facility", facility},
                                    {"department", department}
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
#line 155 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                   Write(startDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            endDate: \'");
#nullable restore
#line 156 "D:\Systems\Referral - MySql\Referral2\Views\Report\IncomingReport.cshtml"
                 Write(endDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            opens: \'right\'\r\n        });\r\n        $(\'.select2\').select2({\r\n            theme: \'bootstrap4\'\r\n        });\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<IncomingReportViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
