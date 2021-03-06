using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace SportAPI.Sport.Attributes
{
  public class SportAPIAuth : Attribute, IAsyncActionFilter
  {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      var identity = context.HttpContext.User.Identities.FirstOrDefault(x => x.AuthenticationType == "Token");

      if (identity is null)
      {
        context.Result = new UnauthorizedResult();
        return;
      }
      await next();
    }
  }
}
