namespace Couple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size (N):");
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter array elements:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if ((arr[i] + arr[i + 1]) % N == 0)
                    count++;
            }

            Console.WriteLine("Result is: " + count);

        }
    }
}
