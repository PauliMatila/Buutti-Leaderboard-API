using Leaderboard_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leaderboard_API.Repositories
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private readonly Leaderboard_api_dbContext _context;

        public LeaderboardRepository(Leaderboard_api_dbContext context)
        {
            _context = context;
        }

        //Methods for getting all scores, adding new scores and deleteing scores
        public Scores GetScore(int id) =>
            _context.Scores.FirstOrDefault(s => s.Id == id);

        public List<Scores> GetAllScores() =>
            _context.Scores.ToList();

        public void AddScore(Scores newScore)
        {
            _context.Scores.Add(newScore);
            _context.SaveChanges();
        }

        public void DeleteScore(int id)
        {
            _context.Scores.Remove(GetScore(id));
            _context.SaveChanges();
        }

        //Methods for getting all levels and adding new levels
        public Levels GetLevel(int id) =>
            _context.Levels.FirstOrDefault(l => l.Id == id);

        public List<Levels> GetAllLevels() =>
            _context.Levels.ToList();

        public void AddLevel(Levels newLevel)
        {
            _context.Levels.Add(newLevel);
            _context.SaveChanges();
        }

        //Methods for getting all players and adding new players
        public List<Players> GetAllPlayers() =>
            _context.Players.ToList();

        public void AddPlayer(Players newPlayer)
        {
            _context.Players.Add(newPlayer);
            _context.SaveChanges();
        }
    }
}
