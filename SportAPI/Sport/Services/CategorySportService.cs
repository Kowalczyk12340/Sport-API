using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class CategorySportService : ICategorySportService
  {
    public Task<int> Create(CategorySportDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CategorySportDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CategorySportDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, CategorySportDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
