#pragma checksum "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Home\ShowUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a62c521e42fe6555daa9426f2d6db3280718b2ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowUser), @"mvc.1.0.view", @"/Views/Home/ShowUser.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ShowUser.cshtml", typeof(AspNetCore.Views_Home_ShowUser))]
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
#line 1 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\_ViewImports.cshtml"
using WebApplication2;

#line default
#line hidden
#line 2 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\_ViewImports.cshtml"
using WebApplication2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a62c521e42fe6555daa9426f2d6db3280718b2ea", @"/Views/Home/ShowUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36aee4455a440795f240a74431c307640c545e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication2.Models.AppUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(61, 134, true);
            WriteLiteral("\r\n<table>\r\n    <thead>\r\n        <td>User ID</td>\r\n        <td>PASSWORD</td>\r\n        <td>DESCRIPTION</td>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 13 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Home\ShowUser.cshtml"
          
           foreach (var item in Model)
           {

#line default
#line hidden
            BeginContext(261, 44, true);
            WriteLiteral("               <tr>\r\n                   <td>");
            EndContext();
            BeginContext(306, 11, false);
#line 17 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Home\ShowUser.cshtml"
                  Write(item.UserId);

#line default
#line hidden
            EndContext();
            BeginContext(317, 30, true);
            WriteLiteral("</td>\r\n                   <td>");
            EndContext();
            BeginContext(348, 13, false);
#line 18 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Home\ShowUser.cshtml"
                  Write(item.Password);

#line default
#line hidden
            EndContext();
            BeginContext(361, 30, true);
            WriteLiteral("</td>\r\n                   <td>");
            EndContext();
            BeginContext(392, 11, false);
#line 19 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Home\ShowUser.cshtml"
                  Write(item.RoleId);

#line default
#line hidden
            EndContext();
            BeginContext(403, 29, true);
            WriteLiteral("</td>\r\n               </tr>\r\n");
            EndContext();
#line 21 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Home\ShowUser.cshtml"

           }
       

#line default
#line hidden
            BeginContext(458, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication2.Models.AppUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
