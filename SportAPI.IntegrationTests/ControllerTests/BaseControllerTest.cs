using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using SportAPI.Sport.Data;
using SportAPI.Sport.Seeders;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SportAPI.IntegrationTests.ControllerTests
{
  public abstract class BaseControllerTest
  {
    private readonly IHostBuilder _hostBuilder;
    protected IHost Application;
    protected HttpClient Client;

    protected BaseControllerTest()
    {
      _hostBuilder = Host
        .CreateDefaultBuilder()
        .ConfigureAppConfiguration(config =>
        {
          config.AddInMemoryCollection(new Dictionary<string, string>() { ["ConnectionStrings:Database"] = "Data Source=DESKTOP-VPKE3ES\\SQLEXPRESS;Initial Catalog=SportAPI;Integrated Security=True" });
          config.AddEnvironmentVariables();
        })
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }


    [OneTimeSetUp]
    public void StartApplication()
    {
      Application = _hostBuilder.Start();
    }

    [OneTimeTearDown]
    public void StopApplication()
    {
      Application.Dispose();
    }

    [SetUp]
    public void EnsureSeedData()
    {
      using var scope = Application.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<SportDbContext>();
      var seeder = new SportClubSeeder(context);

      seeder.Seed();
    }
  }
}
