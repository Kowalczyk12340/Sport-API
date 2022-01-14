using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class SportClubDto : IMapFrom<SportClub>
  {
    public long Id { get; set; }
    public string SportClubName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool? HasOwnStadium { get; set; }
    public string ContactEmail { get; set; }
    public string ContactNumber { get; set; }
    public long AddressId { get; set; }
    public AddressDto Address { get; set; }
    public List<PlayerDto> Players { get; set; }
    public List<TrainingDto> Trainings { get; set; }
    public List<MatchDto> Matches { get; set; }
    public List<CoachDto> Coaches { get; set; }

    public string GetExportObject()
    {
      return $"{Id};{SportClubName};{Description};{Category};{HasOwnStadium};{Category};{Address.City};{Address.Street};{Address.PostalCode};{Trainings.Count};{Coaches.Count};{Players.Count};{Coaches.Count}";
    }
  }
}
