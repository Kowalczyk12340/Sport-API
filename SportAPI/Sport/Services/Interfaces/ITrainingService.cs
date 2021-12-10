using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
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
    Task<long> Create(CreateTrainingDto dto);
    Task Delete(long id);
    Task Update(long id, UpdateTrainingDto dto);
  }
}