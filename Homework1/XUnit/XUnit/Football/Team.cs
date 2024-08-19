using Football.Interfaces;

namespace Football
{
    public class Team:ITeam
    {
        public IPlayer Player { get; }

        public Team(IPlayer player)
        {
            Player = player;
        }

        public void Play(ref int relativeScore)
        {
            Player.Play(ref relativeScore);
        }
    }
}
