using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ITrainingService
  {
    Task<TrainingDto> GetById(long id);
    Task<IEnumerable<TrainingDto>> GetAll();
    Task<long> Create(TrainingDto dto);
    Task Delete(long id);
    Task Update(long id, TrainingDto dto);
  }
}