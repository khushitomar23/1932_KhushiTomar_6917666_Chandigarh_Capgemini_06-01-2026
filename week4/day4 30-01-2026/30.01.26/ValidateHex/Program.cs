using System.Text.RegularExpressions;

namespace ValidateHex
{
    internal class Program
    {
		static void Main()
		{
			Console.WriteLine(ValidateHex("#FF5733"));  // 1
			Console.WriteLine(ValidateHex("#ff5733"));  // 1
			Console.WriteLine(ValidateHex("#FF85HH"));  // -1
			Console.WriteLine(ValidateHex("123456"));   // -1
			Console.WriteLine(ValidateHex("#12345"));   // -1
		}

		static int ValidateHex(string input)
		{
			string pattern = @"^#[0-9A-Fa-f]{6}$";

			if (Regex.IsMatch(input, pattern))
				return 1;
			else
				return -1;
		}
	}
}
