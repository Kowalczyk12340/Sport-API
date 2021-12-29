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
  public class MatchControllerTest : BaseControllerTest
  {
    [Test]
    public async Task TestGetMethodForTwoTeamsAndInHouseValueEndpointInMatch()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/match/5");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<MatchDto>(content);
      var expected = component.TeamOne + " - " + component.TeamTwo + " " + component.InHouse;
      Assert.That(expected != null && expected.Equals("Zawisza Bydgoszcz - Legia Warszawa True"));
    }

    [Test]
    public async Task TestGetMethodForStringDateOfMatchEndpointInMatch()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/match/4");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<MatchDto>(content);
      var expected = component.DateOfMatch.ToString();
      Assert.That(expected != null && expected.Equals("23.10.2021 20:45:00"));
    }

    [TestCase(6)]
    public async Task TestGetAllMethodForDisplayingObjectEndpointInMatch(long id)
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/match");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<MatchDto>>(content);
      var expected = component.FirstOrDefault(x => x.Id == id);
      Assert.That(expected.TeamOne != null && expected.TeamTwo.Equals("Manchester City"));
    }

    [Test]
    public async Task TestGetAllMethodForDisplayingListEndpointInMatch()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/match");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<MatchDto>>(content);
      Assert.That(component.Count > 0 && component.TrueForAll(x => x.TeamOne != null && x.TeamTwo != null));
    }
  }
}
