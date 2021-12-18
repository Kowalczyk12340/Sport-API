// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SportWeb.Client.Shared.SportClubs___kopiować
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
#line 1 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\SportClubs - kopiować\ComponentInformation.razor"
using SPA.Production.BlazorViews.Shared.Models.BoardInfo;

#line default
#line hidden
#nullable disable
    public partial class ComponentInformation : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 50 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\SportClubs - kopiować\ComponentInformation.razor"
       
  public string _partNo;
  private string _description;
  private string _reference;
  private bool _searchByPartNumber { get; set; } = true;
  private BoardInfoTableComponentDto _boardInfoComponent;
  public IEnumerable<ManufacturerInfoDto> Manufacturers = new List<ManufacturerInfoDto>();
  public IEnumerable<BoardInfoDataDto> UsedIn = new List<BoardInfoDataDto>();
  public IEnumerable<ComponentLocationDto> Locations = new List<ComponentLocationDto>();
  private bool Disabled = true;

  [Parameter]
  public BoardInfoTableComponentDto BoardInfoComponent
  {
    get => _boardInfoComponent;
    set
    {
      if (_boardInfoComponent == value) return;
      _boardInfoComponent = value;
      _partNo = value?.PartNo;
      _description = value?.Comment;
      _reference = value?.Reference;
      StateHasChanged();

      ManufacturerInfo(value?.PartNo);
      LocalizationInfo(value?.PartNo);
      UsedInInfo(value?.PartNo);
      if (string.IsNullOrWhiteSpace(BoardInfoComponent?.PartNo))
      {
        Disabled = true;
      }
      else
      {
        Disabled = false;
      }
      StateHasChanged();
    }
  }

  public ManufacturerInfoDto SelectedManufacturer { get; set; }

  protected void SelectedManufacturerChanged(ManufacturerInfoDto selectedManufacturer)
  {
    SelectedManufacturer = selectedManufacturer;
    StateHasChanged();
  }

  protected override void OnInitialized()
  {
    BoardInfoComponent = new BoardInfoTableComponentDto();
    SelectedManufacturer = new ManufacturerInfoDto();
    StateHasChanged();
  }

  private async void ManufacturerInfo(string partNumber)
  {
    if (string.IsNullOrWhiteSpace(partNumber))
    {
      Manufacturers = Array.Empty<ManufacturerInfoDto>();
    }
    else
    {
      Manufacturers = (await _http.GetFromJsonAsync<List<ManufacturerInfoDto>>($"api/board/manufacturers/{partNumber}"));
    }
    SelectedManufacturer = Manufacturers.FirstOrDefault();
    StateHasChanged();
  }

  private async void LocalizationInfo(string partNumber)
  {
    if (string.IsNullOrWhiteSpace(partNumber))
    {
      Locations = Array.Empty<ComponentLocationDto>();
    }
    else
    {
      Locations = (await _http.GetFromJsonAsync<List<ComponentLocationDto>>($"api/board/localizations/{partNumber}"));
    }
    StateHasChanged();
  }

  private async void UsedInInfo(string partNumber)
  {
    if (string.IsNullOrWhiteSpace(partNumber))
    {
      UsedIn = Array.Empty<BoardInfoDataDto>();
    }
    else
    {
      UsedIn = (await _http.GetFromJsonAsync<List<BoardInfoDataDto>>($"api/board/usedin/{partNumber}"));
    }
    StateHasChanged();
  }

  private async void SearchGoogle()
  {
    var link = $@"https://www.google.pl/search?q={SelectedManufacturer.ManufPartNo} datasheet";
    await jsRuntime.InvokeVoidAsync("open", link, "_blank");
  }

  private async void SearchGoogleImage()
  {
    var link = $@"https://www.google.pl/search?hl=pl&site=imghp&tbm=isch&q={SelectedManufacturer.ManufPartNo}";
    await jsRuntime.InvokeVoidAsync("open", link, "_blank");
  }

  private async void SearchSharePoint()
  {
    var link = $@"http://sieradz.scanfil.com/_layouts/15/osssearchresults.aspx?u=http%3A%2F%2Fsieradz%2Escanfil%2Ecom&k={_partNo}";
    await jsRuntime.InvokeVoidAsync("open", link, "_blank");
  }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<Resources.Language> _l { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
