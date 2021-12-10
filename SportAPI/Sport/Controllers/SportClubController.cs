using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SportClubDto>>> GetAll()
    {
      var sportClubDtos = await _sportClubService.GetAll();
      
      if(sportClubDtos is null)
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
    /// <response code="200">SportClub exists and has been successfully retrieved</response>
    /// <response code="404">SportClub does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SportClub), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(typeof(CreateAddressDto), StatusCodes.Status201Created)]
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
    [HttpPut("{id}")]
    public async Task<ActionResult<SportClubDto>> Update([FromBody] UpdateSportClubDto dto, [FromRoute] long id)
    {
      await _sportClubService.Update(id,dto);
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
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
      await _sportClubService.Delete(id);
      return NoContent();
    }
  }
}