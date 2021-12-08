using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ICoachService
  {
    Task<CoachDto> GetById(int id);
    Task<IEnumerable<CoachDto>> GetAll();
    Task<int> Create(CoachDto dto);
    Task Delete(int id);
    Task Update(int id, CoachDto dto);
  }
}
