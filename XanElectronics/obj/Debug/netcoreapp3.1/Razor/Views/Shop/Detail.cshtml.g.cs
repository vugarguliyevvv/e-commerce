#pragma checksum "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5640f477a844fd993ea684b3d584a9413a588731"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Detail), @"mvc.1.0.view", @"/Views/Shop/Detail.cshtml")]
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
#line 1 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\_ViewImports.cshtml"
using XanElectronics.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\_ViewImports.cshtml"
using XanElectronics.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5640f477a844fd993ea684b3d584a9413a588731", @"/Views/Shop/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71df2b8f05ac91fb957a43b85b0a02d10ac29bd9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 800px;height: 800px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product-thumb"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 360px;height: 360px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- breadcrumb-section start -->
<nav class=""breadcrumb-section theme1 bg-lighten2 pt-110 pb-110"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""section-title text-center mb-15"">
                    <h2 class=""title text-dark text-capitalize"">Detail</h2>
                </div>
            </div>
        </div>
    </div>
</nav>
<!-- breadcrumb-section end -->
<!-- product-single start -->
<input type=""hidden"" id=""pageName"" value=""detail"" />
<input type=""hidden"" id=""productDbCount""");
            BeginWriteAttribute("value", " value=\"", 610, "\"", 630, 1);
#nullable restore
#line 21 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
WriteAttributeValue("", 618, Model.Count, 618, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n<section class=\"product-single theme3 pt-60\">\n    <div class=\"container\">\n        <div class=\"row\">\n            <div class=\"col-lg-6 mb-5 mb-lg-0\">\n                <div class=\"position-relative\">\n");
#nullable restore
#line 27 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                     if (Model.IsNew)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-danger top-right\">New</span>\n");
#nullable restore
#line 30 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n                <div class=\"product-sync-init mb-20\">\n                    <div class=\"single-product\">\n                        <div class=\"product-thumb\">\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5640f477a844fd993ea684b3d584a9413a5887316345", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1207, "~/assets/img/product/", 1207, 21, true);
#nullable restore
#line 35 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
AddHtmlAttributeValue("", 1228, Model.ProductImages.ElementAt(0).ImageUrl, 1228, 42, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        </div>\n                    </div>\n                    <!-- single-product end -->\n");
#nullable restore
#line 40 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                     foreach (var item in Model.ProductImages)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"single-product\">\n                            <div class=\"product-thumb\">\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5640f477a844fd993ea684b3d584a9413a5887318576", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1704, "~/assets/img/product/", 1704, 21, true);
#nullable restore
#line 44 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
AddHtmlAttributeValue("", 1725, item.ImageUrl, 1725, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            </div>\n                        </div>\n");
#nullable restore
#line 48 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <!-- single-product end -->\n                </div>\n                <div class=\"product-sync-nav single-product\">\n");
#nullable restore
#line 52 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                     foreach (var image in Model.ProductImages)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"single-product\">\n                            <div class=\"product-thumb\">\n                                <a href=\"javascript:void(0)\"> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5640f477a844fd993ea684b3d584a9413a58873111128", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2321, "~/assets/img/product/", 2321, 21, true);
#nullable restore
#line 56 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
AddHtmlAttributeValue("", 2342, image.ImageUrl, 2342, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\n                            </div>\n                        </div>\n");
#nullable restore
#line 60 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n            </div>\n            <div class=\"col-lg-6 mt-5 mt-md-0\">\n                <div class=\"single-product-info\">\n                    <div class=\"single-product-head\">\n                        <h2 class=\"title mb-20\">");
#nullable restore
#line 66 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n                        <div class=\"star-content mb-20\">\n");
#nullable restore
#line 68 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                             for (int i = 0; i < Model.Star; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"star-on\"><i class=\"ion-ios-star\"></i> </span>\n");
#nullable restore
#line 71 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            
                        </div>
                    </div>
                    <div class=""product-body mb-40"">
                        <div class=""d-flex align-items-center mb-30"">
                            <h6 class=""product-price mr-20"">
");
#nullable restore
#line 78 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                 if (Model.DisCountRate > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <del class=\"del\"> ");
#nullable restore
#line 80 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                                 Write(Model.Price.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</del>\n                                    <span class=\"onsale\"> ");
#nullable restore
#line 81 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                                     Write(Model.ResultPrice.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                                    <span class=\"badge position-static bg-dark rounded-0\">Save ");
#nullable restore
#line 82 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                                                                          Write(Model.DisCountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</span>\n");
#nullable restore
#line 83 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"onsale\"> ");
#nullable restore
#line 86 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                                     Write(Model.ResultPrice.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 87 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </h6>
                            
                        </div>
                        <p>description</p>
                    </div>
                    <div class=""product-footer"">
                        <div class=""product-count style d-flex flex-column flex-sm-row mt-30 mb-30"">
                            <div class=""count d-flex"">
                                <input type=""number"" min=""1"" max=""10"" step=""1"" value=""1"" id=""addProductCount"">
                                <div class=""button-group"">
                                    <button class=""count-btn increment""><i class=""fas fa-chevron-up""></i></button>
                                    <button class=""count-btn decrement""><i class=""fas fa-chevron-down""></i></button>
                                </div>
                            </div>
                            <div>
                                <button class=""btn theme-btn--dark3 btn--xl mt-5 mt-sm-0 rounded-5 ml-3 addToBasket"" data-id=""");
#nullable restore
#line 103 "C:\Users\User\Desktop\KhanElectronics-master\XanElectronics\Views\Shop\Detail.cshtml"
                                                                                                                         Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\n                                    <span class=\"mr-2\"><i class=\"ion-android-add\"></i></span>\n                                    Add to cart\n                                </button>\n                            </div>\n                        </div>\n");
            WriteLiteral(@"                        <div class=""pro-social-links mt-10"">
                            <ul class=""d-flex align-items-center"">
                                <li class=""share"">Share</li>
                                <li><a href=""#""><i class=""ion-social-facebook""></i></a></li>
                                <li><a href=""#""><i class=""ion-social-twitter""></i></a></li>
                                <li><a href=""#""><i class=""ion-social-google""></i></a></li>
                                <li><a href=""#""><i class=""ion-social-pinterest""></i></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- product-single end -->
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script >
     $("".count"").each(function () {
        var count = $(this),
            input = count.find('input[type=""number""]'),
            increament = count.find("".increment""),
            decreament = count.find("".decrement""),
            minValue = input.attr(""min""),
            maxValue = input.attr(""max"");
        increament.on(""click"", function () {
          var oldValue = parseFloat(input.val());
    
          if (oldValue >= maxValue) {
            var newVal = oldValue;
          } else {
            var newVal = oldValue + 1;
          }
    
          count.find(""input"").val(newVal);
          count.find(""input"").trigger(""change"");
        });
        decreament.on(""click"", function () {
          var oldValue = parseFloat(input.val());
    
          if (oldValue <= minValue) {
            var newVal = oldValue;
          } else {
            var newVal = oldValue - 1;
          }
    
          count.find(""input"").val(newVal);
          count.find(""input"").trigger(""change"");
        })");
                WriteLiteral(";\n      });\n    </script>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
