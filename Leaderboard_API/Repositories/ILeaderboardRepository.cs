using Leaderboard_API.Models;
using System.Collections.Generic;

namespace Leaderboard_API.Repositories
{
    public interface ILeaderboardRepository
    {
        void AddLevel(Levels newLevel);
        void AddPlayer(Players newPlayer);
        void AddScore(Scores newScore);
        void DeleteScore(int id);
        List<Levels> GetAllLevels();
        List<Players> GetAllPlayers();
        List<Scores> GetAllScores();
        Scores GetScore(int id);
        Levels GetLevel(int id);
    }
}