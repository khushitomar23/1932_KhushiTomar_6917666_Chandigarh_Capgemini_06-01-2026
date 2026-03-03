namespace sumofmultipleof5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size,i,avg;
            Console.WriteLine("Enter the size");
            size = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[size];
            Console.WriteLine("Enter the array");
            for(i=0;i<size;i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0, count = 0;

            if (size < 0)
            {
                Console.WriteLine(-2);
                
            }

            for (i = 0; i < size; i++)
            {
                if (a[i] < 0)
                {
                    Console.WriteLine(-1);
                  
                }
                if (a[i] % 5 == 0)
                {
                    sum += a[i];
                    count++;
                }
            }

             avg = sum / count;
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Avg = " + avg);
        }
    }
}
