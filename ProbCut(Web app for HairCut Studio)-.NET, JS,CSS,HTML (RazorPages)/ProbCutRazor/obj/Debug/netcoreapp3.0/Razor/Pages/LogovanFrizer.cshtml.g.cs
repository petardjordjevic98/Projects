#pragma checksum "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanFrizer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a28078070c7fb9cb16671735dccbdd229d34e76b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ProbCut.Pages.Pages_LogovanFrizer), @"mvc.1.0.razor-page", @"/Pages/LogovanFrizer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a28078070c7fb9cb16671735dccbdd229d34e76b", @"/Pages/LogovanFrizer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e09fbd7c5ed1e179ac45227a9c37711ca481849e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_LogovanFrizer : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanFrizer.cshtml"
  
    ViewData["Title"] = "LogovanFrizer";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Ulogovali ste se kao Frizer </h1>\r\n<h2>");
#nullable restore
#line 8 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanFrizer.cshtml"
Write(Model.frizer.ime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanFrizer.cshtml"
                 Write(Model.frizer.prezime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n<br /> Imate sledece zakazane termine:<br />\r\n");
#nullable restore
#line 10 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanFrizer.cshtml"
 foreach(var t in Model.frizer.termini)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanFrizer.cshtml"
Write(t.vreme);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 13 "D:\#Projects\#Web\ProbCut (BitBucket)\Aplikacija\Web aplikacija\ProbCutRazor\Pages\LogovanFrizer.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LogovanFrizerModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogovanFrizerModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogovanFrizerModel>)PageContext?.ViewData;
        public LogovanFrizerModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
