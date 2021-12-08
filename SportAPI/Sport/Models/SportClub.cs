using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class SportClub : DomainEntity
  {
    public long Id { get; set; }
    public string SportClubName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool HasOwnStadium { get; set; }
    public string ContactEmail { get; set; }
    public string ContactNumber { get; set; }
    public long AddressId { get; set; }
    public long UserId { get; set; }
    public virtual Address Address { get; set; }
    public virtual User User { get; set; }
    public virtual List<Player> Players { get; set; }
    public virtual List<Training> Trainings { get; set; }
    public virtual List<Match> Matches { get; set; }
    public virtual List<Coach> Coaches { get; set; }
  }
}
