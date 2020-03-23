#pragma checksum "C:\Users\user\Source\Repos\Referral\Referral2\Views\Modals\ViewSeens.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00be45103691babff42514dc00bd7da286cc231b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Modals_ViewSeens), @"mvc.1.0.view", @"/Views/Modals/ViewSeens.cshtml")]
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
#line 1 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Support;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Doctor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Remarks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.ViewPatients;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Consolidated;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Mcc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.MobileModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\user\Source\Repos\Referral\Referral2\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00be45103691babff42514dc00bd7da286cc231b", @"/Views/Modals/ViewSeens.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15693769c079e05a982c91dec78c1a398448498", @"/Views/_ViewImports.cshtml")]
    public class Views_Modals_ViewSeens : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SeenCallViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""modal fade"" id=""seen-modal"">
    <div class=""modal-dialog modal-sm"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4>
                    <i class=""fa fa-user-md""></i>
                    &nbsp;SEEN BY:
                </h4>
            </div>
            <div class=""modal-body"">
");
#nullable restore
#line 14 "C:\Users\user\Source\Repos\Referral\Referral2\Views\Modals\ViewSeens.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"list-group\">\r\n                        <a href=\"#\" class=\"list-group-item clearfix\">\r\n                            <span class=\"title-info\">");
#nullable restore
#line 18 "C:\Users\user\Source\Repos\Referral\Referral2\Views\Modals\ViewSeens.cshtml"
                                                Write(item.MdName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <br>\r\n                            <small class=\"text-primary\">\r\n                                Seen: ");
#nullable restore
#line 21 "C:\Users\user\Source\Repos\Referral\Referral2\Views\Modals\ViewSeens.cshtml"
                                 Write(item.SeenDate.ToString("MMMM dd, yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </small>\r\n                            <br>\r\n                            <small class=\"text-success\">\r\n                                Contact: ");
#nullable restore
#line 25 "C:\Users\user\Source\Repos\Referral\Referral2\Views\Modals\ViewSeens.cshtml"
                                    Write(item.MdContact);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </small>\r\n                        </a>\r\n                    </div>\r\n");
#nullable restore
#line 29 "C:\Users\user\Source\Repos\Referral\Referral2\Views\Modals\ViewSeens.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SeenCallViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
