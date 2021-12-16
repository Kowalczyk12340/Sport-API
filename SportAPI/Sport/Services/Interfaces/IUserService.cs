using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
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
    Task Delete(long id);
    Task Update(long id, UpdateUserDto dto);
    Task RegisterUser(RegisterUserDto dto);
    Task<string> GenerateJwt(LoginDto dto);
  }
}
