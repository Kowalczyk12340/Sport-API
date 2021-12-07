using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class InformationService : IInformationService
  {
    public Task<int> Create(InformationDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<InformationDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<InformationDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, InformationDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
