using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
using SportAPI.Sport.Exceptions;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class RoleService : IRoleService 
  {
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<RoleService> _logger;

    public RoleService(SportDbContext dbContext, IMapper mapper, ILogger<RoleService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }
    public async Task<long> Create(CreateRoleDto dto)
    {
      _logger.LogInformation("Create new role");
      var role = _mapper.Map<Role>(dto);
      await _dbContext.Roles.AddAsync(role);
      await _dbContext.SaveChangesAsync();
      return role.Id;
    }

    public async Task Delete(long id)
    {
      _logger.LogWarning($"It will be deleted role with id: {id}");

      var role = await _dbContext
        .Roles
        .FirstOrDefaultAsync(x => x.Id == id);

      if (role is null)
      {
        throw new NotFoundException("Role not found");
      }

      _dbContext.Roles.Remove(role);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<RoleDto>> GetAll()
    {
      _logger.LogInformation("Display all the roles available in the database");
      var roles = await _dbContext
        .Roles
        .ToListAsync();

      var roleDtos = _mapper.Map<List<RoleDto>>(roles);
      return roleDtos;
    }

    public async Task<RoleDto> GetById(long id)
    {
      _logger.LogInformation($"Display role with id: {id}");
      var role = await _dbContext
        .Roles
        .FirstOrDefaultAsync(x => x.Id == id);

      if (role is null)
      {
        throw new NotFoundException("Role not found");
      }

      var result = _mapper.Map<RoleDto>(role);
      return result;
    }

    public async Task Update(long id, UpdateRoleDto dto)
    {
      _logger.LogInformation($"Edit role with id: {id}");
      var role = await _dbContext
        .Roles
        .FirstOrDefaultAsync(x => x.Id == id);

      if (role is null)
      {
        throw new NotFoundException("Role not found");
      }

      role.RoleName = dto.RoleName;
      await _dbContext.SaveChangesAsync();
    }
  }
}
