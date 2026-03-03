namespace Closest_WholeNumber_Square
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive integer:");
            int num = int.Parse(Console.ReadLine());

            int root = (int)Math.Sqrt(num);

            int lower = root * root;
            int upper = (root + 1) * (root + 1);

            int result;

            if (num - lower <= upper - num)
                result = lower;
            else
                result = upper;

            Console.WriteLine("Result is: " + result);
        }
    }
}
