using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IDepartmentService
  {
    Task<DepartmentDto> GetById(int id);
    Task<IEnumerable<DepartmentDto>> GetAll();
    Task<int> Create(DepartmentDto dto);
    Task Delete(int id);
    Task Update(int id, DepartmentDto dto);
  }
}
