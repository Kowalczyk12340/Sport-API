using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
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
    Task<long> Create(CreateCoachDto dto);
    string SaveToCsv(IEnumerable<CoachDto> components);
    Task Delete(long id);
    Task Update(long id, UpdateCoachDto dto);
  }
}
