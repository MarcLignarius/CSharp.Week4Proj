#pragma checksum "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6348d28ce36b6e1f70bf51fbb87f79d28deba837"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_Index), @"mvc.1.0.view", @"/Views/Clients/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Clients/Index.cshtml", typeof(AspNetCore.Views_Clients_Index))]
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
#line 1 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
using HairSalon.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6348d28ce36b6e1f70bf51fbb87f79d28deba837", @"/Views/Clients/Index.cshtml")]
    public class Views_Clients_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/styles.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(51, 254, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6348d28ce36b6e1f70bf51fbb87f79d28deba8374261", async() => {
                BeginContext(57, 176, true);
                WriteLiteral("\r\n  <meta charset=\'utf-8\'>\r\n  <title>Chez Marc Hair Salon</title>\r\n  <link rel=\'stylesheet\' href=\'https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css\'>\r\n  ");
                EndContext();
                BeginContext(233, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6348d28ce36b6e1f70bf51fbb87f79d28deba8374829", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(296, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(305, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(307, 863, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6348d28ce36b6e1f70bf51fbb87f79d28deba8377045", async() => {
                BeginContext(313, 107, true);
                WriteLiteral("\r\n  <div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n      <h1>Chez Marc Hair Salon</h1>\r\n    </div>\r\n");
                EndContext();
#line 15 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
     if (Model.Count == 0)
    {

#line default
#line hidden
                BeginContext(455, 48, true);
                WriteLiteral("      <p>You have no clients at this time!</p>\r\n");
                EndContext();
#line 18 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
    }

#line default
#line hidden
                BeginContext(510, 4, true);
                WriteLiteral("    ");
                EndContext();
#line 19 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
     if(Model.Count != 0)
    {
      

#line default
#line hidden
#line 21 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
       foreach (Client client in Model)
      {

#line default
#line hidden
                BeginContext(594, 40, true);
                WriteLiteral("        <ul>\r\n          <li>First Name: ");
                EndContext();
                BeginContext(635, 21, false);
#line 24 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
                     Write(client.GetFirstName());

#line default
#line hidden
                EndContext();
                BeginContext(656, 32, true);
                WriteLiteral("</li>\r\n          <li>Last Name: ");
                EndContext();
                BeginContext(689, 20, false);
#line 25 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
                    Write(client.GetLastName());

#line default
#line hidden
                EndContext();
                BeginContext(709, 35, true);
                WriteLiteral("</li>\r\n          <li>Phone Number: ");
                EndContext();
                BeginContext(745, 23, false);
#line 26 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
                       Write(client.GetPhoneNumber());

#line default
#line hidden
                EndContext();
                BeginContext(768, 36, true);
                WriteLiteral("</li>\r\n          <li>Email Address: ");
                EndContext();
                BeginContext(805, 24, false);
#line 27 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
                        Write(client.GetEmailAddress());

#line default
#line hidden
                EndContext();
                BeginContext(829, 36, true);
                WriteLiteral("</li>\r\n        </ul>\r\n        <br>\r\n");
                EndContext();
#line 30 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
      }

#line default
#line hidden
#line 30 "C:\Users\mimim\Desktop\HairSalon.Solution\HairSalon\Views\Clients\Index.cshtml"
       
    }

#line default
#line hidden
                BeginContext(881, 282, true);
                WriteLiteral(@"    <a href=""/clients/new"" class=""btn btn-dark"">Add a new client</a>
    <form action=""/clients/delete"" method=""post"">
      <button type=""submit"" name=""button"" class=""btn btn-dark"">Clear client list</button>
    </form>
    <a href=""/"" class=""btn btn-dark"">Home</a>
  </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1170, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
