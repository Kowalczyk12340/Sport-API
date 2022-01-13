using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos.Update
{
  public class UpdateUserDto : IMapFrom<User>
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Login { get; set; }
    public string Nationality { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
  }
}
