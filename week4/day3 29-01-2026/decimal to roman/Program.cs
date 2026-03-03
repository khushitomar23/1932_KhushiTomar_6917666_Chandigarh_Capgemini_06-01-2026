namespace decimal_to_roman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result;
            string input;
            Console.WriteLine("Enter the string");
            input = Console.ReadLine();
            Console.WriteLine("Roman Number to Decimal is= ");
            result = UserProgramCode.convertRomanTodecimal(input);
            Console.WriteLine(result);

        }
    }
}
