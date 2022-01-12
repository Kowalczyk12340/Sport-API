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
using System.Threading.Tasks;

namespace SportAPI.Sport.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(Roles = "Admin")]
  public class RoleController : ControllerBase
  {
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
      _roleService = roleService;
    }

    /// <summary>
    /// Method to display all roles available in the database
    /// </summary>
    /// <returns>List of roles with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<RoleDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
    {
      var roleDtos = await _roleService.GetAll();

      if (roleDtos is null)
      {
        return NotFound();
      }

      return Ok(roleDtos);
    }

    /// <summary>
    /// Method to delete chosen role with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Role exists and has been successfully deleted</response>
    /// <response code="400">Role exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Role does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _roleService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method, when you can edit or update chosen role
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full role</returns>
    /// <response code="200">Role exists and has been successfully modified</response>
    /// <response code="400">Role exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Role does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoleDto>> Update([FromBody] UpdateRoleDto dto, [FromRoute] long id)
    {
      await _roleService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to get role with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Role with chosen id</returns>
    /// <response code="200">Role exists and has been successfully retrieved</response>
    /// <response code="404">Role does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Role>> Get([FromRoute] long id)
    {
      var role = await _roleService.GetById(id);
      return Ok(role);
    }

    /// <summary>
    /// Method to add role to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created role</returns>
    /// <response code="201">Role has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(RoleDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RoleDto>> Create([FromBody] CreateRoleDto dto)
    {
      try
      {
        var id = await _roleService.Create(dto);
        return Created($"/api/role/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }
  }
}
