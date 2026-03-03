using System;
using System.Collections.Generic;
using System.Text;

namespace DigitSum
{
    internal class UserProgramCode
    {
        public static int sumOfDigits(string[] input1)
        {
            int sum = 0;
            int n = input1.Length;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < input1[i].Length; j++)
                {
                    if (char.IsDigit(input1[i][j]))
                    {
                        sum += (input1[i][j]-'0');
                    }
                    if (!(char.IsLetterOrDigit(input1[i][j])))
                    {
                        return -1;
                    }
                }
				
            }  
      
            return sum;

        }

	}
}
