#pragma checksum "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "344e3467f0edbf91e9647365af4cb97e57e371eb"
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
#line 1 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\_ViewImports.cshtml"
using RealCard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\_ViewImports.cshtml"
using RealCard.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"344e3467f0edbf91e9647365af4cb97e57e371eb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14cc2bc039982a9c326c298a62d74a1aedab973a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
Write(ViewData["Log"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
 if (User.IsInRole("Player"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Player</p>\r\n");
#nullable restore
#line 11 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
 if (User.IsInRole("Moderator"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Moderator</p>\r\n");
#nullable restore
#line 15 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
 if (User.IsInRole("Admin"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Admin</p>\r\n");
#nullable restore
#line 19 "C:\Users\Michael\Desktop\RealCard\RealCard\RealCard\Views\Home\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
