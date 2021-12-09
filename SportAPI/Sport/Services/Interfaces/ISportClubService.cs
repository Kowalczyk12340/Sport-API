using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ISportClubService
  {
    Task<SportClubDto> GetById(long id);
    Task<IEnumerable<SportClubDto>> GetAll();
    Task<long> Create(SportClubDto dto);
    Task Delete(long id);
    Task Update(long id, SportClubDto dto);
  }
}
