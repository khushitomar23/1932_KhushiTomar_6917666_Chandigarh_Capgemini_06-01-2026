namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String str, rev = "";

            Console.WriteLine("Enter the string");
            str = Console.ReadLine();
            foreach (char ch in str)
            {
                rev = ch + rev;
            }
            if(rev==str)
            {
                Console.WriteLine("Palindrome string " + str);
            }
            else
            {
                Console.WriteLine("not a palindrome string " + str);
            }
        }
    }
}
