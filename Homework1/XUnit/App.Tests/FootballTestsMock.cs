using Football;
using Football.Interfaces;
using Moq;

namespace App.Tests
{
    public class FootballTestsMock
    {
        private ITeam _team;

        private int _score = 10;

        public FootballTestsMock()
        {
            var goalkeeperMock = new Mock<IPlayer>();
            goalkeeperMock.Setup(c => c.Play(ref _score)).Callback(() => throw new NotImplementedException("GoalkeeperReducesScoreNotImplemented"));

            _team = new Team(goalkeeperMock.Object);
        }

        [Fact]
        public void GoalkeeperReducesScoreNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => _team.Play(ref _score));
        }
    }
}