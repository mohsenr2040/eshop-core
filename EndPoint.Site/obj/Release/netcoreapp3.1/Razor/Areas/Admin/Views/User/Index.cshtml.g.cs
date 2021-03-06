#pragma checksum "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70d6c5a744b0e5c6510b7aa2dd39bebfe47a5264"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/User/Index.cshtml")]
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
#line 1 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
using eshop.Application.Services.Queries.GetUsers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70d6c5a744b0e5c6510b7aa2dd39bebfe47a5264", @"/Areas/Admin/Views/User/Index.cshtml")]
    public class Areas_Admin_Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultGetUserDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminTemplate/app-assets/img/active/user_valid.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:50px;width:50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminTemplate/app-assets/img/active/user_invalid.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Sweetalert2/sweetalert2.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Adminlayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content-wrapper"">
    <div class=""container-fluid"">
        <!-- Zero configuration table -->
        <section id=""configuration"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            <div class=""card-title-wrap bar-success"">
                                <h4 class=""card-title"">لیست کاربران</h4>
                            </div>
                        </div>
                        <div class=""card-body collapse show"">
                            <div class=""card-block card-dashboard"">
                                <div id=""DataTables_Table_0_wrapper"" class=""dataTables_wrapper container-fluid dt-bootstrap4"">
                                    <form method=""get"" class=""col-xl-4 col-lg-6 col-md-12 mb-1"">
                                        <fieldset class=""form-group"">

                                            <table>
                    ");
            WriteLiteral(@"                            <tr>
                                                    <td>
                                                        <label>
                                                            جستجو:
                                                            <input type=""text"" name=""Str_searchkey"" class=""form-control form-control-sm""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 1567, "\"", 1581, 0);
            EndWriteAttribute();
            WriteLiteral(@" aria-controls=""DataTables_Table_0"">
                                                        </label>
                                                    </td>
                                                    <td style=""padding-top:25px"">
                                                        <button id=""btn_Search"" class=""btn btn badge-blue""> جستجو</button>
                                                    </td>
                                                </tr>
                                            </table>
                                            </fieldset>
                                        </form>

                                            <div class=""row"">
                                                <div class=""col-sm-12"">
                                                    <table class=""table table-striped table-bordered zero-configuration dataTable"" id=""DataTables_Table_0"" role=""grid"" aria-describedby=""DataTables_Table_0_info"">
                              ");
            WriteLiteral(@"                          <thead>
                                                            <tr role=""row"">
                                                                <th style=""width:20px;height:20px""> </th>
                                                                <th class=""sorting_asc"" tabindex=""0"" aria-controls=""DataTables_Table_0"" rowspan=""1"" colspan=""1"" aria-sort=""ascending"" aria-label=""نام: activate to sort column descending"" style=""width: 222px;"">نام</th>
                                                                <th class=""sorting"" tabindex=""0"" aria-controls=""DataTables_Table_0"" rowspan=""1"" colspan=""1"" aria-label=""ایمیل: activate to sort column ascending"" style=""width: 401px;"">ایمیل</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
");
#nullable restore
#line 52 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                             foreach (var item in Model.Users)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <tr role=\"row\" class=\"odd\">\r\n                                                                    <td>\r\n");
#nullable restore
#line 56 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                         if (@item.IsActive == true)
                                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "70d6c5a744b0e5c6510b7aa2dd39bebfe47a52649946", async() => {
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
#nullable restore
#line 59 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                        }
                                                                        else
                                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "70d6c5a744b0e5c6510b7aa2dd39bebfe47a526411556", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 63 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    </td>\r\n                                                                    <td class=\"sorting_1\">");
#nullable restore
#line 65 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                                     Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 66 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                   Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>\r\n                                                                        <button class=\"btn btn-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5142, "\"", 5216, 7);
            WriteAttributeValue("", 5152, "ShowModalEdituser(\'", 5152, 19, true);
#nullable restore
#line 68 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 5171, item.UserId, 5171, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5183, "\',\'", 5183, 3, true);
#nullable restore
#line 68 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 5186, item.FullName, 5186, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5200, "\',\'", 5200, 3, true);
#nullable restore
#line 68 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 5203, item.Email, 5203, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5214, "\')", 5214, 2, true);
            EndWriteAttribute();
            WriteLiteral(">ویرایش</button>\r\n                                                                        <button class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5337, "\"", 5373, 3);
            WriteAttributeValue("", 5347, "DeleteUser(\'", 5347, 12, true);
#nullable restore
#line 69 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 5359, item.UserId, 5359, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5371, "\')", 5371, 2, true);
            EndWriteAttribute();
            WriteLiteral(">حذف</button>\r\n");
#nullable restore
#line 70 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                         if (item.IsActive == true)
                                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                            <button class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5672, "\"", 5713, 3);
            WriteAttributeValue("", 5682, "UserSatusChange(\'", 5682, 17, true);
#nullable restore
#line 72 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 5699, item.UserId, 5699, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5711, "\')", 5711, 2, true);
            EndWriteAttribute();
            WriteLiteral(">غیر فعال</button>\r\n");
#nullable restore
#line 73 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                        }
                                                                        else
                                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                            <button class=\"btn btn-warning\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6069, "\"", 6110, 3);
            WriteAttributeValue("", 6079, "UserSatusChange(\'", 6079, 17, true);
#nullable restore
#line 76 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 6096, item.UserId, 6096, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6108, "\')", 6108, 2, true);
            EndWriteAttribute();
            WriteLiteral("> فعال</button>\r\n");
#nullable restore
#line 77 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    </td>\r\n                                                                </tr>\r\n");
#nullable restore
#line 80 "D:\asp core\e-shop core\e-shop\EndPoint.Site\Areas\Admin\Views\User\Index.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        </tbody>\r\n");
            WriteLiteral(@"                                                    </table>
                                                </div>

                                            </div>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div class=""col-sm-12 col-md-6"">
                                                            <div class=""dataTables_length"" id=""DataTables_Table_0_length"">
                                                                <label>
                                                                    نمایش سطر
                                                                    <select name=""DataTables_Table_0_length"" aria-controls=""DataTables_Table_0"" class=""form-control form-control-sm"">
                                                                        <option value=""10"">10</option>
                                  ");
            WriteLiteral(@"                                      <option value=""25"">25</option>
                                                                        <option value=""50"">50</option>
                                                                        <option value=""100"">100</option>
                                                                    </select>
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class=""row"">
                                                            <div class=""col-sm-12 col-md-5"">
                                                                <div class=""dataTables_info"" id=""DataTables_Table_0_info"" role=""status"" aria-live=""polite"">نمایش 1 تا 10 از 5");
            WriteLiteral(@"7 سطرها</div>
                                                            </div>
                                                            <div class=""col-sm-12 col-md-7"">
                                                                <div class=""dataTables_paginate paging_simple_numbers"" id=""DataTables_Table_0_paginate"">
                                                                    <ul class=""pagination"">
                                                                        <li class=""paginate_button page-item previous disabled"" id=""DataTables_Table_0_previous"">
                                                                            <a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""0"" tabindex=""0"" class=""page-link"">قبلی</a>
                                                                        </li>
                                                                        <li class=""paginate_button page-item active"">
                                                           ");
            WriteLiteral(@"                 <a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""1"" tabindex=""0"" class=""page-link"">1</a>
                                                                        </li>
                                                                        <li class=""paginate_button page-item "">
                                                                            <a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""2"" tabindex=""0"" class=""page-link"">2</a>
                                                                        </li>
                                                                        <li class=""paginate_button page-item ""><a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""3"" tabindex=""0"" class=""page-link"">3</a></li>
                                                                        <li class=""paginate_button page-item ""><a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""4"" tabindex=""0"" class=""page-link"">4</a></li>
                        ");
            WriteLiteral(@"                                                <li class=""paginate_button page-item ""><a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""5"" tabindex=""0"" class=""page-link"">5</a></li>
                                                                        <li class=""paginate_button page-item ""><a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""6"" tabindex=""0"" class=""page-link"">6</a></li>
                                                                        <li class=""paginate_button page-item next"" id=""DataTables_Table_0_next""><a href=""#"" aria-controls=""DataTables_Table_0"" data-dt-idx=""7"" tabindex=""0"" class=""page-link"">بعدی</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                       ");
            WriteLiteral(@"                         </tr>
                                            </table>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "70d6c5a744b0e5c6510b7aa2dd39bebfe47a526424404", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70d6c5a744b0e5c6510b7aa2dd39bebfe47a526425583", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script>
        function DeleteUser(UserId) {
            swal.fire({
                title: 'حذف کاربر',
                text: ""کاربر گرامی از حذف کاربر مطمئن هستید؟"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#7cacbe',
                confirmButtonText: 'بله ، کاربر حذف شود',
                cancelButtonText: 'خیر'
            }).then((result) => {
                if (result.value) {
                    var postData = {
                        'UserId': UserId,
                    };
                    $.ajax({
                        contentType: 'application/x-www-form-urlencoded',
                        dataType: 'json',
                        type: ""POST"",
                        url: ""Delete"",
                        data: postData,

                        success: function (data) {
                            if (data.isSuccess == true) {
                ");
                WriteLiteral(@"                swal.fire(
                                    'موفق!',
                                    data.message,
                                    'success'
                                ).then(function (isConfirm) {
                                    location.reload();
                                });
                            }
                            else {

                                swal.fire(
                                    'هشدار!',
                                    data.message,
                                    'warning'
                                );

                            }
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }

                    });

                }
            })
        }


        function UserSatusChange(UserId) {
            swal.fire({
                title: 'تغییر وضعیت کارب");
                WriteLiteral(@"ر',
                text: ""کاربر گرامی از تغییر وضعیت کاربر مطمئن هستید؟"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#7cacbe',
                confirmButtonText: 'بله ، تغییر وضعیت انجام شود',
                cancelButtonText: 'خیر'
            }).then((result) => {
                if (result.value) {

                    var postData = {
                        'UserId': UserId,
                    };

                    $.ajax({
                        contentType: 'application/x-www-form-urlencoded',
                        dataType: 'json',
                        type: ""POST"",
                        url: ""ChangeUserStatus"",
                        data: postData,
                        success: function (data) {
                            if (data.isSuccess == true) {
                                swal.fire(
                                    'موفق!',
            ");
                WriteLiteral(@"                        data.message,
                                    'success'
                                ).then(function (isConfirm) {
                                    location.reload();
                                });
                            }
                            else {

                                swal.fire(
                                    'هشدار!',
                                    data.message,
                                    'warning'
                                );

                            }
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }

                    });

                }
            })
        }

        function Edituser() {

            var userId = $(""#Edit_UserId"").val();
            var fullName = $(""#Edit_Fullname"").val();
            var email = $('#Edit_Email').val();

       ");
                WriteLiteral(@"     var postData = {
                'Int_userid': userId,
                'Str_fullname': fullName,
                'str_Email': email,
            };


            $.ajax({
                contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: ""POST"",
                url: ""Edit"",
                data: postData,
                success: function (data) {
                    if (data.isSuccess == true) {
                        swal.fire(
                            'موفق!',
                            data.message,
                            'success'
                        ).then(function (isConfirm) {
                            location.reload();
                        });
                    }
                    else {
                        swal.fire(
                            'هشدار!',
                            data.message,
                            'warning'
                        );
                    }
  ");
                WriteLiteral(@"              },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });

            $('#EditUser').modal('hide');

        }


        function ShowModalEdituser(UserId, fullName, email) {
            $('#Edit_Fullname').val(fullName)
            $('#Edit_UserId').val(UserId)
            $('#Edit_Email').val(email)

            $('#EditUser').modal('show');

        }


    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("Modals", async() => {
                WriteLiteral(@"
    <!-- Modal Edit User -->
    <div class=""modal fade"" id=""EditUser"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLongTitle"">ویرایش کاربر</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""col-xl-12 col-lg-12 col-md-12 mb-1"">
                        <fieldset class=""form-group"">
                            <input type=""hidden"" id=""Edit_UserId"" />
                            <label for=""basicInput"">نام و نام خانوادگی</label>
                            <input type=""text"" class=""form-control"" id=""Edi");
                WriteLiteral(@"t_Fullname"">
                        </fieldset>
                        <fieldset class=""form-group"">
                            <label for=""basicInput"">ایمیل</label>
                            <input type=""text"" class=""form-control"" id=""Edit_Email"">
                        </fieldset>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <a class=""btn btn-secondary"" data-dismiss=""modal"">بستن</a>
                    <a class=""btn btn-primary"" onclick=""Edituser()"">اعمال تغییرات</a>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultGetUserDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
