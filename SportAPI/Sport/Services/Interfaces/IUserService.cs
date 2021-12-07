using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> GetById(int id);
    Task<IEnumerable<UserDto>> GetAll();
    Task<int> Create(UserDto dto);
    Task Delete(int id);
    Task Update(int id, UserDto dto);
  }
}
