namespace Count_Of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size,i;
            Console.WriteLine("Enter the size of the String array");
            size=int.Parse(Console.ReadLine());
            string[] input=new string[size];
            Console.WriteLine("Enter the string array");
            for(i=0;i<input.Length;i++)
            {
                input[i] = Console.ReadLine();
            }
            Console.WriteLine("Enter the character");
            char ch=Convert.ToChar(Console.ReadLine());

            int result = UserProgramCode.GetCount(size, input,ch);
            Console.WriteLine("Count of the string= ");
            Console.WriteLine(result);
        }
    }
}
