namespace Sort_Pipe_Separated_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter pipe separated words:");
            string input = Console.ReadLine();

            string[] words = input.Split('|');
            Array.Sort(words);

            Console.WriteLine("Result is: " + string.Join("|", words));
        }
    }
}
