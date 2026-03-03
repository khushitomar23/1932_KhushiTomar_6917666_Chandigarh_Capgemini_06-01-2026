namespace avgofmultiple5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, i, avg, sum = 0, c = 0;
            Console.WriteLine("Enter the number");
            num = Convert.ToInt32(Console.ReadLine());
            if (num < 0)
            {
                avg = -1;
            }
            if(num>500)
            {
                avg = -2;
            }
            for (i = 1; i <= num; i++)
            {
                if (i % 5 == 0)
                {
                    sum += i;
                    c++;
                }
            }
            avg = sum / c;
            Console.WriteLine(avg);
        }
    }
}
