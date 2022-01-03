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
  public class SportClubControllerTest : BaseControllerTest
  {
    [Test]
    public async Task TestGetMethodClubNameNationalityAndCityEndpointInSportClub()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/sportclub/3");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<SportClubDto>(content);
      var expected = component.SportClubName + " " + component.Category + " " + component.ContactEmail;
      Assert.That(expected != null && expected.Equals("Manchester United Klub Piłki Nożnej manchester.united@manu.com"));
    }

    [Test]
    public async Task TestGetMethodForPhoneNumberEndpointInSportClub()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/sportclub/1");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<SportClubDto>(content);
      var expected = component.Coaches.FirstOrDefault().PhoneNumber;
      Assert.That(expected != null && expected.Equals("+48 607 801 212"));
    }

    [TestCase(2)]
    public async Task TestGetAllMethodForContactDatasEndpointInSportClub(long id)
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/sportclub");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<SportClubDto>>(content);
      var expected = component.FirstOrDefault(x => x.Id == id);
      Assert.That(expected.ContactNumber != null && expected.ContactEmail.Equals("wkslegiawarszawa@wojskowi.com"));
    }

    [Test]
    public async Task TestGetAllMethodForDisplayingListEndpointInSportClub()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/sportclub");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<SportClubDto>>(content);
      Assert.That(component.Count > 0 && component.TrueForAll(x => x.Category != null && x.Description != null));
    }
  }
}