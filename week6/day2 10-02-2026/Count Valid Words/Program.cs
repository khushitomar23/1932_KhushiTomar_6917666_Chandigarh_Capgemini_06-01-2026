using System;

class Program
{
    static bool IsValid(string word)
    {
        if (word.Length <= 2)
            return false;

        bool hasVowel = false;
        bool hasConsonant = false;

        foreach (char c in word)
        {
            if (!char.IsLetterOrDigit(c))
                return false;

            if ("aeiouAEIOU".Contains(c))
                hasVowel = true;
            else if (char.IsLetter(c))
                hasConsonant = true;
        }

        return hasVowel && hasConsonant;
    }

    static void Main()
    {
        Console.WriteLine("Enter string of words:");
        string input = Console.ReadLine();

        string[] words = input.Split(' ');
        int count = 0;

        foreach (string word in words)
        {
            if (IsValid(word))
                count++;
        }

        Console.WriteLine("Valid words count is: " + count);
    }
}
