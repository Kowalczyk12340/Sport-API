// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SportWeb.Client.Shared.Leagues
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using SportWeb.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using SportWeb.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Leagues\Localizations.razor"
using SPA.Production.BlazorViews.Shared.Models.BoardInfo;

#line default
#line hidden
#nullable disable
    public partial class Localizations : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 19 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Leagues\Localizations.razor"
       
  private ComponentLocationDto selectedItem = null;
  [Parameter]
  public IEnumerable<ComponentLocationDto> Elements { get; set; }

  protected override void OnInitialized()
  {
    Elements = new List<ComponentLocationDto>();
    selectedItem = new ComponentLocationDto();
  }
  protected override async Task OnParametersSetAsync()
  {
    selectedItem = Elements.FirstOrDefault();
  }

  private string SelectedRow(ComponentLocationDto localizationComponent, int index)
  {
    if (localizationComponent == selectedItem)
    {
      return "mud-theme-info";
    }
    else
    {
      return "";
    }
  }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<Resources.Language> _l { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
