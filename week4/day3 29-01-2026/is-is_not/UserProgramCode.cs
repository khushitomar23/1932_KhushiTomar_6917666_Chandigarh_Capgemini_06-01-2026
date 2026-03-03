using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace is_is_not
{
     class UserProgramCode
    {
        public static string negativeString(string input)
        {
            int i;
            string[] words = input.Split(' ');
            string result = "";
            for(i=0;i<words.Length;i++)
            {
                if (words[i] == "is")
                {
                    result = result + "is not";
                }
                else
                {
                    result += words[i];
                }
                if (i < words.Length - 1)
                {
                    result = result + " ";
                }
            }

            return result;
        }
       
    }
}
