#pragma checksum "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewForms\PregnantForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa0602079a781a5659eae88754203d3913f26c4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViewForms_PregnantForm), @"mvc.1.0.view", @"/Views/ViewForms/PregnantForm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa0602079a781a5659eae88754203d3913f26c4d", @"/Views/ViewForms/PregnantForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15693769c079e05a982c91dec78c1a398448498", @"/Views/_ViewImports.cshtml")]
    public class Views_ViewForms_PregnantForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PregnantViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal fade"" id=""pregnant-form-modal"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""title-form"">BEmONC/ CEmONC REFERRAL FORM</div>
            <div class=""modal-body"">
                ");
#nullable restore
#line 8 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewForms\PregnantForm.cshtml"
           Write(await Html.PartialAsync("~/Views/Shared/_pregnantForm.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button class=""btn btn-default btn-flat fa-pull-left"" data-dismiss=""modal"">
                    <i class=""fa fa-times""></i>
                    &nbsp;Close
                </button>
                <div class=""justify-content-end"">
                    <button class=""btn btn-info"" type=""button"" data-toggle=""modal"" data-target=""#"">
                        <i class=""fa fa-phone""></i>
                        Call Request
                    </button>
                    <!-- RECOMMEND TO REDIRECT -->
                    <button class=""btn btn-danger"" type=""button"" data-toggle=""modal"" data-target=""#"">
                        <i class=""fa fa-line-chart""></i>
                        Recommend to Redirect
                    </button>
                    <!-- ACCEPT -->
                    <button class=""btn btn-success"" id=""accept-btn""");
            BeginWriteAttribute("value", " value=\"", 1302, "\"", 1321, 1);
#nullable restore
#line 26 "C:\Users\Keith\Desktop\doh\Referral2\Referral2\Views\ViewForms\PregnantForm.cshtml"
WriteAttributeValue("", 1310, Model.Code, 1310, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" type=""button"" data-toggle=""modal"" data-target=""#accept-modal"">
                        <i class=""fa fa-check""></i>
                        Accept
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>

<script>

    var acceptBtn = $('#accept-btn');

    acceptBtn.on('click', function () {
        console.log('yow');
        var patientCode = this.value;
        var url = ""/Remarks/AcceptedRemark?code="" + patientCode;
        console.log(url);
        $(""#accept_content"").html(""Loading.............."");
        $.get(url, function (result) {
            $(""#accept_content"").html(result);
        })
    });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PregnantViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591