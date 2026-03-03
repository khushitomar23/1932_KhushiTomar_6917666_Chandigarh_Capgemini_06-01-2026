namespace no_digit
{
    internal class Program
    {
        void TotalDigit(int n)
        {
            int output1 = 1, digit = 0;
            if (n < 0)
            {
                output1 = -1;
            }
            while (n > 0)
            {
                digit++;
                n = n / 10;
            }
            Console.WriteLine("Total digits are=" + digit);
            Console.WriteLine(output1);
        }
        static void Main(string[] args)
        {
            Program ob=new Program();
            ob.TotalDigit(456);
        }
    }
}
