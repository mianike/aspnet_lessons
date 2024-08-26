using Facade.Interfaces;

namespace Facade
{
    public class BrakingSystem : IBrakingSystem
    {
        public void Braking()
        {
            Console.WriteLine("Нажата педаль тормоза. Торможение");
        }

        public void ReleaseBrake()
        {
            Console.WriteLine("Педаль тормоза отпущена");
        }
    }
}
