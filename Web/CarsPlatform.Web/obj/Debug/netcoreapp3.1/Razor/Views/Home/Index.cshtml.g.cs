#pragma checksum "C:\Users\georg\Desktop\Project\Web\CarsPlatform.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae6294044228217a20e0b0bae5f7c988b043e5c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\georg\Desktop\Project\Web\CarsPlatform.Web\Views\_ViewImports.cshtml"
using CarsPlatform.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\georg\Desktop\Project\Web\CarsPlatform.Web\Views\_ViewImports.cshtml"
using CarsPlatform.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\georg\Desktop\Project\Web\CarsPlatform.Web\Views\Home\Index.cshtml"
using CarsPlatform.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae6294044228217a20e0b0bae5f7c988b043e5c1", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39d8ea03c1575a5732391041492ffc58dabdcf36", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\georg\Desktop\Project\Web\CarsPlatform.Web\Views\Home\Index.cshtml"
  
    this.ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to ");
#nullable restore
#line 7 "C:\Users\georg\Desktop\Project\Web\CarsPlatform.Web\Views\Home\Index.cshtml"
                                Write(GlobalConstants.SystemName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"!</h1>
</div>

<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js""></script>
<style>
    body {
        background: #00ffff;
    }
</style>
<br />

<div class=""card bg-primary text-white w-50 col-md-4 offset-md-4"">
    <h3 class=""card-title text-center"">
        <a><span class=""hours""></span></a> :
        <a><span class=""min""></span></a> :
        <a><span class=""sec""></span></a>
        <a><span class=""text-sm-center"" > - ");
#nullable restore
#line 23 "C:\Users\georg\Desktop\Project\Web\CarsPlatform.Web\Views\Home\Index.cshtml"
                                       Write(DateTime.UtcNow.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" year.</span></a>
    </h3>
</div>



<script>
    $(document).ready(function () {
        setInterval(function () {
            var hours = new Date().getHours();
            $("".hours"").html((hours < 10 ? ""0"" : """") + hours);
        }, 1000);
        setInterval(function () {
            var minutes = new Date().getMinutes();
            $("".min"").html((minutes < 10 ? ""0"" : """") + minutes);
        }, 1000);
        setInterval(function () {
            var seconds = new Date().getSeconds();
            $("".sec"").html((seconds < 10 ? ""0"" : """") + seconds);
        }, 1000);
    });
</script>");
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
