using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
using SportAPI.Sport.Exceptions;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using SportAPI.Sport.Models.Enums;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class PlayerService : IPlayerService
  {
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<PlayerService> _logger;

    public PlayerService(SportDbContext dbContext, IMapper mapper, ILogger<PlayerService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }
    public async Task<long> Create(CreatePlayerDto dto)
    {
      _logger.LogInformation("Create a new player");
      var player = _mapper.Map<Player>(dto);
      await _dbContext.Players.AddAsync(player);
      await _dbContext.SaveChangesAsync();
      return player.Id;
    }

    public async Task Delete(long id)
    {
      _logger.LogInformation($"It will be deleted player with id: {id}");

      var player = await _dbContext
        .Players
        .FirstOrDefaultAsync(x => x.Id == id);

      if(player is null)
      {
        throw new NotFoundException("Player not found");
      }

      _dbContext.Players.Remove(player);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<PlayerDto>> GetAll()
    {
      _logger.LogInformation("Display all the players");
      var players = await _dbContext
        .Players
        .ToListAsync();

      var playerDtos = _mapper.Map<List<PlayerDto>>(players);
      return playerDtos;
    }

    public async Task<PlayerDto> GetById(long id)
    {
      _logger.LogInformation($"Display the player with chosen {id}");
      
      var player = await _dbContext
        .Players
        .FirstOrDefaultAsync(x => x.Id == id);

      if(player is null)
      {
        throw new NotFoundException("Player not found");
      }

      var result = _mapper.Map<PlayerDto>(player);
      return result;
    }

    public async Task Update(long id, UpdatePlayerDto dto)
    {
      _logger.LogInformation($"Edit player with {id}");
      var player = await _dbContext
        .Players
        .FirstOrDefaultAsync(x => x.Id == id);

      if(player is null)
      {
        throw new NotFoundException("Player not found");
      }

      player.Name = dto.Name;
      player.Surname = dto.Surname;
      player.Pesel = dto.Pesel;
      player.Nationality = dto.Nationality;
      player.PhoneNumber = dto.PhoneNumber;
      player.Position = dto.Position;
      player.EmailAddress = dto.EmailAddress;
    }
  }
}
