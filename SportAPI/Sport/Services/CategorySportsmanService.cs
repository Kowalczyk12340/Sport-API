using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class CategorySportsmanService : ICategorySportsmanService
  {
    public Task<int> Create(CategorySportsmanDto dto)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CategorySportsmanDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CategorySportsmanDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task Update(int id, CategorySportsmanDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
