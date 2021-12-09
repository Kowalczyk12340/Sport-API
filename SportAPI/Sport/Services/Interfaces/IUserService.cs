using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> GetById(long id);
    Task<IEnumerable<UserDto>> GetAll();
    Task<long> Create(UserDto dto);
    Task Delete(long id);
    Task Update(long id, UserDto dto);
  }
}
