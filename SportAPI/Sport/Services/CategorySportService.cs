using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
using SportAPI.Sport.Exceptions;
using SportAPI.Sport.Models;
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
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<CategorySportService> _logger;

    public CategorySportService(SportDbContext dbContext, IMapper mapper, ILogger<CategorySportService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CategorySportDto dto)
    {
      _logger.LogInformation($"A new Category Sport will be created");
      var categorySport = _mapper.Map<CategorySport>(dto);
      await _dbContext.CategorySports.AddAsync(categorySport);
      await _dbContext.SaveChangesAsync();
      return categorySport.CategorySportId;

    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"Category Sport with id: {id} DELETE action invoked");

      var categorySport = await _dbContext
        .CategorySports
        .FirstOrDefaultAsync(r => r.CategorySportId == id);

      if(categorySport is null)
      {
        throw new NotFoundException("Category Sport not found");
      }

      _dbContext.CategorySports.Remove(categorySport);
      await _dbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<CategorySportDto>> GetAll()
    {
      var categorySports = await _dbContext
        .CategorySports
        .Include(r => r.CategorySportName)
        .ToListAsync();

      var categorySportDtos = _mapper.Map<List<CategorySportDto>>(categorySports);
      return categorySportDtos;
    }

    public async Task<CategorySportDto> GetById(int id)
    {
      var categorySport = await _dbContext
        .CategorySports
        .Include(r => r.CategorySportName)
        .FirstOrDefaultAsync(r => r.CategorySportId == id);

      if(categorySport is null)
      {
        throw new NotFoundException("Category Sport not found");
      }

      var result = _mapper.Map<CategorySportDto>(categorySport);
      return result;
    }

    public async Task Update(int id, CategorySportDto dto)
    {
      var categorySport = await _dbContext
        .CategorySports
        .FirstOrDefaultAsync(r => r.CategorySportId == id);

      if(categorySport is null)
      {
        throw new NotFoundException("Category sport not found");
      }

      categorySport.CategorySportName = dto.CategorySportName;
      await _dbContext.SaveChangesAsync();
    }
  }
}
