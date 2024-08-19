using Football;
using Football.Interfaces;

namespace App.Tests
{
    public class FootballTests
    {
        //PositiveTests
        [Fact]
        public void TeamPlayerNotNull()
        {
            IPlayer player = new Goalkeeper(0);
            ITeam team = new Team(player);

            Assert.NotNull(team.Player);
        }

        [Fact]
        public void ForwardIncreasedScore()
        {
            int score = 0;
            int forwardMaxScoringPower = 10;
            IPlayer player = new Forward(forwardMaxScoringPower);
            ITeam team = new Team(player);

            team.Play(ref score);

            Assert.InRange(score, 0, forwardMaxScoringPower);
        }
        
        //NegativeTests
        [Fact]
        public void GoalkeeperDoesNotReduceScoreBelowZero()
        {
            int score = 0;
            IPlayer goalkeeper = new Goalkeeper(1);
            ITeam team = new Team(goalkeeper);

            team.Play(ref score);

            Assert.Equal(0, score);
        }

        [Fact]
        public void ThrowExcepteionWhenScoringPowerBelowZero()
        {
            Assert.Throws<ArgumentException>((() =>
            {
                var forward = new Forward(-1);
            }));
        }
    }
}