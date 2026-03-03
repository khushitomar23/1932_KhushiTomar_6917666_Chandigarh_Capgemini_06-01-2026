using System.Text.RegularExpressions;

namespace CheckEligible
{
    internal class Program
    {
		static void Main()
		{
			Console.WriteLine(CheckEligibility("18"));  // Eligible
			Console.WriteLine(CheckEligibility("25"));  // Eligible
			Console.WriteLine(CheckEligibility("17"));  // Not Eligible
			Console.WriteLine(CheckEligibility("abc")); // Not Eligible
		}

		static string CheckEligibility(string age)
		{
			string pattern = @"^(1[89]|[2-9]\d|\d{3,})$";

			if (Regex.IsMatch(age, pattern))
				return "Eligible";
			else
				return "Not Eligible";
		}
	}
}
