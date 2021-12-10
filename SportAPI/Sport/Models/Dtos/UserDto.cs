using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class UserDto : IMapFrom<User>
  {
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string SportClubName { get; set; }
    public string Name { get; set; }
  }
}
