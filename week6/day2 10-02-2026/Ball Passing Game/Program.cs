namespace Ball_Passing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of friends:");
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of seconds:");
            int T = int.Parse(Console.ReadLine());

            int from = (T - 1) % N + 1;
            int to = (T % N) + 1;

            Console.WriteLine("In last second, friend " + from + " passed ball to friend " + to);
        }
    }
}
