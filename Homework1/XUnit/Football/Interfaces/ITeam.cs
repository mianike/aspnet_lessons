namespace Football.Interfaces
{
    public interface ITeam
    {
        IPlayer Player { get; }
        void Play(ref int score);
    }
}
