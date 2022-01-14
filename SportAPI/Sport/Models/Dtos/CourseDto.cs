using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Models.Dtos
{
  public class CourseDto
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<CoachCourseDto> CoachCourses { get; set; }

    public string GetExportObject()
    {
      return $"{Id};{Name};{Description};{CoachCourses.Count}";
    }
  }
}
