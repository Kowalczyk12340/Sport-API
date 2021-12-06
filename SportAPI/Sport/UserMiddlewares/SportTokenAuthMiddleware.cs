﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportAPI.Sport.Data;
using System;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.Sport.UserMiddlewares
{
  // ReSharper disable once ClassNeverInstantiated.Global
  /// <summary>
  /// Middleware responsible for Token authorization method.
  /// This method uses a GUID token generated by developers.
  /// Data has to be passed in Authorization header.
  /// Example: Token 75e0d16c-c920-47c2-b701-aa140105085d
  /// </summary>
  public class SportTokenAuthMiddleware
  {
    private readonly RequestDelegate _next;

    public SportTokenAuthMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      var sportContext = context.RequestServices.GetRequiredService<SportDbContext>();

      if (context.Request.Headers.TryGetValue("Authorization", out var sportAuthorizationHeader))
      {
        var values = sportAuthorizationHeader.FirstOrDefault()?.Split();
        if (!(values is null) && values.Count() == 2)
        {
          var authorizationType = values[0];
          var tokenValue = values[1];
          if (authorizationType == "Token" && Guid.TryParse(tokenValue, out var token))
          {
            var user = await sportContext.AuthTokens.FirstOrDefaultAsync(x => x.Id == token);
            if (!(user is null))
            {
              context.User.AddIdentity(new GenericIdentity(user.Name, "Token"));
            }
          }
        }
      }
      await _next.Invoke(context);
    }
  }
}