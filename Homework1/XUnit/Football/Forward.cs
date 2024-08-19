using Football.Interfaces;

namespace Football
{
    public class Forward : IPlayer
    {
        public Random ScoringRandomizer { get; }
        public int MaxScoringPower { get; }

        public Forward(int maxScoringPower)
        {
            ScoringRandomizer = new Random(); 
            if (maxScoringPower < 0)
            {
                throw new ArgumentException($"Argument {nameof(maxScoringPower)} less than zero");
            }
            MaxScoringPower = maxScoringPower;
        }

        public void Play(ref int relativeScore)
        {
            var scorePower = ScoringRandomizer.Next(MaxScoringPower);
            Console.WriteLine($"Нападающий атакует ворота. Сила удара: {scorePower}");
            relativeScore += scorePower;
        }
    }
}
