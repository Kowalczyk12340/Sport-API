using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IRoleService
  {
    Task<RoleDto> GetById(long id);
    Task<IEnumerable<RoleDto>> GetAll();
    Task<long> Create(CreateRoleDto dto);
    Task Delete(long id);
    Task Update(long id, UpdateRoleDto dto);
  }
}
