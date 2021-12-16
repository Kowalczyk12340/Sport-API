using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
  public class UserService : IUserService
  {
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(SportDbContext dbContext, IMapper mapper, ILogger<UserService> logger, IPasswordHasher<User> passwordHasher)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
      _passwordHasher = passwordHasher;
    }

    public async Task Delete(long id)
    {
      _logger.LogWarning($"It will be deleted user with id: {id}");

      var user = await _dbContext
        .Users
        .FirstOrDefaultAsync(x => x.Id == id);

      if(user is null)
      {
        throw new NotFoundException("User not found");
      }

      _dbContext.Users.Remove(user);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
      _logger.LogInformation("Display all the users availbale in the database");
      var users = await _dbContext
        .Users
        .ToListAsync();

      var userDtos = _mapper.Map<List<UserDto>>(users);
      return userDtos;
    }

    public async Task<UserDto> GetById(long id)
    {
      _logger.LogInformation($"Display user with id: {id}");
      var user = await _dbContext
        .Users
        .FirstOrDefaultAsync(x => x.Id == id);

      if(user is null)
      {
        throw new NotFoundException("User not found");
      }

      var result = _mapper.Map<UserDto>(user);
      return result;
    }

    public async Task RegisterUser(RegisterUserDto dto)
    {
      
      var newUser = new User()
      {
        Login = dto.Login,
        DateOfBirth = dto.DateOfBirth,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        RoleId = dto.RoleId,
        IsActive = dto.IsActive
      };

      var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

      newUser.Password = hashedPassword;

      await _dbContext.Users.AddAsync(newUser);
      await _dbContext.SaveChangesAsync();
    }

    public async Task Update(long id, UpdateUserDto dto)
    {
      _logger.LogInformation($"Edit user with id: {id}");
      var user = await _dbContext
        .Users
        .FirstOrDefaultAsync(x => x.Id == id);

      if(user is null)
      {
        throw new NotFoundException("User not found");
      }

      user.FirstName = dto.FirstName;
      user.LastName = dto.LastName;
      user.Login = dto.Login;
      var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
      user.Password = hashedPassword;
      user.DateOfBirth = dto?.DateOfBirth;
      user.IsActive = dto.IsActive;
      await _dbContext.SaveChangesAsync();
    }
  }
}