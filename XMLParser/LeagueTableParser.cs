using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastManStanding
{
    class LeagueTableParser
    {
        // returns a list of team objects
        public async Task<IEnumerable<Team>> GetLeagueTeamsAsync(Uri url)
        {
            var leagueXml = await GetXmlTableAsync(url);

            var teams =
                from t in leagueXml.Descendants("team")
                select new Team(
                                    (string)t.Element("name"),
                                    1,
                                    (int)t.Element("position"),
                                    (int)t.Element("played"),
                                    (int)t.Element("won"),
                                    (int)t.Element("drawn"),
                                    (int)t.Element("lost"),
                                    (int)t.Element("for"),
                                    (int)t.Element("against"),
                                    (int)t.Element("points")
                                    );
            return teams;
        }

        // returns a league table as an XML object
        private async Task<XDocument> GetXmlTableAsync(Uri url)
        {
            var client = new HttpClient();
            var getStringTask = client.GetStringAsync(url);

            // can add code here to be executed before task is executed

            var urlContents = await getStringTask;
            var XTable = XDocument.Parse(urlContents);

            return XTable;
        }
    }
}
