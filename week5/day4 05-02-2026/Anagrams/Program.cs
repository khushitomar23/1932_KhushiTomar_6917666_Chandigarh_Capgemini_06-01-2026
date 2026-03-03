namespace Anagrams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter comma separated words:");
            string input = Console.ReadLine();

            string[] words = input.Split(',');

            string first = String.Concat(words[0].OrderBy(c => c));

            bool isAnagram = true;

            for (int i = 1; i < words.Length; i++)
            {
                string sorted = String.Concat(words[i].OrderBy(c => c));

                if (sorted != first)
                {
                    isAnagram = false;
                    break;
                }
            }
        }
    }
}
