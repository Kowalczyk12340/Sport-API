using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.ControllerTests
{
  public class UserControllerTest : BaseControllerTest
  {
        private HttpClient _client;
        private Mock<IUserService> _userServiceMock = new Mock<IUserService>();

        /*public UserControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory
                  .WithWebHostBuilder(builder =>
                  {
                      builder.ConfigureServices(services =>
                      {
                          var dbContextOptions = services
                              .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<SportDbContext>));

                          services.Remove(dbContextOptions);

                          services.AddSingleton<IUserService>(_userServiceMock.Object);


                          services
                           .AddDbContext<SportDbContext>(options =>
                           {
                               options.UseInMemoryDatabase("RestaurantDb");
                           });

                      });
                  })
                .CreateClient();
        }
        [Test]
        public async Task Login_ForRegisteredUser_ReturnsOk()
        {
            // arrange

            _userServiceMock
                .Setup(e => e.GenerateJwt(It.IsAny<LoginDto>()))
                .Returns(Task.FromResult("jwt"));

            var loginDto = new LoginDto()
            {
                Login = "test@test.com",
                Password = "password123"
            };

            var httpContent = loginDto.ToJsonHttpContent("frontendConnection");
            // act
            var response = await _client.PostAsync("/api/user/login", httpContent);
            // assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }*/
    [Test]
    public async Task TestGetMethodForNameOfNationalityAndLoginEndpointInUser()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/user/3");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<UserDto>(content);
      var expected = component.Nationality + " " + component.Login;
      Assert.That(expected != null && expected.Equals("Scotland alex.fergusson@wp.pl"));
    }

    [Test]
    public async Task TestGetMethodForFirstnameEndpointInUser()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/user/2");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<UserDto>(content);
      var expected = component.FirstName;
      Assert.That(expected != null && expected.Equals("Karol"));
    }

    [TestCase(3)]
    public async Task TestGetAllMethodForDisplayingObjectEndpointInUser(long id)
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/user");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<UserDto>>(content);
      var expected = component.FirstOrDefault(x => x.Id == id);
      Assert.That(expected.Password != null && expected.LastName != null);
    }

    [Test]
    public async Task TestGetAllMethodForDisplayingListEndpointInUser()
    {
      var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetService<SportDbContext>();
      //var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");
      var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/user");
      //.WithAuthHeader(userToAuth);
      var response = await Client.SendAsync(requestMessage);
      var content = await response.Content.ReadAsStringAsync();
      var component = JsonConvert.DeserializeObject<List<UserDto>>(content);
      Assert.That(component.Count > 0 && component.TrueForAll(x => x.Login != null));
    }
  }
}
