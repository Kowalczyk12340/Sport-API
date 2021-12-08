using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class UserDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int InfomationId { get; set; }
    public bool IsActive { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public virtual SportClubDto SportClub { get; set; }
  }
}
