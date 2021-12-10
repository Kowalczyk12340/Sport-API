using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos.Create
{
  public class CreateTrainingDto : IMapFrom<Training>
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime TimeOfTraining { get; set; }
  }
}
