#pragma checksum "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acad7323c116ac18a5e926943cad2bc6f283c4af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ord_Index), @"mvc.1.0.view", @"/Views/Ord/Index.cshtml")]
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
#line 1 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\_ViewImports.cshtml"
using MvcClientApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\_ViewImports.cshtml"
using MvcClientApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acad7323c116ac18a5e926943cad2bc6f283c4af", @"/Views/Ord/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b36223645639508ea2cd0a78118513980fb00764", @"/Views/_ViewImports.cshtml")]
    public class Views_Ord_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MvcClientApp.Models.Orders>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Oid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Dateoforder));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Mid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Totalcost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.M));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Oid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Dateoforder));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Mid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Totalcost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.M.Mname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <!--<td>\r\n                <a asp-action=\"Edit\" asp-route-id=\"");
#nullable restore
#line 56 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
                                              Write(item.Oid);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Edit</a> |\r\n                <a asp-action=\"Details\" asp-route-id=\"");
#nullable restore
#line 57 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
                                                 Write(item.Oid);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Details</a> |\r\n                <a asp-action=\"Delete\" asp-route-id=\"");
#nullable restore
#line 58 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
                                                Write(item.Oid);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Delete</a>\r\n            </td>-->\r\n        </tr>\r\n");
#nullable restore
#line 61 "C:\Users\user\source\repos\MvcClientApp\MvcClientApp\Views\Ord\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MvcClientApp.Models.Orders>> Html { get; private set; }
    }
}
#pragma warning restore 1591