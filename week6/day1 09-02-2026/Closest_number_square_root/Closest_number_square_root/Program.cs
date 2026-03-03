using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int n = int.Parse(Console.ReadLine());

        int i = 0;

        while (i * i <= n)
        {
            i++;
        }

        int lowerSquare = (i - 1) * (i - 1);
        int higherSquare = i * i;

        if (n - lowerSquare <= higherSquare - n)
        {
            Console.WriteLine("Closest perfect square: " + lowerSquare);
        }
        else
        {
            Console.WriteLine("Closest perfect square: " + higherSquare);
        }
    }
}
