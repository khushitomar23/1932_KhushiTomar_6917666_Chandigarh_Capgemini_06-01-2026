namespace longest_non_repeating_string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string s = Console.ReadLine();

            Dictionary<char, int> dict = new Dictionary<char, int>();
            int maxLen = 0;
            int start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];

                if (dict.ContainsKey(ch) && dict[ch] >= start)
                {
                    start = dict[ch] + 1; 
                }

                dict[ch] = i; 
                maxLen = Math.Max(maxLen, i - start + 1);
            }

            Console.WriteLine(maxLen);
        }

    }
}

