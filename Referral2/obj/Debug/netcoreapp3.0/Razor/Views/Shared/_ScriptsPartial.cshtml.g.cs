#pragma checksum "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf9091c4b650d8f3aeb4cdff4602104bbc2659b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ScriptsPartial), @"mvc.1.0.view", @"/Views/Shared/_ScriptsPartial.cshtml")]
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
#line 1 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Support;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Doctor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Remarks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.ViewPatients;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Consolidated;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.ViewModels.Mcc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Referral2.Models.MobileModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf9091c4b650d8f3aeb4cdff4602104bbc2659b9", @"/Views/Shared/_ScriptsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15693769c079e05a982c91dec78c1a398448498", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ScriptsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
    // for details on configuring this project to bundle and minify static web assets.

    // Write your JavaScript code.
    // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
    // for details on configuring this project to bundle and minify static web assets.

    // Write your JavaScript code.

    $(function () {
        //---------------------- NOTIF ---------------------------------



        //--------------------------------------------------------------


        var numberOfNotif = $('span.numberNotif');

        if (numberOfNotif.length > 0) {
            $.when(GetNumberNotif()).done(function (output) {
                numberOfNotif.text(output);
            });
        }

        $('.select2').select2({
            theme: 'bootstrap4'
        });

        var supReport = $('span.supReport");
            WriteLiteral(@"');

        if (supReport.length > 0) {
            $.when(GetSupportReport()).done(function (output) {
                supReport.text("""");
                supReport.text(output);
            });
        }

        //----------------------- TRY-----------------------------------


        //---------------------- ADDRESS CHANGE -------------------------


        //---------------------- ADDRESS CHANGE -------------------------



        //---------------------- MODALS ---------------------------------

        var placeholderElement = $('#modal-placeholders');

        var modals = $('#all_modals');
        modals.on('click', 'button[data-save=""modal""]', function (event) {
            event.preventDefault();
            event.stopImmediatePropagation();
            var content = $($(this).parent()).parent();
            var form = content.find('form');
            var contentId = content.attr('id');
            var actionUrl = form.attr('action');
            var dataToSend =");
            WriteLiteral(@" form.serialize();
            console.log(contentId);
            $.ajax({
                url: actionUrl,
                type: 'post',
                async: true,
                data: dataToSend,
                success: function (output) {
                    var newBody = $('.modal-body', output);
                    var errors = newBody.find('span.text-danger').text();
                    console.log(errors);
                    if (errors == '') {
                        console.log('wtf')
                        $.when(modals.find('.modal.show').modal('hide')).done(function () {
                            console.log(contentId);
                            var modal = $('#' + contentId);
                            LoadingModal(modal);
                            if (contentId == 'update_inventory_modal') {
                                sessionStorage.setItem('onReload', 'update_inventory');
                                location.reload();
                            }
    ");
            WriteLiteral(@"                        else if (contentId == 'issues-modal') {
                                sessionStorage.setItem('onReload', 'updatedIssues');
                                location.reload();
                            }
                            else if (formId == 'update-doctor-modal') {
                                sessionStorage.setItem('onReload', 'updateDoctor');
                                location.reload();
                            }
                            else if (formId == 'change-password-modal') {
                                sessionStorage.setItem('onReload', 'passWordChanged');
                                location.reload();
                            }
                            else if (formId == 'reco-modal') {
                                var input = placeholderElement.find('.modal-footer').find('form').find('.code').val();
                                console.log(input);
                            }
                            else if");
            WriteLiteral(@" (formId == 'switch-user-modal') {
                                location.href = '/Home/Index';
                            }
                            else if (formId == 'add-doctor-modal') {
                                sessionStorage.setItem('onReload', 'addDoctor');
                                location.reload();
                            }
                            else if (formId == 'add-support-modal') {
                                sessionStorage.setItem('onReload', 'addSupport');
                                location.reload();
                            }
                            else if (formId == 'update-support-modal') {
                                sessionStorage.setItem('onReload', 'updateSupport');
                                location.reload();
                            }
                            else if (formId == 'add-facility-modal') {
                                sessionStorage.setItem('onReload', 'addFacility');
                      ");
            WriteLiteral(@"          location.reload();
                            }
                            else if (formId == 'update-facility-modal') {
                                sessionStorage.setItem('onReload', 'updateFacility');
                                location.reload();
                            }
                        });
                    }
                    else {
                        content.find('.modal-body').replaceWith(newBody);
                        if (contentId == 'new_sop') {
                            var disabled = content.find('#notavailable');
                            if (disabled.is(':checked') == true) {
                                content.find('#dateOnset').attr('disabled', true);
                            }
                        }
                        else if (contentId == 'add_patient_modal') {
                            var disabled = content.find('#sameAddress');
                            if (disabled.is(':checked') == true) {
           ");
            WriteLiteral(@"                     content.find('#permanent_address').css('display', 'none');
                            }
                        }
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    alert(thrownError);
                }
            })
        });
        var smallModal = $('#small_modal');
        smallModal.on('hidden.bs.modal', function () {
            var contentId = smallModal.find('.modal-dialog.modal-sm').attr('id');
            LoadingModal('#' + contentId);
        });
        var largeModal = $('#large_modal');
        largeModal.on('hidden.bs.modal', function () {
            var contentId = largeModal.find('.modal-dialog.modal-lg').attr('id');
            LoadingModal('#' + contentId);
        });
        var referModal = $('#refer_modal');
        referModal.on('hidden.bs.modal', function () {
            var contentId = referModal.find('.modal-dialo");
            WriteLiteral(@"g.modal-lg').attr('id');
            LoadingModal('#' + contentId);
            console.log(contentId);
        });



        placeholderElement.on('click', 'button[data-save=""modal""]', function (event) {
            event.preventDefault();
            event.stopImmediatePropagation();
            var content = placeholderElement.find('.modal').find('.modal-content');
            content.prepend('<div id=""overlay_loading"" class=""overlay d-flex justify-content-center align-items-center""><i class=""fas fa-2x fa-sync fa-spin""></i></div>');
            var form = placeholderElement.find('.modal').find('form');
            var formId = placeholderElement.find('.modal').attr('id');
            var actionUrl = form.attr('action');
            var dataToSend = form.serialize();
            console.log(actionUrl);
            $.ajax({
                url: actionUrl,
                type: 'post',
                async: true,
                data: dataToSend,
                success: function (data");
            WriteLiteral(@") {
                    var newBody = $('.modal-body', data);
                    setTimeout(
                        function () {
                            placeholderElement.find('#overlay_loading').remove();
                            placeholderElement.find('.modal-body').replaceWith(newBody);
                            var validation = $('span.text-danger').text();
                            $('.select2').select2({
                                theme: 'bootstrap4'
                            });
                            if (formId == 'reco-modal') {
                                console.log('chat sent');
                                $('#chat').val('');
                                $('div.direct-chat-messages').animate({ scrollTop: $('#last-item').position().top }, 0);
                            }
                            else if (validation == '') {
                                placeholderElement.find('.modal').modal('hide');
                                if (");
            WriteLiteral(@"formId == 'update-doctor-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'updateDoctor');
                                    location.reload();
                                }
                                else if (formId == 'change-password-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'passWordChanged');
                                    location.reload();
                                }
                                else if (formId == 'reco-modal') {
                                    var input = placeholderElement.find('.modal-footer').find('form').find('.code').val();
                                    console.log(input);
                                }
                                else if (formId == 'switch-user-modal') {
           ");
            WriteLiteral(@"                         location.href = '/Home/Index';
                                }
                                else if (formId == 'add-doctor-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'addDoctor');
                                    location.reload();
                                }
                                else if (formId == 'add-support-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'addSupport');
                                    location.reload();
                                }
                                else if (formId == 'update-support-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'updateSupport'");
            WriteLiteral(@");
                                    location.reload();
                                }
                                else if (formId == 'add-facility-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'addFacility');
                                    location.reload();
                                }
                                else if (formId == 'update-facility-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'updateFacility');
                                    location.reload();
                                }
                                else if (formId == 'issues-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'updated");
            WriteLiteral(@"Issues');
                                    location.reload();
                                }
                            }
                        }, 700);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    if (xhr.status === 401) {
                        location.reload();
                    }
                    else {
                        console.log(xhr.status)
                        alert(xhr.responseText);
                        alert(thrownError);
                    }
                }
            });
        });


        //---------------------- MODALS ---------------------------------

        //-------------------- ADDRESS ON CHANGE -------------------




        //-------------------- CHANGE LOGIN STATUS ----------------------------

        var onDuty = $('button#btn-on-duty');
        var offDuty = $('button#btn-off-duty');
        var container = $('div#login-status-modal');

        onDuty.on(");
            WriteLiteral(@"'click', function () {
            SetLoginStatus('onDuty');
            container.modal('hide');
            location.reload();
        });

        offDuty.on('click', function () {
            SetLoginStatus('offDuty');
            container.modal('hide');
            location.reload();
        });



        //-------------------- CHANGE LOGIN STATUS ----------------------------

        //-------------------- DASHBOARD ----------------------------



        //-------------------- END -----------------------------------


    });

    function LoadingModal(id) {
        var urls = '");
#nullable restore
#line 300 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("ModalLoading", "Account"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        return $.ajax({
            url: urls,
            type: 'get',
            async: true,
            success: function (output) {
                $(id).empty();
                $(id).html(output);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.responseText);
                alert(thrownError);
            }
        });
        }


    function ProvinceOnChange(id) {
        var muncitySelect = $('#muncity-filter');
        if (id != '') {
            $.when(GetMuncitiesFiltered(id)).done(function (output) {
                muncitySelect.empty()
                    .append($('<option>', {
                        value: '',
                        text: 'Select City/Municipality'
                    }));
                jQuery.each(output, function (i, item) {
                    muncitySelect.append($('<option>', {
                        value: item.id,
                        text: item.description
              ");
            WriteLiteral(@"      }));
                });
            });
        }
        else {
            muncitySelect.empty()
                .append($('<option>', {
                    value: '',
                    text: 'Select City/Municipality'
                }));
        }
    }

    function MuncityOnChange(id) {
        var barangaySelect = $('#barangay-filter');
        if (id != '') {
            $.when(GetBarangayFiltered(id)).done(function (output) {
                barangaySelect.empty()
                    .append($('<option>', {
                        value: '',
                        text: 'Select Barangay'
                    }));
                jQuery.each(output, function (i, item) {
                    barangaySelect.append($('<option>', {
                        value: item.id,
                        text: item.description
                    }));
                });
            });
        }
        else {
            barangaySelect.empty()
                .append($('<op");
            WriteLiteral(@"tion>', {
                    value: '',
                    text: 'Select Barangay'
                }));
        }
    }

    function OpenModal(btn) {
        var url = btn.data('url');
        var target = btn.data('target');
        var action = btn.data('action');
        console.log(url);
        var content = $(action);
        $.when($(target).modal('show')).done(function () {
            $.ajax({
                url: url,
                tpye: 'get',
                async: true,
                success: function (data) {
                    setTimeout(function () {
                        content.html(data);
                    }, 500);
                },
                timeout: 60000,
                error: function (xhr, ajaxOptions, thrownError) {
                    if (xhr.status === 401) {
                        location.reload();
                    }
                    else {
                        console.log(xhr.status)
                        $('body').fin");
            WriteLiteral(@"d('#loadings').modal('toggle');
                        alert(xhr.responseText);
                        alert(thrownError);
                    }
                }
            });
        });
    }

    //----------------------- FUNCTIONS --------------------------
    function FacilityOnChange(id) {
        var facilityAddress = $('#facilityAddress');
        var departmentSelect = $('#departmentFilter');
        $.when(getDepartmentFiltered(id)).done(function (output) {
            facilityAddress.text(output.address);

            departmentSelect.empty()
                .append($('<option>', {
                    value: '',
                    text: 'Select Department...'
                }));

            departmentSelect.empty()
                .append($('<option>', {
                    value: '',
                    text: 'Any'
                }));

            jQuery.each(output.departments, function (i, item) {
                departmentSelect.append($('<option>', {
   ");
            WriteLiteral(@"                 value: item.departmentId,
                    text: item.departmentName
                }))
            });
        });
    }

    function DepartmentOnChange(facId, depId) {
        if (facId == '0') {
            facId == '24';
        }

        $.when(getMdFiltered(facId, depId)).done(function (output) {
            $('#doctorFiltered').empty()
                .append($('<option>', {
                    value: '',
                    text: 'Any'
                }));

            jQuery.each(output, function (i, item) {
                $('#doctorFiltered').append($('<option>', {
                    value: item.mdId,
                    text: item.doctorName
                }));
            });
        });
    }

    function DashboardAPI(level) {

        //var bar_chart = $('#barChart');

        var link = '");
#nullable restore
#line 454 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("DashboardValues", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '/' + level;
        $.ajax({
            url: link,
            type: ""GET"",
            success: function (data) {
                console.log(data)
                var chartdata = {
                    type: 'bar',
                    data: {
                        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                        // labels: month,
                        datasets: [
                            {
                                label: 'Referred',
                                backgroundColor: '#8e9cff',
                                data: data.referred
                            },
                            {
                                label: 'Accepted',
                                backgroundColor: '#26B99A',
                                data: data.accepted
                            },
                            {
                                label: 'Redirected',
                       ");
            WriteLiteral(@"         backgroundColor: '#03586A',
                                data: data.redirected
                            }
                        ]
                    }
                };


                var ctx = document.getElementById('barChart').getContext('2d');
                new Chart(ctx, chartdata);
            }
        });

");
            WriteLiteral(@"    }

    function Toast(type, message) {
        toastr.options = {
            ""closeButton"": false,
            ""debug"": false,
            ""newestOnTop"": false,
            ""progressBar"": false,
            ""positionClass"": ""toast-top-right"",
            ""preventDuplicates"": false,
            ""onclick"": null,
            ""showDuration"": ""1000"",
            ""hideDuration"": ""1500"",
            ""timeOut"": ""1500"",
            ""extendedTimeOut"": ""1500"",
            ""showEasing"": ""swing"",
            ""hideEasing"": ""linear"",
            ""showMethod"": ""fadeIn"",
            ""hideMethod"": ""fadeOut""
        }
        Command: toastr[type](message)
    }

    function OnBoardChart(chart, trans, tot) {
        var noTrans = tot - trans;
        CanvasJS.addColorSet(""greenShades"",
            [//colorSet Array
                ""#6762ff"",
                ""#ff686b""
            ]);
        console.log(chart);

        var with_transaction1 = Math.round((trans / tot) * 100);
        var no");
            WriteLiteral(@"_transaction1 = Math.round((noTrans/tot) * 100);
        var options1 = {
            colorSet: ""greenShades"",
            exportEnabled: true,
            animationEnabled: true,
            title: {
                text: ""Overall""
            },
            data: [{
                type: ""pie"",
                startAngle: 45,
                showInLegend: ""true"",
                toolTipContent: ""{y}%"",
                legendText: ""{label}"",
                yValueFormatString: ""#,##0.#"" % """",
                dataPoints: [
                    { label: ""With Transaction in "" + with_transaction1 + ""% in "" + ""15 out of 20"", legendText: ""With Transaction"", y: with_transaction1 },
                    { label: ""No Transaction in "" + no_transaction1 + ""% in "" + ""5 out of 20"", legendText: ""No Transaction"", y: no_transaction1 }
                ]
            }]
        };
        chart.CanvasJSChart(options1);
    }

    function GetDashboardValues(level) {
        var urlss = '");
#nullable restore
#line 586 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("DashboardValues", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + level;\r\n        return $.ajax({\r\n        url: urlss,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function GetAvailableDepartments(id) {\r\n        var url = + id; \'");
#nullable restore
#line 595 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                    Write(Url.Action("AvailableDepartments", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n        return $.ajax({\r\n        url: url,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function RemoveFacility(id) {\r\n        var url = \'");
#nullable restore
#line 604 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
              Write(Url.Action("RemoveFacility", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n    $.ajax({\r\n        url: url,\r\n        tpye: \'post\',\r\n        async: true\r\n    });\r\n    }\r\n\r\n    function SetLoginStatus(status) {\r\n        var urlss = \'");
#nullable restore
#line 613 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("ChangeLoginStatus", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + status;\r\n    $.ajax({\r\n        url: urlss,\r\n        tpye: \'get\',\r\n        async: true\r\n    });\r\n    }\r\n\r\n    function CallRequest(code) {\r\n        var urlss = \'");
#nullable restore
#line 622 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("RequestCall", "Remarks"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + code;\r\n    $.ajax({\r\n        url: urlss,\r\n        tpye: \'get\',\r\n        async: true\r\n    });\r\n    }\r\n\r\n    function GetNumberNotif() {\r\n        var urlss = \'");
#nullable restore
#line 631 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("NumberNotif", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        return $.ajax({\r\n        url: urlss,\r\n        tpye: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function GetSupportReport() {\r\n        var url = \'");
#nullable restore
#line 640 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
              Write(Url.Action("SupportReport", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        return $.ajax({\r\n        url: url,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function UpdateRecoCount(code) {\r\n        var url = \'");
#nullable restore
#line 649 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
              Write(Url.Action("RecoCount", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '/' + code;
        $.ajax({
            url: url,
            type: 'get',
            async: true,
            success: function (output) {
                $('#reco_' + code).html(output);
                }
            });
        }

    function GetBarangayFiltered(id) {
        var urls = '");
#nullable restore
#line 661 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("FilteredBarangay", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n        return $.ajax({\r\n        url: urls,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function GetMuncitiesFiltered(id) {\r\n        var url = \'");
#nullable restore
#line 670 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
              Write(Url.Action("GetMuncities", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n        return $.ajax({\r\n            url: url,\r\n            tpye: \'get\',\r\n            async: true\r\n        })\r\n    }\r\n\r\n    function getDepartmentFiltered(id) {\r\n        var urls = \'");
#nullable restore
#line 679 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("FilterDepartment", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("/\' + id;\r\n        return $.ajax({\r\n            url: urls,\r\n            type: \'get\',\r\n            async: true\r\n        });\r\n    }\r\n\r\n\r\n\r\n    function getMdFiltered(facId, depId) {\r\n        var urls = \'");
#nullable restore
#line 690 "G:\DATA BACKUP\PISTING YAWA\Referral\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("FilterUser", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("/\' + facId + \"/\" + depId;\r\n        return $.ajax({\r\n            url: urls,\r\n            type: \'get\',\r\n            async: true\r\n        });\r\n    }\r\n\r\n\r\n//----------------------- FUNCTIONS --------------------------\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591