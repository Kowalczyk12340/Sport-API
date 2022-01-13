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
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class LeagueService : ILeagueService
  {
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<LeagueService> _logger;

    public LeagueService(SportDbContext dbContext, IMapper mapper, ILogger<LeagueService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }
    public async Task<long> Create(CreateLeagueDto dto)
    {
      _logger.LogInformation("Creating a new league");
      var league = _mapper.Map<League>(dto);
      await _dbContext.Leagues.AddAsync(league);
      await _dbContext.SaveChangesAsync();
      return league.Id;
    }

    public async Task Delete(long id)
    {
      _logger.LogWarning($"League with id: {id} DELETE ACTION INVOKED");

      var league = await _dbContext
        .Leagues
        .Include(u => u.SportClubs)
        .FirstOrDefaultAsync(x => x.Id == id);

      if (league is null)
      {
        throw new NotFoundException("League not found");
      }

      _dbContext.Leagues.Remove(league);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<LeagueDto>> GetAll()
    {
      _logger.LogInformation("Get all the leagues with the database");
      var leagues = await _dbContext
        .Leagues
        .Include(x => x.SportClubs)
        .ToListAsync();

      var leagueDtos = _mapper.Map<List<LeagueDto>>(leagues);
      return leagueDtos;
    }

    public async Task<LeagueDto> GetById(long id)
    {
      _logger.LogInformation("Getting the league by chosen id");
      var league = await _dbContext
        .Leagues
        .Include(x => x.SportClubs)
        .FirstOrDefaultAsync(x => x.Id == id);

      if (league is null)
      {
        throw new NotFoundException("League not found");
      }

      var result = _mapper.Map<LeagueDto>(league);
      return result;
    }

    public string SaveToCsv(IEnumerable<LeagueDto> components)
    {
      var headers = "Id;Name;Nationality;IsHigh;CountChampions;CountEurope;CountConference;CountDown;CountClubs";

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

    public async Task Update(long id, UpdateLeagueDto dto)
    {
      _logger.LogInformation($"Updating the league by {id}");

      var league = await _dbContext
        .Leagues
        .Include(u => u.SportClubs)
        .FirstOrDefaultAsync(x => x.Id == id);

      if (league is null)
      {
        throw new NotFoundException("League not found");
      }

      league.Name = dto.Name;
      league.IsHigh = dto.IsHigh;
      league.Nationality = dto.Nationality;
      league.CountForChampionsLeague = dto.CountForChampionsLeague;
      league.CountForEuropeLeague = dto.CountForEuropeLeague;
      league.CountForConferenceLeague = dto.CountForConferenceLeague;
      league.CountForDownLeague = dto.CountForDownLeague;
    }
  }
}