using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using MudBlazor.Services;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using SportWeb.Client.Extensions;

namespace SportWeb.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddMudServices();
      builder.Services.AddLocalization();
      builder.Services.AddBlazoredLocalStorage();

      var host = builder.Build();
      await host.SetDefaultCulture(); // Retrieves local storage value and sets the thread's current culture.
      await host.RunAsync();
    }
  }
}
