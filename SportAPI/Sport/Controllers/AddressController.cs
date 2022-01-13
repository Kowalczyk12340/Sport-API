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
  public class AddressController : ControllerBase
  {
    private readonly IAddressService _addressService;

    /// <summary>
    /// Constructor with Dependency Injection for addressService
    /// </summary>
    /// <param name="addressService"></param>
    public AddressController(IAddressService addressService)
    {
      _addressService = addressService;
    }

    /// <summary>
    /// Method to display all addresses available in the database
    /// </summary>
    /// <returns>List of addresses with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<AddressDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressDto>>> GetAll()
    {
      var addressDtos = await _addressService.GetAll();

      if (addressDtos is null)
      {
        return NotFound();
      }

      return Ok(addressDtos);
    }

    /// <summary>
    /// Method to delete chosen address with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Address exists and has been successfully deletes</response>
    /// <response code="400">Address exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Address does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _addressService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method, when you can edit or update chosen address
    /// suitable address with ID
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full address</returns>
    /// <response code="200">Address exists and has been successfully modified</response>
    /// <response code="400">Address exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Address does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AddressDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressDto>> Update([FromBody] UpdateAddressDto dto, [FromRoute] long id)
    {
      await _addressService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to get address with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Address with chosen id</returns>
    /// <response code="200">Address exists and has been successfully retrieved</response>
    /// <response code="404">Address does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Address>> Get([FromRoute] long id)
    {
      var address = await _addressService.GetById(id);

      return Ok(address);
    }

    /// <summary>
    /// Method to add address to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created address</returns>
    /// <response code="201">Address has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(AddressDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddressDto>> CreateAddress([FromBody] CreateAddressDto dto)
    {
      try
      {
        var id = await _addressService.Create(dto);
        return Created($"/api/address/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }

    /// <summary>
    /// Method to export chosen addresses to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Addresses exist and have been successfully save to csv file</response>
    /// <response code="404">Addresses do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _addressService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _addressService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }
  }
}