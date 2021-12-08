using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class MatchService : IMatchService
  {
    public Task<int> Create(MatchDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MatchDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<MatchDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, MatchDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
