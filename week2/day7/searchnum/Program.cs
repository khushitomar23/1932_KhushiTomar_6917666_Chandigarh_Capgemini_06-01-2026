namespace searchnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int s, i, num, c = 0,output=0;
            Console.WriteLine("Enter the size");
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

            }
            Console.WriteLine("Enter the num to be found");
            num = Convert.ToInt32(Console.ReadLine());
            for (i = 0; i < s; i++)
            {
                if (a[i] < 0)
                {
                    output= -1;
                }
                if (a[i] == num)
                {
                    output=1;
                }
            }
            if (c == 0)
            {
                output = -3;
            }

            Console.WriteLine(output);
        }
    }
}
