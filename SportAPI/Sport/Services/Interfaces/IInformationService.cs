using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IInformationService
  {
    Task<InformationDto> GetById(int id);
    Task<IEnumerable<InformationDto>> GetAll();
    Task<int> Create(InformationDto dto);
    Task Delete(int id);
    Task Update(int id, InformationDto dto);
  }
}
