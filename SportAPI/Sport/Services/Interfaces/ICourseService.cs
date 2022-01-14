using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ICourseService
  {
    Task<CourseDto> GetById(long id);
    Task<IEnumerable<CourseDto>> GetAll();
    Task<long> Create(CreateCourseDto dto);
    string SaveToCsv(IEnumerable<CourseDto> components);
    Task Delete(long id);
    Task Update(long id, UpdateCourseDto dto);
  }
}
