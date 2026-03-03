using System.Text.RegularExpressions;

namespace Location_Code_Update
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the string");

            string invoice = Console.ReadLine();
            // CAP-HYD-123
            Console.WriteLine("Enter the location string code");
            string newLocation = Console.ReadLine(); // BAN

            string pattern = @"(?<=CAP-)[A-Z]+(?=-)";

            string updatedInvoice = Regex.Replace(invoice, pattern, newLocation);

            Console.WriteLine(updatedInvoice);
        }
    }
}
