// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SportWeb.Client.Shared.Coaches___kopiować
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
#line 1 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Coaches - kopiować\Manufacturers.razor"
using SPA.Production.BlazorViews.Shared.Models.BoardInfo;

#line default
#line hidden
#nullable disable
    public partial class Manufacturers : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Coaches - kopiować\Manufacturers.razor"
       
  private ManufacturerInfoDto _selectedManufacturer;
  public ManufacturerInfoDto SelectedManufacturer
  {
    get => _selectedManufacturer;
    set
    {
      if (_selectedManufacturer == value) return;
      _selectedManufacturer = value;
      SelectedManufacturerChanged.InvokeAsync(SelectedManufacturer);
      StateHasChanged();
    }
  }
  [Parameter]
  public EventCallback<ManufacturerInfoDto> SelectedManufacturerChanged { get; set; }
  [Parameter]
  public IEnumerable<ManufacturerInfoDto> Elements { get; set; }

  protected override void OnInitialized()
  {
    SelectedManufacturer = new ManufacturerInfoDto();
    Elements = new List<ManufacturerInfoDto>();
  }

  private string SelectedRow(ManufacturerInfoDto manufacturerComponent, int index)
  {
    if (manufacturerComponent == SelectedManufacturer || manufacturerComponent == _selectedManufacturer)
    {
      return "mud-theme-info";
    }
    else
    {
      return "";
    }
  }

  protected override async Task OnParametersSetAsync()
  {
    SelectedManufacturer = Elements.FirstOrDefault();
  }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<Resources.Language> _l { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
