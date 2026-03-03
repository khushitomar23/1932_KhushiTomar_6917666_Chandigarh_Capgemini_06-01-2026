using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDesignation
{
    internal class UserProgramCode
    {
		public static string[] getEmployee(string[] input1, string input2)
		{
			for(int a = 0; a < input1.Length; a++)
			{
				for(int b = 0; b < input1[a].Length; b++)
				{
					if (!char.IsLetterOrDigit(input1[a][b])) return ["invalid input"];
				}
			}
			int count = 0;
			int i = 1;
			while (i < input1.Length)
			{
				if (input1[i] == input2)
				{
					count++;
				}
				i += 2;
			}
			if (count == 0) return ["No employee for " + input2 + " designation"];
			if (count == input1.Length / 2) return ["All employees belong to same "+input2+" designation"];
			int idx = 0;
			string[] ans = new string[count];
			for( i = 1; i < input1.Length; i += 2)
			{
				if (input1[i] == input2)
				{
					ans[idx] = input1[i - 1];
					idx++;
				}
			}
			return ans;
		}

	}
}
