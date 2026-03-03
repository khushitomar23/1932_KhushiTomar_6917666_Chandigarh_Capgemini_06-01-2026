using System.Text.RegularExpressions;

namespace dayOfdate
{
    internal class Program
    {
		static void Main()
		{
			Console.WriteLine(AddOneYearAndFindDay("30/01/2025")); // Friday
			Console.WriteLine(AddOneYearAndFindDay("31/13/2025")); // -1 (invalid)
		}

		static string AddOneYearAndFindDay(string dateStr)
		{
			// Regex for dd/MM/yyyy
			string pattern = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";

			// Step 1: Validate format
			if (!Regex.IsMatch(dateStr, pattern))
				return "-1";

			// Step 2: Parse date
			if (!DateTime.TryParseExact(
					dateStr,
					"dd/MM/yyyy",
					null,
					System.Globalization.DateTimeStyles.None,
					out DateTime date))
			{
				return "-1"; // Invalid date like 31/02/2025
			}

			// Step 3: Add 1 year
			DateTime newDate = date.AddYears(1);

			// Step 4: Return day name
			return newDate.DayOfWeek.ToString();
		}
	}
}
