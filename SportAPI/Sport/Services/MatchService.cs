using AutoMapper;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models.Dtos;
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
    public Task<long> Create(MatchDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MatchDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<MatchDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, MatchDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
