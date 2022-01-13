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
  [Route("api/sportclub/{sportClubId}/[controller]")]
  [ApiController]
  [Authorize(Roles = "User, Admin")]
  public class PlayerController : ControllerBase
  {
    private readonly IPlayerService _playerService;

    /// <summary>
    /// Constructor with Dependency Injection for playerService
    /// </summary>
    /// <param name="playerService"></param>
    public PlayerController(IPlayerService playerService)
    {
      _playerService = playerService;
    }

    /// <summary>
    /// Method to display all players available in the database
    /// </summary>
    /// <returns>List of players with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<PlayerDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll([FromRoute] long sportClubId)
    {
      var playerDtos = await _playerService.GetAll(sportClubId);

      if (playerDtos is null)
      {
        return NotFound();
      }

      return Ok(playerDtos);
    }

    /// <summary>
    /// Method to delete chosen player with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Player exists and has been successfully deleted</response>
    /// <response code="400">Player exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Player does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteAll([FromRoute] long sportClubId)
    {
      await _playerService.DeleteAll(sportClubId);
      return NoContent();
    }

    /// <summary>
    /// Method to delete chosen player with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Player exists and has been successfully deleted</response>
    /// <response code="400">Player exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Player does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long sportClubId, long id)
    {
      await _playerService.Delete(sportClubId, id);
      return NoContent();
    }

    /// <summary>
    /// Method to export chosen Players to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Players exist and have been successfully save to csv file</response>
    /// <response code="404">Players do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv([FromRoute] long sportClubId)
    {
      var date = DateTime.UtcNow;
      var result = await _playerService.GetAll(sportClubId);
      if (result == null)
      {
        return NotFound();
      }
      var csv = _playerService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method, when you can edit or update chosen player
    /// suitable address with ID
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full player</returns>
    /// <response code="200">Player exists and has been successfully modified</response>
    /// <response code="400">Player exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Player does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PlayerDto>> Update([FromBody] UpdatePlayerDto dto, [FromRoute] long sportClubId, [FromRoute] long id)
    {
      await _playerService.Update(sportClubId, id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to get player with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Player with chosen id</returns>
    /// <response code="200">Player exists and has been successfully retrieved</response>
    /// <response code="404">Player does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Player>> Get([FromRoute] long sportClubId, [FromRoute] long id)
    {
      var player = await _playerService.GetById(sportClubId, id);
      return Ok(player);
    }

    /// <summary>
    /// Method to add player to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created player</returns>
    /// <response code="201">Player has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlayerDto>> Create([FromBody] CreatePlayerDto dto, [FromRoute] long sportClubId)
    {
      try
      {
        var id = await _playerService.Create(sportClubId, dto);
        return Created($"/api/player/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }
  }
}