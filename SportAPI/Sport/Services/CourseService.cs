using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportAPI.Sport.Data;
using SportAPI.Sport.Exceptions;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Models.Dtos.Create;
using SportAPI.Sport.Models.Dtos.Update;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportAPI.Sport.Services
{
  public class CourseService : ICourseService
  {
    private readonly SportDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<CourseService> _logger;

    public CourseService(SportDbContext dbContext, IMapper mapper, ILogger<CourseService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public string SaveToCsv(IEnumerable<CourseDto> components)
    {
      var headers = "Id;Name;Description;Coach;Courses.Count";

      var csv = new StringBuilder(headers);

      csv.Append(Environment.NewLine);

      foreach (var component in components)
      {
        csv.Append(component.GetExportObject());
        csv.Append(Environment.NewLine);
      }
      csv.Append($"Count: {components.Count()}");
      csv.Append(Environment.NewLine);

      return csv.ToString();
    }

    public async Task<long> Create(CreateCourseDto dto)
    {
      _logger.LogInformation("Create new course");
      var course = _mapper.Map<Course>(dto);
      await _dbContext.Courses.AddAsync(course);
      await _dbContext.SaveChangesAsync();
      return course.Id;
    }

    public async Task Delete(long id)
    {
      _logger.LogWarning($"course with id: {id} DELETE action invoked");
      var course = await _dbContext
        .Courses
        .FirstOrDefaultAsync(x => x.Id == id);

      if (course is null)
      {
        throw new NotFoundException("course not found");
      }

      _dbContext.Courses.Remove(course);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CourseDto>> GetAll()
    {
      _logger.LogInformation("Display all the available Courses int this database");
      var Courses = await _dbContext
        .Courses
        .ToListAsync();

      var CourseDtos = _mapper.Map<List<CourseDto>>(Courses);

      return CourseDtos;
    }

    public async Task<CourseDto> GetById(long id)
    {
      _logger.LogInformation("Display the information about course by Id");
      var course = await _dbContext
        .Courses
        .FirstOrDefaultAsync(x => x.Id == id);

      if (course is null)
      {
        throw new NotFoundException("course not found");
      }

      var result = _mapper.Map<CourseDto>(course);
      return result;
    }

    public async Task Update(long id, UpdateCourseDto dto)
    {
      _logger.LogInformation("Update the information about course by Id");

      var course = await _dbContext
        .Courses
        .FirstOrDefaultAsync(x => x.Id == id);

      if (course is null)
      {
        throw new NotFoundException("Course not found");
      }

      course.Name = dto.Name;
      course.Description = dto.Description;
      await _dbContext.SaveChangesAsync();
    }
  }
}
