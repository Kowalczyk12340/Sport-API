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
  public class MatchService : IMatchService
  {
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<MatchService> _logger;

    public MatchService(SportDbContext dbContext, IMapper mapper, ILogger<MatchService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<long> Create(CreateMatchDto dto)
    {
      _logger.LogInformation("Creating a new match");
      var match = _mapper.Map<Match>(dto);
      await _dbContext.Matches.AddAsync(match);
      await _dbContext.SaveChangesAsync();
      return match.Id;
    }

    public async Task Delete(long id)
    {
      _logger.LogWarning($"It will be deleted match with {id}");
      var match = await _dbContext
        .Matches
        .FirstOrDefaultAsync(x => x.Id == id);

      if(match is null)
      {
        throw new NotFoundException("Match not found");
      }

      _dbContext.Matches.Remove(match);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<MatchDto>> GetAll()
    {
      _logger.LogInformation("Display all the matches");

      var matches = await _dbContext
        .Matches
        .ToListAsync();

      var matchDtos = _mapper.Map<List<MatchDto>>(matches);
      return matchDtos;
    }

    public async Task<MatchDto> GetById(long id)
    {
      _logger.LogInformation($"Display match with chosen {id}");

      var match = await _dbContext
        .Matches
        .FirstOrDefaultAsync(x => x.Id == id);
      
      if(match is null)
      {
        throw new NotFoundException("Match not found");
      }

      var result = _mapper.Map<MatchDto>(match);
      return result;
    }

    public async Task Update(long id, UpdateMatchDto dto)
    {
      _logger.LogInformation($"Edit match with {id}");
      var match = await _dbContext
        .Matches
        .FirstOrDefaultAsync(x => x.Id == id);

      if(match is null)
      {
        throw new NotFoundException("Match not found");
      }

      match.TeamOne = dto.TeamOne;
      match.TeamTwo = dto.TeamTwo;
      match.DateOfMatch = dto.DateOfMatch;
      match.InHouse = dto.InHouse;

      await _dbContext.SaveChangesAsync();
    }
  }
}