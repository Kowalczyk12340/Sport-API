using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class CustomerService : ICustomerService
  {
    public Task<int> Create(CustomerDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CustomerDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, CustomerDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
