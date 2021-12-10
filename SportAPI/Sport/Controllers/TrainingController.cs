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
  public class TrainingController : ControllerBase
  {
    private readonly ITrainingService _trainingService;

    public TrainingController(ITrainingService trainingService)
    {
      _trainingService = trainingService;
    }


  }
}
