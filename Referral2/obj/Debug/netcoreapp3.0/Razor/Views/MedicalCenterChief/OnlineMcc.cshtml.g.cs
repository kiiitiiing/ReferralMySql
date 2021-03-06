#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineMcc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "548dfd49bfe0de6a1b59a42b0c9f665c8b1961b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MedicalCenterChief_OnlineMcc), @"mvc.1.0.view", @"/Views/MedicalCenterChief/OnlineMcc.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"548dfd49bfe0de6a1b59a42b0c9f665c8b1961b3", @"/Views/MedicalCenterChief/OnlineMcc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_MedicalCenterChief_OnlineMcc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OnlineMccModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""card card-success"" style=""font-size: 14px;"">
    <div class=""card-header"">
        <h4 class=""card-title"">Online Facilities</h4>
    </div>

    <div class=""card-body"" style=""overflow: auto; height: 400px; scroll"">
        <div class=""list-group"">
");
#nullable restore
#line 10 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineMcc.cshtml"
             foreach (var item in Model)
            {
                var length = 20;
                var facility = item.FacilityName.Length > length ? new string(item.FacilityName.Take(length).ToArray()) + "..." : item.FacilityName;
                var text = item.Online ? "danger" : "success";

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"list-group-item clearfix\"");
            BeginWriteAttribute("title", " title=\"", 654, "\"", 680, 1);
#nullable restore
#line 15 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineMcc.cshtml"
WriteAttributeValue("", 662, item.FacilityName, 662, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"#\">\r\n                    ");
#nullable restore
#line 16 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineMcc.cshtml"
               Write(facility.NameToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <span class=\"fa-pull-right\">\r\n                        <i");
            BeginWriteAttribute("class", " class=\"", 814, "\"", 845, 4);
            WriteAttributeValue("", 822, "fa", 822, 2, true);
            WriteAttributeValue(" ", 824, "fa-circle", 825, 10, true);
            WriteAttributeValue(" ", 834, "text-", 835, 6, true);
#nullable restore
#line 18 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineMcc.cshtml"
WriteAttributeValue("", 840, text, 840, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                    </span>\r\n                </a>\r\n");
#nullable restore
#line 21 "D:\Systems\Referral - MySql\Referral2\Views\MedicalCenterChief\OnlineMcc.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n<script type=\"text/javascript\">\r\n    console.log(\'wtf??\');\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OnlineMccModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
