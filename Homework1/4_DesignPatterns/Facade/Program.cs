namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            var turnSignals = new TurnSignals();
            var steeringWheel = new SteeringWheel();
            var engine = new Engine();
            var brakingSystem = new BrakingSystem();
            var car = new CarFacadeDemo(turnSignals, steeringWheel, engine, brakingSystem);
            Console.WriteLine("Для движения нажмите Enter");
            Console.ReadLine();
            car.Movement();
            Console.WriteLine("Для остановки нажмите Enter");
            Console.ReadLine();
            car.Stop();
        }
    }
}
