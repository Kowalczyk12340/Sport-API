using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Authentication
{
  public class AuthenticationSettings
  {
    public string JwtKey { get; set; }
    public int JwtExpireMinutes { get; set; }
    public string JwtIssuer { get; set; }
  }
}
