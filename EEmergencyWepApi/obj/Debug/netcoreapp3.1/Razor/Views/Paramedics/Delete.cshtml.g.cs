#pragma checksum "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec718a7652ce0f8f57c1c2bb79a4818e292fdfd8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Paramedics_Delete), @"mvc.1.0.view", @"/Views/Paramedics/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec718a7652ce0f8f57c1c2bb79a4818e292fdfd8", @"/Views/Paramedics/Delete.cshtml")]
    public class Views_Paramedics_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EEmergencyWepApi.Models.Paramedic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Paramedic</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayFor(model => model.password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.NIDN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayFor(model => model.NIDN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.fullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayFor(model => model.fullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayFor(model => model.status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.notificationToken));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayFor(model => model.notificationToken));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.team));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "D:\BackEndServer\EEmergencyWepApi\E\E-EmergenycWebAPI\EEmergencyWepApi\Views\Paramedics\Delete.cshtml"
       Write(Html.DisplayFor(model => model.team));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
    
    <form asp-action=""Delete"">
        <input type=""hidden"" asp-for=""phoneNumber"" />
        <input type=""submit"" value=""Delete"" class=""btn btn-danger"" /> |
        <a asp-action=""Index"">Back to List</a>
    </form>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EEmergencyWepApi.Models.Paramedic> Html { get; private set; }
    }
}
#pragma warning restore 1591
