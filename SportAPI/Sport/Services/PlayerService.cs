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
using System.Text;
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

    public async Task<long> Create(long sportClubId, CreatePlayerDto dto)
    {
      var sportClub = await GetSportClubById(sportClubId);
      var playerEntity = _mapper.Map<Player>(dto);
      _logger.LogInformation("Create a new player");
      playerEntity.SportClubId = sportClubId;
      await _dbContext.Players.AddAsync(playerEntity);
      await _dbContext.SaveChangesAsync();
      return playerEntity.Id;
    }

    public async Task DeleteAll(long sportClubId)
    {
      var sportClub = await GetSportClubById(sportClubId);

      _dbContext.RemoveRange(sportClub.Players);
      await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(long sportClubId, long id)
    {
      _logger.LogInformation($"It will be deleted player with id: {id}");

      var club = await GetSportClubById(sportClubId);

      var player = club.Players
        .FirstOrDefault(x => x.Id == id);

      if (player is null)
      {
        throw new NotFoundException("Player not found");
      }

      _dbContext.Players.Remove(player);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<PlayerDto>> GetAll(long sportClubId)
    {
      _logger.LogInformation("Display all the players");

      var club = await GetSportClubById(sportClubId);

      var players = club.Players.ToList();

      var playerDtos = _mapper.Map<List<PlayerDto>>(players);
      return playerDtos;
    }

    public async Task<PlayerDto> GetById(long sportClubId, long id)
    {
      _logger.LogInformation($"Display the player with chosen {id}");

      var club = await GetSportClubById(sportClubId);

      var player = club
        .Players
        .FirstOrDefault(x => x.Id == id);

      if (player is null)
      {
        throw new NotFoundException("Player not found");
      }

      var result = _mapper.Map<PlayerDto>(player);
      return result;
    }

    public string SaveToCsv(IEnumerable<PlayerDto> components)
    {
      var headers = "Id;Name;Surname;Pesel;PhoneNumber;Nationality;EmailAddress;BetterFoot;Position";

      var csv = new StringBuilder(headers);

      csv.Append(Environment.NewLine);

      foreach (var component in components)
      {
        csv.Append(component.GetExportObject());
        csv.Append(Environment.NewLine);
      }
      csv.Append($"Count: {components.Count()}");
      csv.Append(Environment.NewLine);

      return csv.ToString();
    }

    public async Task Update(long sportClubId, long id, UpdatePlayerDto dto)
    {
      _logger.LogInformation($"Edit player with {id}");
      var club = await GetSportClubById(sportClubId);

      var player = club
        .Players
        .FirstOrDefault(x => x.Id == id);

      if (player is null)
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
      await _dbContext.SaveChangesAsync();
    }

    private async Task<SportClub> GetSportClubById(long sportClubId)
    {
      var sportClub = await _dbContext
          .Clubs
          .Include(r => r.Players)
          .FirstOrDefaultAsync(r => r.Id == sportClubId);

      if (sportClub is null)
        throw new NotFoundException("Sport club not found");

      return sportClub;
    }
  }
}
