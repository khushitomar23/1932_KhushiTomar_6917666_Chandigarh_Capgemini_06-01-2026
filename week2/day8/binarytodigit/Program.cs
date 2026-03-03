using System;

namespace binarytodigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string binary;
            int decimalvalue = 0;

            Console.WriteLine("Enter binary number");
            binary = Console.ReadLine();

            // BR 2
            if (binary.Length > 5)
            {
                Console.WriteLine(-2);
                return;
            }

            int power = binary.Length - 1;

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] != '0' && binary[i] != '1')
                {
                    Console.WriteLine(-1);
                    return;
                }

                decimalvalue += (binary[i] - '0') * (int)Math.Pow(2, power);
                power--;
            }

            Console.WriteLine(decimalvalue);
        }
    }
}