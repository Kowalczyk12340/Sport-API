using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ICategorySportsmanService
  {
    Task<CategorySportsmanDto> GetById(int id);
    Task<IEnumerable<CategorySportsmanDto>> GetAll();
    Task<int> Create(CategorySportsmanDto dto);
    Task Delete(int id);
    Task Update(int id, CategorySportsmanDto dto);
  }
}
