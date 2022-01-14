using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class CoachCourse
  {
    public long Id { get; set; }
    public long CoachId { get; set; }
    public virtual Coach Coach { get; set; }
    public long CourseId { get; set; }
    public virtual Course Course { get; set; }
  }
}
