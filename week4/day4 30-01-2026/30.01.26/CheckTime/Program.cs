using System.Text.RegularExpressions;

namespace CheckTime
{
    internal class Program
    {
		static void Main()
		{
			Console.WriteLine(CheckTime("09:30 am")); // Valid
			Console.WriteLine(CheckTime("12:59 PM")); // Valid
			Console.WriteLine(CheckTime("13:00 pm")); // Invalid
			Console.WriteLine(CheckTime("10:75 am")); // Invalid
		}

		static string CheckTime(string input)
		{
			string pattern = @"^(0[1-9]|1[0-2]):([0-5][0-9])\s(am|pm|AM|PM)$";

			if (Regex.IsMatch(input, pattern))
				return "Valid";
			else
				return "Invalid";
		}
	}
}
