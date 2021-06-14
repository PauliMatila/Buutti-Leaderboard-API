using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leaderboard_API.Models;
using Leaderboard_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leaderboard_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public LevelsController(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        [HttpGet]
        public IActionResult GetLevels() =>
            Ok(_leaderboardRepository.GetAllLevels());

        [HttpPost]
        public IActionResult AddNewLevel([FromBody] Levels newLevel)
        {
            if (!TryValidateModel(newLevel))
            {
                return BadRequest();
            }
            _leaderboardRepository.AddLevel(newLevel);
            return Created(Request.Path, newLevel);
        }
    }
}
