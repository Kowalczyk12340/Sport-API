using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class SportClubDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool HasOwnStadium { get; set; }
    public string ContactEmail { get; set; }
    public string ContactNumber { get; set; }
    public int AddressId { get; set; }
    public int UserId { get; set; }
    public virtual Address Address { get; set; }
    public virtual UserDto User { get; set; }
    public virtual List<PlayerDto> Players { get; set; }
    public virtual List<TrainingDto> Trainings { get; set; }
    public virtual List<MatchDto> Matches { get; set; }
    public virtual List<CoachDto> Coaches { get; set; }
  }
}
