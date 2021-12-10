using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos.Update
{
  public class UpdateCoachDto
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Cash { get; set; }
  }
}
