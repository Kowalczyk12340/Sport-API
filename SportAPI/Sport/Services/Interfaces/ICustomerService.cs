using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ICustomerService
  {
    Task<CustomerDto> GetById(int id);
    Task<IEnumerable<CustomerDto>> GetAll();
    Task<int> Create(CustomerDto dto);
    Task Delete(int id);
    Task Update(int id, CustomerDto dto);
  }
}
