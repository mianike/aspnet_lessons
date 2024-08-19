namespace Football.Interfaces
{
    public interface IPlayer
    {
        Random ScoringRandomizer { get; }
        int MaxScoringPower { get; }
        void Play(ref int relativeScore);
    }
}
