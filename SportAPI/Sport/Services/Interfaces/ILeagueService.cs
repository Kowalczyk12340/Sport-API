using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ILeagueService
  {
    Task<LeagueDto> GetById(long id);
    Task<IEnumerable<LeagueDto>> GetAll();
    Task<long> Create(CreateLeagueDto dto);
    Task Delete(long id);
    Task Update(long id, UpdateLeagueDto dto);
  }
}
