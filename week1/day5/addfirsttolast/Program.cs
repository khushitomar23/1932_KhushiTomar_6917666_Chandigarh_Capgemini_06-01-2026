namespace addfirsttolast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 21, 23, 41, 4 };
            int[] b = { 3, 4, 1, 5 };
            int size = 4;
            int[] output = new int[size];

            if (size < 0)
            {
                output[0] = -2;
                
            }

            for (int i = 0; i < size; i++)
            {
                if (a[i] < 0 || b[i] < 0)
                {
                    output[0] = -1;
                    
                }
                output[i] = a[i] + b[size - 1 - i];
            }

            foreach (int x in output)
                Console.Write(x + " ");
        }
    }

}
    
