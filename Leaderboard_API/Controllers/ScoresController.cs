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
    public class ScoresController : ControllerBase
    {
        private readonly ILeaderboardRepository _leaderboardRepository;

        public ScoresController(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        [HttpGet("level/{levelId}")]
        public IActionResult GetlevelScores(int levelId)
        {
            List<Scores> scores = _leaderboardRepository.GetAllScores();
            scores.Where(s => s.Level.Id == levelId);
            return Ok(scores);
        }

        //[HttpPost("level/{levelId}")]
        //public IActionResult AddScoreToLevel(int levelId, [FromBody] Scores newScore)
        //{
        //    Levels newScoreForLevel = _leaderboardRepository.GetLevel(levelId);
        //    _leaderboardRepository.AddScore(newScore);
        //}
    }
}
