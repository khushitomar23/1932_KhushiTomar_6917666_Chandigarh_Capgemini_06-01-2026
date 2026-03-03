using System.Diagnostics.CodeAnalysis;

namespace evendigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num,output=0,digit;

            Console.WriteLine("Enter the number");
            num=Convert.ToInt32(Console.ReadLine());
            if(num<0)
            {
                output = -1;
            }
            else if(num>32767)
            {
                output = -2;
            }
            while(num>0)
            {
                digit = num % 10;
                if (digit % 2 == 0)
                {
                    output = output + digit;
                }
                num = num / 10;

            }
            Console.WriteLine(output);
        }
    }
}
