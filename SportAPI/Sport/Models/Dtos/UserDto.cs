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
    public bool? IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Login { get; set; }
    public string RoleName { get; set; }
    public string Password { get; set; }
    public string Nationality { get; set; }

    public string GetExportObject()
    {
      return $"{Id};{FirstName};{LastName};{IsActive};{DateOfBirth}{Login};{Nationality};{RoleName}";
    }
  }
}