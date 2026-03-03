using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter product code: ");
        char product = char.ToUpper(Console.ReadLine()[0]);

        Console.Write("Enter amount: ");
        int amount = int.Parse(Console.ReadLine());

        double vat = 0;

        switch (product)
        {
            case 'M':
                vat = 5;
                break;
            case 'V':
                vat = 12;
                break;
            case 'C':
                vat = 6.25;
                break;
            case 'D':
                vat = 6;
                break;
            default:
                Console.WriteLine("Invalid product code");
                return;
        }

        double vatAmount = amount * vat / 100;
        Console.WriteLine("VAT Amount = " + vatAmount);
    }
}

