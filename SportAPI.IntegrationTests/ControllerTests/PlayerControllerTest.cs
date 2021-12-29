using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.ControllerTests
{
  public class PlayerControllerTest : BaseControllerTest
  {
    [Test]
    public async Task TestGetMethodForNameAndSurnameWithEmailEndpointInPlayer()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/player/5");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<PlayerDto>(content);
      var expected = component.Name + " " + component.Surname + " - " + component.EmailAddress;
      Assert.That(expected != null && expected.Equals("Filip Mladenović - filip.mladenovic@onet.pl"));
    }

    [Test]
    public async Task TestGetMethodForStringDateOfMatchEndpointInPlayer()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/player/4");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<PlayerDto>(content);
      var expected = component.Nationality.ToString();
      Assert.That(expected != null && expected.Equals("Polska"));
    }

    [TestCase(6)]
    public async Task TestGetAllMethodForDisplayingObjectEndpointInPlayer(long id)
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/player");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<PlayerDto>>(content);
      var expected = component.FirstOrDefault(x => x.Id == id);
      Assert.That(expected.PhoneNumber != null && expected.Position.Equals("Pomocnik"));
    }

    [Test]
    public async Task TestGetAllMethodForDisplayingListEndpointInPlayer()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/player");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<PlayerDto>>(content);
      Assert.That(component.Count > 0 && component.TrueForAll(x => x.Name != null && x.Pesel != null));
    }
  }
}
