#pragma checksum "C:\Users\Lenovo\source\repos\ODLClientApp\ODLClientApp\Views\Test\SuccessfullyBooked.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d355bb12f3f83117fca1cf076bbb30345d2cf38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test_SuccessfullyBooked), @"mvc.1.0.view", @"/Views/Test/SuccessfullyBooked.cshtml")]
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
#line 1 "C:\Users\Lenovo\source\repos\ODLClientApp\ODLClientApp\Views\_ViewImports.cshtml"
using ODLClientApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\ODLClientApp\ODLClientApp\Views\_ViewImports.cshtml"
using ODLClientApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d355bb12f3f83117fca1cf076bbb30345d2cf38", @"/Views/Test/SuccessfullyBooked.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e594200c01635726d77a114437434b2841958c8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Test_SuccessfullyBooked : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\ODLClientApp\ODLClientApp\Views\Test\SuccessfullyBooked.cshtml"
  
    ViewData["Title"] = "SuccessfullyBooked";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>SuccessfullyBooked</h1>\r\n\r\n<div class=\"container text-success\">\r\n\r\n    ");
#nullable restore
#line 10 "C:\Users\Lenovo\source\repos\ODLClientApp\ODLClientApp\Views\Test\SuccessfullyBooked.cshtml"
Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(", your appointment has been successfully booked .Your Id is: ");
#nullable restore
#line 10 "C:\Users\Lenovo\source\repos\ODLClientApp\ODLClientApp\Views\Test\SuccessfullyBooked.cshtml"
                                                                         Write(ViewBag.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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