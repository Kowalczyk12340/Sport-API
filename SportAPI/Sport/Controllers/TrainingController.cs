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
  public class TrainingController : ControllerBase
  {
    private readonly ITrainingService _trainingService;

    public TrainingController(ITrainingService trainingService)
    {
      _trainingService = trainingService;
    }

    /// <summary>
    /// Method to display all trainings available in the database
    /// </summary>
    /// <returns>List of trainings with basic information</returns>
    /// <response code="200">Query has been successfully executed</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [ProducesResponseType(typeof(IEnumerable<TrainingDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingDto>>> GetAll()
    {
      var trainingDtos = await _trainingService.GetAll();

      if (trainingDtos is null)
      {
        return NotFound();
      }

      return Ok(trainingDtos);
    }

    /// <summary>
    /// Method to delete chosen training with the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Training exists and has been successfully deleted</response>
    /// <response code="400">Training exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Training does not exist</response>
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    //[SportAPIAuth]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] long id)
    {
      await _trainingService.Delete(id);
      return NoContent();
    }

    /// <summary>
    /// Method, when you can edit or update chosen training
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="id"></param>
    /// <returns>Full training</returns>
    /// <response code="200">Training exists and has been successfully modified</response>
    /// <response code="400">Training exists, but given parameters were invalid - refer to the error message</response>
    /// <response code="404">Training does not exist</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TrainingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TrainingDto>> Update([FromBody] UpdateTrainingDto dto, [FromRoute] long id)
    {
      await _trainingService.Update(id, dto);
      return Ok();
    }

    /// <summary>
    /// Method to export chosen Trainings to the csv file
    /// </summary>
    /// <param name="id"></param>
    /// <returns>File with csv extensions</returns>
    /// <response code="200">Trainings exist and have been successfully save to csv file</response>
    /// <response code="404">Trainings do not exist</response>
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [HttpGet("exporttoexcel")]
    public async Task<IActionResult> SaveToCsv()
    {
      var date = DateTime.UtcNow;
      var result = await _trainingService.GetAll();
      if (result == null)
      {
        return NotFound();
      }
      var csv = _trainingService.SaveToCsv(result);
      return File(new UTF8Encoding().GetBytes(csv), "text/csv", $"Document-{date}.csv");
    }

    /// <summary>
    /// Method to get training with chosen ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Training with chosen id</returns>
    /// <response code="200">Training exists and has been successfully retrieved</response>
    /// <response code="404">Training does not exist</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Training), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Training>> Get([FromRoute] long id)
    {
      var training = await _trainingService.GetById(id);
      return Ok(training);
    }

    /// <summary>
    /// Method to add training to the database
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The newly created training</returns>
    /// <response code="201">Training has been successfully created</response>
    /// <response code="400">Given parameters were invalid - refer to the error message</response>
    [HttpPost]
    [ProducesResponseType(typeof(TrainingDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrainingDto>> Create([FromBody] CreateTrainingDto dto)
    {
      try
      {
        var id = await _trainingService.Create(dto);
        return Created($"/api/training/{id}", null);
      }
      catch (BadRequestException ex)
      {
        var message = ex.Message;
        return BadRequest(message);
      }
    }
  }
}