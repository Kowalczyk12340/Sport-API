using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class DepartmentService : IDepartmentService
  {
    public Task<int> Create(DepartmentDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<DepartmentDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<DepartmentDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, DepartmentDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
