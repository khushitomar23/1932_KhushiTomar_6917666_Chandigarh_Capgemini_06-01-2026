using System.Text.RegularExpressions;

namespace ValidatePass
{
    internal class Program
    {
		static void Main()
		{
			Console.WriteLine(ValidatePassword("ashok_23")); // 1
			Console.WriteLine(ValidatePassword("1991_23"));  // -1
			Console.WriteLine(ValidatePassword("ashok@2"));  // -1 (less than 8)
			Console.WriteLine(ValidatePassword("Ashok#23")); // 1
		}

		static int ValidatePassword(string password)
		{
			string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@#_])[A-Za-z][A-Za-z\d@#_]{6,}[A-Za-z\d]$";

			if (Regex.IsMatch(password, pattern))
				return 1;
			else
				return -1;
		}
	}
}
