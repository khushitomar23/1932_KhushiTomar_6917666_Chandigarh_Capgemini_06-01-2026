using System;

namespace Firstnonrepeating_Character
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string str = Console.ReadLine();

            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char ch in str)
            {
                if (freq.ContainsKey(ch))
                    freq[ch]++;
                else
                    freq[ch] = 1;
            }
            char? result = null;
            foreach (char ch in str)
            {
                if (freq[ch] == 1)
                {
                    result = ch;
                    break;
                }
            }

            if (result != null)
                Console.WriteLine("First non-repeating character: " + result);
            else
                Console.WriteLine("No non-repeating character found.");


        }
    }
}
