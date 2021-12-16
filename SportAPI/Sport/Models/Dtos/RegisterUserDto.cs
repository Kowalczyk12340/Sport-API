using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class RegisterUserDto
  {
    [Required]
    public string Login { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public long RoleId { get; set; }
  }
}
