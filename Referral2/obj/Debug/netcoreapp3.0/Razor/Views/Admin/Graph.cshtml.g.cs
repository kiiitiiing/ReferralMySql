#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1864c47f5309461bb70653d93a7fb1768e15556"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Graph), @"mvc.1.0.view", @"/Views/Admin/Graph.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1864c47f5309461bb70653d93a7fb1768e15556", @"/Views/Admin/Graph.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Graph : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GraphValuesModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/plugins/chart.js/Chart.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/dist/js/utils.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Graph", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("fa-pull-left form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
  
    ViewData["Title"] = "Graph";
    var startDate = ViewBag.StartDate;
    var endDate = ViewBag.EndDate;
    var dateRange = startDate.ToString("yyyy/MM/dd") + " - " + endDate.ToString("yyyy/MM/dd");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f1864c47f5309461bb70653d93a7fb1768e155568599", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1864c47f5309461bb70653d93a7fb1768e155569713", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div style=\"\r\n     width: 97.5vw;\r\n    position: relative;\r\n    left: 45%;\r\n    right: 45%;\r\n    margin-left: -45vw;\r\n    margin-right: -45vw;\">\r\n\t<div class=\"card card-outline card-success\">\r\n\t\t<div class=\"card-header\">\r\n\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1864c47f5309461bb70653d93a7fb1768e1555611007", async() => {
                WriteLiteral("\r\n\t\t\t\t<input class=\"form-control form-control-sm bg-white\"\r\n\t\t\t\t\t   id=\"daterange\"\r\n\t\t\t\t\t   name=\"daterange\"\r\n\t\t\t\t\t   readonly\r\n\t\t\t\t\t   style=\"cursor:pointer;\"\r\n\t\t\t\t\t   type=\"text\"");
                BeginWriteAttribute("value", "\r\n\t\t\t\t\t   value=\"", 836, "\"", 863, 1);
#nullable restore
#line 28 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
WriteAttributeValue("", 853, dateRange, 853, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t\t\t\t<button type=\"submit\" value=\"Search\" class=\"btn btn-sm btn-success\">\r\n\t\t\t\t\t<i class=\"fa fa-search\"></i>\r\n\t\t\t\t</button>\r\n\t\t\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t</div>\r\n\t\t<div class=\"card-body\">\r\n\t\t\t<div style=\"width: 100%;\">\r\n\t\t\t\t<canvas id=\"canvas\"></canvas>\r\n\t\t\t</div>\r\n\r\n\r\n");
#nullable restore
#line 40 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
             foreach (var item in Model)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<input type=\"text\" class=\"facilityName\"");
            BeginWriteAttribute("value", " value=\"", 1205, "\"", 1227, 1);
#nullable restore
#line 42 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
WriteAttributeValue("", 1213, item.Facility, 1213, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden />\r\n\t\t\t\t<input type=\"hidden\" class=\"incoming\"");
            BeginWriteAttribute("value", " value=\"", 1281, "\"", 1303, 1);
#nullable restore
#line 43 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
WriteAttributeValue("", 1289, item.Incoming, 1289, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t<input type=\"hidden\" class=\"accepted\"");
            BeginWriteAttribute("value", " value=\"", 1350, "\"", 1372, 1);
#nullable restore
#line 44 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
WriteAttributeValue("", 1358, item.Accepted, 1358, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t<input type=\"hidden\" class=\"outgoing\"");
            BeginWriteAttribute("value", " value=\"", 1419, "\"", 1441, 1);
#nullable restore
#line 45 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
WriteAttributeValue("", 1427, item.Outgoing, 1427, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\t\t\t\t<input type=\"hidden\" class=\"total\"");
            BeginWriteAttribute("value", " value=\"", 1485, "\"", 1504, 1);
#nullable restore
#line 46 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
WriteAttributeValue("", 1493, item.Total, 1493, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 47 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
			}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</div>\r\n\t</div>\r\n</div>\r\n<script>\r\n\t//datepicker\r\n\t$(document).ready(function () {\r\n        $(\'input[name=\"daterange\"]\').daterangepicker({\r\n            format: \'YYYY/MM/DD\',\r\n            startDate: \'");
#nullable restore
#line 56 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
                   Write(startDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            endDate: \'");
#nullable restore
#line 57 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
                 Write(endDate.ToString("yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ',
            opens: 'right'
        });
    });
	//end
    var Facilities = [];
    var Incoming = [];
    var Accepted = [];
    var Outgoing = [];
    var IncomingBG = [];
    var AcceptedBG = [];
    var OutgoingBG = [];
    var fac = $('.facilityName');
    var inc = $('.incoming');
    var acc = $('.accepted');
	var out = $('.outgoing');
	for(var i = 0; i < fac.length; i++){
        Facilities[i] = ($(fac[i]).val());
        Incoming[i] = ($(inc[i]).val());
        Accepted[i] = ($(acc[i]).val());
        Outgoing[i] = ($(out[i]).val());
        //IncomingBG = '#0000FF';
        //AcceptedBG = '#0000FF';
        //OutgoingBG = '#0000FF';
    }
	window.chartColors = {
      red: 'rgb(255, 99, 132)',
      orange: 'rgb(255, 159, 64)',
      yellow: 'rgb(255, 205, 86)',
      green: 'rgb(45, 201, 12)',
      blue: 'rgb(54, 162, 235)',
      purple: 'rgb(153, 102, 255)',
      grey: 'rgb(201, 203, 207)'
    };
    var thicc = 6;
    var barPercent = 1;
    var Total = $");
            WriteLiteral(@"('.total');
    var x = 0;
    var color = Chart.helpers.color;
    var horizontalBarChartData = {
        labels: Facilities,
		datasets: [{
			label: 'Incoming',
            backgroundColor: color(window.chartColors.blue).alpha(1).rgbString(),
            borderColor: window.chartColors.blue,
            barPercentage: barPercent,
            borderWidth: 1,
			//barThickness: thicc,
            data: Incoming
		}, {
			label: 'Accepted',
			backgroundColor: color(window.chartColors.red).alpha(1).rgbString(),
			borderColor: window.chartColors.red,
            barPercentage: barPercent,
            borderWidth: 1,
			//barThickness: thicc,
			data: Accepted
		}, {
			label: 'Outgoing',
			backgroundColor: color(window.chartColors.green).alpha(1).rgbString(),
			borderColor: window.chartColors.green,
            barPercentage: barPercent,
            borderWidth: 1,
			//barThickness: thicc,
			data: Outgoing
		}]

	};

	window.onload = function () {
		var ctx = document.get");
            WriteLiteral(@"ElementById('canvas').getContext('2d');
		window.myHorizontalBar = new Chart(ctx, {
			type: 'horizontalBar',
			data: horizontalBarChartData,
			options: {
				// Elements options apply to all of the options unless overridden in a dataset
				// In this case, we are setting the border of each horizontal bar to be 2px wide
				elements: {
					rectangle: {
						borderWidth: 2,
					}
				},
				responsive: true,
                legend: {
                    display: true,
					position: 'bottom',
				},
				title: {
					display: true,
                    text: 'E REFERRAL REPORT IN '+'");
#nullable restore
#line 146 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
                                              Write(startDate.ToString("MMMM yyyy").ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("\'+\' to \'+\'");
#nullable restore
#line 146 "D:\Systems\Referral - MySql\Referral2\Views\Admin\Graph.cshtml"
                                                                                                  Write(endDate.ToString("MMMM yyyy").ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n\t\t\t\t\tfontSize: 30\r\n\t\t\t\t}\r\n\t\t\t}\r\n\t\t});\r\n\r\n    };\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GraphValuesModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
