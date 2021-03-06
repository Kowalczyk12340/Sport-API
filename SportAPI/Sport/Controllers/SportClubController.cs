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
  public class SportClubController : ControllerBase
  {
    private readonly ISportClubService _sportClubService;

    /// <summary>
    /// Constructor with Dependency Injection for sportClubService
    /// </summary>
    /// <param name="sportClubService"></param>
    public SportClubController(ISportClubService sportClubService)
    {
      _sportClubService = sportClubService;
    }

    /// <summary>
    /// Method to display all sport clubs available in the database
    /// </summary>
    /// <returns>List of sport clubs with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<SportClubDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SportClubDto>>> GetAll()
    {
      var sportClubDtos = await _sportClubService.GetAll();

      if (sportClubDtos is null)
      {
        return NotFound();
      }

      return Ok(sportClubDtos);
    }

    /// <summary>
    /// Method to get sport club with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Sport Club with chosen id</returns>
    /// <response code="200">Sport Club exists and has been successfully retrieved</response>
    /// <response code="404">Sport Club does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SportClub), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[Authorize(Policy = "AtLeast18")]
    //[Authorize(Policy = "HasDateOfBirth")]
    //[Authorize(Policy = "HasNationality")]
    public async Task<ActionResult<SportClub>> Get([FromRoute] long id)
    {
      var sportClub = await _sportClubService.GetById(id);
      return Ok(sportClub);
    }

    /// <summary>
    /// Method to add sport club to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created sport club</returns>
    /// <response code="201">Sport Club has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(SportClubDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SportClubDto>> Create([FromBody] CreateSportClubDto dto)
    {
      try
      {
        var id = await _sportClubService.Create(dto);
        return Created($"/api/sportclub/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen sport club
    /// suitable address with ID
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full sport club</returns>
    /// <response code="200">Sport Club exists and has been successfully modified</response>
    /// <response code="400">Sport Club exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Sport Club does not exist</response>
    [ProducesResponseType(typeof(SportClubDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<SportClubDto>> Update([FromBody] UpdateSportClubDto dto, [FromRoute] long id)
    {
      await _sportClubService.Update(id, dto);
      return Ok();
    }


    /// <summary>
    /// Method to delete chosen sport club with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Sport Club exists and has been successfully deletes</response>
    /// <response code="400">Sport Club exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Sport Club does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _sportClubService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method to export chosen sport club to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Clubs exist and have been successfully save to csv file</response>
    /// <response code="404">Clubs do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _sportClubService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _sportClubService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }
  }
}