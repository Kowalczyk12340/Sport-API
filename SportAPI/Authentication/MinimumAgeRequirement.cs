using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Authentication
{
  public class MinimumAgeRequirement : IAuthorizationRequirement
  {
    public int MinimumAge { get; }

    public MinimumAgeRequirement(int minimumAge)
    {
      MinimumAge = minimumAge;
    }
  }
}
