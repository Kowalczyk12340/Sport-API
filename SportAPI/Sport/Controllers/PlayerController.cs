using Microsoft.AspNetCore.Mvc;
using SportAPI.Sport.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayerController : ControllerBase
  {
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
      _playerService = playerService;
    }
  }
}
