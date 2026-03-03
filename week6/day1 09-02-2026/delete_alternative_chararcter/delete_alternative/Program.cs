using System;

class Program
{
    static void Main()
    {
        string s = "abcdef";
        string result = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (i % 2 == 0)
            {
                result = result + s[i];
            }
        }

        Console.WriteLine("Output: " + result);
    }
}
