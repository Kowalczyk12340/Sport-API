using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class AddressService : IAddressService
  {
    public Task<int> Create(AddressDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<AddressDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<AddressDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, AddressDto dto)
    {
      throw new NotImplementedException();
    }
  }
}