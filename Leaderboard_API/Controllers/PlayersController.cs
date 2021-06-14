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
    public class PlayersController : ControllerBase
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public PlayersController(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        [HttpGet]
        public IActionResult GetPlayers() =>
            Ok(_leaderboardRepository.GetAllPlayers());

        [HttpPost]
        public IActionResult AddNewPlayer([FromBody] Players newPlayer)
        {
            if (!TryValidateModel(newPlayer))
            {
                return BadRequest();
            }
            _leaderboardRepository.AddPlayer(newPlayer);
            return Created(Request.Path, newPlayer);
        }
    }
}
