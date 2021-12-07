using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Enums;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class SportsmanService : ISportsmanService
  {
    public Task<int> Create(SportsmanDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<SportsmanDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<SportsmanDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, SportsmanDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
