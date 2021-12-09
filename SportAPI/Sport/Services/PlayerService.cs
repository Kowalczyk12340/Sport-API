using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Enums;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class PlayerService : IPlayerService
  {
    public Task<long> Create(PlayerDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<PlayerDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<PlayerDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, PlayerDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
