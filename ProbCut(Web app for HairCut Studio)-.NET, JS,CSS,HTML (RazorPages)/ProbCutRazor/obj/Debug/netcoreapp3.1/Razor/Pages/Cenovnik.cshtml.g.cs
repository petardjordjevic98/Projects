#pragma checksum "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31c14a285a474014ebf8c62866ca317faada4892"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProbCut.Pages.Pages_Cenovnik), @"mvc.1.0.razor-page", @"/Pages/Cenovnik.cshtml")]
namespace ProbCut.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
using ProbCut.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31c14a285a474014ebf8c62866ca317faada4892", @"/Pages/Cenovnik.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e09fbd7c5ed1e179ac45227a9c37711ca481849e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Cenovnik : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/Cenovnik.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Cenovnik.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("module"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
  
    ViewData["Title"] = LanguageController.Get(Model.lang, "Pricing", "Title");

    if (Model.cene == null)
        Model.cene = LanguageController.GetPricingData();

#line default
#line hidden
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "31c14a285a474014ebf8c62866ca317faada48924782", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 11 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<main id=\"MainCenovnik\">\r\n    <div id=\"pricingHeading\">\r\n        <h1 class=\"display-3 text-center\">");
#line 14 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                     Write(LanguageController.Get(Model.lang, "Pricing", "HeadingTop"));

#line default
#line hidden
            WriteLiteral("</h1>\r\n        <h4 class=\"display-4 text-center\">");
#line 15 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                     Write(LanguageController.Get(Model.lang, "Pricing", "HeadingBottom"));

#line default
#line hidden
            WriteLiteral(@"</h4>
    </div>

    <div id=""tableContainer"">
        <table class=""table table-striped table-bordered"" id=""pricingTable"">
            <thead>
                <tr>
                    <th scope=""col"" style=""width: 6%"">#</th>
                    <th scope=""col"" style=""width: 80%"">");
#line 23 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                  Write(LanguageController.Get(Model.lang, "Pricing", "Service"));

#line default
#line hidden
            WriteLiteral("</th>\r\n                    <th scope=\"col\" style=\"width: 14%\">");
#line 24 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                  Write(LanguageController.Get(Model.lang, "Pricing", "Price"));

#line default
#line hidden
            WriteLiteral("</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <tr>\r\n                    <th scope=\"row\">1</th>\r\n                    <td>");
#line 30 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "HaircutMen"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"HaircutMen\">");
#line 31 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                         Write(Model.cene["HaircutMen"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">2</th>\r\n                    <td>");
#line 35 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "HaircutWomen"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"HaircutWomen\">");
#line 36 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                           Write(Model.cene["HaircutWomen"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">3</th>\r\n                    <td>");
#line 40 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "HaircutChildren"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"HaircutChildren\">");
#line 41 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                              Write(Model.cene["HaircutChildren"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">4</th>\r\n                    <td>");
#line 45 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "BeardTrim"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"BeardTrim\">");
#line 46 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                        Write(Model.cene["BeardTrim"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">5</th>\r\n                    <td>");
#line 50 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "BeardLineUp"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"BeardLineUp\">");
#line 51 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                          Write(Model.cene["BeardLineUp"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">6</th>\r\n                    <td>");
#line 55 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "LineUp"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"LineUp\">");
#line 56 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                     Write(Model.cene["LineUp"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">7</th>\r\n                    <td>");
#line 60 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "HairColoring"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"HairColoring\">");
#line 61 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                           Write(Model.cene["HairColoring"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">8</th>\r\n                    <td>");
#line 65 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "HairDrying"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"HairDrying\">");
#line 66 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                         Write(Model.cene["HairDrying"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">9</th>\r\n                    <td>");
#line 70 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "HairCurling"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"HairCurling\">");
#line 71 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                          Write(Model.cene["HairCurling"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">10</th>\r\n                    <td>");
#line 75 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "HairShading"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"HairShading\">");
#line 76 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                          Write(Model.cene["HairShading"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">11</th>\r\n                    <td>");
#line 80 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "Pricing", "Eyebrows"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    <td class=\"cell-editable\" id=\"Eyebrows\">");
#line 81 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
                                                       Write(Model.cene["Eyebrows"]);

#line default
#line hidden
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</main>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31c14a285a474014ebf8c62866ca317faada489216587", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#line 88 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\Cenovnik.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CenovnikModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CenovnikModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CenovnikModel>)PageContext?.ViewData;
        public CenovnikModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591