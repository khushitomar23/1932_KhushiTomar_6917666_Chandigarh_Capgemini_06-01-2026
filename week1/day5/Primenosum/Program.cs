namespace Primenosum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, s, output = 0,j;
            bool primefind = false;
            Console.WriteLine("enter the size");
            s = Convert.ToInt32(Console.ReadLine());
            if (s < 0)
            {
                output = -2;
            }
            int[] arr = new int[s];
            for (i = 0; i < s; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                if(arr[i] < 0)
                {
                    output = -1;
                }
            }
            for (i = 0; i < s; i++)
            {
                int c = 0;
                if (arr[i] <= 1)
                    continue;
                for (j = 1; j <= arr[i]; j++)
                {
                    if (arr[i] % j == 0)
                    {
                        ++c;
                    }
                }
                    if (c == 2)
                    {
                        output = output + arr[i];
                        primefind = true;

                    }  
            }
            if (!primefind)
            {
                output = -3;
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine(output);
            }
        }
    }
}
