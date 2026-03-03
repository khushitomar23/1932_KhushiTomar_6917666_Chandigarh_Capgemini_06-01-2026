namespace MahirlandMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int count = 0;

            while (N != 10)
            {
                if (N % 3 == 0 && N / 3 >= 10)
                {
                    N = N / 3;
                }
                else if (N > 10)
                {
                    N = N - 2;
                }
                else
                {
                    N = N + 1;
                }
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
