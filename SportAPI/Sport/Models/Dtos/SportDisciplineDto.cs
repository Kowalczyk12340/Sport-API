using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class SportDisciplineDto
  {
    public int SportId { get; set; }
    public int InformationId { get; set; }
    public int CategorySportId { get; set; }
    public string SportName { get; set; }
    public string Description { get; set; }
    public virtual SportsmanDto Sportsman { get; set; }
  }
}
