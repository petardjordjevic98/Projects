#pragma checksum "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4975eaa7ce13bd2bb980e56f67eb0d2e57ba3d0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProbCut.Pages.Pages_MojProfil), @"mvc.1.0.razor-page", @"/Pages/MojProfil.cshtml")]
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
#line 2 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
using ProbCut.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4975eaa7ce13bd2bb980e56f67eb0d2e57ba3d0f", @"/Pages/MojProfil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e09fbd7c5ed1e179ac45227a9c37711ca481849e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_MojProfil : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/MojProfil.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/MojProfil.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
  
    ViewData["Title"] = LanguageController.Get(Model.lang, "MyProfile", "Title");

#line default
#line hidden
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4975eaa7ce13bd2bb980e56f67eb0d2e57ba3d0f4843", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 8 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4975eaa7ce13bd2bb980e56f67eb0d2e57ba3d0f6770", async() => {
                WriteLiteral(@"
    <!-- header -->
    <div style=""display: flex; justify-content: center; text-align: center;"">
        <div id=""MyProfileHeader"">
            <div style=""display: block; margin: auto;"" id=""imageAvatarContainer"">
            </div>
            <h2 class=""h2"" id=""MyProfileHeaderUsername"">");
#line 15 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                                                   Write(Model.vratiKorisnika().username);

#line default
#line hidden
                WriteLiteral(@"</h2>
            <h5 class=""small"" id=""tipKorisnika""></h5>
            <div id=""MyProfileHeaderStatContainer"">
                <div class=""MyProfileHeaderStat"" id=""Stat1Container"">
                    <label id=""stat1"" class=""labelStat""></label>
                    <h5 class=""small"" id=""stat1Opis""></h5>
                </div>

                <div class=""MyProfileHeaderStat"" id=""Stat2Container"">
                    <label id=""stat2"" class=""labelStat""></label>
                    <h5 class=""small"" id=""stat2Opis""></h5>
                </div>
            </div>
        </div>
    </div>

    <div id=""ratingSection"">
        <div class=""my-rating-4"" id=""stars"" data-rating=""5"" style=""display: none; margin-top: 10px;""></div>
    </div>

    <!-- my profile data -->
    <div style=""display: flex; justify-content: center;"">
        <div class=""MyProfileContainer"" id=""MyProfileData"">
            <div id=""buttonEditContainer"">
                <div id=""divButtonRight""></div>
                <di");
                WriteLiteral(@"v id=""divButtonLeft""></div>
            </div>
        </div>
    </div>

    <!-- confirm account delete dialog (modal) -->
    <div class=""modal fade"" id=""modalDelete"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">
                        <i class=""fas fa-exclamation"" style=""color: red; padding-right: 10px;""></i>");
#line 51 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                                                                                              Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmTitle"));

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
#line 58 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
               Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmText"));

#line default
#line hidden
                WriteLiteral("\r\n                </div>\r\n                <div class=\"modal-footer\">\r\n                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">\r\n                        ");
#line 62 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                   Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmButtonClose"));

#line default
#line hidden
                WriteLiteral("\r\n                    </button>\r\n                    <button type=\"button\" class=\"btn btn-primary\" id=\"buttonDeleteAccount\">\r\n                        ");
#line 65 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                   Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmButtonConfirm"));

#line default
#line hidden
                WriteLiteral(@"
                    </button>
                </div>
            </div>
        </div>
    </div>

    <!-- confirm comment delete dialog (modal) -->
    <div class=""modal fade"" id=""modalDeleteComment"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">
                        <i class=""fas fa-exclamation"" style=""color: red; padding-right: 10px;""></i>");
#line 78 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                                                                                              Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmTitle"));

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
#line 85 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
               Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmCommentText"));

#line default
#line hidden
                WriteLiteral("\r\n                </div>\r\n                <div class=\"modal-footer\">\r\n                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">\r\n                        ");
#line 89 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                   Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmButtonClose"));

#line default
#line hidden
                WriteLiteral("\r\n                    </button>\r\n                    <button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\" id=\"buttonDeleteComment\">\r\n                        ");
#line 92 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                   Write(LanguageController.Get(Model.lang, "MyProfile", "DialogConfirmButtonConfirm"));

#line default
#line hidden
                WriteLiteral("\r\n                    </button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4975eaa7ce13bd2bb980e56f67eb0d2e57ba3d0f13760", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#line 99 "C:\Users\HPs\Documents\FinalnaVerzija\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
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
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MojProfilModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MojProfilModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MojProfilModel>)PageContext?.ViewData;
        public MojProfilModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
