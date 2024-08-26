using Facade.Interfaces;

namespace Facade
{
    public class Engine : IEngine
    {
        public void IncreaseFuelSupply()
        {
            Console.WriteLine("Увеличение подачи топлива. Движение автомобиля");
        }

        public void EngineIdling()
        {
            Console.WriteLine("Холостой ход двигателя");
        }
    }
}
