using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IMatchService
  {
    Task<MatchDto> GetById(int id);
    Task<IEnumerable<MatchDto>> GetAll();
    Task<int> Create(MatchDto dto);
    Task Delete(int id);
    Task Update(int id, MatchDto dto);
  }
}
