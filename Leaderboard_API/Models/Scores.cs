using System;
using System.Collections.Generic;

#nullable disable

namespace Leaderboard_API.Models
{
    public partial class Scores
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int TimeInSeconds { get; set; }
        public int HighScore { get; set; }
        public int PlayerId { get; set; }
        public int LevelId { get; set; }

        public virtual Levels Level { get; set; }
        public virtual Players Player { get; set; }
    }
}
