namespace Longest_Non_Decreasing_Binary_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter binary string:");
            string s = Console.ReadLine();

            int zero = 0, one = 0;

            foreach (char c in s)
            {
                if (c == '0') zero++;
                else one++;
            }

            Console.WriteLine("Longest possible length is: " + (zero + one));
        }
    }
}
