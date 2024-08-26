namespace LiskovSubstitution.WithLsp
{
    public abstract class LspVehicle
    {
        public virtual void DriveFast()
        {
            Console.WriteLine("Транспортное средство движется с максимально возможной скоростью");
        }

        public virtual void CargoTransportation()
        {
            Console.WriteLine("Транспортное средство выполняет перевозку максимально вместимого груза");
        }
    }
}
