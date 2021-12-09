using Microsoft.AspNetCore.Mvc;
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
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressDto>>> GetAll()
    {
      var addressDtos = await _addressService.GetAll();

      if(addressDtos is null)
      {
        return NotFound();
      }

      return Ok(addressDtos);
    }

    /// <summary>
    /// Method to delete chosen address with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<AddressDto>> Update([FromBody] UpdateAddressDto dto, [FromRoute] long id)
    {
      await _addressService.Update(id,dto);
      return Ok();
    }

    /// <summary>
    /// Method to get address with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Address>> Get([FromRoute] long id)
    {
      var address = await _addressService.GetById(id);

      return Ok(address);
    }

    /// <summary>
    /// Method to add address to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<AddressDto>> CreateAddress([FromBody] CreateAddressDto dto)
    {
      var id = await _addressService.Create(dto);
      return Created($"/api/address/{id}", null);
    }
  }
}