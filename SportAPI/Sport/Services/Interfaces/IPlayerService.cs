using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IPlayerService
  {
    Task<PlayerDto> GetById(long id);
    Task<IEnumerable<PlayerDto>> GetAll();
    Task<long> Create(CreatePlayerDto dto);
    Task Delete(long id);
    Task Update(long id, UpdatePlayerDto dto);
  }
}
