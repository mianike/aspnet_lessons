using Facade.Interfaces;

namespace Facade
{
    public class SteeringWheel : ISteeringWheel
    {
        public void TurnOnLeft()
        {
            Console.WriteLine("Руль повёрнут влево");
        }

        public void TurnOnRight()
        {
            Console.WriteLine("Руль повёрнут вправо");
        }
    }
}
