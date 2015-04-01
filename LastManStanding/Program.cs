using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastManStanding
{
    /* LastManStanding */
    class Program
    {
        static void Main(string[] args)
        {
            var leaguePL = GetLeagueDataAsync(1).Result;
            var leagueCH = GetLeagueDataAsync(2).Result;

            PrintLeagueTable(leaguePL);
            PrintLeagueTable(leagueCH);

            var formPL = GetFormDataAsync(1).Result;
            var formCH = GetFormDataAsync(2).Result;

            PrintLeagueTable(formPL);
            PrintLeagueTable(formCH);            

            CompareTeams(leaguePL, "West Ham", "Leicester");
            CompareTeams(formPL, "West Ham", "Leicester");                        
        }


        static void CompareTeams(IEnumerable<Team> teamList, string team1, string team2)
        {
            TeamComparer tc1 = new TeamComparer(TeamParser.SelectTeam(teamList, team1), TeamParser.SelectTeam(teamList, team2));
            Console.WriteLine(tc1.ToString());            
        }


        async static Task<IEnumerable<Team>> GetLeagueDataAsync(int league)
        {
            Uri url = new Uri("http://www.footballwebpages.co.uk/league.xml?comp=" + league);

            IEnumerable<Team> teams = await TeamParser.GetLeagueTeamsAsync(url, league);

            return teams;
        }


        async static Task<IEnumerable<Team>> GetFormDataAsync(int league)
        {
            Uri url = new Uri("http://www.footballwebpages.co.uk/form.xml?comp=" + league);

            IEnumerable<Team> teams = await TeamParser.GetLeagueTeamsAsync(url, league);

            return teams;
        }


        static void PrintLeagueTable(IEnumerable<Team> teams)
        {
            var first = teams.First();
            string league = TeamComparer.leagues[first.League];

            Console.WriteLine("\n-----------------" + league +  "-----------------\n");

            foreach (Team t in teams)
            {
                Console.WriteLine(t.ToString());
            }

            Console.Write("\n\n");
        }
    }
}
