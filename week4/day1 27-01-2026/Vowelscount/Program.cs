namespace Vowelscount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String str;
            int i,c=0;
            Console.WriteLine("Enter the string");
            str = Console.ReadLine();
            for(i=0; i <str.Length;i++)
            {
                if (str[i] == 'A' || str[i] == 'E' || str[i] == 'O' || str[i] == 'I' || str[i] =='U'|| str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
                {
                    c++;
                }
            }
            Console.WriteLine("Count of the vowels is= " + c);
        }
    }
}
