using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class RegisterUserDto : IMapFrom<User>
  {
    public string Login { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public long RoleId { get; set; }
  }
}
