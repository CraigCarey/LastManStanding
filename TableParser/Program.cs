using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastManStanding
{
    class Program
    {
        static void Main(string[] args)
        {
            TableParser tp = new TableParser();

            while (true)
            {
                tp.FetchAndPrintPLTable();
                //tp.ParsePOXml();
                //tp.FetchAndPrintStoryTitles();
                
                System.Threading.Thread.Sleep(60000);
            }                
        }
    }


    class TableParser
    {
        public async void FetchAndPrintPLTable()
        {
            var plData = await GetAndParseXmlPLTable();

            foreach (var team in plData)
            {
                Console.WriteLine(team);
            }

            PrintTime("Teams added");
        }


        private async Task<IEnumerable<XText>> GetAndParseXmlPLTable()
        {
            var client = new HttpClient();

            try
            {
                var response = await client.GetAsync("http://www.footballwebpages.co.uk/league.xml?comp=1");
                //var response = await client.GetAsync("https://dl.dropboxusercontent.com/u/43390413/league.xml");

                PrintTime("Received PL Response");
                var responseBody = await response.Content.ReadAsStringAsync();

                //Console.WriteLine(responseBody);

                PrintTime("Read PL Response Body");
                //var league = XDocument.Parse(responseBody);
                var league = XDocument.Load(response);

                IEnumerable<XElement> teams =
                    from el in league.Elements("team")
                    //where (string)el.Attribute("name") == "Chelsea"
                    select el;

                foreach (XElement el in teams)
                    Console.WriteLine(el);


                return league.Root.Elements("leagueTable").Elements("team").Elements("name").DescendantNodes().OfType<XText>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed, yo: {0}", e);
                return null;
            }
        }

        public void PrintTime(string msg)
        {
            string time = DateTime.Now.ToLongTimeString();
            var fullMsg = string.Format("{0} at {1}", msg, time);
            Console.WriteLine(fullMsg);
        }


        public async void FetchAndPrintStoryTitles()
        {
            var storyTitles = await GetAndParseRssFromBBC();

            foreach (var title in storyTitles)
            {
                Console.WriteLine(title);
            }

            PrintTime("Story titles added");
        }

        private async Task<IEnumerable<XText>> GetAndParseRssFromBBC()
        {
            var client = new HttpClient();

            try
            {
                var response = await client.GetAsync("http://feeds.bbci.co.uk/news/rss.xml");
                //var response = await client.GetAsync("https://dl.dropboxusercontent.com/u/43390413/bbc.xml");

                PrintTime("Received BBC Response");
                var responseBody = await response.Content.ReadAsStringAsync();
                PrintTime("Read BBC Response Body");
                var xml = XDocument.Parse(responseBody);
                return xml.Root.Elements("channel").Elements("item").Elements("title").DescendantNodes().OfType<XText>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed, yo: {0}", e);
                return null;
            }

        }

    }
}
