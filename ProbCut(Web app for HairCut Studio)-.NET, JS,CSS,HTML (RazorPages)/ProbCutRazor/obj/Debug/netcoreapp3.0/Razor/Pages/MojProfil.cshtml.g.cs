#pragma checksum "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f836ef2b843eda8f9484a4446a3a6f15eacdfbc8"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f836ef2b843eda8f9484a4446a3a6f15eacdfbc8", @"/Pages/MojProfil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e09fbd7c5ed1e179ac45227a9c37711ca481849e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_MojProfil : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
  
    ViewData["Title"] = "MojProfil";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Moj profil</h1>\r\n\r\n<div class=\"InformacijeOKorisniku\" style=\"border: 1px solid black\">\r\n    <label>Ime: ");
#nullable restore
#line 10 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
           Write(Model.korisnik.ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    <br />\r\n    <label>Prezime: ");
#nullable restore
#line 12 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
               Write(Model.korisnik.prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    <br />\r\n    <label>Username: ");
#nullable restore
#line 14 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                Write(Model.korisnik.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    <br />\r\n    <label>Password: ");
#nullable restore
#line 16 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\MojProfil.cshtml"
                Write(Model.korisnik.password);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    <br />\r\n</div>");
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
