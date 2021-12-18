// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SportWeb.Client.Shared.Players
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
#line 1 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Players\FilteringComponent.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Players\FilteringComponent.razor"
using SPA.Production.BlazorViews.Shared.Models.Changeovers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Players\FilteringComponent.razor"
using SPA.Production.BlazorViews.Client.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Players\FilteringComponent.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Players\FilteringComponent.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
    public partial class FilteringComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 96 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\Players\FilteringComponent.razor"
       
  private readonly TimeSpan IGNORE_HISTORICAL_SHORTER_THAN = new TimeSpan(0, 8, 0);
  private IEnumerable<FoundChangeoverDto> _elements;
  public IEnumerable<MachineConfDto> AllLines { get; set; } = new List<MachineConfDto>();
  private MachineConfDto _machineConf;
  public IEnumerable<FoundChangeoverDto> AllFoundChangeovers = new List<FoundChangeoverDto>();
  public bool IsCheckProto { get; set; } = false;
  public bool IsCheckDeleted { get; set; } = false;
  public DateTime? FromTime = DateTime.Today.AddDays(-1);
  public DateTime? ToTime = DateTime.Today;
  public bool Disabled { get; set; } = true;
  public bool ShowAlert { get; set; } = false;
  public MachineConfDto MachineConf
  {
    get => _machineConf;
    set
    {
      if (_machineConf == value) return;
      _machineConf = value;
      StateHasChanged();
      if (value is not null)
      {
        Disabled = false;
      }
      else
      {
        Disabled = true;
      }
    }
  }
  private FoundChangeoverDto _foundChangeover;
  public FoundChangeoverDto FoundChangeover
  {
    get => _foundChangeover;
    set
    {
      if (_foundChangeover == value) return;
      _foundChangeover = value;
      StateHasChanged();
    }
  }
  private Department _department;
  public Department Department
  {
    get => _department;
    set
    {
      if (_department == value) return;
      _department = value;

      GetAllLines();
      MachineConf = null;
    }
  }

  [Parameter]
  public IEnumerable<FoundChangeoverDto> Elements
  {
    get => _elements;
    set
    {
      if (_elements == value) return;
      _elements = value;

      ElementsChanged.InvokeAsync(value);
    }
  }

  [Parameter]
  public EventCallback<IEnumerable<FoundChangeoverDto>> ElementsChanged { get; set; }

  private void ShowAlerts()
  {
    ShowAlert = true;
  }

  private void CloseMe(bool value)
  {
    if (value)
    {
      ShowAlert = false;
    }
  }

  private async Task GetAllLines()
  {
    try
    {
      AllLines = (await _http.GetFromJsonAsync<List<MachineConfDto>>($"api/changeovers/lines/{Department}"));
      StateHasChanged();
    }
    catch (Exception ex)
    {
      var message = ex.Message;
    }
    StateHasChanged();
  }

  private async Task GetFoundChangeoversData()
  {
    var toTime = ToTime.Value.AddHours(23).AddMinutes(59).AddSeconds(59);

    try
    {
      Elements = (await _http.GetFromJsonAsync<List<FoundChangeoverDto>>($"api/changeovers?lineName={MachineConf?.IdentityName}&department={Department}&fromTime={FromTime.Value.ToString(CultureInfo.InvariantCulture)}&toTime={toTime.ToString(CultureInfo.InvariantCulture)}&isCheckProto={IsCheckProto}&isCheckDeleted={IsCheckDeleted}"));
      StateHasChanged();
    }
    catch (Exception)
    {
      ShowAlerts();
    }
    StateHasChanged();
  }

  protected override void OnInitialized()
  {
    Department = Department.Sieradz;
    Elements = new List<FoundChangeoverDto>();
    StateHasChanged();
  }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IStringLocalizer<Language> _l { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _http { get; set; }
    }
}
#pragma warning restore 1591
