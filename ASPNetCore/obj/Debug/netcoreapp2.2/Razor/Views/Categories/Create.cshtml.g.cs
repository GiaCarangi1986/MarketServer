#pragma checksum "C:\Users\Лиза\Desktop\Конструирование интернет-приложений\5 лаб\ASPNetCore\ASPNetCore\ASPNetCore\Views\Categories\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdb8a6f8bd8565aa9f22f9700131a31f2b1c761b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Create), @"mvc.1.0.view", @"/Views/Categories/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/Create.cshtml", typeof(AspNetCore.Views_Categories_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdb8a6f8bd8565aa9f22f9700131a31f2b1c761b", @"/Views/Categories/Create.cshtml")]
    public class Views_Categories_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASPNetCore.Model.Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Лиза\Desktop\Конструирование интернет-приложений\5 лаб\ASPNetCore\ASPNetCore\ASPNetCore\Views\Categories\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
            BeginContext(78, 717, true);
            WriteLiteral(@"
<h1>Create</h1>

<h4>Category</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Name"" class=""control-label""></label>
                <input asp-for=""Name"" class=""form-control"" />
                <span asp-validation-for=""Name"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(813, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 32 "C:\Users\Лиза\Desktop\Конструирование интернет-приложений\5 лаб\ASPNetCore\ASPNetCore\ASPNetCore\Views\Categories\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
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