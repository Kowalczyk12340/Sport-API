using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Training : DomainEntity
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime TimeOfTraining { get; set; }
    public long SportClubId { get; set; }
    public virtual SportClub SportClub { get; set; }
  }
}
