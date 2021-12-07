using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ISportDisciplineService
  {
    Task<SportDisciplineDto> GetById(int id);
    Task<IEnumerable<SportDisciplineDto>> GetAll();
    Task<int> Create(SportDisciplineDto dto);
    Task Delete(int id);
    Task Update(int id, SportDisciplineDto dto);
  }
}
