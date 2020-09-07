#pragma checksum "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c008879a8415fbb99ff91eda33d8e44f062738b"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c008879a8415fbb99ff91eda33d8e44f062738b", @"/Views/Shared/_ScriptsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acb400f416fbed535a8652d125cd9a4f5184cbac", @"/Views/_ViewImports.cshtml")]
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

        modals.on('click', 'button[data-save=""reco""]', function (event) {
            event.preventDefault();
            event.stopImmediatePropagation();
            var content = $('#reco-modal');
            var form = content.find('form');
            var contentId = content.attr('id');
            var actionUrl = form.attr('action');
            var dataToSend = form.seria");
            WriteLiteral(@"lize();
            console.log(content);
            $.ajax({
                url: actionUrl,
                type: 'post',
                async: true,
                data: dataToSend,
                success: function (output) {
                    var newBody = $('.modal-body', output);
                    newBody.find('#chat').val('');
                    content.find('.modal-body').replaceWith(newBody);
                    $('div.direct-chat-messages').animate({ scrollTop: $('#last-item').position().top }, 0);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.responseText);
                    alert(thrownError);
                }
            })
        });
        modals.on('click', 'button[data-save=""modal""]', function (event) {
            event.preventDefault();
            event.stopImmediatePropagation();
            var content = $($(this).parent()).parent();
            content.prepend('<div id=""overlay_load");
            WriteLiteral(@"ing"" class=""overlay d-flex justify-content-center align-items-center""><i class=""fas fa-2x fa-sync fa-spin""></i></div>');
            var form = content.find('form');
            var contentId = content.attr('id');
            var actionUrl = form.attr('action');
            var dataToSend = form.serialize();
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
     ");
            WriteLiteral(@"                       LoadingModal(modal);
                            if (contentId == 'update_inventory_modal') {
                                sessionStorage.setItem('onReload', 'update_inventory');
                                location.reload();
                            }
                            else if (contentId == 'issues-modal') {
                                sessionStorage.setItem('onReload', 'updatedIssues');
                                location.reload();
                            }
                            else if (contentId == 'update-doctor-modal') {
                                sessionStorage.setItem('onReload', 'updateDoctor');
                                location.reload();
                            }
                            else if (contentId == 'change-password-modal') {
                                sessionStorage.setItem('onReload', 'passWordChanged');
                                location.reload();
                            }
  ");
            WriteLiteral(@"                          else if (contentId == 'didnt-arrive-modal') {
                                location.reload();
                            }
                            else if (contentId == 'arrived-modal') {
                                location.reload();
                            }
                            else if (contentId == 'admitted-modal') {
                                location.reload();
                            }
                            else if (contentId == 'discharged_modal') {
                                location.reload();
                            }
                            else if (contentId == 'cancel-modal') {
                                location.reload();
                            }
                            else if (contentId == 'reco-modal') {
                                var input = placeholderElement.find('.modal-footer').find('form').find('.code').val();
                                console.log(input);
             ");
            WriteLiteral(@"               }
                            else if (contentId == 'switch-user-modal') {
                                location.href = '/Home/Index';
                            }
                            else if (contentId == 'add-doctor-modal') {
                                sessionStorage.setItem('onReload', 'addDoctor');
                                location.reload();
                            }
                            else if (contentId == 'add-support-modal') {
                                sessionStorage.setItem('onReload', 'addSupport');
                                location.reload();
                            }
                            else if (contentId == 'update-support-modal') {
                                sessionStorage.setItem('onReload', 'updateSupport');
                                location.reload();
                            }
                            else if (contentId == 'add-facility-modal') {
                                sessio");
            WriteLiteral(@"nStorage.setItem('onReload', 'addFacility');
                                location.reload();
                            }
                            else if (contentId == 'update-facility-modal') {
                                sessionStorage.setItem('onReload', 'updateFacility');
                                location.reload();
                            }
                        });
                    }
                    else {
                        content.find('#overlay_loading').remove();
                        content.find('.modal-body').replaceWith(newBody);
                        content.find('.select2').select2({
                            theme: 'bootstrap4'
                        });
                        if (contentId == 'new_sop') {
                            var disabled = content.find('#notavailable');
                            if (disabled.is(':checked') == true) {
                                content.find('#dateOnset').attr('disabled', true);
    ");
            WriteLiteral(@"                        }
                        }
                        else if (contentId == 'add_patient_modal') {
                            var disabled = content.find('#sameAddress');
                            if (disabled.is(':checked') == true) {
                                content.find('#permanent_address').css('display', 'none');
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
            var conte");
            WriteLiteral(@"ntId = largeModal.find('.modal-dialog.modal-lg').attr('id');
            LoadingModal('#' + contentId);
        });
        var referModal = $('#refer_modal');
        referModal.on('hidden.bs.modal', function () {
            var contentId = referModal.find('.modal-dialog.modal-lg').attr('id');
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
            var actionUrl = form.attr('action');");
            WriteLiteral(@"
            var dataToSend = form.serialize();
            console.log(actionUrl);
            $.ajax({
                url: actionUrl,
                type: 'post',
                async: true,
                data: dataToSend,
                success: function (data) {
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
                                $('div.direct-chat-m");
            WriteLiteral(@"essages').animate({ scrollTop: $('#last-item').position().top }, 0);
                            }
                            else if (validation == '') {
                                placeholderElement.find('.modal').modal('hide');
                                if (formId == 'update-doctor-modal') {
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
                         ");
            WriteLiteral(@"           var input = placeholderElement.find('.modal-footer').find('form').find('.code').val();
                                    console.log(input);
                                }
                                else if (formId == 'switch-user-modal') {
                                    location.href = '/Home/Index';
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
          ");
            WriteLiteral(@"                      }
                                else if (formId == 'update-support-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'updateSupport');
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
                                    location.reload");
            WriteLiteral(@"();
                                }
                                else if (formId == 'issues-modal') {
                                    //placeholderElement.find('.modal').modal('hide');
                                    sessionStorage.setItem('onReload', 'updatedIssues');
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

        //-------------------- ADDRESS ON CHANGE -----");
            WriteLiteral(@"--------------




        //-------------------- CHANGE LOGIN STATUS ----------------------------

        var onDuty = $('button#btn-on-duty');
        var offDuty = $('button#btn-off-duty');
        var container = $('div#login-status-modal');

        onDuty.on('click', function () {
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

    function GetTableCount(param, type) {
        var urls = '");
#nullable restore
#line 347 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("GetTableCount", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + '?code=' + param + '&type=' + type;
        return $.ajax({
            url: urls,
            type: 'get',
            async: true,
            success: function (output) {
                if (type == 'feedback') {
                    $('#reco_' + param).removeAttr('style');
                    $('#reco_' + param).html(output);
                }
                else if (type == 'issue') {
                    $('#issue_' + param).removeAttr('style');
                    $('#issue_' + param).html(output);
                }
                else if (type == 'seen') {
                    if (output != '') {
                        $('#seen_' + param).removeAttr('style');
                        $('#seen_no_' + param).html(output);
                    }
                }
                else if (type == 'call') {
                    if (output != '') {
                        $('#call_' + param).removeAttr('style');
                        $('#call_no_' + param).html(output);
          ");
            WriteLiteral(@"          }
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.responseText);
                alert(thrownError);
            }
        });
    }

    function LoadingModal(id) {
        var urls = '");
#nullable restore
#line 382 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
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
        barangaySelect.select2({
            theme: 'bootstrap4'
        });
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
                type: 'get',
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
      ");
            WriteLiteral(@"                  console.log(xhr.status)
                        $('body').find('#loadings').modal('toggle');
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

            jQuery.each(output.departments, fu");
            WriteLiteral(@"nction (i, item) {
                departmentSelect.append($('<option>', {
                    value: item.departmentId,
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
#line 539 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
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

    }

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
        Command: toastr[type](message)");
            WriteLiteral(@"
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
        var no_transaction1 = Math.round((noTrans/tot) * 100);
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
                    { label: ""With Transaction in "" + with_transaction1 + ""% in "" + ""15 out of 20"", legendText: ""With Transact");
            WriteLiteral(@"ion"", y: with_transaction1 },
                    { label: ""No Transaction in "" + no_transaction1 + ""% in "" + ""5 out of 20"", legendText: ""No Transaction"", y: no_transaction1 }
                ]
            }]
        };
        chart.CanvasJSChart(options1);
    }

    function GetDashboardValues(level) {
        var urlss = '");
#nullable restore
#line 634 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("DashboardValues", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + level;\r\n        return $.ajax({\r\n        url: urlss,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function GetAvailableDepartments(id) {\r\n        var url = + id; \'");
#nullable restore
#line 643 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                    Write(Url.Action("AvailableDepartments", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n        return $.ajax({\r\n        url: url,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function RemoveFacility(id) {\r\n        var url = \'");
#nullable restore
#line 652 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
              Write(Url.Action("RemoveFacility", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n    $.ajax({\r\n        url: url,\r\n        type: \'post\',\r\n        async: true\r\n    });\r\n    }\r\n\r\n    function SetLoginStatus(status) {\r\n        var urlss = \'");
#nullable restore
#line 661 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("ChangeLoginStatus", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + status;\r\n    $.ajax({\r\n        url: urlss,\r\n        type: \'get\',\r\n        async: true\r\n    });\r\n    }\r\n    function CallRequest(code) {\r\n        var urlss = \'");
#nullable restore
#line 669 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("RequestCall", "Remarks"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + code;\r\n    $.ajax({\r\n        url: urlss,\r\n        type: \'get\',\r\n        async: true\r\n    });\r\n    }\r\n\r\n    function GetNumberNotif() {\r\n        var urlss = \'");
#nullable restore
#line 678 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
                Write(Url.Action("NumberNotif", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        return $.ajax({\r\n        url: urlss,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function GetSupportReport() {\r\n        var url = \'");
#nullable restore
#line 687 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
              Write(Url.Action("SupportReport", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n        return $.ajax({\r\n        url: url,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function UpdateRecoCount(code) {\r\n        var url = \'");
#nullable restore
#line 696 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
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
#line 708 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("FilteredBarangay", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n        return $.ajax({\r\n        url: urls,\r\n        type: \'get\',\r\n        async: true\r\n        });\r\n    }\r\n\r\n    function GetMuncitiesFiltered(id) {\r\n        var url = \'");
#nullable restore
#line 717 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
              Write(Url.Action("GetMuncities", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \'/\' + id;\r\n        return $.ajax({\r\n            url: url,\r\n            type: \'get\',\r\n            async: true\r\n        })\r\n    }\r\n\r\n    function getDepartmentFiltered(id) {\r\n        var urls = \'");
#nullable restore
#line 726 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
               Write(Url.Action("FilterDepartment", "NoReload"));

#line default
#line hidden
#nullable disable
            WriteLiteral("/\' + id;\r\n        return $.ajax({\r\n            url: urls,\r\n            type: \'get\',\r\n            async: true\r\n        });\r\n    }\r\n\r\n\r\n\r\n    function getMdFiltered(facId, depId) {\r\n        var urls = \'");
#nullable restore
#line 737 "D:\Systems\Referral - MySql\Referral2\Views\Shared\_ScriptsPartial.cshtml"
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
