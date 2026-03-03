namespace Insert_a_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter main string:");
            string str = Console.ReadLine();

            Console.WriteLine("Enter substring:");
            string sub = Console.ReadLine();

            Console.WriteLine("Enter position:");
            int pos = int.Parse(Console.ReadLine());

            string result = str.Insert(pos, sub);

            Console.WriteLine("Result is: " + result);
        }
    }
}
