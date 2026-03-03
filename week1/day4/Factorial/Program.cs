namespace Factorial
{
    internal class Number
    {
        void factorial(int n)
        {

            int output = 1, output1 = 1;

            if (n < 0)
            {
                output1 = -1;
            }
            else if (n > 7)
            {
                output1 = -2;
            }
            for (int i = 1; i <= n; i++)
            {
                output = output * i;
            }
            Console.WriteLine("Factorial of the number is=" + output);

            Console.WriteLine(output1);
        }

            static void Main(string[] args)
        {
            Number ob=new Number();
            ob.factorial(10);
        }
    }
}
