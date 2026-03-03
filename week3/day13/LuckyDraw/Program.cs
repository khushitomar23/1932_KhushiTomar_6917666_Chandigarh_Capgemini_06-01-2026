
namespace LuckyDraw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m, n;
            int count = 0;

            Console.WriteLine("Enter m:");
            m = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter n:");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = m; i <= n; i++)
            {
                if (i <= 1)
                    continue;

                int divisorCount = 0;

                
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                        divisorCount++;
                }

                if (divisorCount != 2)
                {
                    int sum1 = SumOfDigits(i);
                    int sum2 = SumOfDigits(i * i);

                    if (sum2 == sum1 * sum1)
                        count++;
                }
            }

            Console.WriteLine("Lucky Numbers Count = " + count);
        }

        static int SumOfDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }
    }
}
