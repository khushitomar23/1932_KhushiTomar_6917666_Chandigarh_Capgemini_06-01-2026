using System;
using System.Collections.Generic;
using System.Text;

namespace FormString
{
    internal class UserPrpgramCode
	{
		public static string formString(string[] input1, int input2)
		{
			string str = "";
			for(int i = 0; i < input1.Length; i++)
			{
				for (int j = 0; j < input1[i].Length; j++)
				{
					if (!(char.IsLetterOrDigit(input1[i][j]))) return "-1";
				}
				if (input1[i].Length < input2)
				{
					str += '$';
				}
				else
				{
					str += input1[i][input2-1];
				}
					
			}
			return str;
		}

	}
}
