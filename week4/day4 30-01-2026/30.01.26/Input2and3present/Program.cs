using System.Text.RegularExpressions;

namespace Input2and3present
{
    internal class Program
    {
        static void Main(string[] args)
        {
			string input1 = "todayisc#exam";
			string input2 = "is";
			string input3 = "exam";

			bool result = CheckOrder(input1, input2, input3);
			Console.WriteLine(result); // True
		}

		static bool CheckOrder(string input1, string input2, string input3)
		{
			// Escape inputs to avoid regex special character issues
			string pattern = Regex.Escape(input2) + ".*" + Regex.Escape(input3);

			return Regex.IsMatch(input1, pattern);
		}
    }
}
