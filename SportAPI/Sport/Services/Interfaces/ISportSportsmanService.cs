using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ISportSportsmanService
  {
    Task<SportSportsmanDto> GetById(int id);
    Task<IEnumerable<SportSportsmanDto>> GetAll();
    Task<int> Create(SportSportsmanDto dto);
    Task Delete(int id);
    Task Update(int id, SportSportsmanDto dto);
  }
}