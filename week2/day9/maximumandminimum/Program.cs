namespace maximumandminimum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s, i, min = 0, max = 0,output=0;
            Console.WriteLine("enter the size ");
            s = Convert.ToInt32(Console.ReadLine());
            if (s < 0)
            {
                output = -2;
            }
            int[] a = new int[s];
            Console.WriteLine("Enter the array");
            for (i = 0; i < s; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
                if (a[i] < 0)
                {
                    output = -1;
                }
                if (a[i] > max)
                {
                    max = a[i];
                }

            }
            min = max;
            for (i = 0; i < s; i++)
            {
                if (a[i]<min)
                {
                    min = a[i];
                }
            }
            Console.WriteLine(output);
            Console.WriteLine(min);
            Console.WriteLine(max);
        }
    }
}
