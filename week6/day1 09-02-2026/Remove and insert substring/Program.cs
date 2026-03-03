namespace Remove_and_insert_substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "HelloWorld";

            Console.WriteLine("Original String: " + str);

            string result = str.Replace("World", "Universe");

            Console.WriteLine("Result is: " + result);
        }
    }
}
