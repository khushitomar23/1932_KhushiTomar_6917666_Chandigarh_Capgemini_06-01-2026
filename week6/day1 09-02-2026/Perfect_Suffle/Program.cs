namespace Perfect_Suffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string x:");
            string x = Console.ReadLine();

            Console.WriteLine("Enter string y:");
            string y = Console.ReadLine();

            Console.WriteLine("Enter string z:");
            string z = Console.ReadLine();

            if (z.Length != x.Length + y.Length)
            {
                Console.WriteLine("Result is: Not Perfect Shuffle");
                return;
            }

            int i = 0, j = 0;

            foreach (char c in z)
            {
                if (i < x.Length && c == x[i])
                    i++;
                else if (j < y.Length && c == y[j])
                    j++;
                else
                {
                    Console.WriteLine("Result is: Not Perfect Shuffle");
                    return;
                }
            }

            Console.WriteLine("Result is: Perfect Shuffle");
        }
    }
}
