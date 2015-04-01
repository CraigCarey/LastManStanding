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
            testTeam = new Team("Test United", 1);
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
        }

        [Test]
        public void TestCalcForm()
        {
            testTeam.lastFive = new int[] {3, 1, 3, 0, 1};
            testTeam.CalcForm();
            double formRes = 42.2;

            Assert.AreEqual(formRes, testTeam.Form, 0.05, "Form calc failed");
        }

        [Test]
        public void TestCompareTeamsLeagueForm()
        {
            Team compTeam1 = new Team("Stoke City", 1, 10, 30, 12, 6, 12, 34, 37, 42);
            Team compTeam2 = new Team("Southampton", 1, 6, 30, 16, 5, 9, 42, 21, 53);

            TeamComparison tc = new TeamComparison(compTeam1, compTeam2);

            Assert.AreEqual(-4, tc.PositionDiff, "Comparison failed: Position");
            Assert.AreEqual(0, tc.PlayedDiff, "Comparison failed: Played");
            Assert.AreEqual(-4, tc.WonDiff, "Comparison failed: Won");
            Assert.AreEqual(1, tc.DrawnDiff, "Comparison failed: Drawn");
            Assert.AreEqual(3, tc.LostDiff, "Comparison failed: Lost");
            Assert.AreEqual(-8, tc.ForDiff, "Comparison failed: For");
            Assert.AreEqual(16, tc.AgainstDiff, "Comparison failed: Against");
            Assert.AreEqual(-24, tc.GoalDiffDiff, "Comparison failed: GoalDiff");
            Assert.AreEqual(-11, tc.PointsDiff, "Comparison failed: Points");
        }

        Team testTeam;

    }
}
