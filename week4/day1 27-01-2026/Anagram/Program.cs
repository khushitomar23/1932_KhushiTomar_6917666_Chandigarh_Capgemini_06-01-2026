namespace Anagram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1, str2;
            Console.WriteLine("Enter first string");
            str1=Console.ReadLine().ToLower();
            Console.WriteLine("Enter second string");
            str2=Console.ReadLine().ToLower();
            char[] arr1 = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);
            string sorted1 = new string(arr1);
            string sorted2 = new string(arr2);

            if (sorted1==sorted2)
            {
                Console.WriteLine("Anagram Numbers " );
            }
            else
            {
                Console.WriteLine("Not Anagram NUmbers");
            }
            
        }
    }
}
