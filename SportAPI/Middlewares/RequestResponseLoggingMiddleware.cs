using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SportAPI.Middlewares
{
  public class RequestResponseLoggingMiddleware
  {
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
      _next = next;
      _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
      await using var memoryStream = new MemoryStream();
      using var reader = new StreamReader(memoryStream);
      await context.Request.Body.CopyToAsync(memoryStream);
      context.Request.Body = memoryStream;

      await LogRequest(context.Request);

      var originalBodyStream = context.Response.Body;
      await using var responseBodyStream = new MemoryStream();
      context.Response.Body = responseBodyStream;

      var stopwatch = Stopwatch.StartNew();
      await _next(context);
      stopwatch.Stop();

      context.Response.Body.Seek(0, SeekOrigin.Begin);
      await context.Response.Body.CopyToAsync(originalBodyStream);
      await LogResponse(context.Response, stopwatch);
      context.Response.Body = originalBodyStream;
    }

    private async Task LogRequest(HttpRequest request)
    {
      request.Body.Seek(0, SeekOrigin.Begin);
      using var reader = new StreamReader(request.Body, leaveOpen: true);
      var body = await reader.ReadToEndAsync();
      if (string.IsNullOrWhiteSpace(body))
      {
        body = "<no request body>";
      }

      string hostname;
      try
      {
        hostname = (await Dns.GetHostEntryAsync(request.HttpContext.Connection.RemoteIpAddress)).HostName;
      }
      catch (Exception exception)
      {
        var message = exception.Message;
        hostname = "UnknownHost";
      }

      _logger.LogInformation("Request from {RemoteIpAddress}({hostname}): {Method} {Scheme}://{Host}{Path}{QueryString} {Body}",
        request.HttpContext.Connection.RemoteIpAddress, hostname, request.Method, request.Scheme, request.Host, request.Path, request.QueryString, body);

      request.Body.Seek(0, SeekOrigin.Begin);
    }

    private async Task LogResponse(HttpResponse response, Stopwatch stopwatch)
    {
      response.Body.Seek(0, SeekOrigin.Begin);
      using var reader = new StreamReader(response.Body, leaveOpen: true);
      var body = await reader.ReadToEndAsync();
      if (string.IsNullOrWhiteSpace(body))
      {
        body = "<no response body>";
      }
      else if (body.Length > 10000)
      {
        body = "<response body is longer than 10000 characters>";
      }
      _logger.LogInformation("Request handled in {Time} ms with response {Status}: {Body}", stopwatch.ElapsedMilliseconds, response.StatusCode, body);
      response.Body.Seek(0, SeekOrigin.Begin);
    }
  }
}

