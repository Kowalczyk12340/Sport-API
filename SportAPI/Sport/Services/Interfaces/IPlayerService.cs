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
    Task<PlayerDto> GetById(long sportClubId, long id);
    Task<IEnumerable<PlayerDto>> GetAll(long sportClubId);
    Task<long> Create(long sportClubId, CreatePlayerDto dto);
    string SaveToCsv(IEnumerable<PlayerDto> components);
    Task DeleteAll(long sportClubId);
    Task Delete(long sportClubId, long id);
    Task Update(long sportClubId, long id, UpdatePlayerDto dto);
  }
}
