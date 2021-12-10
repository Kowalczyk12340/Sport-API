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
  public class TrainingService : ITrainingService
  {
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<TrainingService> _logger;

    public TrainingService(SportDbContext dbContext, IMapper mapper, ILogger<TrainingService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }
    public Task<long> Create(TrainingDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<TrainingDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<TrainingDto> GetById(long id)
    {
      throw new NotImplementedException();
    }

    public Task Update(long id, TrainingDto dto)
    {
      throw new NotImplementedException();
    }
  }
}