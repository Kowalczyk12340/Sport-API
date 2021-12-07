using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IStatusInformationService
  {
    Task<StatusInformationDto> GetById(int id);
    Task<IEnumerable<StatusInformationDto>> GetAll();
    Task<int> Create(StatusInformationDto dto);
    Task Delete(int id);
    Task Update(int id, StatusInformationDto dto);
  }
}