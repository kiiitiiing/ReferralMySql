#pragma checksum "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df0fa1301efb166de3b1a515eb4b8dbcf82d3ef0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminDashboard), @"mvc.1.0.view", @"/Views/Admin/AdminDashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df0fa1301efb166de3b1a515eb4b8dbcf82d3ef0", @"/Views/Admin/AdminDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15693769c079e05a982c91dec78c1a398448498", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminDashboardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/sounds/sound1.ogg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml"
  
    ViewData["Title"] = "Admin Dashboard";
    var totalDoctor = Model.TotalDoctors;
    var onlineDoctors = Model.OnlineDoctors;
    var activeFacility = Model.ActviteFacilities;
    var referredPatients = Model.ReferredPatients;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""row"">
        <!-- ADMIN DASHBOARD -->
        <div class=""col-md-9"">
            <div class=""card card-success card-outline"">
                <div class=""card-header with-border"">
                    <h4>Admin: Dashboard</h4>
                </div>
                <div class=""card-body"">
                    <div class=""row"">
                        <!-- TOTAL DOCTORS -->
                        <div class=""col-sm-6"">
                            <div class=""small-box bg-gradient-yellow"">
                                <div class=""inner"" style=""padding-left: 30px;"">
                                    <h4>");
#nullable restore
#line 23 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml"
                                   Write(totalDoctor);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>

                                    <p>TOTAL DOCTORS</p>
                                </div>
                                <div class=""icon"">
                                    <i class=""fa fa-user-md""></i>
                                </div>
                            </div>
                        </div>
                        <!-- ONLINE DOCTORS -->
                        <div class=""col-sm-6"">
                            <div class=""small-box bg-gradient-cyan"">
                                <div class=""inner"" style=""padding-left: 30px;"">
                                    <h4>");
#nullable restore
#line 36 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml"
                                   Write(onlineDoctors);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>

                                    <p>ONLINE DOCTORS</p>
                                </div>
                                <div class=""icon"">
                                    <i class=""fa fa-users""></i>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <!-- ACTIVE FACILITIES -->
                        <div class=""col-sm-6"">
                            <div class=""small-box bg-gradient-red"">
                                <div class=""inner"" style=""padding-left: 30px;"">
                                    <h4>");
#nullable restore
#line 51 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml"
                                   Write(activeFacility);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>

                                    <p>ACTIVE FACILITIES</p>
                                </div>
                                <div class=""icon"">
                                    <i class=""fa fa-hospital""></i>
                                </div>
                            </div>
                        </div>
                        <!-- REFERRED PATIENTS -->
                        <div class=""col-sm-6"">
                            <div class=""small-box bg-gradient-green"">
                                <div class=""inner"" style=""padding-left: 30px;"">
                                    <h4>");
#nullable restore
#line 64 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml"
                                   Write(referredPatients);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>

                                    <p>REFERRED PATIENTS</p>
                                </div>
                                <div class=""icon"">
                                    <i class=""far fa-file-alt""></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- LINKS -->
        <div class=""col-md-3"">
            ");
#nullable restore
#line 79 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml"
       Write(await Html.PartialAsync("~/Views/Shared/PartialViews/_LinksPartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
        <!-- MONTHLY ACTIVITY -->
        <div class=""col-md-9"">
            <div class=""card"">
                <div class=""card-header"">
                    <h4>Monthly Activity</h4>
                </div>
                <div class=""card-body"" id=""dashboard_div"">
                    <div class=""chart"">
                        <canvas id=""barChart"" height=""326"" width=""653"" style=""width: 523px; height: 261px;""></canvas>
                    </div>
                </div>
            </div>
        </div>
    </div>

<audio id=""soundFx"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "df0fa1301efb166de3b1a515eb4b8dbcf82d3ef012207", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</audio>\r\n\r\n<script>\r\n    DashboardAPI(\'");
#nullable restore
#line 101 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\Admin\AdminDashboard.cshtml"
             Write(User.FindFirstValue(ClaimTypes.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
    //$('#notif-modal').modal('show');

    

    var title = ""New Referral""
    var patient = ""Jane Doe"";
    var actionMd = ""Dr. Keith Joseph"";
    var status = """";
    var facility = ""Talisay District Hospital"";

    var delay = 5000;
    $(function () {
        Lobibox.notify('success', {
            delay: false,
            img: 'assets/hospitallogos/DOHLOGO.png',
            title: title,
            msg: patient + ' was referred by ' + actionMd + ' of ' + facility
        });
    });

    /*
        toastr.options = {
          ""closeButton"": false,
          ""debug"": false,
          ""newestOnTop"": false,
          ""progressBar"": false,
          ""positionClass"": ""toast-bottom-right"",
          ""preventDuplicates"": false,
          ""onclick"": null,
          ""showDuration"": ""300"",
          ""hideDuration"": ""1000"",
          ""timeOut"": ""0"",
          ""extendedTimeOut"": ""1000"",
          ""showEasing"": ""swing"",
          ""hideEasing"": ""linear"",
          ""showMeth");
            WriteLiteral("od\": \"fadeIn\",\r\n          \"hideMethod\": \"fadeOut\"\r\n    }\r\n    Command: toastr[\"success\"](patient + \" was referred by \" + actionMd + \" of \" + facility, title)*/\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminDashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591