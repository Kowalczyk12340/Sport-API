using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class CoachService : ICoachService
  {
    public Task<int> Create(CoachDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CoachDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CoachDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, CoachDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
