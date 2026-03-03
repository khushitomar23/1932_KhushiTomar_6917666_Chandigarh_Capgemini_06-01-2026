using System;

class Program
{
    static void Main()
    {
        string str = "I am a programmer. I learn at Codeforwin.";
        string word = "I";

        int index = str.LastIndexOf(word);

        if (index != -1)
        {
            str = str.Remove(index, word.Length);
        }

        Console.WriteLine(str);
    }
}
