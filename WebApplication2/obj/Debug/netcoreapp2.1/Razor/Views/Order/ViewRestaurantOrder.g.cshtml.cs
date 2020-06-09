#pragma checksum "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f44b94ff87fe63c04176e318e470582166e5f042"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_ViewRestaurantOrder), @"mvc.1.0.view", @"/Views/Order/ViewRestaurantOrder.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/ViewRestaurantOrder.cshtml", typeof(AspNetCore.Views_Order_ViewRestaurantOrder))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f44b94ff87fe63c04176e318e470582166e5f042", @"/Views/Order/ViewRestaurantOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36aee4455a440795f240a74431c307640c545e", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_ViewRestaurantOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication2.Models.Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-info "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeOrderStatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(180, 21, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n");
            EndContext();
#line 9 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
     if (Model.Count()==0)
    {

#line default
#line hidden
            BeginContext(236, 60, true);
            WriteLiteral("        <h2 style=\"color:brown\">No Order is available</h2>\r\n");
            EndContext();
#line 12 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(320, 462, true);
            WriteLiteral(@"        <table class=""table"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">Id</th>
                    <th scope=""col"">Date</th>
                    <th scope=""col"">Description</th>
                    <th scope=""col"">CustomerId</th>
                    <th scope=""col"">TotalPrice</th>
                    <th scope=""col"">Status</th>

                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 28 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                 if (Model.Count() > 0)
                {
                    
                    foreach (var order in Model)
                    {

#line default
#line hidden
            BeginContext(937, 66, true);
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
            EndContext();
            BeginContext(1004, 8, false);
#line 34 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                                   Write(order.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1012, 35, true);
            WriteLiteral("</th>\r\n                        <td>");
            EndContext();
            BeginContext(1048, 10, false);
#line 35 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                       Write(order.Date);

#line default
#line hidden
            EndContext();
            BeginContext(1058, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1094, 17, false);
#line 36 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                       Write(order.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1111, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1147, 12, false);
#line 37 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                       Write(order.UserId);

#line default
#line hidden
            EndContext();
            BeginContext(1159, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1195, 16, false);
#line 38 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                       Write(order.TotalPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1211, 37, true);
            WriteLiteral("</td>\r\n                        <td>\r\n");
            EndContext();
#line 40 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                             if (order.OrderStatus == 1)
                            {

#line default
#line hidden
            BeginContext(1337, 102, true);
            WriteLiteral("                                <span style=\"font-weight:bolder; color:forestgreen\">Delivered</span>\r\n");
            EndContext();
#line 43 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
            BeginContext(1569, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(1601, 122, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "257d6775e05042f695a596f90fadd946", async() => {
                BeginContext(1712, 7, true);
                WriteLiteral("Deliver");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 47 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                                                                                                                        WriteLiteral(order.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1723, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 48 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                            }

#line default
#line hidden
            BeginContext(1756, 62, true);
            WriteLiteral("                        </td>\r\n\r\n\r\n                    </tr>\r\n");
            EndContext();
#line 53 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
                        

                    }
                    

                }

#line default
#line hidden
            BeginContext(1912, 50, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 66 "C:\Users\Lenovo\source\repos\WebApplication2\WebApplication2\Views\Order\ViewRestaurantOrder.cshtml"
    }

#line default
#line hidden
            BeginContext(1969, 16, true);
            WriteLiteral("\r\n\r\n    \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication2.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
