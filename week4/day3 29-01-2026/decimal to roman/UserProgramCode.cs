using System;
using System.Collections.Generic;
using System.Text;

namespace decimal_to_roman
{
     class UserProgramCode
    {
        public static int convertRomanTodecimal(string input)
        {
            int result = 0,i;
            for(i=0;i<input.Length;i++)
            {
                if(input[i] =='I')
                {
                    result += 1;
                }
                else if(input[i]=='V')
                    {
                    result += 5;
                }
                else if (input[i] == 'X')
                {
                    result += 10;
                }
                else if (input[i] == 'L')
                {
                    result += 50;
                }
                else if (input[i] == 'C')
                {
                    result += 100;
                }
                else if (input[i] == 'D')
                {
                    result += 500;
                }
                else if (input[i] == 'M')
                {
                    result += 1000;
                }
                else
                {
                    return -1;
                }
            }
            return result;
           
        }
    }
}
