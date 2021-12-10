using AutoMapper;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
using SportAPI.Sport.Models.Dtos;
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
    public Task<long> Create(PlayerDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<PlayerDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<PlayerDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, PlayerDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
