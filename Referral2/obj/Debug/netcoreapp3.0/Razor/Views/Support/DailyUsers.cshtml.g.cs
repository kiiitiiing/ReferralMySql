#pragma checksum "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77df26c77f43761a0e9703cfacb36945778e482c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Support_DailyUsers), @"mvc.1.0.view", @"/Views/Support/DailyUsers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77df26c77f43761a0e9703cfacb36945778e482c", @"/Views/Support/DailyUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15693769c079e05a982c91dec78c1a398448498", @"/Views/_ViewImports.cshtml")]
    public class Views_Support_DailyUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<DailyUsersViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DailyUsers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/PartialViews/_SupportLinksPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
  
    ViewData["Title"] = "Daily Users";

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
                        <span class=""badge fa-pull-right"">
                            ");
#nullable restore
#line 20 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                       Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n                    </div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77df26c77f43761a0e9703cfacb36945778e482c8938", async() => {
                WriteLiteral(@"
                        <!-- CARD DANGER BODY -->
                        <div class=""card-body"">
                                <!-- SELECT DATE -->
                                <div class=""form-group"">
                                    <input class=""form-control"" type=""text"" id=""datetimepicker"" name=""date""");
                BeginWriteAttribute("value", " value=\"", 1095, "\"", 1139, 1);
#nullable restore
#line 28 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
WriteAttributeValue("", 1103, ViewBag.Date.ToString("dd/MM/yyyy"), 1103, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                </div>
                        </div>
                        <div class=""card-footer"">
                            <div class=""form-group"">
                                <!-- FILTER -->
                                <button type=""submit"" class=""btn btn-block btn-success"">
                                    <i class=""fa fa-filter""></i>
                                    &nbsp;Filter Result
                                </button>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77df26c77f43761a0e9703cfacb36945778e482c10454", async() => {
                    WriteLiteral("\r\n                                    <i class=\"fa fa-file-excel\"></i>\r\n                                    &nbsp;Export Data\r\n                                ");
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
#line 38 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                                                 WriteLiteral(true);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["export"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-export", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["export"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                                                                        WriteLiteral(ViewBag.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["date"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-date", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["date"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "77df26c77f43761a0e9703cfacb36945778e482c15088", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
                    <div class=""card-header card-success with-border"">
                        <h4>
                            Daily Users
                        </h4>
                    </div>
                    <!-- DAILY USERS BODY -->
                    <div class=""card-body"">
");
#nullable restore
#line 59 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                         if (Model.Count() > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""table-responsive"">
                                <table class=""table table-striped table-hover table-bordered"" style=""font-size: 14px;"">
                                    <thead>
                                        <tr class=""bg-black"">
                                            <th>User</th>
                                            <th class=""text-center"">On Duty</th>
                                            <th class=""text-center"">Off Duty</th>
                                            <th class=""text-center"">Login</th>
                                            <th class=""text-center"">Logout</th>

                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 74 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                         foreach (var item in Model)
                                        {
                                            var logout = item.LogoutTime == default ? "" : item.LogoutTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                                            var login = item.LoginTime == default ? "" : item.LoginTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td style=\"font-size:0.9em;white-space: nowrap;\">");
#nullable restore
#line 79 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                                                                            Write(item.MDName.NameToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td class=\"text-center text-success\">\r\n");
#nullable restore
#line 81 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                                     if (item.OnDuty == "login")
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <i class=\"fa fa-check\"></i>\r\n");
#nullable restore
#line 84 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </td>\r\n                                                <td class=\"text-center text-danger\">\r\n");
#nullable restore
#line 87 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                                     if (item.OnDuty == "login off")
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <i class=\"fa fa-check\"></i>\r\n");
#nullable restore
#line 90 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </td>\r\n                                                <td class=\"text-center text-info\">\r\n                                                    ");
#nullable restore
#line 93 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                               Write(login);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                                <td class=\"text-center text-warning\">\r\n                                                    ");
#nullable restore
#line 96 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                               Write(logout);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 99 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n");
#nullable restore
#line 103 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
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
#line 112 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"card-footer\">\r\n                        ");
#nullable restore
#line 115 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Support\DailyUsers.cshtml"
                   Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_PageList.cshtml", new PageListModel
                        {
                            Action = "DailyUsers",
                            HasNextPage = Model.HasNextPage,
                            HasPreviousPage = Model.HasPreviousPage,
                            PageIndex = Model._pageIndex,
                            TotalPages = Model._totalPages,
                            Parameters = new Dictionary<string, string>
                            {
                                {"page",Model._pageIndex.ToString() },
                                {"date", ViewBag.Date.ToString("dd/MM/yyyy") }
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

<script>
    $(function () {
        $('#datetimepicker').datepicker({
            format: 'dd/mm/yyyy',
            autoclose: true,
            forceParse: true
        });
    })
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<DailyUsersViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
