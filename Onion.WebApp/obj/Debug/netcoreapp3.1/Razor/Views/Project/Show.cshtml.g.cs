#pragma checksum "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2f1859ac5473071a49da8fdbbbed42b889974e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_Show), @"mvc.1.0.view", @"/Views/Project/Show.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2f1859ac5473071a49da8fdbbbed42b889974e6", @"/Views/Project/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Onion.AppCore.Entities.Project>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Project/Show"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("list-group-item list-group-item-action active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-current", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Project/Create"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary col-4 mt-4 "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"container mainSize col-12\">\r\n    <div class=\"row col-12\">\r\n        <aside class=\" col-3 mt-3\">\r\n\r\n            <div class=\"list-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2f1859ac5473071a49da8fdbbbed42b889974e64756", async() => {
                WriteLiteral("\r\n                    <div class=\"d-flex w-100 justify-content-between\">\r\n                        <h5 class=\"mb-1\">Projects</h5>\r\n                        <small>Now</small>\r\n                    </div>\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <a href=""#"" class=""list-group-item list-group-item-action"">
                    <div class=""d-flex w-100 justify-content-between"">
                        <h6 class=""mb-1"">Steps</h6>
                    </div>

                </a>
                <a href=""#"" class=""list-group-item list-group-item-action "">
                    <div class=""d-flex w-100 justify-content-between"">
                        <h6 class=""mb-1"">Tasks</h6>
                    </div>

                </a>
                <a href=""#"" class=""list-group-item list-group-item-action"">
                    <div class=""d-flex w-100 justify-content-between"">
                        <h6 class=""mb-1"">SubTasks</h6>
                    </div>

                </a> <a href=""#"" class=""list-group-item list-group-item-action"">
                    <div class=""d-flex w-100 justify-content-between"">
                        <h6 class=""mb-1"">Conditions</h6>
                    </div>

                </a>
            </");
            WriteLiteral("div>\r\n        </aside>\r\n        <div class=\" col-9\">\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f2f1859ac5473071a49da8fdbbbed42b889974e67389", async() => {
                WriteLiteral("+ New Project");
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
            WriteLiteral(@"


            <table class=""table table-striped table-hover mt-4 col-11"">
                <thead>
                    <tr>
                        <th scope=""col"">
                            №
                        </th>
                        <th scope=""col"">
                            <a class=""m-1"" asp-action=""List"">Name</a>
                        </th>
                        <th scope=""col"">
                            <a class=""m-1"" asp-action=""List"">
                                CreateDate
                            </a>
                        </th>
                        <th scope=""col"">
                            <a class=""m-1"" asp-action=""List"">Cost</a>
                        </th>
                        <th scope=""col"">
                            <a class=""m-1"" asp-action=""List"">EmpAmount</a>
                        </th>
                        <th scope=""col"">
                            <a class=""m-1"" asp-action=""List"">TechStack</a>
                     ");
            WriteLiteral("   </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 71 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                       int i = 1;

                    foreach (var proj in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n\r\n\r\n                        <td scope=\"row\">");
#nullable restore
#line 78 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td scope=\"row\">");
#nullable restore
#line 79 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                                   Write(proj.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td scope=\"row\">");
#nullable restore
#line 80 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                                   Write(proj.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td scope=\"row\">");
#nullable restore
#line 81 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                                   Write(proj.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td scope=\"row\">");
#nullable restore
#line 82 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                                   Write(proj.EmployeeAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2 px-4\">");
#nullable restore
#line 83 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                                          Write(proj.TechStack);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 85 "C:\Users\kosty\source\repos\Diploma\Onion.WebApp\Views\Project\Show.cshtml"
                    i++;
                    } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Onion.AppCore.Entities.Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
