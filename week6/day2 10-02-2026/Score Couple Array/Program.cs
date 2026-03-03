namespace Score_Couple_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array elements (space separated):");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int score = 0;

            
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if ((arr[i] + arr[i + 1]) % 2 == 0)
                    score += 5;
            }

            
            for (int i = 0; i < arr.Length - 2; i++)
            {
                int sum = arr[i] + arr[i + 1] + arr[i + 2];
                int product = arr[i] * arr[i + 1] * arr[i + 2];

                if (sum % 2 != 0 && product % 2 == 0)
                    score += 10;
            }

            Console.WriteLine("Final Score is: " + score);
        }
    }
}
