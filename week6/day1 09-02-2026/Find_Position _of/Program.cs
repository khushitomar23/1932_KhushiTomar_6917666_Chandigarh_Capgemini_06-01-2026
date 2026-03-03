namespace Find_Position__of
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of lines:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                int pos1 = line.IndexOf("the");
                int pos2 = line.IndexOf("of");

                Console.WriteLine("the: " + (pos1 == -1 ? -1 : pos1));
                Console.WriteLine("of: " + (pos2 == -1 ? -1 : pos2));
            }
        }
    }
}
