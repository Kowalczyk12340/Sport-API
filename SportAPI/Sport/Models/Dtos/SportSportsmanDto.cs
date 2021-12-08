using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class SportSportsmanDto
  {
    public int SportId { get; set; }
    public int SportsmanId { get; set; }
    public int Amount { get; set; }
    public double Worth { get; set; }
  }
}