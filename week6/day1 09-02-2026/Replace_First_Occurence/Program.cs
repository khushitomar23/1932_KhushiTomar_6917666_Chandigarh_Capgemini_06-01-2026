namespace Replace_First_Occurence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string:");
            string str = Console.ReadLine();

            Console.WriteLine("Enter character to replace:");
            char oldChar = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Enter character to replace with:");
            char newChar = Convert.ToChar(Console.ReadLine());

            int index = str.IndexOf(oldChar);

            if (index != -1)
            {
                str = str.Remove(index, 1).Insert(index, newChar.ToString());
            }

            Console.WriteLine("Result is: " + str);
        }
    }
}
