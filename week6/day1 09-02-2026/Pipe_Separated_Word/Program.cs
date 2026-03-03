namespace Pipe_Separated_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter pipe separated words:");
            string input = Console.ReadLine();

            string[] words = input.Split('|');
            Array.Reverse(words);

            Console.WriteLine("Result is: " + string.Join("|", words));
        }
    }
}
