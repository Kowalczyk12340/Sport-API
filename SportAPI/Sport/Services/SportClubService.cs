using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class SportClubService : ISportClubService
  {
    public Task<int> Create(SportClubDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<SportClubDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<SportClubDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, SportClubDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
