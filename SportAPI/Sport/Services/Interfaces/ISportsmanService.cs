using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ISportsmanService
  {
    Task<SportsmanDto> GetById(int id);
    Task<IEnumerable<SportsmanDto>> GetAll();
    Task<int> Create(SportsmanDto dto);
    Task Delete(int id);
    Task Update(int id, SportsmanDto dto);
  }
}
