using System;

class Program
{
    static void Main()
    {
        string s = "aabbcc";
        int count = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            if (s[i] == s[i + 1])
            {
                count++;
                i++; // skip the next character
            }
        }

        Console.WriteLine("Maximum Deletions: " + count);
    }
}
