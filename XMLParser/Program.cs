using System;
using System.Linq;
using System.Collections.Generic;

namespace LastManStanding
{
    class Program   /* XMLParser */
    {
        static void Main(string[] args)
        {
            GetDataAsync();

            // stops program from ending before async methods have finished
            System.Threading.Thread.Sleep(5000);
        }

        // async, because uses 'await'
        async static void GetDataAsync()
        {
            LeagueTableParser tp = new LeagueTableParser();

            Uri PLUri = new Uri("http://www.footballwebpages.co.uk/league.xml?comp=1");

            IEnumerable<Team> teamsPL = await tp.GetLeagueTeamsAsync(PLUri, 1);

            Console.WriteLine("\n----------------- Premiership -----------------\n");

            Team chelsea = LeagueTableParser.SelectTeam(teamsPL, "Chelsea");
            Team liverpool = LeagueTableParser.SelectTeam(teamsPL, "Liverpool");

        }
        
    }
}
