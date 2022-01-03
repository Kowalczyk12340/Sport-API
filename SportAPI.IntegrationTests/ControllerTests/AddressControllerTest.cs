using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using SportAPI.IntegrationTests.Infrastructure;
using SportAPI.Sport.Controllers;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.ControllerTests
{
  public class AddressControllerTest : BaseControllerTest
  {
    [Test]
    public async Task TestGetMethodForCityEndpointInAddress()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/address/3");
        //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<AddressDto>(content);
      var expected = component.City;
      Assert.That(expected != null && expected.Equals("Manchester"));
    }

    [Test]
    public async Task TestGetMethodForPostalCodeEndpointInAddress()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/address/2");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<AddressDto>(content);
      var expected = component.PostalCode;
      Assert.That(expected != null && expected.Equals("11-321"));
    }

    [TestCase(3)]
    public async Task TestGetAllMethodForDisplayingObjectEndpointInAddress(long id)
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/address");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<AddressDto>>(content);
      var expected = component.FirstOrDefault(x => x.Id == id);
      Assert.That(expected.City != null && expected.Street.Equals("Wolf Street Centre 563"));
    }

    [Test]
    public async Task TestGetAllMethodForDisplayingListEndpointInAddress()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/address");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<AddressDto>>(content);
      Assert.That(component.Count > 0 && component.TrueForAll(x => x.City != null));
    }

    /*[TestCase(10074L)]
    public async Task TestPostMethodForDisplayingListEndpointInAddress(long id)
    {
      //Arrange
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      var searchAddress = await context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
      var newAddress = new Address
      {
        City = "Katowice",
        Street = "Józefa Piłsudskiego 34",
        PostalCode = "56-039"
      };
      //Act
      var newAddressBody = JsonConvert.SerializeObject(newAddress);
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Put, "/api/address");
        //.WithAuthHeader(userToAuth);
      requestMessage.Content = new StringContent(newAddressBody, Encoding.UTF8,
        "application/json");
      var response = await Client.SendAsync(requestMessage);
      var stringContent = await response.Content.ReadAsStringAsync();
      var addressDto = JsonConvert.DeserializeObject<AddressDto>(stringContent);
      //Assert
      Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
      Assert.AreEqual(99, addressDto.Id);
      Assert.AreEqual("Katowice", addressDto.City);
    }*/
  }
}