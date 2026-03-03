using System;
using System.Collections.Generic;
using System.Text;

namespace Count_Of_Elements
{
     class UserProgramCode
    {
        public static int GetCount(int size, string[] input, char ch)
        {
            int count = 0;
            char Char = char.ToLower(ch);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (!((input[i][j] >= 'A' && input[i][j] <= 'Z') ||
                          (input[i][j] >= 'a' && input[i][j] <= 'z')))
                    {
                        return -2;   
                    }
                }

                if (char.ToLower(input[i][0]) == Char)
                {
                    count++;
                }
            }

            if (count == 0)
                return -1;

            return count;
    
        }
    }
}
