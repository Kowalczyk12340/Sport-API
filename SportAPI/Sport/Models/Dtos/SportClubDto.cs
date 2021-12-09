﻿using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class SportClubDto : IMapFrom<Address>
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool HasOwnStadium { get; set; }
    public string ContactEmail { get; set; }
    public string ContactNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public List<PlayerDto> Players { get; set; }
    public List<TrainingDto> Trainings { get; set; }
    public List<MatchDto> Matches { get; set; }
    public List<CoachDto> Coaches { get; set; }
  }
}
