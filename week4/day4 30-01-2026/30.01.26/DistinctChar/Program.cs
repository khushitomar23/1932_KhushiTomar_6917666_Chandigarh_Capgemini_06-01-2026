using System.Text.RegularExpressions;

namespace DistinctChar
{
    internal class Program
    {
		static void Main()
		{
			string input = "hi this is my book";
			string result = RemoveDuplicateCharacters(input);
			Console.WriteLine(result);
		}

		static string RemoveDuplicateCharacters(string input)
		{
			string pattern = @"(.)(?=.*\1)";
			return Regex.Replace(input, pattern, "");
		}
	}
}
