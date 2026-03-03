namespace evenandodd
{
    internal class Program
    {
        void EvenandOdd(int[] arr, int size)
        {
            int output1 = 1, i, oddsum = 0, evensum = 0, avg;

            if (size < 0)
            {
                output1 = -2;
            }
            for (i = 0; i < size; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evensum = evensum + arr[i];
                }
                else
                {
                    oddsum = oddsum + arr[i];
                }
                if (arr[i] < 0)
                {
                    output1 = -1;
                }
            }
            avg = (evensum + oddsum) / 2;
            Console.WriteLine("Average is=" + avg);
            Console.WriteLine(output1);

        }
        static void Main(string[] args)
        {
            Program ob= new Program();
            int s, i;
            int[] a = new int[50];
            Console.WriteLine("enter the size of array= ");
            s = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter first Array");
            for (i = 0; i < s; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            ob.EvenandOdd(a, s);

        }
    }
}
