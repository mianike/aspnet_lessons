using Facade.Interfaces;

namespace Facade
{
    public class TurnSignals : ITurnSignals
    {
        public void TurnOnLeft()
        {
            Console.WriteLine("Включён левый поворотник");
        }

        public void TurnOffLeft()
        {
            Console.WriteLine("Выключен левый поворотник");
        }

        public void TurnOnRight()
        {
            Console.WriteLine("Включён правый поворотник");
        }

        public void TurnOffRight()
        {
            Console.WriteLine("Выключен правый поворотник");
        }
    }
}
