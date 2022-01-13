using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using SportAPI.IntegrationTests.Infrastructure;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.ControllerTests
{
    public class AuthTest : BaseControllerTest
    {

        [Test]
        public async Task GetUnauthorizedError()
        {
            var match = new CreateMatchDto
            {
                TeamOne = "CSKA Sofia",
                TeamTwo = "Lewski Sofia",
                DateOfMatch = new DateTime(2022, 2, 2, 14, 10, 34),
                InHouse = true,
                SportClubId = 1
            };

            var command = JsonConvert.SerializeObject(match);
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/match");

            request.Content = new StringContent(command, Encoding.UTF8, "application/json");
            var response = await Client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task IsAuthenticated()
        {
            var scope = Application.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<SportDbContext>();

            var userToAuth = await context.Users.FirstOrDefaultAsync(x => x.Login == "marcinkowalczyk24.7@gmail.com");

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/address")
                                                       .WithAuthHeader(userToAuth);

            var response = await Client.SendAsync(requestMessage);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
