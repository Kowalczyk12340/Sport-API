using SportAPI.Sport.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services.Interfaces
{
  public interface ICategorySportService
  {
    Task<CategorySportDto> GetById(int id);
    Task<IEnumerable<CategorySportDto>> GetAll();
    Task<int> Create(CategorySportDto dto);
    Task Delete(int id);
    Task Update(int id, CategorySportDto dto);
  }
}
