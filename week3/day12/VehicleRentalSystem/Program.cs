namespace VehicleRentalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("KHUSHI");

            Vehicle v1 = new Car("ydcwer78");
            Vehicle v2 = new Bike("6738vdbns");

            RentalTransaction r1 = new RentalTransaction(v1, c1, 3);
            RentalTransaction r2 = new RentalTransaction(v2, c1, 2);

            Console.WriteLine("---- Car Rental ----");
            r1.ShowBill();

            Console.WriteLine("\n---- Bike Rental ----");
            r2.ShowBill();
        }
    }
}
