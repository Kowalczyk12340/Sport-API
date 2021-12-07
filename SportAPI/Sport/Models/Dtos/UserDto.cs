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
    public string CardId { get; set; }
    public bool IsActive { get; set; }
    public string Login { get; set; }
    public int Password { get; set; }
  }
}
