using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using SportAPI.Sport.Controllers;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.ControllerTests
{
  public class AddressControllerTest : BaseControllerTest
  {
    [Test]
    public async Task TestCityEndpointInAddress()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();

      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/address/7");

      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<Address>(content);

      var expected = component.City;

      Assert.That(expected != null);
    }
  }
}
