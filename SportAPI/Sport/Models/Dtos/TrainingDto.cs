using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class TrainingDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime TimeOfTraining { get; set; }
    public int SportClubId { get; set; }
    public virtual SportClubDto SportClub { get; set; }
  }
}
