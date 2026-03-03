namespace Longest_Palindromic_Substring_Length
{
    internal class Program
    {
        static bool IsPalindrome(string s)
        {
            int start = 0, end = s.Length - 1;
            while (start < end)
            {
                if (s[start] != s[end])
                    return false;
                start++;
                end--;
            }
            return true;
        }

        static void Main()
        {
            Console.WriteLine("Enter string:");
            string str = Console.ReadLine();

            int max = 1;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    string sub = str.Substring(i, j - i + 1);
                    if (IsPalindrome(sub) && sub.Length > max)
                        max = sub.Length;
                }
            }

            Console.WriteLine("Result is: " + max);
        }
    }
}
