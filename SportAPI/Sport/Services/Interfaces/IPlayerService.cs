using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IPlayerService
  {
    Task<PlayerDto> GetById(int id);
    Task<IEnumerable<PlayerDto>> GetAll();
    Task<int> Create(PlayerDto dto);
    Task Delete(int id);
    Task Update(int id, PlayerDto dto);
  }
}
