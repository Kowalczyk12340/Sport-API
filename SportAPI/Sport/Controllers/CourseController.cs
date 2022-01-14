using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPI.Sport.Attributes;
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

namespace SportAPI.Sport.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(Roles = "User, Admin")]
  public class CourseController : ControllerBase
  {
    private readonly ICourseService _courseService;

    /// <summary>
    /// Constructor with Dependency Injection for courseService
    /// </summary>
    /// <param name="courseService"></param>
    public CourseController(ICourseService courseService)
    {
      _courseService = courseService;
    }

    /// <summary>
    /// Method to display all courses available in the database
    /// </summary>
    /// <returns>List of courses with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<CourseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
    {
      var CourseDtos = await _courseService.GetAll();

      if (CourseDtos is null)
      {
        return NotFound();
      }

      return Ok(CourseDtos);
    }

    /// <summary>
    /// Method to delete chosen course with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">course exists and has been successfully deletes</response>
    /// <response code="400">course exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">course does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _courseService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method to edit and update chosen information
    /// about course with ID
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full course</returns>
    /// <response code="200">course exists and has been successfully modified</response>
    /// <response code="400">course exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">course does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CourseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CourseDto>> Update([FromBody] UpdateCourseDto dto, [FromRoute] long id)
    {
      await _courseService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to get course with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>course with chosen id</returns>
    /// <response code="200">course exists and has been successfully retrieved</response>
    /// <response code="404">course does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Course>> Get([FromRoute] long id)
    {
      var course = await _courseService.GetById(id);

      return Ok(course);
    }

    /// <summary>
    /// Method to add course to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created course</returns>
    /// <response code="201">course has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(CourseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CourseDto>> Create([FromBody] CreateCourseDto dto)
    {
      try
      {
        var id = await _courseService.Create(dto);
        return Created($"/api/course/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method to export chosen courses to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">courses exist and have been successfully save to csv file</response>
    /// <response code="404">courses do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _courseService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _courseService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }
  }
}