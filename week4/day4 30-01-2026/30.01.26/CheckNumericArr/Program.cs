using System.Text.RegularExpressions;

namespace CheckNumericArr
{
    internal class Program
    {
		static void Main()
		{
			string[] arr1 = { "23", "24.5" };
			string[] arr2 = { "23", "one" };

			Console.WriteLine(CheckNumericArray(arr1)); // 1
			Console.WriteLine(CheckNumericArray(arr2)); // -1
		}

		static int CheckNumericArray(string[] input)
		{
			string pattern = @"^-?\d+(\.\d+)?$";

			foreach (string value in input)
			{
				if (!Regex.IsMatch(value, pattern))
					return -1;
			}

			return 1;
		}
	}
}
