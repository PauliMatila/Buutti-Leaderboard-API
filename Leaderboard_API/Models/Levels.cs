using System;
using System.Collections.Generic;

#nullable disable

namespace Leaderboard_API.Models
{
    public partial class Levels
    {
        public Levels()
        {
            Scores = new HashSet<Scores>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Scores> Scores { get; set; }
    }
}
