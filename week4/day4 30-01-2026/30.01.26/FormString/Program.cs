namespace FormString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length:");
            int k = int.Parse(Console.ReadLine());
            string[] str = new string[k];
            for(int i = 0; i < k; i++)
            {
                str[i] = Console.ReadLine();
            }
            Console.WriteLine("Enter n:");
            int n = int.Parse(Console.ReadLine());
            string result = UserPrpgramCode.formString(str, n);
            Console.WriteLine(result);
        }
    }
}
