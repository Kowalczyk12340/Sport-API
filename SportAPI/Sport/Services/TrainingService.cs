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
    public Task<int> Create(TrainingDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<TrainingDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<TrainingDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, TrainingDto dto)
    {
      throw new NotImplementedException();
    }
  }
}