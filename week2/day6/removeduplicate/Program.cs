namespace RemoveDuplicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 2, 3, 3 };
            int size = 5, i, j, k = 0;
            int[] output = new int[size];
            
            for (i = 0; i < size; i++)
            {
                if (a[i] < 0)
                {
                    output[0] = -1;
                }
            }
            for (i = 0; i < size; i++)
            {
                bool duplicate = false;
                for (j = 0; j < i; j++)
                {
                    if (a[i] == a[j])
                    {
                        duplicate = true;
                        break;
                    }

                }
                if (!duplicate)
                {
                    output[k] = a[i];
                    k++;
                }
            }
            for (i = 0; i < k; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
