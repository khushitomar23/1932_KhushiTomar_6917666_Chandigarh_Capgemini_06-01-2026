using System;

class Program
{
    static void Main()
    {
        string input = "Hello World";
        char ch = 'A';
        int position = 3;

        string result = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (i == position)
            {
                result = result + ch;
            }
            result = result + input[i];
        }

        Console.WriteLine("Result: " + result);
    }
}
