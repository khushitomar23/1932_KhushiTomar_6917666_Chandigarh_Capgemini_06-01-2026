namespace Insert_Multiple_substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "ABCDEF";

            string result = str.Insert(0, "Hello");
            result = result.Insert(5, "World");
            result = result.Insert(result.Length, "!");

            Console.WriteLine("Result is: " + result);
        }
    }
}
