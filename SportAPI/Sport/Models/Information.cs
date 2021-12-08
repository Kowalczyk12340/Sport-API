using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Information : DomainEntity
  {
    public int InformationId { get; set; }
    public int CustomerId { get; set; }
    public int InformationStatusId { get; set; }
    public int JournalistId { get; set; }
    public string Info { get; set; }
    public int Title { get; set; }
    public string DateOfInfo { get; set; }
    public string Description { get; set; }
    public virtual Journalist Journalist { get; set; }
    public virtual Customer Customer { get; set; }
    public IEnumerable<SportDiscipline> Disciplines { get; set; }
  }
}
