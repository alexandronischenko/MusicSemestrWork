#pragma checksum "/Users/alexandronischenko/Documents/GitHub/ITIS_2021/MusicSemestrWork/MusicSemestrWork/Views/Post/Post.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6be8778f601f4cfbcfafe7a9350f3af81443453"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Post), @"mvc.1.0.view", @"/Views/Post/Post.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6be8778f601f4cfbcfafe7a9350f3af81443453", @"/Views/Post/Post.cshtml")]
    public class Views_Post_Post : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MusicSemestrWork.Models.Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/alexandronischenko/Documents/GitHub/ITIS_2021/MusicSemestrWork/MusicSemestrWork/Views/Post/Post.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n    <!-- ГЛАВНАЯ ЧАСТЬ -->\n    <div class=\"container\" style=\"margin-bottom: 50px; margin-top: 50px;\">\n        <div class=\"border post-detail\">\n            <img style=\"width: 100%;\"");
            BeginWriteAttribute("src", " src=\"", 247, "\"", 265, 1);
#nullable restore
#line 10 "/Users/alexandronischenko/Documents/GitHub/ITIS_2021/MusicSemestrWork/MusicSemestrWork/Views/Post/Post.cshtml"
WriteAttributeValue("", 253, Model.Image, 253, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            <div class=\"post-info\">\n\n                <div style=\"margin: 20px;\">\n                    <h5>");
#nullable restore
#line 14 "/Users/alexandronischenko/Documents/GitHub/ITIS_2021/MusicSemestrWork/MusicSemestrWork/Views/Post/Post.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                    <p>");
#nullable restore
#line 15 "/Users/alexandronischenko/Documents/GitHub/ITIS_2021/MusicSemestrWork/MusicSemestrWork/Views/Post/Post.cshtml"
                  Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                </div>\n\n");
            WriteLiteral("            </div>\n        </div>\n    </div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MusicSemestrWork.Models.Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
