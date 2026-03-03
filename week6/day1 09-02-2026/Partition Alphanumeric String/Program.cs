namespace Partition_Alphanumeric_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter alphanumeric string:");
            string str = Console.ReadLine();

            string left = "";
            string right = "";

            foreach (char c in str)
            {
                if (char.IsDigit(c))
                    left += c;     
                else
                    right += c;    
            }

            Console.WriteLine("Left part: " + left);
            Console.WriteLine("Right part: " + right);
        }
    }
}
