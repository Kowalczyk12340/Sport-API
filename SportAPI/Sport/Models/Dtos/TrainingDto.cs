using SportAPI.Sport.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class TrainingDto : IMapFrom<Training>
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime TimeOfTraining { get; set; } 
    public long SportClubId { get; set; }

        public string GetExportObject()
        {
            return $"{Id};{Name};{Description};{TimeOfTraining.ToString()};{SportClubId}";
        }
    }
}
