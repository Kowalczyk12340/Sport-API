using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class JournalistService : IJournalistService
  {
    public Task<int> Create(JournalistDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<JournalistDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<JournalistDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, JournalistDto dto)
    {
      throw new NotImplementedException();
    }
  }
}