namespace Comma_Separated
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first list (comma separated):");
            string[] first = Console.ReadLine().Split(',');

            Console.WriteLine("Enter second list (comma separated):");
            string[] second = Console.ReadLine().Split(',');

            for (int i = 0; i < first.Length; i++)
            {
                int n = int.Parse(first[i]);
                int sum = 0;

                for (int j = 0; j < second.Length; j++)
                {
                    if (n == int.Parse(second[j]))
                    {
                        sum += n;
                    }
                }

                Console.WriteLine(n + "-" + sum);
            }
        }
    }
}
