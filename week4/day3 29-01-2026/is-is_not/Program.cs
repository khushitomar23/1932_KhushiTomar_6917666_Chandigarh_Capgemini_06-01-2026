namespace is_is_not
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Enter the String");
            input= Console.ReadLine();
            string result = UserProgramCode.negativeString(input);
            Console.WriteLine(result);
        }
    }
}
