#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8d5e2669943894f30e958ae7c6488eb179231a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MedicalCenterChief_OnlineDoctors), @"mvc.1.0.view", @"/Views/MedicalCenterChief/OnlineDoctors.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8d5e2669943894f30e958ae7c6488eb179231a3", @"/Views/MedicalCenterChief/OnlineDoctors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_MedicalCenterChief_OnlineDoctors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WhosOnlineModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "WhosOnline", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/PartialViews/_MainMenuPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle elevation-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/dist/img/MDMale.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User Avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
  
    ViewData["Title"] = "Online Doctors";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content"">
    <div class=""container"">
        <div class=""row"">
            <!-- CARD DANGER -->
            <div class=""col-md-3"">
                <!-- SELECT USER -->
                <div class=""card card-danger card-green"">
                    <!-- CARD DANGER HEADER -->
                    <div class=""card-header"">
                        <h3 class=""card-title"">
                            Filter Result<br />
                        </h3>
                    </div>
                    <!-- CARD DANGER BODY -->
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8d5e2669943894f30e958ae7c6488eb179231a310417", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"_token\"");
                BeginWriteAttribute("value", " value=\"", 759, "\"", 767, 0);
                EndWriteAttribute();
                WriteLiteral(@" autocomplete=""off"" />
                        <div class=""card-body"">
                            <!-- SEARCH -->
                            <div class=""form-group"">
                                <input type=""text"" placeholder=""Enter name.."" class=""form-control""");
                BeginWriteAttribute("value", " value=\"", 1038, "\"", 1068, 1);
#nullable restore
#line 25 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
WriteAttributeValue("", 1046, ViewBag.CurrentSearch, 1046, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"SearchString\" required autocomplete=\"off\" />\r\n                            </div>\r\n                            <!-- FACILITY -->\r\n                            <div class=\"form-group\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8d5e2669943894f30e958ae7c6488eb179231a311800", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8d5e2669943894f30e958ae7c6488eb179231a312105", async() => {
                        WriteLiteral("Select All");
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
#nullable restore
#line 29 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
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
                WriteLiteral(@"
                            </div>
                            <div class=""form-group hide""></div>
                            <!-- BUTTONS -->
                            <div class=""form-group"">
                                <!-- FILTER -->
                                <button type=""submit"" value=""Filter"" class=""btn btn-block btn-success justify-content-center"">
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e8d5e2669943894f30e958ae7c6488eb179231a316792", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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
                <!-- ONLINE DOCTORS -->
                <div class=""card card-outline"" style=""background: rgba(255, 255, 255, 0.4)"">
                    <!-- DAILY USERS HEADER -->
                    <div class=""card-header with-border"">
                        <h2>
                            Online Doctors
                        </h2>
                    </div>
                    <!-- DAILY USERS BODY -->
                    <div class=""card-body"">
                        <div class=""row"">
");
#nullable restore
#line 59 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
                             foreach (var item in Model)
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
            BeginWriteAttribute("class", " class=\"", 3961, "\"", 3997, 2);
            WriteAttributeValue("", 3969, "widget-user-header", 3969, 18, true);
#nullable restore
#line 78 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
WriteAttributeValue(" ", 3987, widgetBg, 3988, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 160px;\">\r\n                                            <div class=\"widget-user-image\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e8d5e2669943894f30e958ae7c6488eb179231a320468", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </div>\r\n                                            <h3 class=\"widget-user-username\">");
#nullable restore
#line 82 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
                                                                        Write(GlobalFunctions.GetFullName(item.Fname,item.Mname+item.Lname));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                            <h5 class=\"widget-user-desc badge bg-maroon\" style=\"position:absolute; bottom:45%; right:5%;\">");
#nullable restore
#line 83 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
                                                                                                                                     Write(abbrv);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                        </div>
                                        <div class=""card-footer p-0"">
                                            <ul class=""nav flex-column"">
                                                <li class=""nav-item"">
                                                    <a href=""#"" class=""nav-link"">
                                                        ");
#nullable restore
#line 89 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
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
#line 97 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
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
#line 105 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
                                                   Write(status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        <span class=\"float-right badge bg-success\">\r\n                                                            ");
#nullable restore
#line 107 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
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
#line 115 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineDoctors.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WhosOnlineModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
