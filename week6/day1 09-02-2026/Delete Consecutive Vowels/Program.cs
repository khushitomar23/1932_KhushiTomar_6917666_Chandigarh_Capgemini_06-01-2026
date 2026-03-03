namespace Delete_Consecutive_Vowels
{
    internal class Program
    {
        class Pro
        {
            static bool IsVowel(char c)
            {
                return "aeiouAEIOU".IndexOf(c) != -1;
            }

            static void Main()
            {
                Console.WriteLine("Enter string:");
                string str = Console.ReadLine();

                int count = 0;

                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (IsVowel(str[i]) && IsVowel(str[i + 1]))
                    {
                        count++;
                        i++;
                    }
                }

                Console.WriteLine("Result is: " + count);
            }
        }
    }
}
