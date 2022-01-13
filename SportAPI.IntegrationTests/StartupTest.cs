using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.AspNetCore.Hosting;
using SportAPI.Sport.Services.Interfaces;
using Moq;
using Microsoft.Extensions.Configuration;
using SportAPI.Sport.Controllers;
using SportAPI.Sport.Services;

namespace SportAPI.IntegrationTests
{
    public class StartupTest
    {
        [Test]
        public void StartupClassForSportClubAndLeagueServiceTest()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
            Assert.IsNotNull(webHost.Services.GetRequiredService<ISportClubService>());
            Assert.IsNotNull(webHost.Services.GetRequiredService<ILeagueService>());
        }

        [Test]
        public void StartupClassForUserServiceTest()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
            Assert.IsNotNull(webHost.Services.GetRequiredService<IUserService>());
        }
    }
}