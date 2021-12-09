using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NodaTime;
using SportAPI.Middlewares;
using SportAPI.Sport.Data;
using SportAPI.Sport.Seeders;
using SportAPI.Sport.Services;
using SportAPI.Sport.Services.Interfaces;
using SportAPI.Sport.UserMiddlewares;
using SportAPI.Swashbucle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SportAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers()
        .AddFluentValidation(fv =>
        {
          fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
        });

      services.AddLogging();
      services.AddSwaggerGen(options =>
      {
        options.AddSecurityDefinition("Token", new OpenApiSecurityScheme
        {
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey,
          Scheme = "basic",
          In = ParameterLocation.Header,
          Description = "Authorize using a Guid token generated by me.<br /><br />Usage: <b>Token [token]</b><br />Example: Token 1ca77ad5-9042-4263-82d9-b2ca0bea6d1c"
        });
        options.AddSecurityDefinition("DBHash", new OpenApiSecurityScheme
        {
          Name = "DBHash",
          Type = SecuritySchemeType.ApiKey,
          Scheme = "basic",
          In = ParameterLocation.Header,
          Description = "Authorize using your login and generated MD5 hash.<br /><br />Usage: <b>[login] [hash]</b><br />Example: login1 b872ac091e82f9d0b3f53b299212ce95"
        });
        options.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Sport API",
          Description = "An API for managing and doing CRUD operations for Sport API"
        });
        
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        options.IncludeXmlComments(xmlPath);
        options.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
        options.OperationFilter<SecurityRequirementsOperationFilter>();
      });
      services.AddSingleton<IClock, SystemClock>(x => SystemClock.Instance);
      services.AddSportDbContext(Configuration.GetConnectionString("Database"));
      services.AddMediatR(typeof(Startup));
      //services.AddAutoMapper(typeof(Startup));
      services.AddScoped<SportClubSeeder>();
      services.AddAutoMapper(this.GetType().Assembly);
      services.AddScoped<IPlayerService, PlayerService>();
      services.AddScoped<IAddressService, AddressService>();
      services.AddScoped<ISportClubService, SportClubService>();
      services.AddScoped<ITrainingService, TrainingService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IMatchService, MatchService>();
      services.AddScoped<ICoachService, CoachService>();
      services.AddScoped<ErrorHandlingMiddleware>();
      services.AddScoped<RequestTimeMiddleware>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SportClubSeeder seed)
    {
      seed.Seed();
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportAPI v1"));
      }

      app.UseCors(policy => policy.SetIsOriginAllowed(x => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
      app.UseMiddleware<SportDbAuthMiddleware>();
      app.UseMiddleware<SportTokenAuthMiddleware>();
      app.UseMiddleware<ErrorHandlingMiddleware>();
      app.UseMiddleware<RequestTimeMiddleware>();
      app.UseMiddleware<RequestResponseLoggingMiddleware>();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
