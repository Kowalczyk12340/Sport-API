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
    public Task<int> Create(PlayerDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<PlayerDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<PlayerDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, PlayerDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
