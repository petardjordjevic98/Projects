#pragma checksum "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66910aed9dbd4ae5f4262aed779a11836b35b467"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProbCut.Pages.Pages_LogovanVlasnik), @"mvc.1.0.razor-page", @"/Pages/LogovanVlasnik.cshtml")]
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
#line 2 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
using ProbCut.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66910aed9dbd4ae5f4262aed779a11836b35b467", @"/Pages/LogovanVlasnik.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e09fbd7c5ed1e179ac45227a9c37711ca481849e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_LogovanVlasnik : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/LogovanVlasnik.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "DodajFrizera", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/LogovanVlasnik.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("module"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
  
    ViewData["Title"] = LanguageController.Get(Model.lang, "LogovanVlasnik", "Title");

#line default
#line hidden
            WriteLiteral("\r\n");
#line 8 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
 if (Model.vlasnik != null)
{

#line default
#line hidden
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "66910aed9dbd4ae5f4262aed779a11836b35b4676704", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 10 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
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
            WriteLiteral("\r\n    <main id=\"AdminPageMain\">\r\n        <div style=\"display: flex; flex-direction: column; margin-top: 30px;\">\r\n            <div class=\"display-3 text-center\">");
#line 13 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                          Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "Title"));

#line default
#line hidden
            WriteLiteral("</div>\r\n            <label class=\"text-primary text-center\" style=\"font-size:xx-large\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 604, "\"", 655, 2);
            WriteAttributeValue("", 611, "./MojProfil?username=", 611, 21, true);
#line 15 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
WriteAttributeValue("", 632, Model.vlasnik.username, 632, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">(");
#line 15 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                   Write(Model.vlasnik.ime);

#line default
#line hidden
            WriteLiteral(" ");
#line 15 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                                      Write(Model.vlasnik.prezime);

#line default
#line hidden
            WriteLiteral(")</a>\r\n            </label>\r\n            <br />\r\n        </div>\r\n\r\n        <div class=\"text-secondary\" style=\"font-size:xx-large\">");
#line 20 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                          Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "LabelBarbers"));

#line default
#line hidden
            WriteLiteral("</div>\r\n        <br />\r\n\r\n");
#line 23 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
         foreach (var f in Model.frizeri)
        {

#line default
#line hidden
            WriteLiteral("            <div style=\"display: flex; flex-direction: column;\">\r\n                <div style=\"display: flex;\">\r\n                    <label class=\"text-info\" style=\"font-size:x-large\"><a");
            BeginWriteAttribute("href", " href=\"", 1163, "\"", 1202, 2);
            WriteAttributeValue("", 1170, "./MojProfil?username=", 1170, 21, true);
#line 27 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
WriteAttributeValue("", 1191, f.username, 1191, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">");
#line 27 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                                                             Write(f.ime);

#line default
#line hidden
            WriteLiteral(" ");
#line 27 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                                                                    Write(f.prezime);

#line default
#line hidden
            WriteLiteral("</a></label>\r\n                    <div style=\"display: flex; flex-direction: row-reverse; flex-grow: 1;\">\r\n                        <button class=\"btn btn-danger buttonDeleteBarber\" style=\"margin-left: 20px\"");
            BeginWriteAttribute("id", " id=\"", 1427, "\"", 1437, 1);
#line 29 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
WriteAttributeValue("", 1432, f.id, 1432, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">");
#line 29 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                                                          Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "ButtonDeleteBarber"));

#line default
#line hidden
            WriteLiteral("</button>\r\n                    </div>\r\n                </div>\r\n                <br />\r\n                <label class=\"text-secondary\" style=\"font-size:large\">");
#line 33 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                 Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "LabelNumOfAppointments"));

#line default
#line hidden
            WriteLiteral(" ");
#line 33 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                                                                                                 Write(f.termini.Count);

#line default
#line hidden
            WriteLiteral("</label>\r\n            </div>\r\n");
            WriteLiteral("            <table class=\"table table-bordered table-hover table-striped\" id=\"tableAdmin\">\r\n                <thead>\r\n                    <tr>\r\n                        <td>");
#line 39 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                       Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "TableHeaderTime"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                        <td>");
#line 40 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                       Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "TableHeaderDuration"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                        <td>");
#line 41 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                       Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "TableHeaderType"));

#line default
#line hidden
            WriteLiteral("</td>\r\n                    </tr>\r\n                </thead>\r\n\r\n                <tbody>\r\n");
#line 46 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                     foreach (var t in f.termini)
                    {

#line default
#line hidden
            WriteLiteral("                        <tr>\r\n                            <td>");
#line 49 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                           Write(t.vreme);

#line default
#line hidden
            WriteLiteral("</td>\r\n                            <td>");
#line 50 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                           Write(t.trajanjeUMinutima);

#line default
#line hidden
            WriteLiteral("</td>\r\n                            <td>");
#line 51 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                           Write(t.vrstaUsluge);

#line default
#line hidden
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#line 53 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                    }

#line default
#line hidden
            WriteLiteral("                </tbody>\r\n\r\n            </table>\r\n            <br /><br /><br />\r\n");
#line 58 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
        }

#line default
#line hidden
            WriteLiteral("\r\n        <div style=\"display: flex; justify-content: center;\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66910aed9dbd4ae5f4262aed779a11836b35b46716936", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66910aed9dbd4ae5f4262aed779a11836b35b46717211", async() => {
#line 62 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                                                Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "ButtonAddBarber"));

#line default
#line hidden
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>

        <!-- confirm barber account delete (modal) -->
        <div class=""modal fade"" id=""modalDeleteBarber"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
            <div class=""modal-dialog modal-dialog-centered"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"">
                            <i class=""fas fa-exclamation"" style=""color: red; padding-right: 10px;""></i>");
#line 72 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                                                                                                  Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "ModalTitle"));

#line default
#line hidden
            WriteLiteral(@"
                        </h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        ");
#line 79 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                   Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "ModalQuestion"));

#line default
#line hidden
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"modal-footer\">\r\n                        <button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\" id=\"modalButtonDeleteBarber\">\r\n                            ");
#line 83 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                       Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "ModalButtonYes"));

#line default
#line hidden
            WriteLiteral("\r\n                        </button>\r\n                        <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">\r\n                            ");
#line 86 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
                       Write(LanguageController.Get(Model.lang, "LogovanVlasnik", "ModalButtonNo"));

#line default
#line hidden
            WriteLiteral("\r\n                        </button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <br /><br /><br />\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66910aed9dbd4ae5f4262aed779a11836b35b46722765", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
#line 95 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
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
            WriteLiteral("\r\n    </main>\r\n");
#line 97 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanVlasnik.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LogovanVlasnikModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogovanVlasnikModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogovanVlasnikModel>)PageContext?.ViewData;
        public LogovanVlasnikModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
