using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class User : BaseEntity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Login { get; set; }
    public long RoleId { get; set; }
    public virtual Role Role { get; set; }
    public string Password { get; set; }
    public string Nationality { get; set; }
    public virtual SportClub SportClub { get; set; }
  }
}
