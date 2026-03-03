namespace Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String str,rev=" ";
            
            Console.WriteLine("Enter the string");
            str = Console.ReadLine();
            foreach(char ch in str)
            {
                rev = ch + rev;
            }
            Console.WriteLine("Reversed string is = " + rev);

        }
    }
}
