using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastManStanding
{
    public class Team
    {
        public Team(string teamName, int league, int position = 0, int gamesPlayed = 0,
                    int gamesWon = 0, int gamesDrawn = 0, int gamesLost = 0,
                    int goalsFor = 0, int goalsAgainst = 0, int numPoints = 0)
        {
            Name = teamName;
            League = league;
            Position = position;
            Played = gamesPlayed;
            Won = gamesWon;
            Drawn = gamesDrawn;
            Lost = gamesLost;
            Points = numPoints;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            GoalDiff = goalsFor - goalsAgainst;
        }
        
        public string Name { get; private set; }
        public int League { get; private set; }
        public int Position { get; private set; }
        public int Played { get; private set; }
        public int Won { get; private set; }
        public int Drawn { get; private set; }
        public int Lost { get; private set; }
        public int Points { get; private set; }
        public int GoalsFor { get; private set; }
        public int GoalsAgainst { get; private set; }
        public int GoalDiff { get; private set; }
        public double Form { get; private set; }

        public string[] leagues = { "", "PL", "CH" };

        public int[] lastFive = new int[5];

        public override string ToString()
        {
            string league = leagues[League];

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} ", league);
            sb.AppendFormat("{0,-3} ", Position);
            sb.AppendFormat("{0} ", Name);
            sb.AppendFormat("{0} ", Played);
            sb.AppendFormat("{0} ", Won);
            sb.AppendFormat("{0} ", Drawn);
            sb.AppendFormat("{0} ", Lost);
            sb.AppendFormat("{0} ", GoalsFor);
            sb.AppendFormat("{0} ", GoalsAgainst);
            sb.AppendFormat("{0} ", GoalDiff);
            sb.AppendFormat("{0} ", Points);

            return sb.ToString();
        }
    }
}
