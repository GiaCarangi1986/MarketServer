#pragma checksum "C:\Users\Лиза\Desktop\Конструирование интернет-приложений\5 лаб\ASPNetCore\ASPNetCore\ASPNetCore\Views\Categories\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7aa09d3afc9cfc58e9139973c7c5c737133b7e02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Delete), @"mvc.1.0.view", @"/Views/Categories/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/Delete.cshtml", typeof(AspNetCore.Views_Categories_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7aa09d3afc9cfc58e9139973c7c5c737133b7e02", @"/Views/Categories/Delete.cshtml")]
    public class Views_Categories_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASPNetCore.Model.Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Лиза\Desktop\Конструирование интернет-приложений\5 лаб\ASPNetCore\ASPNetCore\ASPNetCore\Views\Categories\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(78, 178, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Category</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(257, 40, false);
#line 15 "C:\Users\Лиза\Desktop\Конструирование интернет-приложений\5 лаб\ASPNetCore\ASPNetCore\ASPNetCore\Views\Categories\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(297, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(361, 36, false);
#line 18 "C:\Users\Лиза\Desktop\Конструирование интернет-приложений\5 лаб\ASPNetCore\ASPNetCore\ASPNetCore\Views\Categories\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(397, 262, true);
            WriteLiteral(@"
        </dd>
    </dl>
    
    <form asp-action=""Delete"">
        <input type=""hidden"" asp-for=""IdCategory"" />
        <input type=""submit"" value=""Delete"" class=""btn btn-danger"" /> |
        <a asp-action=""Index"">Back to List</a>
    </form>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASPNetCore.Model.Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
