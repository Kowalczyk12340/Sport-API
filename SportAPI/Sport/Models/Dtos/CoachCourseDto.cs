using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class CoachCourseDto
  {
    public long Id { get; set; }
    public long CoachId { get; set; }
    public CoachDto Coach { get; set; }
    public long CourseId { get; set; }
    public CourseDto Course { get; set; }
  }
}
