using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface IAddressService
  {
    Task<AddressDto> GetById(long id);
    Task<IEnumerable<AddressDto>> GetAll();
    Task<long> Create(CreateAddressDto dto);
    string SaveToCsv(IEnumerable<AddressDto> components);
    Task Delete(long id);
    Task Update(long id, UpdateAddressDto dto);
  }
}
