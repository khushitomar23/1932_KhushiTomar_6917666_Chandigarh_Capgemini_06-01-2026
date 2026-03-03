namespace inserttheelement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            int[] a = { 10, 30, 20, 40 };
            int size = a.Length;
            int insert = 25;
            if (size < 0)
            {
                Console.WriteLine(-2);
                return;
            }
            for (i = 0; i < size; i++)
            {
                if (a[i] < 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            Array.Sort(a);

            int[] output = new int[size + 1];
            int k = 0;

            for (i = 0; i < size; i++)
            {
                if (insert < a[i] && k == i)
                {
                    output[k] = insert;
                    k++;
                }
                output[k] = a[i];
                k++;
            }
            if (k == size)
            {
                output[k] = insert;
            }

            foreach (int x in output)
            {
                Console.Write(x + " ");
            }
        }
    }
}
