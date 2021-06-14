using System;
using System.Collections.Generic;

#nullable disable

namespace Leaderboard_API.Models
{
    public partial class Players
    {
        public Players()
        {
            Scores = new HashSet<Scores>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public int CountryCode { get; set; }

        public virtual ICollection<Scores> Scores { get; set; }
    }
}
