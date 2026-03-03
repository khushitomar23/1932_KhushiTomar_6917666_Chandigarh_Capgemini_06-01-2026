using System.Text.RegularExpressions;

namespace Email_Validation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(email, pattern))
            {
                Console.WriteLine("Valid");
            }
            else
                Console.WriteLine("Invalid");
        }
    }
}
