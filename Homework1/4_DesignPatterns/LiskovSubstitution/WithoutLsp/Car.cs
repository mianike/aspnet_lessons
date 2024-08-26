namespace LiskovSubstitution.WithoutLsp
{
    public class Car : Vehicle
    {
        public override void DriveFast()
        {
            Console.WriteLine("Автомобиль движется со скоростью 200 км/ч");
        }

        public override void CargoTransportation()
        {
            Console.WriteLine("Автомобиль выполняет перевозку небольшого груза");
        }
    }
}
