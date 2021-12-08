using SportAPI.Sport.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class SportsmanDto
  {
    public int CategorySportsmanId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public string Discipline { get; set; }
    public BetterFoot Foot { get; set; }
    public string Description { get; set; }
    public virtual SportDisciplineDto Sport { get; set; }
  }
}
