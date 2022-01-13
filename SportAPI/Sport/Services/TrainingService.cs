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
    public async Task<long> Create(CreateTrainingDto dto)
    {
      _logger.LogInformation("Create a new training");
      var training = _mapper.Map<Training>(dto);
      await _dbContext.Trainings.AddAsync(training);
      await _dbContext.SaveChangesAsync();
      return training.Id;
    }

    public async Task Delete(long id)
    {
      _logger.LogWarning($"It will be deleted training with id: {id}");

      var training = await _dbContext
        .Trainings
        .FirstOrDefaultAsync(x => x.Id == id);

      if(training is null)
      {
        throw new NotFoundException("Training not found");
      }

      _dbContext.Trainings.Remove(training);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TrainingDto>> GetAll()
    {
      _logger.LogInformation("Displaying all the trainings");
      var trainings = await _dbContext
        .Trainings
        .ToListAsync();

      var trainingDtos = _mapper.Map<List<TrainingDto>>(trainings);
      return trainingDtos;
    }

    public async Task<TrainingDto> GetById(long id)
    {
      _logger.LogInformation($"Editing training with {id}");
      var training = await _dbContext
        .Trainings
        .FirstOrDefaultAsync(x => x.Id == id);

      if(training is null)
      {
        throw new NotFoundException("Training not found");
      }

      var result = _mapper.Map<TrainingDto>(training);
      return result;
    }

        public string SaveToCsv(IEnumerable<TrainingDto> components)
        {
            var headers = "Id;Name;Description;TimeOfTraining;SportClubId";

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

        public async Task Update(long id, UpdateTrainingDto dto)
    {
      _logger.LogInformation($"Edit training with {id}");
      var training = await _dbContext
        .Trainings
        .FirstOrDefaultAsync(x => x.Id == id);

      if(training is null)
      {
        throw new NotFoundException("Training not found");
      }

      training.Name = dto.Name;
      training.TimeOfTraining = dto.TimeOfTraining;
      training.Description = dto.Description;
      await _dbContext.SaveChangesAsync();
    }
  }
}