using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int number = int.Parse(Console.ReadLine());

        int sum = 0;

        while (number > 0)
        {
            int digit = number % 10;
            sum = sum + digit;
            number = number / 10;
        }

        Console.WriteLine("Sum of digits: " + sum);
    }
}
