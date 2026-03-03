namespace Totalmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int X = Convert.ToInt32(Console.ReadLine());
            int Y = Convert.ToInt32(Console.ReadLine());
            int N1 = Convert.ToInt32(Console.ReadLine());
            int N2 = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());

            bool found = false;
            int type1 = 0, type2 = 0;

            for (int i = N1; i >= 0; i--)
            {
                for (int j = 0; j <= N2; j++)
                {
                    if (i * X + j * Y == M)
                    {
                        type1 = i;
                        type2 = j;
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }

            if (found)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(type1);
                Console.WriteLine(type2);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
