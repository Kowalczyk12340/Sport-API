using Microsoft.AspNetCore.Mvc;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategorySportController : ControllerBase
  {
    private readonly ICategorySportService _categorySportServive;

    /// <summary>
    /// Constructor with Dependency Injection for categorySportService
    /// </summary>
    public CategorySportController(ICategorySportService categorySportService)
    {
      _categorySportServive = categorySportService;
    }

    /// <summary>
    /// Method to display all sport categories available in the database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategorySportDto>>> GetAll()
    {
      var categorySportDtos = await _categorySportServive.GetAll();

      if(categorySportDtos is null)
      {
        return NotFound();
      }

      return Ok(categorySportDtos);
    }

    /// <summary>
    /// Method to delete chosen category sport with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _categorySportServive.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method to edit chosen sport category 
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<CategorySportDto>> Update([FromBody] CategorySportDto dto, [FromRoute] int id)
    {
      await _categorySportServive.Update(id, dto);

      return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategorySport>> Get([FromRoute] int id)
    {
      var categorySport = await _categorySportServive.GetById(id);

      return Ok(categorySport);
    }

    [HttpPost]
    public async Task<ActionResult<CategorySportDto>> CreateCategorySport([FromBody] CategorySportDto dto)
    {
      var id = await _categorySportServive.Create(dto);

      return Created($"/api/categorySport/{id}", null);
    }
  }
}