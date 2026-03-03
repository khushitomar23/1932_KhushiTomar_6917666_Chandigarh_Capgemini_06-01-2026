using System.Text.RegularExpressions;

namespace Invoice_Number_Update
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
           
            string invoice = Console.ReadLine();
            Console.WriteLine("Enter the increment");
            int increment = int.Parse(Console.ReadLine());

            Match match = Regex.Match(invoice, @"\d+");

            int number = int.Parse(match.Value);
            int newNumber = number + increment;

        
            string updatedInvoice = Regex.Replace(invoice, @"\d+", newNumber.ToString());

            Console.WriteLine(updatedInvoice);
        }
    }
}
