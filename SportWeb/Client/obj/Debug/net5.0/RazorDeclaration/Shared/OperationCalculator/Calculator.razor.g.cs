// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SportWeb.Client.Shared.OperationCalculator
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
    public partial class Calculator : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 189 "C:\Users\Dell\Desktop\c#\SportAPI\SportWeb\Client\Shared\OperationCalculator\Calculator.razor"
       
  public enum Operation
  {
    plus,
    minus,
    division,
    multiplication,
    memory,
    none
  };

  public int OldQuantity { get; set; }
  public int NewQuantity { get; set; }

  [Parameter]
  public EventCallback<int> QuantityChanged { get; set; }
  private int _value;
  [Parameter]
  public int Quantity
  {
    get => _value;
    set
    {
      if (_value == value) return;
      _value = value;
      QuantityChanged.InvokeAsync(Quantity);
      NewQuantity = value;
    }
  }
  public int Memory { get; set; }

  public Operation CurrentOperation { get; set; } = Operation.none;

  public void MemoryStore()
  {
    Memory = NewQuantity;
    NewQuantity = 0;
  }

  public void MemoryAdd()
  {
    Memory += NewQuantity;
    NewQuantity = 0;
  }

  public void MemorySubtract()
  {
    Memory -= NewQuantity;
    NewQuantity = 0;
  }

  public void MemoryRestore()
  {
    Quantity = Memory;
    NewQuantity = Memory;
    CurrentOperation = Operation.memory;

  }

  public void MemoryClear()
  {
    Memory = 0;
  }

  public void ButtonNumber(int number)
  {
    NewQuantity = NewQuantity * 10 + number;
    Quantity = NewQuantity;


  }

  public void Backspace()
  {
    NewQuantity = (NewQuantity - (NewQuantity % 10)) / 10;
    Quantity = NewQuantity;


  }

  public void Remove()
  {
    NewQuantity = 0;
    Quantity = NewQuantity;


  }

  public void RemoveAll()
  {
    OldQuantity = 0;
    NewQuantity = 0;
    CurrentOperation = Operation.none;
    Quantity = NewQuantity;


  }

  public void ReversalNumber()
  {
    NewQuantity *= -1;
    Quantity = NewQuantity;


  }

  public void Sqrt()
  {
    NewQuantity = (int)Math.Truncate(Math.Sqrt(NewQuantity));
    Quantity = NewQuantity;


  }

  public void Pow()
  {
    NewQuantity = (int)Math.Truncate(Math.Pow(NewQuantity, 2));
    Quantity = NewQuantity;


  }

  public void Fraction()
  {
    NewQuantity = 1 / NewQuantity;
    Quantity = NewQuantity;
  }

  public void Equals()
  {
    switch (CurrentOperation)
    {
      case Operation.plus:
        OldQuantity += NewQuantity;
        CurrentOperation = Operation.none;
        break;
      case Operation.minus:
        OldQuantity -= NewQuantity;
        CurrentOperation = Operation.none;
        break;
      case Operation.division:
        if (NewQuantity != 0)
        {
          OldQuantity /= NewQuantity;
        }
        else
        {
          Console.WriteLine("It is not possible to divide by 0!");
        }
        CurrentOperation = Operation.none;
        break;
      case Operation.multiplication:
        OldQuantity *= NewQuantity;
        CurrentOperation = Operation.none;
        break;
      case Operation.memory:
        OldQuantity = NewQuantity;
        CurrentOperation = Operation.none;
        break;
      default:
        OldQuantity = 0;
        CurrentOperation = Operation.none;
        break;
    }
    Quantity = OldQuantity;
    NewQuantity = 0;

  }

  public void MakeOperation(Operation operation)
  {
    if (CurrentOperation != Operation.none)
    {
      Equals();

    }
    else
    {
      OldQuantity = NewQuantity;
      Quantity = NewQuantity;
    }
    NewQuantity = 0;
    CurrentOperation = operation;
  }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
