using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ITrainingService
  {
    Task<TrainingDto> GetById(int id);
    Task<IEnumerable<TrainingDto>> GetAll();
    Task<int> Create(TrainingDto dto);
    Task Delete(int id);
    Task Update(int id, TrainingDto dto);
  }
}