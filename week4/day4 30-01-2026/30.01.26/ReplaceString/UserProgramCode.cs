using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceString
{
    internal class UserProgramCode
    {
        public static string ReplaceString(string input1,int input2,char input3)
        {
            for(int i = 0; i < input1.Length; i++)
            {
                if (!(char.IsLetter(input1[i]) || input1[i]==' ')) return "Invalid String";
            }
            if (input2 < 0) return "Number not positive";
            if (char.IsLetterOrDigit(input3)) return "Character not a special char";
            string[] word = input1.Split(' ');

            word[input2 - 1] = new string(input3, word[input2 - 1].Length);

            return string.Join(' ', word);
        }
    }
}
