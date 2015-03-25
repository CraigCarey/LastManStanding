using System;
using NUnit.Framework;

namespace LastManStanding
{
    [TestFixture]
    class TeamTester
    {
        [SetUp]
        public void Begin()
        {
            Console.WriteLine("Setup TeamTester");
            testTeam = new Team("Test United");
        }

        [TearDown]
        public void End()
        {
            System.Console.WriteLine("TeamTester TearDown OK");
        }

        [Test]
        public void TestTeamConstructor()
        {
            testTeam = new Team("Test United", 1, 13);
            StringAssert.AreEqualIgnoringCase("Test United", testTeam.Name, "Team constructor failed: name");
            Assert.AreEqual(1, testTeam.League, "Team constructor failed: league");
            Assert.AreEqual(13, testTeam.Points, "Team constructor failed: points");
        }

        [Test]
        public void TestCalcForm()
        {
            testTeam.lastFive = new int[] {3, 1, 3, 0, 1};
            testTeam.CalcForm();
            double formRes = 42.2;

            Assert.AreEqual(formRes, testTeam.Form, 0.05, "Form calc failed");
        }

        Team testTeam;

    }
}
