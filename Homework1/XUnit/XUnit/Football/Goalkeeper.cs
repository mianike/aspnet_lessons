using Football.Interfaces;

namespace Football
{
    public class Goalkeeper : IPlayer
    {
        public Random ScoringRandomizer { get; }
        public int MaxScoringPower { get; }

        public Goalkeeper(int maxScoringPower)
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
            Console.WriteLine($"Вратарь защищает ворота. Сила защиты: {scorePower}");
            relativeScore = Math.Max(0, relativeScore - scorePower);
        }
    }
}
