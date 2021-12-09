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
    public Task<long> Create(CoachDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CoachDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CoachDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, CoachDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
