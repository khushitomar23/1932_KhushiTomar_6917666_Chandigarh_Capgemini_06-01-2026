using System.Text.RegularExpressions;

namespace AddYear
{
    internal class Program
    {
		static void Main()
		{
			Console.WriteLine(AddYearsToDate("2026-01-30", 3));  
			Console.WriteLine(AddYearsToDate("30-01-2026", 3));  
			Console.WriteLine(AddYearsToDate("2026-01-30", -2)); 
		}

		static string AddYearsToDate(string dateStr, int years)
		{
			
			string pattern = @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";

			
			if (!Regex.IsMatch(dateStr, pattern))
				return "-1";

			
			if (years < 0)
				return "-2";

			
			if (DateTime.TryParse(dateStr, out DateTime date))
			{
				DateTime newDate = date.AddYears(years);
				return newDate.ToString("yyyy-MM-dd");
			}
			else
			{
				return "-1"; 
			}
		}
	}
}
