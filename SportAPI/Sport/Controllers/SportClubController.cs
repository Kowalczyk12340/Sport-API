using Microsoft.AspNetCore.Mvc;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Dtos;
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

    public SportClubController(ISportClubService sportClubService)
    {
      _sportClubService = sportClubService;
    }

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
  }
}
