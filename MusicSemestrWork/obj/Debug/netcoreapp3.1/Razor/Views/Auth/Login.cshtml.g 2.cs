#pragma checksum "/Users/alexandronischenko/Documents/GitHub/ITIS_2021/MusicSemestrWork/MusicSemestrWork/Views/Auth/Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1420a2680a8f3ddaf4ad25275bd910f1b06074ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Login), @"mvc.1.0.razor-page", @"/Views/Auth/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1420a2680a8f3ddaf4ad25275bd910f1b06074ef", @"/Views/Auth/Login.cshtml")]
    public class Views_Auth_Login : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/alexandronischenko/Documents/GitHub/ITIS_2021/MusicSemestrWork/MusicSemestrWork/Views/Auth/Login.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""registration-form"">
    
   
    <h1 class=""text-center"" style=""font-family: Arial; font-weight: lighter;"">Вход в аккаунт</h1>

    <form asp-action=""Login"" asp-controller=""Account"" asp-anti-forgery=""true"" method=""post"" style=""width: 50%;"">
        <div style=""margin-top: 20px;"">
            <p>Электронная почта</p>
            <input type=""text"" name=""email"" asp-for=""Email"" style=""color: black"">
        </div>

        <div style=""margin-top: 20px;"">
            <p>Пароль</p>
            <input type=""text"" name=""password"" asp-for=""Password"" style=""color: black"">
        </div>

        <button type=""submit"" class=""btn registration-button"" style=""background-color: #889382; color: white; "">Войти</button>
    </form>

</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MusicSemestrWork.Models.User> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MusicSemestrWork.Models.User> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MusicSemestrWork.Models.User>)PageContext?.ViewData;
        public MusicSemestrWork.Models.User Model => ViewData.Model;
    }
}
#pragma warning restore 1591
