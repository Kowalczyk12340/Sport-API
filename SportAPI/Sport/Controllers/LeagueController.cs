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
  public class LeagueController : ControllerBase
  {
    private readonly ILeagueService _leagueService;

    /// <summary>
    /// Constructor for LeagueController with league service added by Dependency Injection
    /// </summary>
    /// <param name="leagueService"></param>
    public LeagueController(ILeagueService leagueService)
    {
      _leagueService = leagueService;
    }

    /// <summary>
    /// Method to display all leagues available in the database
    /// </summary>
    /// <returns>List of leagues with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<LeagueDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeagueDto>>> GetAll()
    {
      var leagueDtos = await _leagueService.GetAll();

      if (leagueDtos is null)
      {
        return NotFound();
      }

      return Ok(leagueDtos);
    }

    /// <summary>
    /// Method to export chosen Leagues to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Leagues exist and have been successfully save to csv file</response>
    /// <response code="404">Leagues do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _leagueService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _leagueService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get league with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>League with chosen id</returns>
    /// <response code="200">League exists and has been successfully retrieved</response>
    /// <response code="404">League does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(League), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<League>> Get([FromRoute] long id)
    {
      var league = await _leagueService.GetById(id);
      return Ok(league);
    }

    /// <summary>
    /// Method to add league to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created league</returns>
    /// <response code="201">League has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(LeagueDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LeagueDto>> Create([FromBody] CreateLeagueDto dto)
    {
      try
      {
        var id = await _leagueService.Create(dto);
        return Created($"/api/league/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method, when you can edit or update chosen league by id
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full league</returns>
    /// <response code="200">League exists and has been successfully modified</response>
    /// <response code="400">League exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">League does not exist</response>
    [ProducesResponseType(typeof(LeagueDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpPut("{id}")]
    public async Task<ActionResult<LeagueDto>> Update([FromBody] UpdateLeagueDto dto, [FromRoute] long id)
    {
      await _leagueService.Update(id, dto);
      return Ok();
    }


    /// <summary>
    /// Method to delete chosen league with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">League exists and has been successfully deletes</response>
    /// <response code="400">League exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">League does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _leagueService.Delete(id);
      return NoContent();
    }
  }
}