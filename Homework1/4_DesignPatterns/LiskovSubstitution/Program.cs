using LiskovSubstitution.WithLsp;
using LiskovSubstitution.WithoutLsp;

namespace LiskovSubstitution
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region WithoutLsp
            Console.WriteLine("Реализация нарушения принципа подстановки Барбары Лисков");
            Console.WriteLine();

            Vehicle car = new Car();
            Vehicle truck = new Truck();
            Vehicle racingCar = new RacingCar();

            car.DriveFast();
            car.CargoTransportation();

            truck.DriveFast();
            truck.CargoTransportation();

            racingCar.DriveFast();
            racingCar.CargoTransportation();
            #endregion

            #region WithLsp
            Console.WriteLine();
            Console.WriteLine("Реализация принципа подстановки Барбары Лисков");
            Console.WriteLine();

            LspVehicle lspCar = new LspCar();
            LspVehicle lspTruck = new LspTruck();
            LspVehicle lspRacingCar = new LspRacingCar();

            lspCar.DriveFast();
            lspCar.CargoTransportation();

            lspTruck.DriveFast();
            lspTruck.CargoTransportation();

            lspRacingCar.DriveFast();
            lspRacingCar.CargoTransportation();

            Console.ReadKey();
            #endregion
        }
    }







}
