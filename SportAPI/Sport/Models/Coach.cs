using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Coach : DomainEntity
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Cash { get; set; }
    public long SportClubId { get; set; }
    public virtual SportClub SportClub { get; set; }
    public List<CoachCourse> CoachCourses { get; set; }
  }
}
