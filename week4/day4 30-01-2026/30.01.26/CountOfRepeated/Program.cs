using System.Text.RegularExpressions;

namespace CountOfRepeated
{
    internal class Program
    {
		static void Main()
		{
			Console.WriteLine(CountTripleRepeats("abcdddefggg")); // 2
			Console.WriteLine(CountTripleRepeats("ertyyyrere"));  // 1
		}

		static int CountTripleRepeats(string input1)
		{
			string pattern = @"(.)\1{2}";
			MatchCollection matches = Regex.Matches(input1, pattern);
			return matches.Count;
		}
	}
}
