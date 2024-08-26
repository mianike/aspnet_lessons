namespace LiskovSubstitution.WithoutLsp
{
    public class RacingCar : Vehicle
    {
        public override void DriveFast()
        {
            Console.WriteLine("Гоночный автомобиль движется со скоростью 300 км/ч");
        }

        public override void CargoTransportation()
        {
            Console.WriteLine("ОШИБКА! Гоночный автомобиль не может перевезти груз");
        }
    }
}
