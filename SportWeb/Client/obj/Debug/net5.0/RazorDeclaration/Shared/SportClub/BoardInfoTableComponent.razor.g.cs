// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SportWeb.Client.Shared.SportClub
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
#line 1 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\SportClub\BoardInfoTableComponent.razor"
using SPA.Production.BlazorViews.Shared.Models.BoardInfo;

#line default
#line hidden
#nullable disable
    public partial class BoardInfoTableComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\SportClub\BoardInfoTableComponent.razor"
       
  private BoardInfoDataDto _boardComponent;
  private bool _searchByPartNumber { get; set; } = true;
  private string searchString = "";
  public string SummaryQuantity { get; set; }
  private BoardInfoTableComponentDto _selectedComponent;
  private IEnumerable<BoardInfoTableComponentDto> Elements = new List<BoardInfoTableComponentDto>();
  public BoardInfoTableComponentDto SelectedComponent
  {
    get => _selectedComponent;
    set
    {
      if (_selectedComponent == value) return;
      _selectedComponent = value;
      SelectedComponentChanged.InvokeAsync(value);
      StateHasChanged();
    }
  }
  [Parameter]
  public EventCallback<BoardInfoTableComponentDto> SelectedComponentChanged { get; set; }
  [Parameter]
  public BoardInfoDataDto BoardInfoData
  {
    get => _boardComponent;
    set
    {
      if (_boardComponent == value) return;
      _boardComponent = value;
      FetchComponents();
      StateHasChanged();
    }
  }

  private string SelectedRow(BoardInfoTableComponentDto boardInfoTableComponent, int index)
  {
    if (boardInfoTableComponent == SelectedComponent)
    {
      return "mud-theme-info";
    }
    else
    {
      return "";
    }
  }

  protected override void OnInitialized()
  {
    BoardInfoData = new BoardInfoDataDto();
  }

  public void SumQuantity()
  {
    var quantity = 0.0;
    foreach (var item in Elements)
    {
      quantity += item.Quantity;
    }
    quantity = Math.Round(quantity, 4);
    SummaryQuantity = $"{quantity}";
    StateHasChanged();
  }

  public async void FetchComponents()
  {
    if (BoardInfoData is not null)
    {
      if (!(string.IsNullOrWhiteSpace(BoardInfoData.PartNo) && string.IsNullOrWhiteSpace(BoardInfoData.Revision)))
      {
        Elements = (await _http.GetFromJsonAsync<List<BoardInfoTableComponentDto>>($"api/board/components/{BoardInfoData.PartNo}/{BoardInfoData.Revision}"));
        foreach (var item in Elements)
        {
          if (!(item is null))
          {
            if (!(string.IsNullOrWhiteSpace(item.Reference)))
            {
              item.Reference = item.Reference.Replace(",", ", ");
            }
          }
        }
      }
      SelectedComponent = Elements.FirstOrDefault();
      SumQuantity();
    }
    else
    {
      Elements = Array.Empty<BoardInfoTableComponentDto>();
      SelectedComponent = null;
      SummaryQuantity = "";
    }
  }

  private bool FilterFunc(BoardInfoTableComponentDto element)
  {
    if (string.IsNullOrWhiteSpace(searchString))
      return true;
    if (element.OperationNo.Contains(searchString, StringComparison.OrdinalIgnoreCase))
      return true;
    if (element.PartNo.Contains(searchString, StringComparison.OrdinalIgnoreCase))
      return true;
    if (element.Comment.Contains(searchString, StringComparison.OrdinalIgnoreCase))
      return true;
    if (element.Reference.Contains(searchString, StringComparison.OrdinalIgnoreCase))
      return true;
    if ($"{element.OperationNo} {element.PartNo} {element.Comment} {element.Reference}".Contains(searchString))
      return true;
    return false;
  }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<Resources.Language> _l { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
