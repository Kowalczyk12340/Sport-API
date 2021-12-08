using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ISportClubService
  {
    Task<SportClubDto> GetById(int id);
    Task<IEnumerable<SportClubDto>> GetAll();
    Task<int> Create(SportClubDto dto);
    Task Delete(int id);
    Task Update(int id, SportClubDto dto);
  }
}
