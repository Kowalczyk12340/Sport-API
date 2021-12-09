using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IMatchService
  {
    Task<MatchDto> GetById(long id);
    Task<IEnumerable<MatchDto>> GetAll();
    Task<long> Create(MatchDto dto);
    Task Delete(long id);
    Task Update(long id, MatchDto dto);
  }
}
