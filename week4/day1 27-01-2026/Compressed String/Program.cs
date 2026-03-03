namespace Compressed_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string result = "";

            int count = 1;

            for (int i = 0; i < s.Length; i++)
            {
                
                if (i + 1 < s.Length && s[i] == s[i + 1])
                {
                    count++;
                }
                else
                {
                    
                    result += s[i] + count.ToString();
                    count = 1; 
                }
            }

            Console.WriteLine(result);
        }
    }
}
