namespace LiskovSubstitution.WithLsp
{
    public class LspTruck : LspVehicle
    {
        public override void CargoTransportation()
        {
            Console.WriteLine("Грузовик выполняет грузоперевозку");
        }
    }
}
