namespace ReplaceString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a str:");
            string str = Console.ReadLine();
            Console.WriteLine("Enter a word number:");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter special chr:");
            char ch = (char)Console.Read();

            string result = UserProgramCode.ReplaceString(str, num, ch);
            Console.WriteLine(result);
        }
    }
}
