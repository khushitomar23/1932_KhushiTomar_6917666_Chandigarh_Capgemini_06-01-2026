using System.Text.RegularExpressions;

namespace Strong_Password_Validation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

            if (Regex.IsMatch(password, pattern))
                Console.WriteLine("Strong");
            else
                Console.WriteLine("Weak");
        }
    }
}
