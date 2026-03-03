using System.Text.RegularExpressions;

namespace Date_Extraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, @"\b\d{2}/\d{2}/\d{4}\b");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
