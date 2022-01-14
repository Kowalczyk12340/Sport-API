using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models
{
  public class Course
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<CoachCourse> CoachCourses { get; set; }
  }
}
