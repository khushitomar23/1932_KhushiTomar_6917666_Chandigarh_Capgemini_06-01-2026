namespace Count_Triplets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array elements:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine("Enter value of d:");
            int d = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if ((arr[i] + arr[j] + arr[k]) % d == 0)
                            count++;
                    }
                }
            }

            Console.WriteLine("Triplet count is: " + count);
        }
    }
}
