using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NodaTime;
using SportAPI.Authentication;
using Newtonsoft.Json.Serialization;
using SportAPI.Middlewares;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Seeders;
using SportAPI.Sport.Services;
using SportAPI.Sport.Services.Interfaces;
using SportAPI.Sport.UserMiddlewares;
using SportAPI.Swashbucle;
using SportAPI.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SportAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("HasNationality", builder => builder.RequireClaim("Nationality"));
                options.AddPolicy("HasDateOfBirth", builder => builder.RequireClaim("DateOfBirth"));
                options.AddPolicy("AtLeast18", builder => builder.AddRequirements(new MinimumAgeRequirement(18)));
            });

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            //services.AddScoped<IAuthorizationHandler, SportClubResourceOperationRequirementHandler>();
            //services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews()
              .AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
              .Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options
              .SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddControllers()
              .AddFluentValidation(fv =>
              {
                  fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            fv.DisableDataAnnotationsValidation = true;
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
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sport API",
                    Description = "An API for managing and doing CRUD operations for Sport API"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
                options.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            //Enable CORS
            services.AddCors(options =>
            {
                var frontendURL = $"http://localhost:3000";
                options.AddPolicy("frontendConnection",builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins(frontendURL);
                        //.WithExposedHeaders(new string[] { "totalAmountOfRecords" });
                });
            });

            services.AddSingleton<IClock, SystemClock>(x => SystemClock.Instance);
            services.AddSportDbContext(Configuration.GetConnectionString("Database"));
            services.AddDbContext<SportDbContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<SportClubSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ISportClubService, SportClubService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddScoped<IValidator<SportClubQuery>, SportClubQueryValidator>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestTimeMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SportClubSeeder seed)
        {
            seed.Seed();
            app.UseResponseCaching();
            app.UseStaticFiles();
            //Enable CORS
            app.UseCors("frontendConnection");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportAPI v1"));
            }

            app.UseMiddleware<SportTokenAuthMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<RequestTimeMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseAuthentication();
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
