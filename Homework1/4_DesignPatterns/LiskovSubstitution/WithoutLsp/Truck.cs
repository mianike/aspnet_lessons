namespace LiskovSubstitution.WithoutLsp
{
    public class Truck : Vehicle
    {
        public override void DriveFast()
        {
            Console.WriteLine("ОШИБКА! Грузовик не может двигаться быстро");
        }

        public override void CargoTransportation()
        {
            Console.WriteLine("Грузовик выполняет грузоперевозку");
        }
    }
}
