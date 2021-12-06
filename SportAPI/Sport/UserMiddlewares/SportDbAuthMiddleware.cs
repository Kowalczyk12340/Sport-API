using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportAPI.Sport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.Sport.UserMiddlewares
{
  public class SportDbAuthMiddleware
  {
    private readonly RequestDelegate _next;

    public SportDbAuthMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      var sportContext = context.RequestServices.GetRequiredService<SportDbContext>();

      if (context.Request.Headers.TryGetValue("DBHash", out var sportAuthorizationHeader))
      {
        var userLogin = sportAuthorizationHeader.FirstOrDefault()?.Split()[0];
        if (!string.IsNullOrEmpty(userLogin))
        {
          var user = await sportContext.Users.FirstOrDefaultAsync(x => x.Login == userLogin && x.IsActive);

          if (user != null)
          {
            var userIdsAndLastNameBytes = Encoding.UTF8.GetBytes($"{user.Id}{user.LastName}");
            var userDbHash = CreateHash(userIdsAndLastNameBytes);
            var headerHash = sportAuthorizationHeader.FirstOrDefault().Split()[1];

            if (userDbHash == headerHash)
            {
              context.User.AddIdentity(new GenericIdentity(user.Id.ToString(), "DBHash"));
            }
          }
        }
      }

      await _next.Invoke(context);
    }

    /// <summary>
    /// Generates hash from given string using MD5 algorithm.
    /// </summary>
    /// <param name="input">String to generate the hash from</param>
    /// <returns></returns>
    private string CreateHash(byte[] input)
    {
      using var provider = System.Security.Cryptography.MD5.Create();
      var builder = new StringBuilder();

      provider.ComputeHash(input).ToList().ForEach(result =>
      {
        builder.Append(result.ToString("x2").ToLower());
      });

      return builder.ToString();
    }
  }
}
