using System.Text.RegularExpressions;

namespace Phone_Number_Extraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, @"\b\d{10}\b");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
