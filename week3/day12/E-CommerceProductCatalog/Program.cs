namespace E_CommerceProductCatalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Electronics(1, "Laptop", 50000, 5);
            Product p2 = new Books(2, "C# Book", 500, 10);

            Customer c1 = new Customer("KHUSHI");

            Cart cart1 = new Cart(p1, 1);
            Cart cart2 = new Cart(p2, 2);

            Order order1 = new Order(c1, cart1);
            Order order2 = new Order(c1, cart2);

            Console.WriteLine("---- Product Details ----");
            p1.Display();
            Console.WriteLine();
            p2.Display();

            Console.WriteLine("\n---- Order Summary ----");
            order1.ShowOrder();
            order2.ShowOrder();
        }
    }
}
