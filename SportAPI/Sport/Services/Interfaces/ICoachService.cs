using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ICoachService
  {
    Task<CoachDto> GetById(long id);
    Task<IEnumerable<CoachDto>> GetAll();
    Task<long> Create(CoachDto dto);
    Task Delete(long id);
    Task Update(long id, CoachDto dto);
  }
}
