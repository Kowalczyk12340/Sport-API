using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Journalist : DomainEntity
  {
    public int JournalistId { get; set; }
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Position { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Seniority { get; set; }
    public IEnumerable<Information> Informations { get; set; }
  }
}
