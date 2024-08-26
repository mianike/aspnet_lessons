namespace LiskovSubstitution.WithLsp
{
    public class LspRacingCar : LspVehicle
    {
        public override void DriveFast()
        {
            Console.WriteLine("Гоночный автомобиль движется со скоростью 300 км/ч");
        }
    }
}
