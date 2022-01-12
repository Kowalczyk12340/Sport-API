using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace SportAPI.IntegrationTests
{
    public class StartupTest
    {
        private readonly List<Type> _controllerTypes;
        private readonly WebApplicationFactory<Startup> _factory;

        public StartupTest(WebApplicationFactory<Startup> factory)
        {
            _controllerTypes = typeof(Startup)
                .Assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ControllerBase)))
                .ToList();

            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    _controllerTypes.ForEach(c => services.AddScoped(c));
                });
            });
        }

        [Test]
        public void ConfigureServicesForControllersRegisterAllDependencies()
        {
            //Arrange
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            //Act
            //Assert
            _controllerTypes.ForEach(t =>
            {
                var controller = scope.ServiceProvider.GetService(t);
                controller.Should().NotBeNull();
            });
        }
    }
}