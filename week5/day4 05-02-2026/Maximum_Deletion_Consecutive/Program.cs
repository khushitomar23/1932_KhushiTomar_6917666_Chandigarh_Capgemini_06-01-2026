namespace Maximum_Deletion_Consecutive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string s = Console.ReadLine();

            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Result is: 0");
                return;
            }

            int deletions = s.Length / 2;

            Console.WriteLine("Result is: " + deletions);
        }
    }
}
