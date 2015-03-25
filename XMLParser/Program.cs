using System;
using System.Collections.Generic;

namespace LastManStanding
{
    class Program
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
            Uri CHUri = new Uri("http://www.footballwebpages.co.uk/league.xml?comp=2");

            IEnumerable<Team> teamsPL = await tp.GetLeagueTeamsAsync(PLUri);

            Console.WriteLine("\n----------------- Premiership -----------------\n");
            
            foreach (Team t in teamsPL)
            {
                Console.WriteLine(t.ToString());
            }

            Console.WriteLine("\n----------------- Championship -----------------\n");

            IEnumerable<Team> teamsCH = await tp.GetLeagueTeamsAsync(CHUri);

            foreach (Team t in teamsCH)
            {
                Console.WriteLine(t.ToString());
            }

        }
    }
}
