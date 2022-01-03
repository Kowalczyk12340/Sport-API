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
  public class TrainingControllerTest : BaseControllerTest
  {
    [Test]
    public async Task TestGetMethodForNameOfTrainingAndTimeOfTrainingEndpointInTraining()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/training/3");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<TrainingDto>(content);
      var expected = component.Name + " " + component.TimeOfTraining.ToString();
      Assert.That(expected != null && expected.Equals("Trening Techniczny 28.11.2021 10:45:00"));
    }

    [Test]
    public async Task TestGetMethodForStringDateOfMatchEndpointInTraining()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/training/2");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<TrainingDto>(content);
      var expected = component.Description;
      Assert.That(expected != null && expected.Equals("Trening, który odbywa się na boisku treningowym, w którym zawodnicy grający w polu strzelają bramkarzom z różnych pozycji na boisku"));
    }

    [TestCase(3)]
    public async Task TestGetAllMethodForDisplayingObjectEndpointInTraining(long id)
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/training");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<TrainingDto>>(content);
      var expected = component.FirstOrDefault(x => x.Id == id);
      Assert.That(expected.Name != null && expected.Description != null);
    }

    [Test]
    public async Task TestGetAllMethodForDisplayingListEndpointInTraining()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/training");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<TrainingDto>>(content);
      Assert.That(component.Count > 0 && component.TrueForAll(x => x.Name != null));
    }
  }
}
