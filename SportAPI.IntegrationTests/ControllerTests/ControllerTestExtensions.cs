using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.IntegrationTests.ControllerTests
{
    public static class ControllerTestExtensions
    {
        public static T WithIdentity<T>(this T controller, string nameIdentifier, string firstname, 
            string lastname, string roleName, string nationality, string login, DateTime dateOfBirth, string password) where T : ControllerBase
        {
            controller.EnsureHttpContext();

            var principal = new ClaimsPrincipal(new ClaimsIdentity(
            new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim(ClaimTypes.Name, $"{firstname}"),
                new Claim(ClaimTypes.Role, $"{roleName}"),
                new Claim(ClaimTypes.Country, $"{nationality}"),
                new Claim(ClaimTypes.Email, $"{login}"),
                new Claim(ClaimTypes.Surname, $"{lastname}"),
                new Claim(ClaimTypes.DateOfBirth, $"{dateOfBirth}"),
                new Claim(ClaimTypes.Authentication, $"{password}")
            }, "TestAuthentication"));


            controller.ControllerContext.HttpContext.User = principal;

            return controller;
        }

        public static T WithAnonymousIdentity<T>(this T controller) where T : ControllerBase
        {
            controller.EnsureHttpContext();

            var principal = new ClaimsPrincipal(new ClaimsIdentity());

            controller.ControllerContext.HttpContext.User = principal;

            return controller;
        }

        private static T EnsureHttpContext<T>(this T controller) where T : ControllerBase
        {
            if (controller.ControllerContext == null)
            {
                controller.ControllerContext = new ControllerContext();
            }

            if (controller.ControllerContext.HttpContext == null)
            {
                controller.ControllerContext.HttpContext = new DefaultHttpContext();
            }

            return controller;
        }
    }
}
