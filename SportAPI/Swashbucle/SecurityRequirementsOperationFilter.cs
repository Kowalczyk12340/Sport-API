using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using SportAPI.Sport.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SportAPI.Swashbucle
{
  public class SecurityRequirementsOperationFilter : IOperationFilter
  {
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      var authAttribute = context.MethodInfo.GetCustomAttributes(true).OfType<SportAPIAuth>().FirstOrDefault();

      if (!(authAttribute is null))
      {
        operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

        operation.Security = new List<OpenApiSecurityRequirement>
        {
          new OpenApiSecurityRequirement
          {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Token"
                }
              }, Array.Empty<string>()
            }
          }
        };
      }
    }
  }
}