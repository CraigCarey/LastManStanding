using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastManStanding
{
    class Program
    {
        static void Main(string[] args)
        {
            Team testTeam = new Team("Test United", 1, 13);            

            testTeam.lastFive = new int[] { 3, 1, 3, 0, 1 };
            testTeam.CalcForm();

            Console.WriteLine("{0} {1} {2} {3}%", testTeam.Name, testTeam.League, testTeam.Points, testTeam.Form);
        }
    }
}
