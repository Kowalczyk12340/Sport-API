using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class StatusInformationService : IStatusInformationService
  {
    public Task<int> Create(StatusInformationDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<StatusInformationDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<StatusInformationDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, StatusInformationDto dto)
    {
      throw new NotImplementedException();
    }
  }
}