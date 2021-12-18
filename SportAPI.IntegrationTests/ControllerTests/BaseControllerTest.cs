﻿using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace SportAPI.IntegrationTests.ControllerTests
{
  public abstract class BaseControllerTest
  {
    private readonly IHostBuilder _hostBuilder;
    protected IHost Application;
    public HttpClient Client;

    protected BaseControllerTest()
    {
      _hostBuilder = Host
        .CreateDefaultBuilder()
        .ConfigureAppConfiguration(config =>
        {
          config.AddInMemoryCollection(new Dictionary<string, string>() { ["ConnectionStrings:Database"] = @"Data Source=10.10.10.70\localifs; Initial Catalog=LWH10_SIERADZ; uid=siesdev; pwd=8pBVgbBdHsb5yQKQ" });
          config.AddEnvironmentVariables();
        })
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
        .ConfigureWebHost(webHost => { webHost.UseIISIntegration(); });
    }


    [OneTimeSetUp]
    public void StartApplication()
    {
      Application = _hostBuilder.Start();
      Client = Application.GetTestClient();
    }

    [OneTimeTearDown]
    public void StopApplication()
    {
      Application.Dispose();
    }

    /*[SetUp]
    public void EnsureSeedData()
    {
      using var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<SportDbContext>();
      var seeder = new SportClubSeeder(context,_passwordHasher);

      seeder.Seed();
    }*/
  }
}
