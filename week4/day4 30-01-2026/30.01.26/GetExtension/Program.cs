using System.Text.RegularExpressions;

namespace GetExtension
{
    internal class Program
    {

		static void Main()
		{
			Console.WriteLine(GetExtension("File.dat"));        // dat
			Console.WriteLine(GetExtension("report.pdf"));      // pdf
			Console.WriteLine(GetExtension("archive.tar.gz"));  // gz
			Console.WriteLine(GetExtension("file"));            // -1
		}

		static string GetExtension(string fileName)
		{
			string pattern = @"\.([^.]+)$";

			Match match = Regex.Match(fileName, pattern);

			if (match.Success)
				return match.Groups[1].Value;
			else
				return "-1";
		}
	}
}
