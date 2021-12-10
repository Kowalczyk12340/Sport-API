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
using System.Threading.Tasks;

namespace SportAPI.Sport.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MatchController : ControllerBase
  {
    private readonly IMatchService _matchService;

    /// <summary>
    /// Constructor with Dependency Injection for matchService
    /// </summary>
    /// <param name="matchService"></param>
    public MatchController(IMatchService matchService)
    {
      _matchService = matchService;
    }

    /// <summary>
    /// Method to display all matches available in the database
    /// </summary>
    /// <returns>List of matches with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<MatchDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchDto>>> GetAll()
    {
      var matchDtos = await _matchService.GetAll();

      if(matchDtos is null)
      {
        return NotFound();
      }

      return Ok(matchDtos);
    }


    /// <summary>
    /// Method to delete chosen match with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Match exists and has been successfully deletes</response>
    /// <response code="400">Match exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Match does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _matchService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method, when you can edit or 
    /// update chosen match with ID
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full match</returns>
    /// <response code="200">Match exists and has been successfully modified</response>
    /// <response code="400">Match exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Match does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(MatchDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MatchDto>> Update([FromBody] UpdateMatchDto dto, [FromRoute] long id)
    {
      await _matchService.Update(id,dto);
      return Ok();
    }

    /// <summary>
    /// Method to get match with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Match with chosen id</returns>
    /// <response code="200">Match exists and has been successfully retrieved</response>
    /// <response code="404">Match does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Match), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Match>> Get([FromRoute] long id)
    {
      var match = await _matchService.GetById(id);

      return Ok(match);
    }

    /// <summary>
    /// Method to add match to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created match</returns>
    /// <response code="201">Match has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(MatchDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MatchDto>> Create(CreateMatchDto dto)
    {
      try
      {
        var id = await _matchService.Create(dto);
        return Created($"/api/match/{id}", null);
      }
      catch(BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }
  }
}