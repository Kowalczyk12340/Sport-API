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
  //[Authorize(Roles = "User, Admin")]
  public class CoachController : ControllerBase
  {
    private readonly ICoachService _coachService;

    /// <summary>
    /// Constructor with Dependency Injection for coachService
    /// </summary>
    /// <param name="coachService"></param>
    public CoachController(ICoachService coachService)
    {
      _coachService = coachService;
    }

    /// <summary>
    /// Method to display all coaches available in the database
    /// </summary>
    /// <returns>List of coaches with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<CoachDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CoachDto>>> GetAll()
    {
      var coachDtos = await _coachService.GetAll();

      if (coachDtos is null)
      {
        return NotFound();
      }

      return Ok(coachDtos);
    }

    /// <summary>
    /// Method to delete chosen coach with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Coach exists and has been successfully deletes</response>
    /// <response code="400">Coach exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Coach does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _coachService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method to edit and update chosen information
    /// about coach with ID
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full coach</returns>
    /// <response code="200">Coach exists and has been successfully modified</response>
    /// <response code="400">Coach exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Coach does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CoachDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CoachDto>> Update([FromBody] UpdateCoachDto dto, [FromRoute] long id)
    {
      await _coachService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to get coach with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Coach with chosen id</returns>
    /// <response code="200">Coach exists and has been successfully retrieved</response>
    /// <response code="404">Coach does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Coach), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Coach>> Get([FromRoute] long id)
    {
      var coach = await _coachService.GetById(id);

      return Ok(coach);
    }

    /// <summary>
    /// Method to add coach to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created coach</returns>
    /// <response code="201">Coach has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(CoachDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CoachDto>> Create([FromBody] CreateCoachDto dto)
    {
      try
      {
        var id = await _coachService.Create(dto);
        return Created($"/api/coach/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method to export chosen coaches to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Coaches exist and have been successfully save to csv file</response>
    /// <response code="404">Coaches do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _coachService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _coachService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }
  }
}