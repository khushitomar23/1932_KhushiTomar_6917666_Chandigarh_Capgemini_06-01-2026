using System.Text.RegularExpressions;

namespace Electricity_Bill_Generation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the readings");
            string input1 = Console.ReadLine();   
            string input2 = Console.ReadLine();
            Console.WriteLine("Enter the rate per unit");
            int rate = int.Parse(Console.ReadLine()); 

         
            string num1 = Regex.Match(input1, @"\d+").Value;
            string num2 = Regex.Match(input2, @"\d+").Value;

            int reading1 = int.Parse(num1);
            int reading2 = int.Parse(num2);

            int units = Math.Abs(reading2 - reading1);
            int bill = units * rate;

            Console.WriteLine(bill);
        }
    }
}
