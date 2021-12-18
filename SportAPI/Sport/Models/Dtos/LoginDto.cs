using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class LoginDto : IMapFrom<User>
  {
    public string Login { get; set; }
    public string Password { get; set; }
  }
}
