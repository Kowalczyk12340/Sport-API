using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos.Update
{
  public class UpdateSportClubDto : IMapFrom<SportClub>
  {
    public string SportClubName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool HasOwnStadium { get; set; }
    public string ContactEmail { get; set; }
    public string ContactNumber { get; set; }
  }
}
