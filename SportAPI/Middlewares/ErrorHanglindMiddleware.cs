﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Middlewares
{
  public class ErrorHandlingMiddleware : IMiddleware
  {
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
      _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      try
      {
        await next.Invoke(context);
      }
      catch (NotFoundException ex)
      {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync(ex.Message);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, ex.Message);

        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Something went wrong");
      }
    }
  }
}

