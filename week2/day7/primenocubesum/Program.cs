namespace primenocubesum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, sum = 0;
            Console.WriteLine("Enter the number");
            n = Convert.ToInt32(Console.ReadLine());

            if (n < 0)
            {
                sum = -1;
            }
            if (n > 32767)
            {
                sum = -2;
            }

            for (int i = 2; i <= n; i++)
            {
                int count = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                        count++;
                }
                if (count == 2)
                {
                    sum += i * i * i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
