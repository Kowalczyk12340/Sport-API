using AutoMapper;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
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
    public Task<long> Create(CreateLeagueDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<LeagueDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<LeagueDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, UpdateLeagueDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
