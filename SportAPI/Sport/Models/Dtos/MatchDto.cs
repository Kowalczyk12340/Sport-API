using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class MatchDto
  {
    public int Id { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public bool InHouse { get; set; }
    public DateTime DateOfMatch { get; set; }
    public int SportClubId { get; set; }
    public virtual SportClubDto SportClub { get; set; }
  }
}
