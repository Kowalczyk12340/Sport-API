using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class SportDisciplineService : ISportDisciplineService
  {
    public Task<int> Create(SportDisciplineDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<SportDisciplineDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<SportDisciplineDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, SportDisciplineDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
