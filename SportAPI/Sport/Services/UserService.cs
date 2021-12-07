using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class UserService : IUserService
  {
    public Task<int> Create(UserDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<UserDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, UserDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
