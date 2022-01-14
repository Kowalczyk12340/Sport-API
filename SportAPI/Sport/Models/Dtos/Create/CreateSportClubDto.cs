using SportAPI.Sport.Models.Enums;
using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos.Create
{
  public class CreateSportClubDto : IMapFrom<SportClub>
  {
    public string SportClubName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool? HasOwnStadium { get; set; }
    public string ContactEmail { get; set; }
    public string ContactNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public long LeagueId { get; set; }
  }
}
