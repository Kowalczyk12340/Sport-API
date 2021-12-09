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