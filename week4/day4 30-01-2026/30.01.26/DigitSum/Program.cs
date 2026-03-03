namespace DigitSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of element:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the elements:");
            string[] str = new string[n];
            for(int i = 0; i < n; i++)
            {
                str[i]= Console.ReadLine();
            }
            int result = UserProgramCode.sumOfDigits(str);
            Console.WriteLine("Sum of digits = " + result);
        }
    }
}
