namespace Missing_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers from 1 to N with one missing:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int n = arr.Length + 1;
            int total = n * (n + 1) / 2;

            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            Console.WriteLine("Missing number is: " + (total - sum));
        }
    }
}
