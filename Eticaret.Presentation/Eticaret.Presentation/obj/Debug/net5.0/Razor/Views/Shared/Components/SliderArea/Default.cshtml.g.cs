#pragma checksum "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\Shared\Components\SliderArea\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2e4300a592901e53b94e61398eaa209a00ce6a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SliderArea_Default), @"mvc.1.0.view", @"/Views/Shared/Components/SliderArea/Default.cshtml")]
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
#line 1 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\_ViewImports.cshtml"
using Eticaret.Presentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\_ViewImports.cshtml"
using Eticaret.Presentation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\Shared\Components\SliderArea\Default.cshtml"
using Eticaret.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2e4300a592901e53b94e61398eaa209a00ce6a1", @"/Views/Shared/Components/SliderArea/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b11e296975fd3811b136a67feaa7e5a9cfb980bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SliderArea_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Slider>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"slider-area\">\r\n    <!-- Slider -->\r\n    <div class=\"block-slider block-slider4\">\r\n        <ul");
            BeginWriteAttribute("class", " class=\"", 152, "\"", 160, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"bxslider-home4\">\r\n");
#nullable restore
#line 7 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\Shared\Components\SliderArea\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 287, "\"", 309, 2);
            WriteAttributeValue("", 293, "/img/", 293, 5, true);
#nullable restore
#line 10 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\Shared\Components\SliderArea\Default.cshtml"
WriteAttributeValue("", 298, item.Image, 298, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Slide\">\r\n                    <div class=\"caption-group\">\r\n                        <h2 class=\"caption title\">\r\n                            ");
#nullable restore
#line 13 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\Shared\Components\SliderArea\Default.cshtml"
                       Write(item.Header.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h2>\r\n                        <a class=\"caption button-radius\"");
            BeginWriteAttribute("href", " href=\"", 565, "\"", 582, 1);
#nullable restore
#line 15 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\Shared\Components\SliderArea\Default.cshtml"
WriteAttributeValue("", 572, item.Link, 572, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"icon\"></span>Shop now</a>\r\n                    </div>\r\n                </li>\r\n");
#nullable restore
#line 18 "C:\Users\90545\Desktop\ETicaret-Ders\Eticaret.Presentation\Eticaret.Presentation\Views\Shared\Components\SliderArea\Default.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </ul>\r\n    </div>\r\n    <!-- ./Slider -->\r\n</div> <!-- End slider area -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Slider>> Html { get; private set; }
    }
}
#pragma warning restore 1591
