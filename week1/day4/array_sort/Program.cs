namespace array_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s, i;
            Console.WriteLine("enter the size of array= ");
            s = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[s];
            int[] b = new int[s];
          
            Console.WriteLine("Enter first Array");
            for (i = 0; i < s; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter second array");
            for (i = 0; i < s; i++)
            {
                b[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] output1 = new int[s];
            
            if (s < 0)
            {
                output1[0] = -2;
                
            }
            Array.Sort(a);
            Array.Sort(b);
            Array.Reverse(b);
            for (i = 0; i < s; i++)
            {
                if (a[i] < 0 || b[i] < 0)
                {
                    output1[0] = -1;
                }
                output1[i] = a[i] * b[s - 1 - i];
            }
            
            foreach (int o in output1)
            {
                Console.Write(o + " ");
            }
        }
    }
}
