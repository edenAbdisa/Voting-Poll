#pragma checksum "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d8913f74e19cd9cd0bfc0e08b3cd66b06a798ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Election_Details), @"mvc.1.0.view", @"/Views/Election/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Election/Details.cshtml", typeof(AspNetCore.Views_Election_Details))]
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
#line 1 "C:\Users\mx\source\repos\Voting\Voting\Views\_ViewImports.cshtml"
using Voting;

#line default
#line hidden
#line 2 "C:\Users\mx\source\repos\Voting\Voting\Views\_ViewImports.cshtml"
using Voting.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d8913f74e19cd9cd0bfc0e08b3cd66b06a798ab", @"/Views/Election/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aac503c25ba70b62b4a3346c427f6f14a61fda0", @"/Views/_ViewImports.cshtml")]
    public class Views_Election_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Voting.Models.Election>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(76, 244, true);
            WriteLiteral("\r\n<h2 style=\"text-align:center;\">Details</h2>\r\n<hr/>\r\n<div class=\"row\" style=\" padding-left: 30%; padding-right: 30%;align-content:center;\">\r\n    <div style=\"width: 100%;\">\r\n        <dl class=\"dl-horizontal\">\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(321, 40, false);
#line 13 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(361, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(417, 36, false);
#line 16 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(453, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(509, 45, false);
#line 19 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(554, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(610, 41, false);
#line 22 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(651, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(707, 43, false);
#line 25 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(750, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(806, 39, false);
#line 28 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(845, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(901, 42, false);
#line 31 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(943, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(999, 38, false);
#line 34 "C:\Users\mx\source\repos\Voting\Voting\Views\Election\Details.cshtml"
           Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1037, 87, true);
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n</div>\r\n<br/>\r\n<br />\r\n<br />\r\n<br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Voting.Models.Election> Html { get; private set; }
    }
}
#pragma warning restore 1591
