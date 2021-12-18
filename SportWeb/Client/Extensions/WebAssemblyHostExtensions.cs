using System.Globalization;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SportWeb.Client.Extensions
{
  public static class WebAssemblyHostExtensions
  {
    public async static Task SetDefaultCulture(this WebAssemblyHost host)
    {
      var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
      var cultureString = await localStorage.GetItemAsync<string>("Culture");

      CultureInfo cultureInfo;

      if (!string.IsNullOrWhiteSpace(cultureString))
      {
        cultureInfo = new CultureInfo(cultureString);
      }
      else
      {
        cultureInfo = new CultureInfo("en-US");
      }

      CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
      CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
  }
}
