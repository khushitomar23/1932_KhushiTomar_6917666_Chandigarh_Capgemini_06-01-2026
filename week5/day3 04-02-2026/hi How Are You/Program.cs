using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input1 = "Hi how are you Dear";
        string input2 = "KhushiTomarChoudhary"; 

        string finalInput = input1 + " " + input2;

        string pattern = @"^Hi how are you Dear\s[A-Za-z]{16,}$";

        if (Regex.IsMatch(finalInput, pattern))
        {
            Console.WriteLine(finalInput);
        }
        else
        {
            Console.WriteLine("Invalid input (Name must be more than 15 characters)");
        }
    }
}
