namespace Positive_integer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive integer:");
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number = number / 10;
            }

            Console.WriteLine("Result is: " + sum);
        }
    }
}
