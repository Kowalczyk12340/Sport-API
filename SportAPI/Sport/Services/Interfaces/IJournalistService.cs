using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IJournalistService
  {
    Task<JournalistDto> GetById(int id);
    Task<IEnumerable<JournalistDto>> GetAll();
    Task<int> Create(JournalistDto dto);
    Task Delete(int id);
    Task Update(int id, JournalistDto dto);
  }
}