using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IAddressService
  {
    Task<AddressDto> GetById(int id);
    Task<IEnumerable<AddressDto>> GetAll();
    Task<int> Create(AddressDto dto);
    Task Delete(int id);
    Task Update(int id, AddressDto dto);
  }
}
